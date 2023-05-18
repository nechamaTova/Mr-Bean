# Mr Bean 

## Installation
1. Clone the repository to your local machine.
2. Open the project in your preferred IDE.
3. Run the application.
## Usage
1. Open a Application pages or use swagger.
2. Navigate to the API endpoints to interact with the application.


## Dependencies
### Frameworks
- ASP.NET Core 7.0
### Packages
- Entity Framework Core
- NLog
- zxcvbn-core
- Swashbuckle

## Description and Structure
This is a coffee shop site.
The project was written with ASP.NET Core 7.0
Its structure is based on REST API, and arranged into various layers: Controllers, Bussiness and Data layer.
The layers correspond with each other through Dependency Injection, and through the global Entities project.
DTO entities were also used, in order to prevent circular dependency between the objects and provide encapsulation.
The conversion from entities to DTO object and vice versa was activated with AutoMapper.
The connection to the database via EntitiesFramework of Microsoft, was created by database first.

Integrated Error Handling by middleware, through logging first to file.

Scalability - The functions are asynchronous throughout the entire project (using async await), conductive to maintaining scalability.

The project uses Swagger.

## Securing
Validations are created in both client and server sides, for the sake of preventing unneccessary network traffic and to ensure security.
Users passwords must be strong. Special libraries to ensure password strength.

## Configuration
configuratins settings are held by the `appsettings.json`file. 




