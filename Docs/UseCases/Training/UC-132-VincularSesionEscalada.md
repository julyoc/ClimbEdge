# Caso de Uso Expandido: UC-132

| **Campo** | **Descripción** |
|-----------|-----------------|
| **ID** | UC-132 |
| **Descripción** | Vincular una sesión de escalada a un plan de entrenamiento específico |
| **Actores** | Usuario, Entrenador, Sistema |
| **Pre Condiciones** | El usuario debe tener un plan de entrenamiento activo. Debe existir al menos una sesión de entrenamiento planificada. El usuario debe estar autenticado. |

## Pasos Básicos

1. El usuario accede a la sección "Mi Entrenamiento" del sistema
2. El usuario selecciona el plan de entrenamiento activo
3. El sistema muestra el calendario de entrenamiento con las sesiones programadas
4. El usuario selecciona una sesión de entrenamiento de tipo escalada
5. El sistema muestra las opciones para vincular sesiones de escalada
6. El usuario selecciona "Agregar Sesión de Escalada"
7. El sistema muestra el formulario de configuración de sesión de escalada:
   - Tablero o zona de escalada objetivo
   - Objetivo planificado de la sesión
   - Enfoque técnico específico
   - Nivel de intensidad deseado
   - Duración estimada
8. El usuario completa la configuración y confirma
9. El sistema crea el registro TrainingSessionClimbing
10. El usuario realiza la sesión de escalada en el tablero/zona seleccionada
11. El sistema registra automáticamente la UserSession cuando el usuario inicia la escalada
12. El sistema vincula automáticamente la UserSession con la TrainingSessionClimbing
13. Durante la sesión, el sistema registra:
    - Problemas intentados y completados
    - Tiempo de descanso entre problemas
    - Progreso técnico observado
14. Al finalizar la sesión, el usuario puede agregar:
    - Notas de rendimiento
    - Autoevaluación de la sesión
    - Áreas de mejora identificadas
15. El sistema actualiza automáticamente las métricas de entrenamiento
16. El sistema genera un resumen de la sesión vinculada al plan de entrenamiento

## Casos de Excepción

**E1: Plan de entrenamiento no activo**
- **Condición**: El usuario no tiene un plan de entrenamiento activo
- **Acción**: El sistema sugiere crear un nuevo plan o activar uno existente

**E2: Sesión de entrenamiento no compatible**
- **Condición**: La sesión de entrenamiento seleccionada no es de tipo escalada
- **Acción**: El sistema muestra mensaje de error y sugiere sesiones compatibles

**E3: Conflicto de horarios**
- **Condición**: Ya existe una sesión de escalada programada en el mismo horario
- **Acción**: El sistema alerta sobre el conflicto y permite reprogramar

**E4: Error en vinculación automática**
- **Condición**: La UserSession no se vincula automáticamente con TrainingSessionClimbing
- **Acción**: El sistema permite vinculación manual y registra el error para revisión

**E5: Sesión interrumpida**
- **Condición**: La sesión de escalada se interrumpe antes de completarse
- **Acción**: El sistema guarda el progreso parcial y permite continuar o finalizar

## Validaciones/Reglas de Negocio

- Solo se pueden vincular sesiones de escalada a entrenamientos de tipo "Climbing" o "Technical"
- Una sesión de escalada solo puede estar vinculada a una sesión de entrenamiento
- El tiempo registrado en la sesión de escalada debe coincidir con la duración planificada (±30%)
- Las métricas de intensidad deben estar dentro del rango planificado para la semana de entrenamiento
- Se debe registrar al menos un problema intentado para considerar válida la sesión
- Los datos de la sesión se incorporan automáticamente a las estadísticas del plan de entrenamiento

## Post Condiciones

- Se crea un registro en TrainingSessionClimbing vinculando ambas sesiones
- La UserSession queda asociada al plan de entrenamiento
- Se actualizan las métricas de progreso del plan de entrenamiento
- Se registran los datos de rendimiento específicos de escalada
- El usuario recibe feedback sobre su progreso en el plan
- Los datos están disponibles para análisis posterior del entrenador
- Se actualiza el volumen de entrenamiento semanal

## Flujos Alternativos

**A1: Vinculación posterior**
- El usuario puede vincular una sesión de escalada ya realizada a una sesión de entrenamiento
- El sistema valida que las fechas y características sean compatibles

**A2: Múltiples sesiones de escalada**
- Una sesión de entrenamiento puede incluir múltiples sesiones de escalada cortas
- El sistema suma las duraciones y promedía las métricas de intensidad

**A3: Sesión con entrenador**
- Si la sesión incluye un entrenador, se habilitan campos adicionales para feedback del coach
- El entrenador puede añadir observaciones técnicas y recomendaciones

## Información Adicional

**Prioridad**: Alta
**Frecuencia de Uso**: Alta
**Complejidad**: Media-Alta
**Tiempo de Respuesta**: < 3 segundos
**Versión**: 1.0
**Fecha**: 2025-08-01

**Métricas de Éxito**:
- % de sesiones de entrenamiento que incluyen escalada exitosamente vinculadas
- Tiempo promedio para vincular una sesión
- Satisfacción del usuario con la funcionalidad de vinculación
- Precisión de las métricas automáticamente calculadas
