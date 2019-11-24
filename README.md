# address-book-api

AddressBook is an ASP.NET Core Web API which provides a public address book (contacts) functionality.

# Features

* contacts need to contain name, date of birth, address and multiple telephone numbers 
* contacts need to be unique by name and address 
* creating, updating and deleting contacts 
* providing access to single and multiple contacts (with pagination) 
* provide a way of receiveing live updates for connected clients using SignalR

## Prerequirements

* Visual Studio 2019 
* .NET Core 3.0.1 SDK 
* PostgreSQL 

## Frameworks Used

* .NET Core 3.0
* Entity Framework Core 3.1.0
* Npgsql 3.1.0 
* Automapper

### Architecture Overview
The architecture patterns used for this application are based on DDD (Domain-Driven Design) approach.

## Solution Overview

#### AddressBook.Domain
- POCO entity classes
- DTOs
- Repository interfaces
- Services 

#### AddressBook.Infrastructure
- Data persistance infrastructure: repository implementations
- ORM: Entity Framework Core

#### AddressBook.Api
- ASP.NET Core Web API
- Application contracts and implementation
- MVC filters 
- API Models
- Hubs

## How to create the database

- Open solution in Visual Studio
- Open the appsettings.json file from AddressBook.Api
- Add the connectionstring for PostgreSQL connection string
```
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Username=postgres;Password=password;Database=AddressBookDB;"
  }
}
```
- In the the Package Manager console:
     - Select Default Project: AddressBook.Infrastructure
     - Run ```update-database```

## SignalR Hubs

**NotificationHub** is responsible for handling messages from clients and broadcasting them to all connected clients.


The `BroadcastMessage` method can be called by a connected client to send a message to all clients.
