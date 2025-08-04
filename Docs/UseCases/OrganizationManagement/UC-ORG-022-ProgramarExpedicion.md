# Caso de Uso Expandido: UC-ORG-022

| **Campo** | **Descripción** |
|-----------|-----------------|
| **ID** | UC-ORG-022 |
| **Descripción** | Programar expedición de montañismo por parte de una organización verificada |
| **Actores** | Propietario de Organización, Administrador de Organización, Sistema de Notificaciones, Sistema de Pagos, Sistema Meteorológico |
| **Pre Condiciones** | La organización debe estar verificada por el sistema. El usuario debe tener rol de Propietario o Administrador. La organización debe tener al menos un instructor certificado disponible. Debe existir la montaña y ruta de destino en el sistema. |

## Pasos Básicos

1. El administrador accede a "Gestión de Expediciones" en el panel de organización
2. El sistema muestra el dashboard de expediciones con opciones de gestión
3. El administrador selecciona "Nueva Expedición"
4. El sistema muestra el formulario de creación de expedición
5. El administrador completa información básica:
   - Nombre de la expedición
   - Descripción detallada
   - Montaña y ruta de destino
   - Fechas de inicio y fin
   - Duración planificada
   - Nivel de experiencia requerido
6. El administrador configura parámetros de participación:
   - Número mínimo y máximo de participantes
   - Requisitos de experiencia específicos
   - Certificaciones requeridas
   - Restricciones de edad
   - Fecha límite de inscripción
7. El administrador establece costos:
   - Costo total por participante
   - Moneda
   - Política de cancelación
   - Descuentos por membresía
   - Forma de pago (completo/parcial)
8. El administrador planifica logística:
   - Punto de encuentro
   - Transporte incluido (si aplica)
   - Alojamiento base
   - Equipamiento proporcionado por la organización
   - Lista de equipamiento personal requerido
9. El administrador asigna personal:
   - Guía principal (instructor certificado)
   - Guías asistentes (si aplica)
   - Personal de apoyo (médico, cocinero, etc.)
   - Roles y responsabilidades
10. El administrador configura aspectos de seguridad:
    - Permisos requeridos para la montaña
    - Seguro obligatorio
    - Plan de comunicación
    - Contactos de emergencia
    - Protocolo de evacuación básico
11. El administrador revisa toda la información ingresada
12. El sistema valida la disponibilidad de guías y fechas
13. El sistema verifica permisos y requisitos legales
14. El administrador confirma la creación de la expedición
15. El sistema crea la expedición con estado "Programada"
16. El sistema genera automáticamente documentos base
17. El sistema publica la expedición según configuración de visibilidad
18. El sistema notifica a miembros elegibles de la organización
19. El sistema muestra confirmación con enlace de gestión

## Casos de Excepción

**E1: Conflicto de fechas con guías**
- **Condición**: Los guías seleccionados no están disponibles en las fechas
- **Acción**: El sistema muestra conflictos y sugiere guías alternativos o fechas alternativas

**E2: Ruta no disponible en fechas seleccionadas**
- **Condición**: La ruta tiene restricciones estacionales o permisos no disponibles
- **Acción**: El sistema muestra información sobre restricciones y sugiere alternativas

**E3: Organización no verificada**
- **Condición**: La organización perdió su estatus de verificación
- **Acción**: El sistema bloquea la creación y redirige a información sobre re-verificación

**E4: Sin guías certificados disponibles**
- **Condición**: No hay instructores certificados en la organización
- **Acción**: El sistema sugiere certificar instructores o permite expedición privada con guía externo

**E5: Error en generación automática**
- **Condición**: Falla al generar itinerarios o documentos automáticos
- **Acción**: El sistema permite continuar con creación manual y notifica al equipo técnico

## Validaciones/Reglas de Negocio

- Solo organizaciones verificadas pueden crear expediciones públicas
- Toda expedición debe tener al menos un guía certificado asignado
- El número máximo de participantes no puede exceder la capacidad de la ruta
- La fecha de inscripción debe ser al menos 7 días antes del inicio
- Expediciones a rutas que requieren permisos deben configurar tiempo adicional
- El costo mínimo debe cubrir seguros obligatorios y permisos

## Post Condiciones

- La expedición queda programada y publicada
- Se generan automáticamente las plantillas de itinerario
- Se configuran los sistemas de inscripción y pago
- Se notifica a miembros elegibles de la organización
- Se crea el plan de seguridad básico
- Se activan alertas meteorológicas automáticas
- Se registra la expedición en el calendario organizacional

## Información Adicional

**Prioridad**: Alta
**Frecuencia de Uso**: Media
**Complejidad**: Alta
**Versión**: 1.0
**Fecha**: 2025-07-31
