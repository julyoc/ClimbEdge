# Caso de Uso Expandido: UC-131

| **Campo** | **Descripción** |
|-----------|-----------------|
| **ID** | UC-131 |
| **Descripción** | Realizar una sesión de entrenamiento siguiendo el plan establecido |
| **Actores** | Usuario, Entrenador, Sistema |
| **Pre Condiciones** | El usuario debe tener un plan de entrenamiento activo. Debe existir una sesión programada para el día actual. El usuario debe estar autenticado. |

## Pasos Básicos

1. El usuario accede a la sección "Mi Entrenamiento" del sistema
2. El sistema muestra el plan de entrenamiento activo con la sesión del día
3. El usuario selecciona "Iniciar Sesión de Entrenamiento"
4. El sistema presenta la sesión programada con:
   - Objetivo de la sesión
   - Ejercicios planificados
   - Duración estimada
   - Zona de entrenamiento objetivo
5. El usuario confirma el inicio de la sesión
6. El sistema registra el tiempo de inicio en TrainingSession
7. Para cada ejercicio programado:
   - El sistema muestra las especificaciones del ejercicio
   - El usuario realiza el ejercicio
   - El usuario registra los resultados (series, repeticiones, peso, tiempo)
   - El sistema guarda los datos en SessionExercise
8. El usuario puede pausar la sesión si es necesario
9. El sistema registra pausas y descansos automáticamente
10. Al completar todos los ejercicios, el usuario indica finalización
11. El sistema registra el tiempo de finalización
12. El usuario evalúa la sesión:
    - Calificación general (1-10)
    - Nivel de esfuerzo percibido
    - Notas adicionales
13. El sistema actualiza las métricas del plan de entrenamiento
14. El sistema registra la sesión como completada
15. El sistema muestra resumen de la sesión y progreso hacia objetivos

## Casos de Excepción

**E1: Sesión no programada para hoy**
- **Condición**: No hay sesión programada para la fecha actual
- **Acción**: El sistema permite crear sesión libre o reprogramar sesión pendiente

**E2: Sesión interrumpida**
- **Condición**: La sesión se interrumpe por motivos externos
- **Acción**: El sistema guarda el progreso parcial y permite continuar posteriormente

**E3: Ejercicio no disponible**
- **Condición**: El equipamiento necesario no está disponible
- **Acción**: El sistema sugiere ejercicios alternativos equivalentes

**E4: Valores fuera de rango**
- **Condición**: Los datos ingresados son inconsistentes con capacidades del usuario
- **Acción**: El sistema valida y solicita confirmación o corrección

## Validaciones/Reglas de Negocio

- Solo se puede tener una sesión activa por usuario simultáneamente
- Los valores de peso, repeticiones y tiempo deben estar en rangos realistas
- La duración de la sesión no puede exceder 4 horas
- Se debe completar al menos 50% de ejercicios para considerarla válida
- Los descansos entre ejercicios se registran automáticamente
- La evaluación de la sesión es obligatoria

## Post Condiciones

- Se marca la sesión como completada en TrainingSession
- Se registran todos los ejercicios realizados en SessionExercise
- Se actualizan las métricas de progreso del plan
- Se calculan automáticamente estadísticas de rendimiento
- El usuario recibe feedback sobre su progreso
- Se programa automáticamente la siguiente sesión
- Los datos están disponibles para análisis posterior

## Flujos Alternativos

**A1: Sesión con entrenador virtual**
- El sistema proporciona guía paso a paso para cada ejercicio
- Se incluyen videos demostrativos y consejos técnicos
- Se ajustan cargas automáticamente basadas en rendimiento previo

**A2: Sesión grupal**
- Múltiples usuarios pueden realizar la misma sesión
- Se sincronizan ejercicios y descansos
- Se comparten resultados entre participantes

## Información Adicional

**Prioridad**: Alta
**Frecuencia de Uso**: Diaria
**Complejidad**: Media
**Tiempo de Respuesta**: < 2 segundos
**Versión**: 1.0
**Fecha**: 2025-08-01
