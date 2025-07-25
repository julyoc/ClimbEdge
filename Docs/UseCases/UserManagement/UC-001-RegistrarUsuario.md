# Caso de Uso Expandido: UC-001

| **Campo** | **Descripción** |
|-----------|-----------------|
| **ID** | UC-001 |
| **Descripción** | Registrar nuevo usuario en el sistema ClimbEdge |
| **Actores** | Usuario, Sistema |
| **Pre Condiciones** | El usuario debe tener acceso a internet y un navegador web compatible. El sistema debe estar operativo y la base de datos disponible. |

## Pasos Básicos

1. El usuario accede a la página de registro del sistema ClimbEdge
2. El sistema muestra el formulario de registro con los campos requeridos
3. El usuario ingresa la información personal básica:
   - Nombre de usuario (único)
   - Correo electrónico (único)
   - Contraseña (con validaciones de seguridad)
   - Confirmación de contraseña
4. El usuario acepta los términos y condiciones del servicio
5. El usuario envía el formulario de registro
6. El sistema valida la información ingresada
7. El sistema verifica que el nombre de usuario y correo no existan
8. El sistema crea la cuenta de usuario con estado "pendiente de verificación"
9. El sistema crea automáticamente un perfil de usuario básico asociado
10. El sistema envía un correo de confirmación al email proporcionado
11. El sistema muestra mensaje de confirmación de registro exitoso
12. El usuario recibe el correo y hace clic en el enlace de verificación
13. El sistema activa la cuenta del usuario
14. El sistema redirige al usuario a la página de inicio de sesión

## Casos de Excepción

**E1: Información inválida**
- **Condición**: Los datos ingresados no cumplen con las validaciones
- **Acción**: El sistema muestra mensajes de error específicos y permite corregir

**E2: Usuario o email ya existe**
- **Condición**: El nombre de usuario o correo electrónico ya están registrados
- **Acción**: El sistema muestra mensaje de error y sugiere opciones alternativas

**E3: Error en envío de email**
- **Condición**: El sistema no puede enviar el correo de confirmación
- **Acción**: El sistema permite reenviar el correo o contactar soporte

**E4: Enlace de verificación expirado**
- **Condición**: El usuario intenta verificar con un enlace caducado
- **Acción**: El sistema permite solicitar un nuevo enlace de verificación

## Validaciones/Reglas de Negocio

- El nombre de usuario debe tener entre 3 y 50 caracteres alfanuméricos
- La contraseña debe tener al menos 8 caracteres, incluir mayúsculas, minúsculas y números
- El correo electrónico debe tener formato válido
- Los términos y condiciones deben ser aceptados obligatoriamente
- El enlace de verificación expira en 24 horas
- Solo se permite una cuenta por dirección de correo electrónico

## Post Condiciones

- Se crea un nuevo registro en la tabla AppUser con estado verificado
- Se crea un perfil de usuario básico asociado en la tabla UserProfile
- El usuario puede iniciar sesión en el sistema
- El usuario recibe un email de bienvenida con información básica del sistema
- Se registra la actividad en los logs del sistema

## Información Adicional

**Prioridad**: Alta
**Frecuencia de Uso**: Alta
**Complejidad**: Media
**Versión**: 1.0
**Fecha**: 2025-07-25
