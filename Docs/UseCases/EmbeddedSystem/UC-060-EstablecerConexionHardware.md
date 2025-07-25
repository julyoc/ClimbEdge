# Caso de Uso Expandido: UC-060

| **Campo** | **Descripción** |
|-----------|-----------------|
| **ID** | UC-060 |
| **Descripción** | Establecer y mantener conexión WebSocket entre hardware embebido y sistema cloud |
| **Actores** | Sistema Embebido, Sistema Cloud, Administrador Hardware |
| **Pre Condiciones** | La Raspberry Pi debe estar operativa y conectada a red. El sistema cloud debe estar disponible. Los certificados de seguridad deben estar válidos. |

## Pasos Básicos

1. El sistema embebido se inicia y ejecuta proceso de conexión
2. El sistema embebido verifica conectividad de red local
3. El sistema embebido resuelve dirección del servidor cloud
4. El sistema embebido intenta establecer conexión WebSocket segura
5. El sistema embebido envía credenciales de autenticación:
   - ID único del dispositivo
   - Token de autenticación
   - Versión de firmware
   - Información de hardware
6. El sistema cloud valida las credenciales del dispositivo
7. El sistema cloud verifica que el dispositivo esté autorizado
8. Se establece el canal WebSocket bidireccional
9. El sistema embebido envía estado inicial:
   - Estado de sensores FSR
   - Estado de LEDs WS2812B
   - Configuración actual
   - Logs de errores recientes
10. El sistema cloud registra dispositivo como conectado
11. Se establece mecanismo de heartbeat:
    - El embebido envía ping cada 30 segundos
    - El cloud responde con pong
    - Se detecta desconexión si no hay respuesta
12. El sistema embebido queda listo para recibir comandos
13. Se inicia monitoreo continuo de la conexión

## Casos de Excepción

**E1: Falla de conectividad de red**
- **Condición**: No hay acceso a internet desde la Raspberry Pi
- **Acción**: El sistema reintenta cada 60 segundos y registra intentos

**E2: Credenciales inválidas**
- **Condición**: El token de autenticación no es válido o expiró
- **Acción**: El sistema solicita renovación de credenciales al administrador

**E3: Servidor cloud no disponible**
- **Condición**: El servicio cloud está caído o en mantenimiento
- **Acción**: El sistema entra en modo offline y reintenta conexión periódicamente

**E4: Certificados SSL expirados**
- **Condición**: Los certificados de seguridad no son válidos
- **Acción**: El sistema alerta al administrador y bloquea conexión hasta actualización

**E5: Hardware no autorizado**
- **Condición**: El dispositivo no está registrado en el sistema cloud
- **Acción**: El sistema proporciona instrucciones de registro y bloquea acceso

## Validaciones/Reglas de Negocio

- Solo dispositivos autenticados pueden establecer conexión
- La conexión debe usar encriptación TLS 1.3 o superior
- El heartbeat no debe exceder 45 segundos sin respuesta
- Se permite máximo 3 intentos de reconexión por minuto
- Los logs de conexión se mantienen por 30 días mínimo

## Post Condiciones

- Se establece canal de comunicación bidireccional seguro
- El hardware puede recibir comandos del sistema cloud
- El sistema cloud puede monitorear estado del hardware
- Se activa tracking automático de eventos de escalada
- El dispositivo queda listo para operación de tablero

## Información Adicional

**Prioridad**: Crítica
**Frecuencia de Uso**: Continua (24/7)
**Complejidad**: Alta
**Tiempo de Respuesta**: < 10 segundos para establecer conexión
**Versión**: 1.0
**Fecha**: 2025-07-25
