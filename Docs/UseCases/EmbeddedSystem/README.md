# Casos de Uso - Sistema Embebido

Este módulo contiene los casos de uso para el sistema embebido de ClimbEdge, incluyendo control de hardware, sensores y LEDs.

## Visión General

El sistema embebido es el corazón de la interacción física con los tableros de escalada, proporcionando:
- Control completo de hardware embebido (Raspberry Pi, sensores, LEDs)
- Detección automática de toques en presas usando sensores FSR
- Iluminación inteligente de problemas con LEDs WS2812B
- Comunicación bidireccional con el sistema central
- Operación en tiempo real para experiencia fluida

## Casos de Uso Incluidos

### UC-060: Establecer Conexión Hardware
**Actor Principal:** Técnico, Sistema  
**Descripción:** Establecimiento de conexión y comunicación entre el sistema central y hardware embebido.  
**Complejidad:** Alta  
**Prioridad:** Alta  

### UC-061: Detectar Toque en Presa
**Actor Principal:** Sistema Embebido, Sensor FSR  
**Descripción:** Detección automática y precisa de toques en presas individuales usando sensores de fuerza.  
**Complejidad:** Media  
**Prioridad:** Alta  

### UC-062: Iluminar Problema
**Actor Principal:** Sistema Embebido, LEDs WS2812B  
**Descripción:** Iluminación específica de presas para visualizar problemas de escalada con efectos personalizables.  
**Complejidad:** Media  
**Prioridad:** Alta  

## Actores Principales

- **Técnico:** Especialista en configuración e instalación de hardware
- **Sistema Embebido:** Raspberry Pi con software de control
- **Sensor FSR:** Sensores de fuerza resistivos para detección
- **LEDs WS2812B:** Sistema de iluminación RGB direccionable
- **Usuario:** Escalador que interactúa con el hardware
- **Sistema Central:** Servidor que coordina operaciones

## Componentes de Hardware

### Raspberry Pi 4B
- **Función:** Controlador central del sistema embebido
- **Especificaciones:** 4GB RAM, WiFi, Bluetooth, GPIO
- **Sistema Operativo:** Raspberry Pi OS customizado
- **Software:** ClimbEdge Embedded Service
- **Conectividad:** WiFi para comunicación con servidor

### Sensores FSR (Force Sensitive Resistors)
- **Cantidad:** Uno por presa (típicamente 200+ por tablero)
- **Tipo:** Interlink 402 o similar
- **Rango:** 0.2N a 20N de fuerza
- **Ubicación:** Montados detrás de cada presa
- **Conectividad:** Multiplexores analógicos para GPIO

### LEDs WS2812B
- **Cantidad:** Uno o más por presa
- **Tipo:** LEDs RGB direccionables (Neopixel)
- **Control:** Protocolo serie de un solo cable
- **Consumo:** ~60mA por LED a máxima intensidad
- **Efectos:** Color sólido, parpadeo, gradientes, animaciones

### Multiplexores y Circuitería
- **ADC:** Convertidores analógico-digital para sensores
- **Multiplexores:** 74HC4051 para múltiples sensores
- **Drivers:** Drivers de corriente para LEDs
- **Protección:** Circuitos de protección contra sobrecarga
- **Alimentación:** Fuentes de 5V reguladas

## Arquitectura del Sistema

### Comunicación
```
[Sistema Central] <--WiFi--> [Raspberry Pi] <--GPIO--> [Sensores/LEDs]
```

### Protocolos de Comunicación
- **WiFi:** Comunicación principal con servidor
- **WebSocket:** Comunicación en tiempo real
- **SPI/I2C:** Comunicación con periféricos
- **GPIO:** Control directo de sensores y LEDs
- **UART:** Debugging y comunicación serie

### Software Embebido
- **ClimbEdge Service:** Servicio principal de control
- **Sensor Manager:** Gestión de sensores FSR
- **LED Controller:** Control de sistema de iluminación
- **Network Manager:** Gestión de conectividad
- **Update Service:** Sistema de actualizaciones remotas

## Flujos de Trabajo Típicos

### Inicialización del Sistema
1. Boot del Raspberry Pi
2. Cargar ClimbEdge Embedded Service
3. Inicializar hardware (sensores y LEDs)
4. Establecer conexión WiFi
5. Registrarse con el sistema central (UC-060)
6. Sincronizar configuración y calibración
7. Ejecutar test de hardware completo
8. Marcar sistema como "Ready"

### Detección de Toques
1. Lectura continua de sensores FSR (UC-061)
2. Filtrado digital de señales de ruido
3. Aplicación de umbrales de detección
4. Detección de eventos de toque/liberación
5. Timestamping de eventos
6. Envío de eventos al sistema central
7. Mantenimiento de estado de cada presa

### Visualización de Problemas
1. Recepción de comando de iluminación (UC-062)
2. Parsing de configuración de LEDs
3. Configuración de colores por presa
4. Aplicación de efectos (parpadeo, fade)
5. Actualización en tiempo real de estado
6. Sincronización de efectos entre presas
7. Mantenimiento de brillo y colores

## Configuración y Calibración

### Calibración de Sensores
- **Zero Calibration:** Calibración de punto cero sin carga
- **Sensitivity Adjustment:** Ajuste de sensibilidad individual
- **Threshold Setting:** Configuración de umbrales de detección
- **Debounce Timing:** Configuración de tiempo de debounce
- **Temperature Compensation:** Compensación por temperatura

### Configuración de LEDs
- **Color Mapping:** Mapeo de colores por tipo de presa
- **Brightness Control:** Control de brillo general e individual
- **Effect Configuration:** Configuración de efectos visuales
- **Power Management:** Gestión de consumo energético
- **Sync Settings:** Configuración de sincronización

