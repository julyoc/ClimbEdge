# Caso de Uso Expandido: UC-013

| **Campo** | **Descripción** |
|-----------|-----------------|
| **ID** | UC-013 |
| **Descripción** | Establecer conexión entre el tablero físico y el sistema cloud |
| **Actores** | Propietario de Tablero, Sistema Embebido, Sistema Cloud |
| **Pre Condiciones** | El hardware del tablero debe estar operativo. La Raspberry Pi debe tener conectividad de red. El tablero debe estar registrado en el sistema. Los sensores y LEDs deben estar instalados. |

## Pasos Básicos

1. El propietario accede a la configuración de hardware del tablero
2. El sistema muestra el estado actual de conectividad
3. El propietario selecciona "Conectar Hardware"
4. El sistema genera un código de emparejamiento único
5. El propietario ingresa el código en el sistema embebido (Raspberry Pi)
6. El sistema embebido valida el código con el servidor cloud
7. Se establece la conexión WebSocket segura entre hardware y cloud
8. El sistema embebido envía información de identificación:
   - ID único del dispositivo
   - Versión del firmware
   - Configuración de hardware (sensores, LEDs)
   - Estado de componentes
9. El sistema cloud valida la información del hardware
10. Se realiza la calibración inicial de sensores:
    - El sistema solicita tocar cada presa
    - Se registran valores base de cada sensor FSR
    - Se establecen umbrales de detección
11. Se prueba el sistema de iluminación:
    - El sistema enciende LEDs en secuencia
    - Se verifica funcionamiento de cada LED WS2812B
12. El sistema actualiza el estado del tablero como "Conectado"
13. Se establece el monitoreo continuo de heartbeat
14. El sistema confirma conexión exitosa al propietario

## Casos de Excepción

**E1: Código de emparejamiento inválido**
- **Condición**: El código ingresado no es válido o ha expirado
- **Acción**: El sistema genera un nuevo código y permite reintentar

**E2: Hardware no responde**
- **Condición**: El sistema embebido no establece conexión
- **Acción**: El sistema proporciona guía de troubleshooting y verificación de red

**E3: Sensores defectuosos**
- **Condición**: Algunos sensores FSR no responden durante calibración
- **Acción**: El sistema marca sensores problemáticos y permite continuar con los funcionales

**E4: LEDs no funcionan**
- **Condición**: Parte del sistema de iluminación no responde
- **Acción**: El sistema identifica LEDs defectuosos y ajusta configuración

**E5: Conflicto de hardware**
- **Condición**: El hardware ya está conectado a otro tablero
- **Acción**: El sistema requiere desconexión previa o transferencia de propiedad

## Validaciones/Reglas de Negocio

- Solo un hardware puede estar conectado por tablero
- La calibración debe completarse con al menos 80% de sensores funcionales
- El código de emparejamiento expira en 15 minutos
- Se requiere conectividad estable para mantener la conexión
- El heartbeat debe recibirse cada 30 segundos máximo

## Post Condiciones

- El tablero físico está conectado y operativo
- Los sensores están calibrados y listos para detectar toques
- El sistema de LEDs está funcional para mostrar problemas
- Se establece monitoreo continuo del estado del hardware
- El tablero puede recibir comandos remotos del sistema cloud
- Se registra la conexión en logs del sistema

## Información Adicional

**Prioridad**: Crítica (para tableros físicos)
**Frecuencia de Uso**: Baja (solo durante configuración inicial)
**Complejidad**: Alta
**Tiempo de Respuesta**: 2-5 minutos para calibración completa
**Versión**: 1.0
**Fecha**: 2025-07-25
