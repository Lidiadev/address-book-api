using AddressBook.Api.Infrastructure.ActionResults;
using AddressBook.Api.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;
using System.Net;

namespace AddressBook.Api.Infrastructure.Filters
{
    public class HttpGlobalExceptionFilter : ExceptionFilterAttribute
    {
        private readonly IWebHostEnvironment _environment;

        public HttpGlobalExceptionFilter(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public override void OnException(ExceptionContext context)
        {

            if (context.Exception.GetType() == typeof(ContactException))
            {
                var json = new JsonErrorResponse
                {
                    Messages = new[] { context.Exception.Message }
                };

                context.Result = new BadRequestObjectResult(json);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else
            {
                var json = new JsonErrorResponse
                {
                    Messages = new[] { "An error occurred. Try again." }
                };

                if (_environment.IsDevelopment())
                {
                    json.DeveloperMessage = context.Exception;
                }

                context.Result = new InternalServerErrorObjectResult(json);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
            context.ExceptionHandled = true;

            base.OnException(context);
        }
    }
}
