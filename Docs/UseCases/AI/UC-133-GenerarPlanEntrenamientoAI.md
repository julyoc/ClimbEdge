# Caso de Uso Expandido: UC-133

| **Campo** | **Descripción** |
|-----------|-----------------|
| **ID** | UC-133 |
| **Descripción** | Generar plan de entrenamiento personalizado usando inteligencia artificial |
| **Actores** | Usuario, Sistema AI, Entrenador |
| **Pre Condiciones** | El usuario debe estar registrado y autenticado. Debe tener completado su perfil físico. El sistema AI debe estar operativo. |

## Pasos Básicos

1. El usuario accede a la sección "Crear Plan AI" en el módulo de entrenamiento
2. El sistema solicita información adicional del usuario:
   - Objetivo principal (fuerza, resistencia, técnica, competición)
   - Tiempo disponible por sesión (min/max)
   - Días disponibles por semana
   - Lesiones o limitaciones actuales
   - Experiencia en entrenamiento específico
   - Preferencias de ejercicios
3. El usuario completa el formulario de requisitos
4. El sistema valida la información ingresada
5. El sistema invoca el módulo de IA para análisis:
   - Analiza historial de entrenamientos previos
   - Evalúa progreso y rendimiento actual
   - Identifica fortalezas y debilidades
   - Considera factores de periodización
6. El sistema AI genera recomendaciones:
   - Estructura macro del plan (mesociclos)
   - Distribución semanal de entrenamientos
   - Progresión de cargas y volumen
   - Ejercicios específicos por sesión
7. El sistema presenta el plan propuesto al usuario:
   - Vista general del plan (12-16 semanas)
   - Desglose semanal detallado
   - Objetivos específicos por fase
   - Métricas de seguimiento
8. El usuario revisa y puede solicitar ajustes:
   - Modificar días de entrenamiento
   - Cambiar intensidad general
   - Excluir ejercicios específicos
   - Ajustar duración de sesiones
9. El sistema AI incorpora los ajustes solicitados
10. El usuario aprueba el plan final
11. El sistema crea el TrainingPlan en base de datos
12. El sistema programa todas las sesiones (TrainingSession)
13. El sistema notifica al usuario sobre activación del plan
14. El sistema establece recordatorios y seguimiento automático

## Casos de Excepción

**E1: Información insuficiente**
- **Condición**: Los datos del usuario son insuficientes para generar plan
- **Acción**: El sistema solicita completar evaluaciones adicionales

**E2: Sistema AI no disponible**
- **Condición**: El módulo de IA no responde o presenta errores
- **Acción**: El sistema ofrece planes pre-diseñados basados en plantillas

**E3: Objetivos incompatibles**
- **Condición**: Los objetivos ingresados son contradictorios
- **Acción**: El sistema identifica conflictos y solicita priorización

**E4: Limitaciones restrictivas**
- **Condición**: Las limitaciones del usuario no permiten un plan efectivo
- **Acción**: El sistema recomienda consulta con profesional

## Validaciones/Reglas de Negocio

- El plan debe tener una duración mínima de 4 semanas
- Máximo 6 sesiones de entrenamiento por semana
- Cada sesión debe durar entre 30 minutos y 3 horas
- Debe incluir al menos un día de descanso por semana
- La progresión de cargas debe ser gradual (máximo 10% semanal)
- Debe considerar principios de periodización deportiva
- Los ejercicios deben ser apropiados para el nivel del usuario

## Post Condiciones

- Se crea un nuevo TrainingPlan en el sistema
- Se generan todas las TrainingSession programadas
- Se establecen objetivos específicos y métricas de seguimiento
- El usuario recibe notificación de plan activado
- Se programa seguimiento automático de progreso
- El plan queda disponible para modificaciones futuras
- Se registra la intervención del sistema AI para aprendizaje

## Flujos Alternativos

**A1: Plan basado en plan anterior**
- El sistema AI analiza planes previos exitosos
- Aplica progresión natural basada en resultados anteriores
- Mantiene ejercicios que fueron efectivos

**A2: Plan colaborativo con entrenador**
- Un entrenador revisa y ajusta la propuesta de IA
- Se combina experiencia humana con análisis de datos
- El entrenador puede anular recomendaciones específicas

**A3: Plan adaptativo**
- El plan se ajusta automáticamente basado en resultados
- Se modifican cargas según respuesta del usuario
- Se rebalancean objetivos según progreso real

## Información Adicional

**Prioridad**: Alta
**Frecuencia de Uso**: Mensual
**Complejidad**: Alta
**Tiempo de Respuesta**: < 10 segundos
**Versión**: 1.0
**Fecha**: 2025-08-01
