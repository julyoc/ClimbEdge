# Caso de Uso Expandido: UC-003

| **Campo** | **Descripción** |
|-----------|-----------------|
| **ID** | UC-003 |
| **Descripción** | Gestionar información del perfil personal del usuario |
| **Actores** | Usuario, Sistema |
| **Pre Condiciones** | El usuario debe estar autenticado en el sistema. Debe existir un perfil de usuario asociado a la cuenta. |

## Pasos Básicos

1. El usuario accede a la sección "Mi Perfil" desde el menú principal
2. El sistema muestra la información actual del perfil:
   - Información personal (nombre, apellidos, fecha nacimiento)
   - Información de contacto (email, teléfono, ubicación)
   - Información de escalada (nivel experiencia, estilo preferido)
   - Foto de perfil
   - Configuraciones de privacidad
3. El usuario selecciona "Editar Perfil"
4. El sistema habilita los campos editables del formulario
5. El usuario modifica la información deseada:
   - Actualiza datos personales
   - Cambia foto de perfil
   - Modifica información de escalada
   - Actualiza contacto de emergencia
   - Ajusta configuraciones de privacidad
6. El usuario selecciona "Guardar Cambios"
7. El sistema valida la información ingresada
8. El sistema verifica que el email sea único si fue modificado
9. El sistema actualiza los datos en la tabla UserProfile
10. El sistema muestra confirmación de actualización exitosa
11. El sistema registra la actividad de modificación en logs
12. El usuario puede ver los cambios reflejados inmediatamente

## Casos de Excepción

**E1: Email duplicado**
- **Condición**: El nuevo email ya está registrado por otro usuario
- **Acción**: El sistema muestra error y mantiene el email anterior

**E2: Imagen demasiado grande**
- **Condición**: La foto de perfil excede el tamaño máximo permitido
- **Acción**: El sistema comprime automáticamente o solicita una imagen menor

**E3: Datos inválidos**
- **Condición**: Algún campo contiene información con formato incorrecto
- **Acción**: El sistema destaca los campos problemáticos y permite corregir

**E4: Sesión expirada**
- **Condición**: La sesión del usuario expira durante la edición
- **Acción**: El sistema guarda un borrador local y solicita nueva autenticación

## Validaciones/Reglas de Negocio

- La fecha de nacimiento no puede ser futura ni indicar edad menor a 13 años
- El teléfono debe tener formato válido internacional
- El nivel de experiencia debe estar entre "Principiante" y "Profesional"
- La foto de perfil debe ser JPG/PNG y no exceder 5MB
- Los campos de contacto de emergencia son opcionales pero recomendados
- Las configuraciones de privacidad por defecto protegen datos personales

## Post Condiciones

- Los datos del perfil se actualizan en la base de datos
- Los cambios son visibles inmediatamente para el usuario
- Otros usuarios ven los cambios según las configuraciones de privacidad
- Se mantiene un registro de auditoría de las modificaciones
- Las notificaciones se envían según las nuevas preferencias configuradas

## Información Adicional

**Prioridad**: Alta
**Frecuencia de Uso**: Media
**Complejidad**: Media
**Versión**: 1.0
**Fecha**: 2025-07-25
