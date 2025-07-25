# Casos de Uso - Gestión de Tableros

Este módulo contiene los casos de uso para la gestión completa de tableros de escalada en ClimbEdge, incluyendo configuración, hardware, miembros y administración.

## Visión General

El sistema de gestión de tableros es el núcleo del ClimbEdge, proporcionando:
- Creación y configuración de tableros de escalada personalizados
- Integración completa con hardware embebido (sensores y LEDs)
- Gestión de miembros y permisos de acceso
- Configuración detallada de presas y elementos del tablero
- Administración de múltiples tipos de tableros (MoonBoard, Kilter, custom)

## Casos de Uso Incluidos

### UC-010: Crear Tablero
**Actor Principal:** Propietario de Tablero  
**Descripción:** Permite crear un nuevo tablero definiendo configuración básica y características físicas.  
**Complejidad:** Alta  
**Prioridad:** Alta  

### UC-011: Configurar Tablero
**Actor Principal:** Propietario de Tablero  
**Descripción:** Configuración detallada del tablero incluyendo presas, ángulos y propiedades físicas.  
**Complejidad:** Alta  
**Prioridad:** Alta  

### UC-012: Gestionar Miembros
**Actor Principal:** Propietario de Tablero, Administrador  
**Descripción:** Administración de usuarios con acceso al tablero y sus roles/permisos.  
**Complejidad:** Media  
**Prioridad:** Alta  

### UC-013: Conectar Hardware
**Actor Principal:** Propietario de Tablero, Técnico  
**Descripción:** Configuración e integración del hardware embebido (Raspberry Pi, sensores, LEDs).  
**Complejidad:** Alta  
**Prioridad:** Media  

## Actores Principales

- **Propietario de Tablero:** Usuario que posee y administra el tablero
- **Administrador:** Usuario con permisos administrativos del tablero
- **Miembro:** Usuario con acceso al tablero para escalar
- **Técnico:** Especialista en configuración de hardware
- **Sistema Embebido:** Hardware conectado (Raspberry Pi, sensores, LEDs)

## Entidades Principales

- **Board:** Tablero principal con configuración y propiedades
- **BoardConfig:** Configuración detallada del tablero (dimensiones, presas)
- **BoardMember:** Miembros del tablero con roles específicos
- **BoardItem:** Presas individuales del tablero
- **BoardAngle:** Ángulos de inclinación disponibles
- **BoardItemType:** Tipos de presas (cantos, regletas, etc.)

## Tipos de Tableros Soportados

### MoonBoard
- **Características:** Tablero estándar con configuración oficial
- **Dimensiones:** 12x12 presas, ángulos específicos
- **Hardware:** LEDs integrados, sensores opcionales
- **Problemas:** Base de datos oficial de problemas

### Kilter Board
- **Características:** Tablero con presas Kilter oficiales
- **Dimensiones:** Variables según modelo
- **Hardware:** Sistema de LEDs integrado
- **Problemas:** Sincronización con app oficial

### Tableros Personalizados
- **Características:** Configuración completamente personalizable
- **Dimensiones:** Definidas por el usuario
- **Hardware:** Configuración modular
- **Problemas:** Creación libre de problemas

### Spray Wall
- **Características:** Muro de escalada sin estructura fija
- **Dimensiones:** Variables y dinámicas
- **Hardware:** Sensores móviles opcionales
- **Problemas:** Marcado con cinta o chalk

## Configuración de Hardware

### Raspberry Pi
- **Función:** Controlador central del sistema
- **Conexiones:** WiFi, GPIO pins, sensores I2C/SPI
- **Software:** ClimbEdge embedded OS
- **Monitoring:** Estado y diagnostics en tiempo real

### Sensores FSR (Force Sensitive Resistors)
- **Función:** Detección de toques en presas
- **Ubicación:** Detrás de cada presa del tablero
- **Precisión:** Detección de presión calibrable
- **Conectividad:** Multiplexores para múltiples sensores

### LEDs WS2812B
- **Función:** Iluminación de presas para problemas
- **Configuración:** LED por presa o grupos de presas
- **Colores:** RGB completo programable
- **Efectos:** Parpadeo, fade, animaciones

### Sistema de Alimentación
- **Voltaje:** 5V DC para LEDs y sensores
- **Consumo:** Calculado según número de componentes
- **Backup:** UPS opcional para continuidad
- **Seguridad:** Protecciones de sobrecarga

