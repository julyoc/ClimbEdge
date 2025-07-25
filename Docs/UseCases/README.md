# Casos de Uso Expandidos - ClimbEdge

Este directorio contiene la documentación detallada de todos los casos de uso del sistema ClimbEdge, organizados por módulos funcionales.

## Estructura de Documentación

### 1. Gestión de Usuarios
- [UC-001: Registrar Usuario](./UserManagement/UC-001-RegistrarUsuario.md)
- [UC-002: Iniciar Sesión](./UserManagement/UC-002-IniciarSesion.md)
- [UC-003: Gestionar Perfil](./UserManagement/UC-003-GestionarPerfil.md)
- [UC-004: Configurar Preferencias](./UserManagement/UC-004-ConfigurarPreferencias.md)

### 2. Gestión de Tableros
- [UC-010: Crear Tablero](./BoardManagement/UC-010-CrearTablero.md)
- [UC-011: Configurar Tablero](./BoardManagement/UC-011-ConfigurarTablero.md)
- [UC-012: Gestionar Miembros](./BoardManagement/UC-012-GestionarMiembros.md)
- [UC-013: Conectar Hardware](./BoardManagement/UC-013-ConectarHardware.md)

### 3. Gestión de Problemas
- [UC-020: Crear Problema Manual](./ProblemManagement/UC-020-CrearProblemaManual.md)
- [UC-021: Generar Problema con IA](./ProblemManagement/UC-021-GenerarProblemaIA.md)
- [UC-022: Validar Problema](./ProblemManagement/UC-022-ValidarProblema.md)
- [UC-023: Visualizar Problema](./ProblemManagement/UC-023-VisualizarProblema.md)

### 4. Sesiones y Progreso
- [UC-030: Iniciar Sesión Escalada](./SessionAndProgress/UC-030-IniciarSesionEscalada.md)
- [UC-031: Intentar Problema](./SessionAndProgress/UC-031-IntentarProblema.md)
- [UC-032: Registrar Progreso](./SessionAndProgress/UC-032-RegistrarProgreso.md)
- [UC-033: Analizar Rendimiento](./SessionAndProgress/UC-033-AnalizarRendimiento.md)

### 5. Rutas de Escalada
- [UC-040: Crear Zona Escalada](./ClimbingRoutes/UC-040-CrearZonaEscalada.md)
- [UC-041: Documentar Ruta](./ClimbingRoutes/UC-041-DocumentarRuta.md)
- [UC-042: Registrar Ascensión](./ClimbingRoutes/UC-042-RegistrarAscension.md)

### 6. Sistema IA
- [UC-050: Entrenar Modelo IA](./AISystem/UC-050-EntrenarModeloIA.md)
- [UC-051: Generar Problema Automático](./AISystem/UC-051-GenerarProblemaAutomatico.md)

### 7. Sistema Embebido
- [UC-060: Establecer Conexión Hardware](./EmbeddedSystem/UC-060-EstablecerConexionHardware.md)
- [UC-061: Detectar Toque Presa](./EmbeddedSystem/UC-061-DetectarToquePresa.md)
- [UC-062: Iluminar Problema](./EmbeddedSystem/UC-062-IluminarProblema.md)

### 8. Administración Sistema
- [UC-070: Configurar Sistema](./SystemAdministration/UC-070-ConfigurarSistema.md)
- [UC-071: Monitorear Sistema](./SystemAdministration/UC-071-MonitorearSistema.md)

## Convenciones

- **ID del Caso de Uso**: UC-XXX-NombreCasoUso
- **Formato**: Markdown (.md)
- **Estructura**: Basada en el estándar de documentación de casos de uso
- **Versionado**: Cada caso de uso incluye información de versión y cambios

## Actores del Sistema

- **Usuario**: Escalador general que utiliza el sistema
- **Administrador**: Usuario con permisos administrativos
- **Entrenador**: Usuario especializado en crear planes de entrenamiento
- **Propietario de Tablero**: Usuario que posee y administra un tablero específico
- **Sistema IA**: Sistema automatizado de inteligencia artificial
- **Sistema Embebido**: Hardware conectado (sensores, LEDs, Raspberry Pi)
