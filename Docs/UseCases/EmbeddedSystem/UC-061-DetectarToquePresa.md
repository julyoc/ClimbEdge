# Caso de Uso Expandido: UC-061

| **Campo** | **Descripción** |
|-----------|-----------------|
| **ID** | UC-061 |
| **Descripción** | Detectar cuando un escalador toca una presa del tablero usando sensores FSR |
| **Actores** | Sistema Embebido, Escalador, Sistema Cloud |
| **Pre Condiciones** | El hardware del tablero debe estar operativo y calibrado. Los sensores FSR deben estar funcionando correctamente. Debe existir conexión WebSocket con el sistema cloud. Una sesión de escalada debe estar activa. |

## Pasos Básicos

1. El sistema embebido inicializa el bucle de lectura de sensores
2. El sistema configura los multiplexores (CD74HC4067) para la secuencia de lectura
3. El sistema embebido lee continuamente los valores analógicos de cada sensor FSR:
   - Selecciona el canal del multiplexor correspondiente
   - Lee el valor del ADC (MCP3008)
   - Convierte el valor digital a presión
4. El sistema compara cada lectura con el umbral de detección calibrado
5. Cuando detecta un cambio significativo (toque o liberación):
   - Registra el timestamp exacto del evento
   - Identifica la posición específica de la presa (x, y)
   - Determina el tipo de evento (toque/liberación)
6. El sistema aplica filtros de ruido y debounce:
   - Elimina lecturas espurias
   - Confirma eventos con múltiples muestras
7. El sistema valida que el evento sea parte de un problema activo
8. El sistema empaqueta los datos del evento:
   - ID del tablero
   - Posición de la presa (x, y)
   - Timestamp del evento
   - Tipo de evento
   - Fuerza aplicada (valor del sensor)
9. El sistema transmite el evento vía WebSocket al sistema cloud
10. El sistema cloud confirma la recepción del evento
11. El sistema embebido actualiza su estado interno
12. El proceso continúa en bucle para detectar el siguiente evento

## Casos de Excepción

**E1: Sensor defectuoso**
- **Condición**: Un sensor FSR no responde o da lecturas inconsistentes
- **Acción**: El sistema marca el sensor como defectuoso y notifica al cloud

**E2: Pérdida de conexión**
- **Condición**: Se pierde la conexión WebSocket con el cloud
- **Acción**: El sistema almacena eventos localmente hasta reestablecer conexión

**E3: Sobrecarga de eventos**
- **Condición**: Se generan demasiados eventos muy rápidamente
- **Acción**: El sistema aplica throttling y agrupa eventos similares

**E4: Lectura inválida del ADC**
- **Condición**: El ADC MCP3008 retorna valores fuera de rango
- **Acción**: El sistema reintenta la lectura y reporta si persiste el error

**E5: Problema no activo**
- **Condición**: Se detecta toque pero no hay problema seleccionado
- **Acción**: El sistema registra como evento de calibración o práctica libre

## Validaciones/Reglas de Negocio

- La frecuencia de muestreo debe ser al menos 100Hz por sensor
- El umbral de detección debe ser configurable entre 100-1000 gramos
- Los eventos duplicados en un intervalo de 50ms se consideran rebote
- Solo se procesan toques en presas configuradas en el tablero
- Los eventos se envían en tiempo real con latencia máxima de 10ms
- Se mantiene un buffer local de 1000 eventos en caso de desconexión

## Post Condiciones

- El evento de toque es registrado con timestamp preciso
- Los datos son transmitidos al sistema cloud para procesamiento
- El estado del sensor se actualiza en la memoria del sistema embebido
- Se mantiene la continuidad del tracking durante la sesión
- Los eventos se almacenan localmente como respaldo
- El sistema está listo para detectar el siguiente evento

## Información Adicional

**Prioridad**: Crítica
**Frecuencia de Uso**: Muy Alta (continua durante sesiones)
**Complejidad**: Alta
**Tiempo de Respuesta**: < 10ms
**Versión**: 1.0
**Fecha**: 2025-07-25
