# Caso de Uso Expandido: UC-050

| **Campo** | **Descripción** |
|-----------|-----------------|
| **ID** | UC-050 |
| **Descripción** | Entrenar un modelo de inteligencia artificial con datos de problemas de escalada |
| **Actores** | Administrador IA, Sistema de Entrenamiento, Modelo IA |
| **Pre Condiciones** | Debe existir suficiente dataset de problemas de escalada. Los recursos computacionales deben estar disponibles. El modelo base debe estar definido. |

## Pasos Básicos

1. El administrador IA accede al módulo de entrenamiento de modelos
2. El sistema muestra modelos disponibles y estado actual
3. El administrador selecciona "Entrenar Nuevo Modelo" o "Reentrenar Existente"
4. El administrador configura parámetros de entrenamiento:
   - Tipo de modelo (red neuronal, algoritmo genético, etc.)
   - Dataset de entrenamiento a utilizar
   - Parámetros específicos del modelo
   - Recursos computacionales asignados
5. El sistema prepara el dataset de entrenamiento:
   - Recopila datos de BoardProblem existentes
   - Extrae características relevantes (dificultad, presas, ángulos)
   - Limpia y normaliza los datos
   - Divide en conjuntos de entrenamiento, validación y prueba
6. El administrador revisa calidad del dataset:
   - Distribución de dificultades
   - Variedad de estilos de problemas
   - Completitud de datos
   - Balance entre diferentes tipos
7. El administrador inicia el proceso de entrenamiento
8. El sistema ejecuta entrenamiento:
   - Carga datos en memoria del sistema de ML
   - Inicializa modelo con parámetros configurados
   - Ejecuta ciclos de entrenamiento iterativos
   - Monitorea métricas de rendimiento
9. Durante entrenamiento, el sistema:
   - Actualiza métricas en tiempo real
   - Guarda checkpoints periódicos
   - Valida contra conjunto de validación
   - Detecta posible overfitting
10. Al completar entrenamiento:
    - El sistema evalúa modelo contra conjunto de prueba
    - Genera reporte de rendimiento final
    - Compara con modelos anteriores
11. El administrador revisa resultados y decide:
    - Aceptar modelo como nuevo activo
    - Rechazar y ajustar parámetros
    - Requerir más datos de entrenamiento
12. Si se acepta, el sistema actualiza modelo en producción

## Casos de Excepción

**E1: Dataset insuficiente**
- **Condición**: No hay suficientes datos para entrenamiento efectivo
- **Acción**: El sistema sugiere esperar más datos o usar transfer learning

**E2: Recursos computacionales insuficientes**
- **Condición**: No hay suficiente CPU/GPU para el entrenamiento
- **Acción**: El sistema sugiere reducir complejidad o programar para horarios de menor carga

**E3: Entrenamiento divergente**
- **Condición**: El modelo no converge o performance empeora
- **Acción**: El sistema detiene entrenamiento y sugiere ajustar hiperparámetros

**E4: Overfitting detectado**
- **Condición**: El modelo memoriza datos sin generalizar
- **Acción**: El sistema aplica regularización o early stopping

**E5: Falla en infraestructura**
- **Condición**: Error en hardware o software durante entrenamiento
- **Acción**: El sistema restaura desde último checkpoint y reinicia

## Validaciones/Reglas de Negocio

- Se requieren mínimo 1000 problemas únicos para entrenamiento básico
- El entrenamiento no debe exceder 24 horas continuas
- Se debe mantener al menos 20% de datos para validación
- Los modelos deben superar performance de línea base establecida
- Se requiere aprobación para modelos que consuman recursos significativos

## Post Condiciones

- Se genera un modelo IA entrenado y evaluado
- El modelo está disponible para generación de problemas
- Se documenta completamente el proceso de entrenamiento
- Se actualizan métricas de rendimiento del sistema IA
- Se genera conocimiento para mejorar futuros entrenamientos

## Información Adicional

**Prioridad**: Media
**Frecuencia de Uso**: Baja (mensual/trimestral)
**Complejidad**: Muy Alta
**Tiempo de Respuesta**: 2-24 horas según complejidad
**Versión**: 1.0
**Fecha**: 2025-07-25
