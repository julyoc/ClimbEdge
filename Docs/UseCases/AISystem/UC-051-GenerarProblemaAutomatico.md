# Caso de Uso Expandido: UC-051

| **Campo** | **Descripción** |
|-----------|-----------------|
| **ID** | UC-051 |
| **Descripción** | Generar automáticamente un problema de escalada utilizando inteligencia artificial |
| **Actores** | Usuario, Sistema IA, Modelo IA, Sistema |
| **Pre Condiciones** | Debe existir al menos un modelo IA entrenado y activo. El usuario debe tener permisos para generar problemas. El tablero debe estar configurado con presas disponibles. Debe existir suficiente data de entrenamiento. |

## Pasos Básicos

1. El usuario accede a la función "Generar Problema con IA"
2. El sistema muestra la interfaz de configuración de generación
3. El usuario especifica los parámetros de generación:
   - Tablero objetivo
   - Nivel de dificultad deseado (1-32)
   - Ángulo del tablero
   - Estilo de escalada (técnico, potencia, resistencia, etc.)
   - Restricciones específicas (presas prohibidas, zonas preferidas)
4. El usuario selecciona el modelo IA a utilizar (si hay múltiples disponibles)
5. El usuario envía la solicitud de generación
6. El sistema crea un registro en AIGenerationRequest con estado "Pending"
7. El sistema valida los parámetros de entrada
8. El sistema selecciona el modelo IA apropiado si no fue especificado
9. El sistema prepara los datos de entrada para el modelo:
   - Configuración del tablero (dimensiones, presas disponibles)
   - Parámetros de dificultad y estilo
   - Restricciones y preferencias
10. El sistema invoca el modelo IA con los parámetros preparados
11. El modelo IA procesa la solicitud y genera múltiples candidatos de problemas
12. El sistema evalúa cada candidato usando el modelo matemático de dificultad
13. El sistema selecciona el mejor candidato basado en los criterios especificados
14. El sistema crea automáticamente el BoardProblem con los datos generados
15. El sistema actualiza AIGenerationRequest con estado "Completed"
16. El sistema notifica al usuario que el problema ha sido generado
17. El usuario puede revisar y ajustar el problema generado si es necesario

## Casos de Excepción

**E1: Modelo IA no disponible**
- **Condición**: El modelo seleccionado está inactivo o en mantenimiento
- **Acción**: El sistema sugiere modelos alternativos o programa la generación para más tarde

**E2: Parámetros incompatibles**
- **Condición**: Los parámetros especificados son imposibles de cumplir
- **Acción**: El sistema sugiere ajustes a los parámetros y permite modificar la solicitud

**E3: Generación fallida**
- **Condición**: El modelo IA no puede generar un problema válido
- **Acción**: El sistema reintenta con parámetros relajados o sugiere creación manual

**E4: Problema duplicado**
- **Condición**: El problema generado es muy similar a uno existente
- **Acción**: El sistema regenera o sugiere variaciones del problema existente

**E5: Timeout de generación**
- **Condición**: El proceso de generación excede el tiempo límite
- **Acción**: El sistema cancela la operación y sugiere parámetros menos complejos

## Validaciones/Reglas de Negocio

- La dificultad generada debe estar dentro de ±1 nivel de la solicitada
- El problema debe ser físicamente posible según las reglas de escalada
- Debe haber al menos 3 presas de mano y 2 de pie
- Las presas de inicio y fin deben ser claramente diferenciadas
- El tiempo máximo de generación es 30 segundos
- Se debe registrar toda la actividad del modelo para auditoría

## Post Condiciones

- Se crea un nuevo BoardProblem generado automáticamente
- Se registra la actividad en AIGenerationRequest y AIModelLog
- El problema está disponible para ser intentado inmediatamente
- Se almacenan los datos de generación para mejorar futuros modelos
- El usuario recibe notificación del problema generado
- El problema puede ser editado manualmente si es necesario

## Información Adicional

**Prioridad**: Media
**Frecuencia de Uso**: Media
**Complejidad**: Muy Alta
**Tiempo de Respuesta**: < 30 segundos
**Versión**: 1.0
**Fecha**: 2025-07-25
