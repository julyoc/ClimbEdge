# Caso de Uso Expandido: UC-012

| **Campo** | **Descripción** |
|-----------|-----------------|
| **ID** | UC-012 |
| **Descripción** | Gestionar miembros de un tablero, incluyendo invitaciones, roles y permisos |
| **Actores** | Propietario de Tablero, Administrador de Tablero, Usuario, Sistema |
| **Pre Condiciones** | El tablero debe existir. El usuario que gestiona debe tener permisos de administración. El sistema de notificaciones debe estar operativo. |

## Pasos Básicos

1. El administrador accede a la gestión de miembros del tablero
2. El sistema muestra la lista actual de miembros con sus roles:
   - Propietario (Owner)
   - Administrador (Admin)
   - Miembro (Member)
   - Observador (Viewer)
3. El administrador selecciona "Invitar Nuevo Miembro"
4. El administrador ingresa información del usuario a invitar:
   - Email o nombre de usuario
   - Rol a asignar
   - Mensaje personalizado (opcional)
   - Fecha de expiración de invitación
5. El sistema valida que el usuario existe en el sistema
6. El sistema verifica que el usuario no sea ya miembro
7. El sistema crea la invitación y envía notificación al usuario
8. El usuario invitado recibe la notificación y puede:
   - Aceptar la invitación
   - Rechazar la invitación
   - Ignorar (expira automáticamente)
9. Si acepta, el sistema crea el registro BoardMember
10. El administrador puede modificar roles de miembros existentes:
    - Selecciona un miembro de la lista
    - Cambia su rol (respetando jerarquías)
    - Confirma el cambio
11. El administrador puede remover miembros:
    - Selecciona miembro a remover
    - Confirma la acción
    - El sistema elimina el registro BoardMember
12. El sistema notifica cambios relevantes a los afectados

## Casos de Excepción

**E1: Usuario no encontrado**
- **Condición**: El email o usuario a invitar no existe en el sistema
- **Acción**: El sistema sugiere enviar invitación de registro al email

**E2: Usuario ya es miembro**
- **Condición**: El usuario invitado ya pertenece al tablero
- **Acción**: El sistema muestra el rol actual y permite modificarlo

**E3: Intento de degradar propietario**
- **Condición**: Se intenta cambiar el rol del propietario único
- **Acción**: El sistema bloquea la acción y explica que debe transferir propiedad primero

**E4: Límite de miembros excedido**
- **Condición**: Se alcanza el límite máximo de miembros del plan
- **Acción**: El sistema sugiere upgrade del plan o remoción de miembros inactivos

**E5: Invitación expirada**
- **Condición**: El usuario intenta aceptar una invitación caducada
- **Acción**: El sistema informa del vencimiento y permite solicitar nueva invitación

## Validaciones/Reglas de Negocio

- Debe haber siempre al menos un propietario por tablero
- Los administradores no pueden modificar roles de otros administradores
- Solo el propietario puede asignar roles de administrador
- Las invitaciones expiran en 7 días por defecto
- Máximo 50 miembros por tablero en plan básico
- Los miembros removidos pierden acceso inmediatamente

## Post Condiciones

- Los cambios de membresía se reflejan inmediatamente
- Los usuarios afectados reciben notificaciones apropiadas
- Se actualiza la lista de miembros del tablero
- Se registran todas las acciones de gestión en logs
- Los permisos de acceso se actualizan automáticamente

## Información Adicional

**Prioridad**: Alta
**Frecuencia de Uso**: Media
**Complejidad**: Media
**Versión**: 1.0
**Fecha**: 2025-07-25
