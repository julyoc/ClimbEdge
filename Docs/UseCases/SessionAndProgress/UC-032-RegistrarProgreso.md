# Caso de Uso Expandido: UC-032

| **Campo** | **Descripción** |
|-----------|-----------------|
| **ID** | UC-032 |
| **Descripción** | Registrar y almacenar el progreso del escalador durante intentos de problemas |
| **Actores** | Sistema, Escalador, Sistema Embebido |
| **Pre Condiciones** | Debe existir una sesión activa. El escalador debe estar intentando un problema. Los sistemas de tracking deben estar operativos. |

## Pasos Básicos

1. El sistema inicia registro automático al comenzar un intento
2. El sistema captura datos en tiempo real:
   - Timestamp de inicio del intento
   - Presas tocadas en secuencia
   - Tiempo en cada posición
   - Movimientos entre presas
3. El sistema registra eventos específicos:
   - Primera presa tocada (inicio oficial)
   - Caídas o descansos
   - Violaciones de reglas
   - Última presa alcanzada antes de caída
4. Al finalizar el intento, el sistema registra:
   - Resultado final (completado/fallido)
   - Tiempo total utilizado
   - Porcentaje de problema completado
   - Punto máximo alcanzado
5. El sistema solicita información adicional al escalador:
   - Tipo de tick realizado
   - Dificultad percibida (1-32)
   - Calidad del problema (1-5 estrellas)
   - Comentarios específicos
6. El sistema calcula métricas derivadas:
   - Eficiencia de movimientos
   - Tiempo por presa
   - Consistencia en la escalada
   - Mejora respecto a intentos anteriores
7. El sistema actualiza registros:
   - UserSessionProgress con datos del intento
   - Estadísticas acumuladas del escalador
   - Estadísticas del problema
   - BoardSessionSummary para resumen de tablero
8. El sistema genera feedback automático:
   - Progreso comparado con intentos anteriores
   - Sugerencias de mejora
   - Reconocimiento de logros alcanzados
9. El sistema almacena datos para análisis posterior:
   - Patrones de movimiento
   - Tendencias de rendimiento
   - Datos para entrenamiento de IA

## Casos de Excepción

**E1: Pérdida de datos durante intento**
- **Condición**: Falla la captura de datos por problemas técnicos
- **Acción**: El sistema permite registro manual y marca como "datos parciales"

**E2: Intento ambiguo**
- **Condición**: No está claro si el intento fue exitoso o fallido
- **Acción**: El sistema solicita clarificación al escalador antes de registrar

**E3: Datos inconsistentes**
- **Condición**: Los datos capturados contienen inconsistencias
- **Acción**: El sistema valida con el escalador y permite correcciones

**E4: Problema modificado durante registro**
- **Condición**: El problema cambia mientras se registra progreso
- **Acción**: El sistema asocia progreso con versión original del problema

**E5: Límite de almacenamiento**
- **Condición**: Se alcanza límite de datos de progreso almacenados
- **Acción**: El sistema archiva datos antiguos y continúa con nuevos registros

## Validaciones/Reglas de Negocio

- Todos los intentos deben registrarse, exitosos o fallidos
- El tiempo mínimo de intento es 5 segundos
- Solo se registra progreso en presas válidas del problema
- Las evaluaciones de dificultad deben estar en rango válido
- Se mantiene histórico completo para análisis de tendencias

## Post Condiciones

- El progreso queda permanentemente registrado en la base de datos
- Las estadísticas del escalador se actualizan inmediatamente
- El sistema tiene datos para generar reportes y análisis
- Se mantiene trazabilidad completa del rendimiento del escalador
- Los datos están disponibles para sistemas de recomendación y IA

## Información Adicional

**Prioridad**: Crítica
**Frecuencia de Uso**: Muy Alta (cada intento)
**Complejidad**: Media
**Tiempo de Respuesta**: < 2 segundos para procesamiento post-intento
**Versión**: 1.0
**Fecha**: 2025-07-25
