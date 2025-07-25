# Caso de Uso Expandido: UC-042

| **Campo** | **Descripción** |
|-----------|-----------------|
| **ID** | UC-042 |
| **Descripción** | Registrar una ascensión completada o intentada en una ruta de escalada outdoor |
| **Actores** | Escalador, Sistema |
| **Pre Condiciones** | El usuario debe estar autenticado. La ruta debe existir en el sistema. El usuario debe tener una sesión activa en la zona correspondiente. |

## Pasos Básicos

1. El escalador completa o intenta una ruta de escalada
2. El escalador accede a la ruta específica en el sistema
3. El sistema muestra la información de la ruta y la opción "Registrar Ascensión"
4. El escalador selecciona "Registrar Ascensión"
5. El sistema muestra el formulario de registro de ascensión
6. El escalador selecciona el tipo de tick:
   - Onsight (primera vez sin información previa)
   - Flash (primera vez con información previa)
   - Redpoint (encadenada tras varios intentos)
   - Repeat (ruta ya encadenada anteriormente)
   - Attempt (intento sin completar)
   - Toprope (encadenada en top rope)
   - Dogged (con descansos en la cuerda)
7. El escalador indica si completó la ruta o no
8. El escalador registra información adicional:
   - Fecha y hora de la ascensión
   - Compañeros de escalada
   - Condiciones climáticas
   - Estado de la ruta
   - Gear utilizado
9. El escalador añade notas personales sobre la experiencia
10. El escalador evalúa la ruta (dificultad percibida, calidad, etc.)
11. El escalador puede subir fotos o videos de la ascensión
12. El escalador envía el registro
13. El sistema valida la información ingresada
14. El sistema crea el registro en UserSessionProgress
15. El sistema actualiza las estadísticas de la ruta
16. El sistema actualiza las estadísticas personales del escalador
17. El sistema confirma el registro exitoso

## Casos de Excepción

**E1: Ruta no encontrada**
- **Condición**: La ruta especificada no existe en el sistema
- **Acción**: El sistema sugiere rutas similares o permite crear nueva ruta

**E2: Ascensión duplicada**
- **Condición**: El usuario ya registró una ascensión en la misma fecha
- **Acción**: El sistema pregunta si desea actualizar el registro existente

**E3: Datos inconsistentes**
- **Condición**: La información ingresada tiene contradicciones
- **Acción**: El sistema destaca los campos problemáticos y solicita corrección

**E4: Sesión no activa**
- **Condición**: No hay una sesión activa en la zona correspondiente
- **Acción**: El sistema permite registrar retroactivamente o iniciar sesión

**E5: Evaluación extrema**
- **Condición**: La evaluación de dificultad difiere mucho del consenso
- **Acción**: El sistema solicita confirmación y justificación

## Validaciones/Reglas de Negocio

- La fecha de ascensión no puede ser futura
- Solo se permite un tick del mismo tipo por día en la misma ruta
- Las evaluaciones de dificultad deben estar en el rango válido de la escala
- Los comentarios no pueden exceder 1000 caracteres
- Las fotos deben tener tamaño máximo de 10MB
- Se requiere confirmación para ascensiones de grado muy superior al habitual

## Post Condiciones

- Se crea un registro en UserSessionProgress con los detalles de la ascensión
- Se actualizan las estadísticas de la ruta (número de ascensiones, evaluaciones)
- Se actualizan las estadísticas personales del escalador
- La ascensión aparece en el historial personal del usuario
- Se contribuye a las estadísticas globales de la ruta
- Otros usuarios pueden ver la ascensión (según configuración de privacidad)

## Información Adicional

**Prioridad**: Alta
**Frecuencia de Uso**: Alta
**Complejidad**: Media
**Versión**: 1.0
**Fecha**: 2025-07-25
