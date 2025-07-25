# Caso de Uso Expandido: UC-002

| **Campo** | **Descripción** |
|-----------|-----------------|
| **ID** | UC-002 |
| **Descripción** | Autenticar usuario en el sistema ClimbEdge |
| **Actores** | Usuario, Sistema |
| **Pre Condiciones** | El usuario debe tener una cuenta registrada y verificada. El sistema debe estar operativo. El usuario no debe tener una sesión activa. |

## Pasos Básicos

1. El usuario accede a la página de inicio de sesión
2. El sistema muestra el formulario de autenticación
3. El usuario ingresa sus credenciales:
   - Nombre de usuario o correo electrónico
   - Contraseña
4. El usuario selecciona la opción "Recordarme" (opcional)
5. El usuario envía el formulario
6. El sistema valida las credenciales contra la base de datos
7. El sistema verifica que la cuenta esté activa y no bloqueada
8. El sistema verifica si tiene autenticación de dos factores (2FA) habilitada
9. Si tiene 2FA: el sistema solicita el código de verificación
10. El usuario ingresa el código 2FA (si aplica)
11. El sistema valida el código 2FA
12. El sistema crea una sesión de usuario
13. El sistema genera y almacena el token de autenticación
14. El sistema registra la actividad de inicio de sesión
15. El sistema redirige al usuario al dashboard principal

## Casos de Excepción

**E1: Credenciales incorrectas**
- **Condición**: Usuario o contraseña no coinciden
- **Acción**: El sistema muestra mensaje de error, incrementa contador de intentos fallidos

**E2: Cuenta bloqueada**
- **Condición**: La cuenta ha excedido el límite de intentos fallidos
- **Acción**: El sistema muestra mensaje de cuenta bloqueada y opciones de recuperación

**E3: Cuenta no verificada**
- **Condición**: El usuario no ha verificado su correo electrónico
- **Acción**: El sistema muestra mensaje y opción de reenviar verificación

**E4: Código 2FA incorrecto**
- **Condición**: El código de autenticación de dos factores es inválido
- **Acción**: El sistema permite reintentar hasta 3 veces, luego bloquea temporalmente

**E5: Sesión simultánea detectada**
- **Condición**: El usuario ya tiene una sesión activa en otro dispositivo
- **Acción**: El sistema pregunta si desea cerrar la sesión anterior o denegar el acceso

## Validaciones/Reglas de Negocio

- Máximo 5 intentos fallidos antes de bloquear la cuenta por 15 minutos
- Las sesiones expiran después de 24 horas de inactividad
- El código 2FA debe ser validado en un plazo de 5 minutos
- Solo se permite una sesión activa por usuario (configurable)
- Los tokens de sesión deben renovarse cada 2 horas

## Post Condiciones

- El usuario tiene una sesión activa en el sistema
- Se registra la actividad de inicio de sesión con timestamp y IP
- Se establece una cookie de sesión segura (HttpOnly)
- El usuario puede acceder a todas las funcionalidades según sus permisos
- Se actualiza el campo LastLoginAt en el perfil del usuario

## Información Adicional

**Prioridad**: Alta
**Frecuencia de Uso**: Muy Alta
**Complejidad**: Media
**Versión**: 1.0
**Fecha**: 2025-07-25
