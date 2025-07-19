# ClimbEdge

ClimbEdge is a platform designed to facilitate the management of climbing routes, including their creation, modification, and deletion. It also supports the management of users and their roles within the system.

## Architecture

**ClimbEdge** is built using clean architecture, which allows for scalability and flexibility in development. The system is divided into several key layers:

### Layer: Domain

This layer contains the core business logic and domain entities. It is independent of any external frameworks or libraries, ensuring that the business rules are not affected by changes in technology.

### Layer: Application

This layer acts as a bridge between the domain layer and the external world. It contains application services that orchestrate the use cases of the system, ensuring that the business logic is applied correctly.

### Layer: Infrastructure

This layer provides the necessary infrastructure to support the application, including database access, external APIs, and other system integrations. It is responsible for implementing the interfaces defined in the domain and application layers.

### Layer: Presentation (API)

This layer is responsible for exposing the application's functionality through a RESTful API. It handles HTTP requests and responses, converting them into application service calls and returning the results to the client.

### Layer: Common

This layer contains shared utilities and components that are used across different layers of the application. It includes logging, error handling, and other common functionalities that do not belong to any specific layer.

## Version ClimbEdge

### Version Format

Format of versions

```sh
v[mayor: version].[minor: funcionalidad].[path: corrección]-[pre-release: puede ser dev alpha beta rc ,etc].[incremental seg�n el tipo de pre-release]+[build: auto incremental general].[yyyymmdd]

�jm: v0.0.1-dev.0001+0001.20250711
```

[https://semver.org/](https://semver.org/)

### Versions

...

## Migrations

Migrations scripts:

```bash
# Crear migración (ejecutar desde la raíz del proyecto)
dotnet ef migrations add [NombreMigracion] --project ClimbEdge.Infrastructure --startup-project ClimbEdge.API -o Persistence/Migrations

# Aplicar migración
dotnet ef database update --project ClimbEdge.Infrastructure --startup-project ClimbEdge.API

# Otros comandos útiles
dotnet ef migrations list --project ClimbEdge.Infrastructure --startup-project ClimbEdge.API
dotnet ef migrations remove --project ClimbEdge.Infrastructure --startup-project ClimbEdge.API
dotnet ef database drop --project ClimbEdge.Infrastructure --startup-project ClimbEdge.API
dotnet tool update --global dotnet-ef --version 8.0.18
```
