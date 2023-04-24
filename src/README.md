# Description
## GtMotive Technical test
NET 6 project using clean architecture, CQRS pattern (with mediatR) and Unit of work pattern.
EF In Memory.
Swagger implemented.

# Architecture
## Clean Arhitecture
### Layers
- #### **Host**: Web API Project
- #### **ApplicationCore**: Layer that joins the domain layer to higher level layers, command and queries features logic implementation
- #### **Domain**: Inner Layer of the solution. No element that compose it has an external dependency
- #### **Infrastructure**: Implementation of interfaces declared in application layer (ApiDbContext with EF InMemory implementation)
- #### **Tests**: UnitTest project using XUnit (Functional, Unit and Infrastructure)

# Methods
## Auth Controller
- Microsoft Identity implemented
- Methods to create new user
- Login to get token with an existing user (emal and password)
## Vehicle Controller
- POST to create new vehicle
- GET to get all vehicles (availables and not expired)
- GET vehicle information by id
- Authorization implemented
## Reservation Controller
- POST to create new reservation
- GET reservations
- DELETE to remove vehicle reservation
- Authorization implemented
## VehicleState Controller
- GET all vehicle states
- Authorization implemented

# RunApplication
## Default Project: InventoryManager.API
## Build solution: 
	> dotnet msbuild .\microservice.sln
## Restore solution Nugets: 
	> dotnet restore .\microservice.sln
## Run: 
	> cd .\GtMotive.Estimate.Microservice.Host
	> dotnet run