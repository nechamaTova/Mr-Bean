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
Its structure is based on REST API, and arranged into 4 layers: UI Layers, Controllers, Bussiness and Data layer.

- UI Layers: This layer handles the presentation and user interface aspects of the API.
- Business Layer: The business logic resides in this layer, where various operations and workflows are implemented.
- Repository: The repository layer is responsible for performing database operations, such as CRUD operations and data retrieval.

The layers correspond with each other through Dependency Injection, and through the global Entities project.
DTO entities were also used, in order to prevent circular dependency between the objects and provide encapsulation.
The conversion from entities to DTO object and vice versa was activated with AutoMapper.
The connection to the database via EntitiesFramework of Microsoft, was created by database first.

Integrated Error Handling by middleware, through logging first to file.

Scalability - Async/await programming patterns have been utilized throughout the project to improve performance and responsiveness. Asynchronous operations are employed wherever appropriate to avoid blocking threads and improve the overall system throughput.

The project uses Swagger.

## Securing
Validations are created in both client and server sides, for the sake of preventing unneccessary network traffic and to ensure security.
Users passwords must be strong. Special libraries to ensure password strength.

## Configuration
A configurator has been implemented to handle future changes efficiently. This approach enables easy modification of various settings and configurations without requiring significant code modifications.





