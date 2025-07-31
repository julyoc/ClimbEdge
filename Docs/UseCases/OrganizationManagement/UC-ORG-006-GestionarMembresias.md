# Caso de Uso Expandido: UC-ORG-006

| **Campo** | **Descripción** |
|-----------|-----------------|
| **ID** | UC-ORG-006 |
| **Descripción** | Gestionar membresías de usuarios en una organización de escalada |
| **Actores** | Administrador de Organización, Propietario de Organización, Sistema de Notificaciones, Sistema de Pagos |
| **Pre Condiciones** | El usuario debe tener rol de Administrador o Propietario en la organización. La organización debe existir y estar activa. Debe haber al menos una solicitud de membresía o miembro existente. |

## Pasos Básicos

1. El administrador accede al panel de "Gestión de Membresías"
2. El sistema muestra el dashboard con:
   - Solicitudes pendientes de aprobación
   - Lista de miembros activos
   - Membresías próximas a vencer
   - Estadísticas generales
3. El administrador selecciona la acción a realizar:
   - Gestionar solicitudes pendientes
   - Modificar membresías existentes
   - Renovar membresías
   - Suspender/reactivar miembros
4. Para gestionar solicitudes pendientes:
   - El administrador selecciona "Solicitudes Pendientes"
   - El sistema muestra lista de solicitudes con información del solicitante
   - El administrador revisa cada solicitud individualmente
   - El administrador puede aprobar, rechazar o solicitar información adicional
5. Para modificar membresías existentes:
   - El administrador selecciona "Miembros Activos"
   - El sistema muestra lista filtrable/buscable de miembros
   - El administrador selecciona un miembro específico
   - El sistema muestra el perfil detallado del miembro
   - El administrador puede cambiar tipo, modificar fechas, suspender o agregar notas
6. El administrador confirma los cambios realizados
7. El sistema valida la consistencia de los cambios
8. El sistema actualiza la base de datos
9. El sistema registra la acción en el historial de auditoría
10. El sistema envía notificaciones automáticas a los usuarios afectados
11. El sistema actualiza métricas y estadísticas
12. El sistema muestra confirmación de éxito

## Casos de Excepción

**E1: Aprobación con modificaciones**
- **Condición**: El administrador quiere aprobar con un tipo diferente de membresía
- **Acción**: El sistema permite seleccionar tipo apropiado y agregar comentarios explicativos

**E2: Rechazo de solicitud**
- **Condición**: El administrador decide rechazar la solicitud
- **Acción**: El sistema solicita motivo obligatorio y procesa el rechazo notificando al usuario

**E3: Suspensión temporal de miembro**
- **Condición**: El administrador necesita suspender a un miembro
- **Acción**: El sistema solicita motivo y duración, bloquea accesos y notifica al miembro

**E4: Error en procesamiento de pagos**
- **Condición**: Falla al procesar cambios que afectan billing
- **Acción**: El sistema revierte cambios parciales y notifica del error

**E5: Límite de membresías alcanzado**
- **Condición**: Se intenta aprobar membresía cuando se alcanzó el límite
- **Acción**: El sistema sugiere actualizar plan de organización o poner en lista de espera

## Validaciones/Reglas de Negocio

- Solo administradores pueden modificar membresías
- Toda acción debe quedar registrada en auditoría
- Los miembros deben ser notificados de cambios en su estado
- Las suspensiones deben tener motivo documentado
- No se puede eliminar miembros, solo suspender o desactivar
- Los cambios de tipo de membresía pueden afectar tarifas
- Miembros suspendidos mantienen historial pero pierden accesos

## Post Condiciones

- El estado de las membresías se actualiza según las acciones realizadas
- Se envían notificaciones automáticas a los usuarios afectados
- Se registran todas las acciones en el historial de auditoría
- Se actualizan los contadores y métricas de la organización
- Los cambios en billing se procesan automáticamente
- Los accesos del sistema se actualizan según el nuevo estado

## Información Adicional

**Prioridad**: Alta
**Frecuencia de Uso**: Alta
**Complejidad**: Media
**Versión**: 1.0
**Fecha**: 2025-07-31
