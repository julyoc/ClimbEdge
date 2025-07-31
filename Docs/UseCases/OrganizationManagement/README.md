# Casos de Uso - Gestión de Organizaciones

Este documento contiene los casos de uso específicos para la gestión de organizaciones en ClimbEdge.

## Índice

### Gestión Básica de Organizaciones
- [UC-ORG-001: Registrar Organización](./UC-ORG-001-RegistrarOrganizacion.md)
- [UC-ORG-002: Verificar Organización](./UC-ORG-002-VerificarOrganizacion.md)
- [UC-ORG-003: Gestionar Perfil de Organización](./UC-ORG-003-GestionarPerfil.md)
- [UC-ORG-004: Configurar Horarios y Servicios](./UC-ORG-004-ConfigurarServicios.md)

### Gestión de Membresías
- [UC-ORG-005: Solicitar Membresía](./UC-ORG-005-SolicitarMembresia.md)
- [UC-ORG-006: Gestionar Membresías](./UC-ORG-006-GestionarMembresias.md)
- [UC-ORG-007: Renovar Membresía](./UC-ORG-007-RenovarMembresia.md)
- [UC-ORG-008: Cancelar Membresía](./UC-ORG-008-CancelarMembresia.md)

### Gestión de Instalaciones
- [UC-ORG-009: Registrar Instalaciones](./UC-ORG-009-RegistrarInstalaciones.md)
- [UC-ORG-010: Gestionar Reservas de Instalaciones](./UC-ORG-010-GestionarReservas.md)
- [UC-ORG-011: Configurar Capacidad y Acceso](./UC-ORG-011-ConfigurarAcceso.md)

### Gestión de Eventos
- [UC-ORG-012: Crear Evento](./UC-ORG-012-CrearEvento.md)
- [UC-ORG-013: Gestionar Participantes de Evento](./UC-ORG-013-GestionarParticipantes.md)
- [UC-ORG-014: Configurar Inscripciones](./UC-ORG-014-ConfigurarInscripciones.md)
- [UC-ORG-015: Cancelar/Reprogramar Evento](./UC-ORG-015-CancelarEvento.md)

### Gestión de Certificaciones
- [UC-ORG-016: Otorgar Certificación](./UC-ORG-016-OtorgarCertificacion.md)
- [UC-ORG-017: Renovar Certificación](./UC-ORG-017-RenovarCertificacion.md)
- [UC-ORG-018: Validar Certificaciones](./UC-ORG-018-ValidarCertificaciones.md)

### Gestión de Instructores
- [UC-ORG-019: Registrar Instructor](./UC-ORG-019-RegistrarInstructor.md)
- [UC-ORG-020: Gestionar Horarios de Instructor](./UC-ORG-020-GestionarHorarios.md)
- [UC-ORG-021: Asignar Especialidades](./UC-ORG-021-AsignarEspecialidades.md)

### Gestión de Expediciones
- [UC-ORG-022: Programar Expedición](./UC-ORG-022-ProgramarExpedicion.md)
- [UC-ORG-023: Gestionar Logística de Expedición](./UC-ORG-023-GestionarLogistica.md)
- [UC-ORG-024: Gestionar Participantes de Expedición](./UC-ORG-024-GestionarParticipantesExpedicion.md)
- [UC-ORG-025: Seguimiento de Expedición](./UC-ORG-025-SeguimientoExpedicion.md)

### Gestión de Archivos y Documentos
- [UC-ORG-026: Subir Documentos Legales](./UC-ORG-026-SubirDocumentos.md)
- [UC-ORG-027: Gestionar Galería](./UC-ORG-027-GestionarGaleria.md)
- [UC-ORG-028: Configurar Waivers](./UC-ORG-028-ConfigurarWaivers.md)

### Reportes y Análisis
- [UC-ORG-029: Generar Reportes de Membresía](./UC-ORG-029-ReportesMembresia.md)
- [UC-ORG-030: Analizar Utilización de Instalaciones](./UC-ORG-030-AnalizarUtilizacion.md)
- [UC-ORG-031: Reportes Financieros](./UC-ORG-031-ReportesFinancieros.md)

## Actores

### Primarios
- **Usuario**: Persona que puede registrar una organización o solicitar membresía
- **Propietario de Organización**: Usuario que registró la organización y tiene máximos privilegios
- **Administrador de Organización**: Usuario con permisos administrativos delegados por el propietario
- **Instructor**: Miembro especializado que puede impartir clases y certificaciones
- **Miembro**: Usuario que pertenece a una organización con diferentes tipos de membresía

### Secundarios
- **Administrador del Sistema**: Usuario con privilegios de sistema para verificar organizaciones
- **Sistema de Pagos**: Sistema externo para procesar pagos de membresías y eventos
- **Sistema de Notificaciones**: Sistema para enviar comunicaciones automáticas

## Reglas de Negocio

### RN-ORG-001: Verificación de Organizaciones
Solo las organizaciones verificadas por el sistema pueden:
- Otorgar certificaciones oficiales
- Programar expediciones públicas
- Aparecer en listados públicos destacados

### RN-ORG-002: Membresías
- Una persona puede ser miembro de múltiples organizaciones
- Los tipos de membresía determinan los niveles de acceso a instalaciones y eventos
- Las membresías tienen fechas de expiración y deben renovarse

### RN-ORG-003: Certificaciones
- Solo instructores certificados pueden otorgar certificaciones
- Las certificaciones tienen fechas de expiración según el tipo
- El sistema mantiene un registro histórico de todas las certificaciones

### RN-ORG-004: Expediciones Organizacionales
- Solo organizaciones verificadas pueden programar expediciones públicas
- Las expediciones deben tener al menos un guía certificado
- Se requiere seguro de responsabilidad civil para expediciones grupales
