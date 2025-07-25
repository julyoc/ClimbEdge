# Caso de Uso Expandido: UC-022

| **Campo** | **Descripción** |
|-----------|-----------------|
| **ID** | UC-022 |
| **Descripción** | Validar que un problema de escalada sea físicamente posible y correctamente configurado |
| **Actores** | Creador de Problemas, Validador Experto, Sistema, Sistema Embebido |
| **Pre Condiciones** | Debe existir un problema creado (manual o IA). El tablero debe estar configurado correctamente. El sistema de validación debe estar operativo. |

## Pasos Básicos

1. El sistema ejecuta validación automática al crear/modificar un problema
2. El sistema verifica la validez estructural:
   - Presencia de al menos una presa de inicio
   - Presencia de al menos una presa de fin
   - Distancias alcanzables entre presas consecutivas
   - Ausencia de saltos imposibles
3. El sistema ejecuta validación biomecánica:
   - Ángulos de alcance dentro de límites humanos
   - Secuencias que no requieren posiciones imposibles
   - Verificación de equilibrio en posiciones clave
4. El sistema calcula y valida la dificultad:
   - Aplica el modelo matemático de dificultad
   - Compara con dificultad asignada manualmente
   - Verifica coherencia con problemas similares
5. Si hay hardware conectado, se ejecuta validación física:
   - Se ilumina el problema en el tablero
   - Se solicita al creador probar físicamente el problema
   - Se registran los toques reales durante la prueba
6. El sistema analiza la prueba física (si aplica):
   - Verifica que la secuencia sea seguible
   - Detecta presas no utilizadas o innecesarias
   - Identifica posibles mejoras o ajustes
7. El sistema genera reporte de validación:
   - Problemas detectados (errores críticos)
   - Advertencias (posibles mejoras)
   - Sugerencias de optimización
8. Si hay errores críticos:
   - El problema se marca como "Requiere Revisión"
   - Se bloquea para uso público hasta corrección
9. Si solo hay advertencias:
   - El problema puede usarse con advertencias
   - Se sugieren mejoras opcionales
10. El sistema registra resultado de validación
11. Se notifica al creador del resultado

## Casos de Excepción

**E1: Problema físicamente imposible**
- **Condición**: Las presas están demasiado alejadas o en posiciones imposibles
- **Acción**: El sistema bloquea el problema y sugiere correcciones específicas

**E2: Dificultad inconsistente**
- **Condición**: La dificultad calculada difiere significativamente de la asignada
- **Acción**: El sistema sugiere ajustar dificultad o modificar el problema

**E3: Hardware no disponible para validación física**
- **Condición**: No hay conexión con el tablero físico
- **Acción**: El sistema continúa con validación teórica solamente

**E4: Problema sin sentido escalístico**
- **Condición**: El problema no sigue patrones lógicos de escalada
- **Acción**: El sistema marca para revisión por experto humano

**E5: Error en cálculo de dificultad**
- **Condición**: Falla el modelo matemático de evaluación
- **Acción**: El sistema solicita evaluación manual y registra el error

## Validaciones/Reglas de Negocio

- Distancia máxima entre presas: 80cm para manos, 100cm para pies
- Ángulo máximo de alcance: 45° desde vertical
- Al menos 3 presas deben ser utilizables en la secuencia
- La dificultad no puede variar más de ±3 niveles del cálculo automático
- Problemas públicos requieren validación completa
- Problemas privados pueden usar validación básica

## Post Condiciones

- El problema tiene un estado de validación definido
- Se genera un reporte detallado de validación
- Los errores críticos están documentados y deben corregirse
- El problema puede marcarse como "Validado" o "Requiere Revisión"
- Se registra toda la actividad de validación en logs
- Los usuarios reciben información sobre la validez del problema

## Información Adicional

**Prioridad**: Alta
**Frecuencia de Uso**: Alta (automática en cada creación)
**Complejidad**: Alta
**Tiempo de Respuesta**: 5-30 segundos (según si incluye prueba física)
**Versión**: 1.0
**Fecha**: 2025-07-25
