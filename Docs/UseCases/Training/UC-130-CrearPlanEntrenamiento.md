# Caso de Uso Expandido: UC-130

| **Campo** | **Descripción** |
|-----------|-----------------|
| **ID** | UC-130 |
| **Descripción** | Crear un plan de entrenamiento personalizado para mejorar el rendimiento en escalada |
| **Actores** | Usuario, Entrenador, Sistema |
| **Pre Condiciones** | El usuario debe estar autenticado. Debe existir al menos una prueba de forma física base o datos fisiológicos del usuario. El sistema debe tener plantillas de entrenamiento disponibles. |

## Pasos Básicos

1. El usuario accede a la sección "Entrenamiento" del sistema
2. El usuario selecciona "Crear Nuevo Plan de Entrenamiento"
3. El sistema muestra el asistente de creación de plan de entrenamiento
4. El usuario completa la información básica del plan:
   - Nombre del plan de entrenamiento
   - Objetivo principal (Mountaineering, Alpine_Technical, General_Climbing, Competition)
   - Fecha de inicio
   - Duración total en semanas (8-52 semanas)
   - Nivel de experiencia actual
5. El sistema presenta opciones de configuración:
   - Crear plan desde plantilla predefinida
   - Crear plan personalizado desde cero
   - Importar plan de otro usuario/entrenador
6. Si elige plantilla, el sistema muestra plantillas disponibles filtradas por objetivo
7. Si elige plan personalizado, el usuario define:
   - Objetivos a largo plazo (lista de metas específicas)
   - Objetivos a corto plazo (hitos semanales/mensuales)
   - Disponibilidad semanal (días y horas disponibles)
   - Preferencias de entrenamiento (indoor/outdoor, intensidad)
8. El sistema solicita datos fisiológicos base:
   - Usar datos existentes más recientes
   - Programar nueva evaluación fisiológica
   - Ingresar datos manualmente
9. El sistema genera la estructura del plan:
   - Divide en períodos de entrenamiento (Transition, Base, Specific, Tapering)
   - Asigna semanas a cada período
   - Calcula volúmenes de entrenamiento por zona
10. El usuario revisa y ajusta la estructura propuesta
11. El sistema crea los registros en la base de datos:
    - TrainingPlan principal
    - TrainingPeriod para cada fase
    - TrainingWeek para cada semana
    - TrainingSession base para cada día
12. El sistema configura objetivos automáticos basados en las metas
13. El sistema asocia los datos fisiológicos base al plan
14. El usuario confirma la creación del plan
15. El sistema marca el plan como activo y notifica al usuario

## Casos de Excepción

**E1: Datos fisiológicos insuficientes**
- **Condición**: No existen datos fisiológicos previos del usuario
- **Acción**: El sistema programa una prueba de forma física antes de crear el plan

**E2: Conflicto con plan existente**
- **Condición**: El usuario ya tiene un plan activo en las fechas seleccionadas
- **Acción**: El sistema sugiere desactivar el plan anterior o modificar fechas

**E3: Plantilla no compatible**
- **Condición**: La plantilla seleccionada no es compatible con el nivel del usuario
- **Acción**: El sistema sugiere plantillas alternativas o modificaciones

**E4: Objetivos inconsistentes**
- **Condición**: Los objetivos a largo y corto plazo son inconsistentes
- **Acción**: El sistema muestra las inconsistencias y solicita aclaración

**E5: Disponibilidad insuficiente**
- **Condición**: Las horas disponibles son insuficientes para el objetivo planteado
- **Acción**: El sistema sugiere objetivos más realistas o mayor disponibilidad

## Validaciones/Reglas de Negocio

- Un usuario solo puede tener un plan de entrenamiento activo a la vez
- La duración mínima de un plan es 4 semanas y máxima 52 semanas
- Los períodos de entrenamiento deben seguir una secuencia lógica
- El volumen semanal debe incrementarse gradualmente (no más del 10% por semana)
- Debe haber al menos 1 día de descanso por semana
- Los objetivos deben ser medibles y tener fechas específicas
- El plan debe incluir al menos 20% de entrenamiento específico de escalada

## Post Condiciones

- Se crea un nuevo TrainingPlan con estado activo
- Se generan todos los TrainingPeriod, TrainingWeek y TrainingSession asociados
- Se crean TrainingGoal específicos basados en los objetivos del usuario
- Se asocian los datos fisiológicos base como línea de referencia
- El usuario recibe una notificación de plan creado exitosamente
- El sistema programa recordatorios para las primeras sesiones
- Se inicializa el tracking de progreso del plan

## Flujos Alternativos

**A1: Creación con entrenador**
- Si un entrenador crea el plan para un cliente:
  - El entrenador selecciona el usuario cliente
  - Se notifica al usuario sobre el plan creado
  - El entrenador queda como creador del plan
  - Se habilitan funciones de supervisión

**A2: Plan basado en experiencia previa**
- El sistema puede sugerir mejoras basadas en planes anteriores del usuario
- Se copian ejercicios y configuraciones exitosas de planes previos
- Se ajustan volúmenes basados en el progreso histórico

**A3: Plan colaborativo**
- Múltiples usuarios pueden crear un plan grupal
- Se sincronizan objetivos comunes
- Se coordinan sesiones grupales

## Información Adicional

**Prioridad**: Alta
**Frecuencia de Uso**: Media
**Complejidad**: Alta
**Tiempo de Respuesta**: < 5 segundos
**Versión**: 1.0
**Fecha**: 2025-08-01

**Métricas de Éxito**:
- % de planes completados exitosamente
- Tiempo promedio de creación de plan
- Adherencia promedio al plan creado
- Mejora en métricas de rendimiento al finalizar el plan

**Consideraciones Técnicas**:
- El asistente debe manejar estado entre pasos
- Validación en tiempo real de configuraciones
- Cálculos automáticos de volúmenes y progresiones
- Integración con sistema de notificaciones para recordatorios