## Roles y Permisos

### Propietario (Owner)
- **Permisos Completos:** Todas las funciones del tablero
- **Configuración:** Modificar cualquier aspecto del tablero
- **Miembros:** Gestionar todos los roles y permisos
- **Hardware:** Configurar y calibrar hardware
- **Problemas:** Crear, modificar y eliminar cualquier problema

### Administrador (Admin)
- **Gestión de Miembros:** Invitar y gestionar miembros
- **Configuración Limitada:** Algunos aspectos de configuración
- **Problemas:** Moderar y aprobar problemas
- **Sesiones:** Gestionar sesiones de escalada
- **Estadísticas:** Acceso completo a métricas

### Miembro (Member)
- **Escalada:** Acceso completo a funciones de escalada
- **Problemas:** Crear y intentar problemas
- **Estadísticas:** Ver estadísticas propias y del grupo
- **Configuración Personal:** Ajustes de sesión personal

### Viewer
- **Solo Lectura:** Ver problemas y estadísticas
- **Sin Escalada:** No puede usar hardware ni crear problemas
- **Estadísticas Limitadas:** Solo estadísticas públicas
- **Demo:** Perfecto para demostraciones y visitantes

## Flujos de Trabajo Típicos

### Configuración Inicial
1. Crear tablero básico (UC-010)
2. Configurar dimensiones y presas (UC-011)
3. Conectar y calibrar hardware (UC-013)
4. Invitar miembros iniciales (UC-012)
5. Crear problemas de prueba
6. Validar funcionamiento completo

### Gestión Diaria
1. Monitorear estado del hardware
2. Gestionar sesiones de escalada
3. Aprobar nuevos problemas
4. Resolver issues técnicos
5. Actualizar configuraciones según feedback

### Mantenimiento
1. Calibrar sensores periódicamente
2. Limpiar y mantener presas
3. Actualizar software embebido
4. Backup de configuraciones
5. Optimizar performance del sistema

## Configuraciones Avanzadas

### Calibración de Sensores
- **Sensitivity:** Ajuste de sensibilidad por presa
- **Debounce:** Tiempo de estabilización de señal
- **Threshold:** Umbrales de detección de toque
- **Compensation:** Compensación por desgaste y temperatura

### Configuración de LEDs
- **Brightness:** Intensidad lumínica por color
- **Color Mapping:** Asignación de colores por tipo de presa
- **Animations:** Efectos visuales personalizados
- **Power Management:** Optimización de consumo energético

### Networking
- **WiFi Configuration:** Configuración de red inalámbrica
- **Port Forwarding:** Acceso remoto al sistema
- **Security:** Configuración de seguridad de red
- **Cloud Sync:** Sincronización con servicios en la nube

## Métricas y Monitoreo

### Hardware
- **Uptime:** Tiempo de funcionamiento sin interrupciones
- **Sensor Status:** Estado individual de cada sensor
- **LED Performance:** Funcionamiento de sistema de iluminación
- **Power Consumption:** Consumo energético en tiempo real

### Uso
- **Session Frequency:** Frecuencia de uso del tablero
- **Member Activity:** Actividad individual de miembros
- **Problem Popularity:** Problemas más intentados
- **Hardware Utilization:** Uso efectivo del hardware

### Performance
- **Response Time:** Tiempo de respuesta del sistema
- **Data Sync:** Velocidad de sincronización de datos
- **Error Rate:** Frecuencia de errores del sistema
- **User Experience:** Métricas de satisfacción del usuario

## Consideraciones Técnicas

### Confiabilidad
- **Redundancy:** Sistemas de backup para componentes críticos
- **Error Recovery:** Recuperación automática de errores
- **Diagnostics:** Sistema de diagnósticos completo
- **Maintenance Alerts:** Alertas proactivas de mantenimiento

### Escalabilidad
- **Modular Design:** Diseño modular para expansión
- **Hot Swapping:** Cambio de componentes sin parar el sistema
- **Multi-Board:** Gestión de múltiples tableros desde una instancia
- **Cloud Integration:** Integración con servicios en la nube

### Seguridad
- **Network Security:** Seguridad de comunicaciones de red
- **Access Control:** Control de acceso físico y digital
- **Data Protection:** Protección de datos de usuarios
- **Update Security:** Actualizaciones seguras de software
