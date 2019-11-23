using System;
using System.Threading.Tasks;
using AddressBook.Api.Models.Contact;
using AddressBook.Domain.Dtos.Contacts;
using AddressBook.Domain.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AddressBook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;
        private readonly ILogger<ContactsController> _logger;

        public ContactsController(IContactService contactService,
            IMapper mapper,
            ILogger<ContactsController> logger)
        {
            _contactService = contactService ?? throw new ArgumentNullException(nameof(contactService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // GET api/contacts
        [HttpGet]
        public async Task<ActionResult> Get([FromQuery] GetContactsQueryModel queryModel)
        {
            return Ok(await _contactService.GetPaginatedAsync(_mapper.Map<ContactsQueryDto>(queryModel)));
        }

        // GET api/contacts/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Contact id is required.");
            }

            var contact = await _contactService.GetByIdAsync(id);

            if (contact == null)
            {
                return NotFound($"No contact id {id} found.");
            }

            return Ok(_mapper.Map<ContactDetailsModel>(contact));
        }

        // POST api/contacts
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ContactCreateModel model)
        {
            var contactDto = _mapper.Map<ContactCreateDto>(model);

            var contact = await _contactService.AddAsync(contactDto);

            return CreatedAtRoute("Get", new { id = contact.Id }, contact);
        }

        // PUT api/contacts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody]ContactUpdateModel model)
        {
            if (!await _contactService.ContactExists(id))
            {
                return NotFound();
            }

            var contactDto = _mapper.Map<ContactUpdateDto>(model);
            contactDto.Id = id;

            await _contactService.UpdateContactAsync(contactDto);

            // TODO: check what to return
            return NoContent();
        }

        // DELETE api/contacts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (!await _contactService.ContactExists(id))
            {
                return NotFound();
            }

            await _contactService.DeleteContactAsync(id);

            return NoContent();
        }
    }
}
