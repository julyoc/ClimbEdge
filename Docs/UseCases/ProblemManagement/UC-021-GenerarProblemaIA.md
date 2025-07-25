# Caso de Uso Expandido: UC-021

| **Campo** | **Descripción** |
|-----------|-----------------|
| **ID** | UC-021 |
| **Descripción** | Generar un problema de escalada utilizando inteligencia artificial |
| **Actores** | Usuario, Sistema IA, Modelo IA, Sistema |
| **Pre Condiciones** | Debe existir al menos un modelo IA entrenado y activo. El usuario debe tener permisos para generar problemas. El tablero debe estar configurado. Debe haber suficientes datos de entrenamiento disponibles. |

## Pasos Básicos

1. El usuario accede a "Crear Problema" y selecciona "Generar con IA"
2. El sistema muestra la interfaz de configuración de generación IA
3. El usuario configura los parámetros de generación:
   - Tablero objetivo
   - Nivel de dificultad deseado (1-32)
   - Ángulo del tablero
   - Estilo de problema (técnico, potencia, resistencia, equilibrio)
   - Número de presas aproximado
   - Restricciones específicas (zonas prohibidas, presas obligatorias)
4. El usuario puede ajustar parámetros avanzados:
   - Creatividad del modelo (conservador/innovador)
   - Similitud con problemas existentes
   - Longitud de secuencia preferida
5. El usuario envía la solicitud de generación
6. El sistema crea registro en AIGenerationRequest con estado "Pending"
7. El sistema selecciona el modelo IA más apropiado basado en parámetros
8. El sistema prepara datos de entrada:
   - Configuración del tablero
   - Problemas existentes como referencia
   - Restricciones y preferencias
9. El modelo IA procesa la solicitud:
   - Analiza patrones de problemas similares
   - Genera múltiples candidatos
   - Evalúa viabilidad de cada candidato
10. El sistema evalúa candidatos usando modelo matemático de dificultad
11. El sistema selecciona el mejor candidato
12. El sistema crea automáticamente el BoardProblem
13. El sistema actualiza AIGenerationRequest a "Completed"
14. El sistema notifica al usuario del problema generado
15. El usuario puede revisar, ajustar o regenerar si no está satisfecho

## Casos de Excepción

**E1: Parámetros imposibles**
- **Condición**: Los parámetros solicitados no pueden generar un problema válido
- **Acción**: El sistema sugiere ajustes y explica limitaciones

**E2: Modelo IA sobrecargado**
- **Condición**: El modelo está procesando demasiadas solicitudes
- **Acción**: El sistema pone la solicitud en cola y estima tiempo de espera

**E3: Generación fallida**
- **Condición**: El modelo no puede generar ningún candidato válido
- **Acción**: El sistema ofrece relajar restricciones o intentar con parámetros diferentes

**E4: Problema muy similar a existente**
- **Condición**: El problema generado es casi idéntico a uno existente
- **Acción**: El sistema informa la similitud y permite regenerar o aceptar

**E5: Error en evaluación**
- **Condición**: Falla al calcular la dificultad del problema generado
- **Acción**: El sistema asigna dificultad estimada y marca para revisión manual

## Validaciones/Reglas de Negocio

- La dificultad generada debe estar en rango ±2 de la solicitada
- El problema debe tener al menos 3 presas y máximo 30
- Debe ser físicamente escalable según biomecánica básica
- No puede duplicar exactamente problemas existentes
- Tiempo máximo de generación: 45 segundos
- Se limita a 10 generaciones por usuario por día

## Post Condiciones

- Se crea un nuevo BoardProblem generado por IA
- Se registra toda la actividad en AIGenerationRequest y AIModelLog
- El problema está disponible para escalada inmediatamente
- Se almacenan datos para mejorar futuros entrenamientos del modelo
- El usuario puede modificar el problema generado si lo desea
- Se actualiza el rendimiento del modelo con feedback del usuario

## Información Adicional

**Prioridad**: Media
**Frecuencia de Uso**: Media
**Complejidad**: Muy Alta
**Tiempo de Respuesta**: 15-45 segundos
**Versión**: 1.0
**Fecha**: 2025-07-25