### Configuración de Red
- **WiFi Credentials:** Credenciales de red inalámbrica
- **Server Endpoints:** Endpoints del servidor central
- **Security Settings:** Configuración de seguridad
- **Retry Policies:** Políticas de reconexión
- **Bandwidth Management:** Gestión de ancho de banda

## Protocolos de Comunicación

### Mensajes del Sistema
```json
{
  "type": "sensor_event",
  "timestamp": 1642637400,
  "sensor_id": "hold_12_7",
  "event": "touch_start",
  "force": 850
}
```

### Comandos de LEDs
```json
{
  "type": "led_command",
  "holds": ["hold_12_7", "hold_11_8"],
  "color": "#FF0000",
  "effect": "solid",
  "brightness": 80
}
```

### Estado del Sistema
```json
{
  "type": "system_status",
  "status": "ready",
  "sensors": {
    "total": 198,
    "active": 197,
    "errors": 1
  },
  "leds": {
    "total": 198,
    "active": 198,
    "power_consumption": 2.4
  }
}
```

## Gestión de Errores

### Tipos de Errores
- **Sensor Failures:** Fallas individuales de sensores
- **LED Failures:** Fallas en cadenas de LEDs
- **Communication Errors:** Errores de comunicación
- **Power Issues:** Problemas de alimentación
- **Calibration Drift:** Deriva de calibración

### Estrategias de Recuperación
- **Hot Swapping:** Reemplazo en caliente de componentes
- **Graceful Degradation:** Operación con funcionalidad reducida
- **Automatic Recalibration:** Recalibración automática
- **Error Reporting:** Reporte automático de errores
- **Remote Diagnostics:** Diagnósticos remotos

### Monitoreo
- **Health Checks:** Verificaciones periódicas de salud
- **Performance Metrics:** Métricas de rendimiento
- **Error Logging:** Logging detallado de errores
- **Predictive Maintenance:** Mantenimiento predictivo
- **Alert System:** Sistema de alertas automáticas

## Optimizaciones de Performance

### Sensor Reading
- **Sampling Rate:** Optimización de frecuencia de muestreo
- **Batch Processing:** Procesamiento en lotes
- **Interrupt Handling:** Manejo eficiente de interrupciones
- **DMA Usage:** Uso de DMA para transferencias
- **Multi-threading:** Procesamiento multi-hilo

### LED Control
- **Frame Rate:** Optimización de FPS de LEDs
- **Color Space:** Optimización de espacio de color
- **Power Efficiency:** Eficiencia energética
- **Heat Management:** Gestión térmica
- **Smooth Transitions:** Transiciones suaves

### Communication
- **Message Compression:** Compresión de mensajes
- **Batching:** Agrupación de mensajes
- **Connection Pooling:** Pool de conexiones
- **Buffering:** Buffering inteligente
- **Prioritization:** Priorización de mensajes

## Seguridad y Confiabilidad

### Seguridad de Red
- **Encryption:** Encriptación de comunicaciones
- **Authentication:** Autenticación de dispositivos
- **Firewall:** Configuración de firewall
- **VPN:** Conexión VPN opcional
- **Certificate Management:** Gestión de certificados

### Confiabilidad del Hardware
- **Redundancy:** Redundancia en componentes críticos
- **ESD Protection:** Protección contra descargas
- **Surge Protection:** Protección contra sobretensiones
- **Environmental Protection:** Protección ambiental
- **Quality Components:** Componentes de alta calidad

### Actualizaciones
- **OTA Updates:** Actualizaciones over-the-air
- **Rollback Capability:** Capacidad de rollback
- **Staged Deployment:** Despliegue escalonado
- **Version Control:** Control de versiones
- **Backup/Recovery:** Backup y recuperación

## Métricas y Monitoreo

### Métricas de Hardware
- **Sensor Accuracy:** Precisión de sensores
- **LED Performance:** Rendimiento de LEDs
- **Power Consumption:** Consumo energético
- **Temperature:** Temperatura de componentes
- **Uptime:** Tiempo de funcionamiento

### Métricas de Software
- **Response Time:** Tiempo de respuesta
- **Message Throughput:** Throughput de mensajes
- **Error Rate:** Tasa de errores
- **Memory Usage:** Uso de memoria
- **CPU Utilization:** Utilización de CPU

### Métricas de Usuario
- **Touch Accuracy:** Precisión de detección
- **Visual Quality:** Calidad visual de LEDs
- **System Responsiveness:** Responsividad del sistema
- **User Satisfaction:** Satisfacción del usuario
- **Problem Completion:** Completación de problemas

## Consideraciones de Instalación

### Requisitos Físicos
- **Mounting:** Montaje seguro de componentes
- **Wiring:** Cableado profesional y organizado
- **Ventilation:** Ventilación adecuada
- **Accessibility:** Accesibilidad para mantenimiento
- **Safety:** Cumplimiento de normas de seguridad

### Requisitos Eléctricos
- **Power Supply:** Fuente de alimentación adecuada
- **Grounding:** Conexión a tierra apropiada
- **Circuit Protection:** Protección de circuitos
- **Load Calculation:** Cálculo de cargas eléctricas
- **Emergency Shutdown:** Parada de emergencia

### Requisitos de Red
- **WiFi Coverage:** Cobertura WiFi adecuada
- **Bandwidth:** Ancho de banda suficiente
- **Network Security:** Seguridad de red
- **Backup Connectivity:** Conectividad de respaldo
- **Remote Access:** Acceso remoto para soporte
