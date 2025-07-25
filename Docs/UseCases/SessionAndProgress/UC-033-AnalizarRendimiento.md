# Caso de Uso Expandido: UC-033

| **Campo** | **Descripción** |
|-----------|-----------------|
| **ID** | UC-033 |
| **Descripción** | Analizar el rendimiento del escalador y generar reportes de progreso |
| **Actores** | Escalador, Entrenador, Sistema |
| **Pre Condiciones** | Debe existir historial de sesiones y progreso del escalador. El sistema de análisis debe estar operativo. Debe haber suficientes datos para generar análisis significativos. |

## Pasos Básicos

1. El escalador accede a la sección "Análisis de Rendimiento"
2. El sistema muestra el dashboard principal con métricas clave:
   - Problemas completados por período
   - Evolución de dificultad promedio
   - Tiempo promedio por intento
   - Ratio de éxito por dificultad
3. El escalador selecciona tipo de análisis deseado:
   - Análisis por período (día, semana, mes, año)
   - Análisis por dificultad
   - Análisis por estilo de problema
   - Comparativa con otros escaladores
4. El sistema genera gráficos y visualizaciones:
   - Tendencias de progreso temporal
   - Distribución de dificultades intentadas vs completadas
   - Heatmaps de rendimiento por tipo de problema
   - Curvas de aprendizaje personalizadas
5. El sistema calcula métricas avanzadas:
   - Velocidad de progresión (dificultad/tiempo)
   - Consistencia en diferentes estilos
   - Eficiencia de entrenamiento
   - Puntos fuertes y débiles identificados
6. El sistema proporciona insights automáticos:
   - Patrones detectados en el rendimiento
   - Sugerencias de áreas de mejora
   - Recomendaciones de problemas para próximas sesiones
   - Alertas sobre posible estancamiento o regresión
7. El escalador puede configurar objetivos:
   - Meta de dificultad para período específico
   - Número de problemas a completar
   - Objetivos de consistencia
   - Metas de tiempo por problema
8. El sistema genera reportes personalizados:
   - Resumen de progreso por período
   - Comparativa con objetivos establecidos
   - Recomendaciones específicas de entrenamiento
   - Predicciones de progreso futuro
9. El escalador puede exportar o compartir análisis con entrenadores

## Casos de Excepción

**E1: Datos insuficientes**
- **Condición**: No hay suficiente historial para análisis significativo
- **Acción**: El sistema muestra datos disponibles y sugiere más actividad

**E2: Datos inconsistentes**
- **Condición**: Se detectan anomalías en los datos históricos
- **Acción**: El sistema identifica y excluye datos problemáticos del análisis

**E3: Falla en cálculo de métricas**
- **Condición**: Error al procesar algoritmos de análisis
- **Acción**: El sistema muestra métricas básicas y registra error para corrección

**E4: Objetivos inalcanzables**
- **Condición**: Los objetivos establecidos son irrealistas según análisis
- **Acción**: El sistema sugiere objetivos más realistas basados en progresión actual

## Validaciones/Reglas de Negocio

- Se requieren mínimo 10 intentos para análisis básico
- Los análisis comparativos solo incluyen usuarios con consentimiento
- Las predicciones tienen máximo 6 meses de proyección
- Los datos personales se anonimiza en comparativas grupales
- Solo entrenadores autorizados pueden ver análisis detallados de otros

## Post Condiciones

- El escalador comprende su rendimiento actual y tendencias
- Se generan recomendaciones personalizadas para mejora
- Los objetivos están establecidos de manera realista
- Se identifican áreas específicas de fortaleza y debilidad
- Los datos están listos para sesiones de entrenamiento dirigido

## Información Adicional

**Prioridad**: Media
**Frecuencia de Uso**: Media (semanal/mensual)
**Complejidad**: Alta
**Tiempo de Respuesta**: 5-15 segundos según complejidad del análisis
**Versión**: 1.0
**Fecha**: 2025-07-25
