# Caso de Uso Expandido: UC-004

| **Campo** | **Descripción** |
|-----------|-----------------|
| **ID** | UC-004 |
| **Descripción** | Configurar preferencias personales del sistema y notificaciones |
| **Actores** | Usuario, Sistema |
| **Pre Condiciones** | El usuario debe estar autenticado. Debe existir un perfil de usuario con configuraciones por defecto. |

## Pasos Básicos

1. El usuario accede a "Configuración" o "Preferencias" desde su perfil
2. El sistema muestra las categorías de configuración disponibles:
   - Preferencias generales
   - Notificaciones
   - Privacidad
   - Escalada
   - Idioma y región
3. El usuario selecciona "Preferencias Generales" y configura:
   - Idioma de la interfaz
   - Zona horaria
   - Unidades de medida (métrico/imperial)
   - Tema de la aplicación (claro/oscuro)
4. El usuario configura "Notificaciones":
   - Notificaciones por email (activar/desactivar)
   - Notificaciones push (activar/desactivar)
   - Tipos específicos (nuevos problemas, invitaciones, logros)
   - Frecuencia de resúmenes
5. El usuario ajusta "Configuraciones de Escalada":
   - Nivel de experiencia preferido
   - Estilo de escalada favorito
   - Escalas de dificultad preferidas
   - Recordatorios de entrenamiento
6. El usuario modifica "Configuraciones de Privacidad":
   - Visibilidad del perfil (público/privado)
   - Mostrar estadísticas a otros usuarios
   - Permitir invitaciones de desconocidos
   - Compartir ubicación en sesiones
7. El usuario guarda las configuraciones
8. El sistema valida y aplica los cambios
9. El sistema actualiza las preferencias en la base de datos
10. El sistema confirma que los cambios han sido guardados

## Casos de Excepción

**E1: Configuración incompatible**
- **Condición**: Algunas configuraciones seleccionadas son mutuamente incompatibles
- **Acción**: El sistema muestra advertencia y sugiere configuraciones alternativas

**E2: Error al guardar**
- **Condición**: Falla al actualizar las preferencias en la base de datos
- **Acción**: El sistema mantiene configuraciones anteriores y permite reintentar

**E3: Configuración de notificaciones inválida**
- **Condición**: El dispositivo no soporta notificaciones push
- **Acción**: El sistema desactiva esa opción y sugiere alternativas

## Validaciones/Reglas de Negocio

- Al menos un método de notificación debe permanecer activo
- La zona horaria debe ser válida según estándares UTC
- Las configuraciones de privacidad no pueden ser más restrictivas que las políticas del sistema
- Los cambios de idioma requieren recarga de la aplicación
- Las notificaciones críticas de seguridad no pueden ser desactivadas

## Post Condiciones

- Las nuevas preferencias se aplican inmediatamente en la interfaz
- Las configuraciones se guardan en el perfil del usuario
- Las notificaciones futuras respetan las nuevas configuraciones
- El sistema adapta su comportamiento según las preferencias
- Se registra la actividad de cambio de configuraciones

## Información Adicional

**Prioridad**: Media
**Frecuencia de Uso**: Baja
**Complejidad**: Media
**Versión**: 1.0
**Fecha**: 2025-07-25
