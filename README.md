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

## Índice de Contenidos

### 📘 Documentación Principal

- [README.md](./README.md) - Información general del proyecto
- [LICENSE](./LICENSE) - Licencia de software privado y propietario

### 🏗️ Arquitectura y Diagramas

- **Diagramas UML**
  - [Diagrama de Entidad-Relación](./Docs/Diagrams/EntityRelation.puml) - Modelo de datos completo
  - [Diagrama de Paquetes](./Docs/Diagrams/Package.puml) - Organización de entidades
  - [Arquitectura del Sistema](./Docs/Diagrams/architecture.puml) - Visión general arquitectónica
  - [Diagramas de Casos de Uso](./Docs/Diagrams/UseCase/) - Funcionalidades del sistema

### 📋 Especificaciones y Lineamientos

- **Documentos Técnicos**
  - [Resumen del Proyecto ClimbEdge](./Docs/Guidelines&Specifications/Resumen_Proyecto_ClimbEdge.md) - Visión general del sistema
  - [Modelo Matemático de Dificultad](./Docs/Guidelines&Specifications/ClimbEdge_Dificultad_ModeloMatematico.md) - Algoritmos de cálculo
  - [Reglas del Sistema](./Docs/Guidelines&Specifications/Reglas_ClimbEdge.md) - Reglas de escalada y uso
  - [Guía de Presas y Texturas](./Docs/Guidelines&Specifications/HOLDS.md) - Tipos de elementos del tablero
  - [Sensores FSR](./Docs/Guidelines&Specifications/SENSOR_FSR.md) - Especificaciones de hardware
  - [Conexiones Hardware](./Docs/Guidelines&Specifications/CONNECTIONS.md) - Configuración de dispositivos

### 📖 Casos de Uso Expandidos

- **[Índice General de Casos de Uso](./Docs/UseCases/README.md)**
- **Gestión de Usuarios**
  - [UC-001: Registrar Usuario](./Docs/UseCases/UserManagement/UC-001-RegistrarUsuario.md)
  - [UC-002: Iniciar Sesión](./Docs/UseCases/UserManagement/UC-002-IniciarSesion.md)
  - [UC-003: Gestionar Perfil](./Docs/UseCases/UserManagement/UC-003-GestionarPerfil.md)
  - [UC-004: Configurar Preferencias](./Docs/UseCases/UserManagement/UC-004-ConfigurarPreferencias.md)
- **Gestión de Tableros**
  - [UC-010: Crear Tablero](./Docs/UseCases/BoardManagement/UC-010-CrearTablero.md)
  - [UC-011: Configurar Tablero](./Docs/UseCases/BoardManagement/UC-011-ConfigurarTablero.md)
  - [UC-012: Gestionar Miembros](./Docs/UseCases/BoardManagement/UC-012-GestionarMiembros.md)
  - [UC-013: Conectar Hardware](./Docs/UseCases/BoardManagement/UC-013-ConectarHardware.md)
- **Gestión de Problemas**
  - [UC-020: Crear Problema Manual](./Docs/UseCases/ProblemManagement/UC-020-CrearProblemaManual.md)
  - [UC-021: Generar Problema con IA](./Docs/UseCases/ProblemManagement/UC-021-GenerarProblemaIA.md)
  - [UC-022: Validar Problema](./Docs/UseCases/ProblemManagement/UC-022-ValidarProblema.md)
  - [UC-023: Visualizar Problema](./Docs/UseCases/ProblemManagement/UC-023-VisualizarProblema.md)
- **Sesiones y Progreso**
  - [UC-030: Iniciar Sesión Escalada](./Docs/UseCases/SessionAndProgress/UC-030-IniciarSesionEscalada.md)
  - [UC-031: Intentar Problema](./Docs/UseCases/SessionAndProgress/UC-031-IntentarProblema.md)
  - [UC-032: Registrar Progreso](./Docs/UseCases/SessionAndProgress/UC-032-RegistrarProgreso.md)
  - [UC-033: Analizar Rendimiento](./Docs/UseCases/SessionAndProgress/UC-033-AnalizarRendimiento.md)
- **Rutas de Escalada**
  - [UC-040: Crear Zona Escalada](./Docs/UseCases/ClimbingRoutes/UC-040-CrearZonaEscalada.md)
  - [UC-041: Documentar Ruta](./Docs/UseCases/ClimbingRoutes/UC-041-DocumentarRuta.md)
  - [UC-042: Registrar Ascensión](./Docs/UseCases/ClimbingRoutes/UC-042-RegistrarAscension.md)
- **Sistema IA**
  - [UC-050: Entrenar Modelo IA](./Docs/UseCases/AISystem/UC-050-EntrenarModeloIA.md)
  - [UC-051: Generar Problema Automático](./Docs/UseCases/AISystem/UC-051-GenerarProblemaAutomatico.md)
- **Sistema Embebido**
  - [UC-060: Establecer Conexión Hardware](./Docs/UseCases/EmbeddedSystem/UC-060-EstablecerConexionHardware.md)
  - [UC-061: Detectar Toque Presa](./Docs/UseCases/EmbeddedSystem/UC-061-DetectarToquePresa.md)
  - [UC-062: Iluminar Problema](./Docs/UseCases/EmbeddedSystem/UC-062-IluminarProblema.md)
- **Administración Sistema**
  - [UC-070: Configurar Sistema](./Docs/UseCases/SystemAdministration/UC-070-ConfigurarSistema.md)
  - [UC-071: Monitorear Sistema](./Docs/UseCases/SystemAdministration/UC-071-MonitorearSistema.md)

### 🎨 Diseños y Recursos

- **Modelos 3D** - [Docs/Designs/3dModels/](./Docs/Designs/3dModels/)
- **Dibujos Técnicos** - [Docs/Designs/Drawings/](./Docs/Designs/Drawings/)
- **Documentos** - [Docs/Resources/Documents/](./Docs/Resources/Documents/)
- **Imágenes** - [Docs/Resources/Images/](./Docs/Resources/Images/)

### 💻 Código Fuente

- **Backend (API)** - [ClimbEdge.API/](./ClimbEdge.API/)
- **Capa de Aplicación** - [ClimbEdge.Application/](./ClimbEdge.Application/)
- **Capa de Dominio** - [ClimbEdge.Domain/](./ClimbEdge.Domain/)
- **Infraestructura** - [ClimbEdge.Infrastructure/](./ClimbEdge.Infrastructure/)
- **Utilidades Comunes** - [ClimbEdge.Common/](./ClimbEdge.Common/)
- **Frontend Web** - [ClimbEdge.Front/](./ClimbEdge.Front/)
- **Sistema Embebido** - [ClimbEdge.Rpi/](./ClimbEdge.Rpi/)

### 🔧 Herramientas de Desarrollo

- **Comandos de Migración** - Scripts para Entity Framework (ver sección Migrations)
- **Compilación** - `dotnet build` para compilar la solución
- **Ejecución** - `dotnet run --project ClimbEdge.API` para ejecutar la API
- **Testing** - `dotnet test` para ejecutar pruebas unitarias
- **Documentación** - PlantUML para diagramas UML
- **Control de Versiones** - Git con formato de versionado semántico
- **Base de Datos** - PostgreSQL con Entity Framework Core
- **Frontend** - Qwik framework para la interfaz web
- **Sistema Embebido** - Raspberry Pi con Python para hardware

