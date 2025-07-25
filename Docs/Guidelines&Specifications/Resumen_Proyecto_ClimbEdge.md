# ClimbEdge - Resumen del Proyecto

**Fecha:** 2025-07-25

## Visión General

**ClimbEdge** es un sistema integral para entrenamiento, evaluación y planificación en escalada, centrado especialmente en MoonBoards personalizados. El proyecto une hardware, software y datos en una sola plataforma, brindando una experiencia inmersiva y adaptable al nivel del usuario.

---

## Componentes Principales

### 1. **Hardware**
- **MoonBoard** casero con hasta 216 presas.
- **Sensores FSR caseros** conectados a través de multiplexores (CD74HC4067) y un ADC (MCP3008) a una **Raspberry Pi Zero 2 W**.
- **Luces LED WS2812B** direccionables para indicar rutas o presas activas.
- Sistema de **alimentación de 5V** para sensores y LEDs, con convertidores de nivel lógico.

---

### 2. **Cliente Embebido**
- Sistema operativo **Alpine Linux** minimalista optimizado para bajo consumo.
- Programa en **Rust** para lectura eficiente de sensores y envío de datos vía **WebSocket**.
- Cliente actúa como nodo tonto, recibiendo órdenes desde el servidor.

---

### 3. **Servidor Cloud**
- Servidor centralizado en la nube (ej. DigitalOcean).
- Exposición de APIs REST y WebSocket.
- Generación dinámica de problemas de escalada (`BoardProblem`) en base a:
  - Dificultad del tablero (`BoardConfig`)
  - Ángulo (`BoardAngle`)
  - Tipos de presas (`BoardItem`)
  - Pesos ponderados (modelo matemático definido)

---

### 4. **Modelo de Datos**
Estructura relacional con entidades como:
- `Board`, `BoardConfig`, `BoardItem`, `BoardProblem`, `UserSession`, `UserSessionProgress`, etc.
- Dificultades normalizadas en escala **1 a 32**
- Sistema de tracking y progreso por usuario

---

### 5. **Interfaz Web**
- Construido en **QwikCity** por su SSR ultra-rápido.
- Integración con backend mediante cookies HttpOnly seguras.
- Funcionalidades:
  - Visualización de rutas
  - Control remoto del board
  - Visualización de progreso
  - Notificaciones en tiempo real (SignalR/WebSocket)

---

### 6. **Modelo Matemático de Dificultad**
Dificultad de un problema `D` calculada en función de:
- Dificultad del tablero `C`
- Ángulo del tablero `A`
- Presas utilizadas `d_i`
- Tipos de uso (mano, pie, etc.)
- Fórmulas con pesos y normalización

---

### 7. **Objetivos del Proyecto**
- Digitalizar y personalizar entrenamientos de escalada.
- Permitir análisis y progresión a lo largo del tiempo.
- Facilitar el control remoto de tableros desde cualquier parte.
- Implementar IA en el futuro para generación automática de rutas adaptadas.

---

## Estado Actual
- [x] Modelo de datos completo
- [x] Conexión y esquema de sensores FSR
- [x] Sistema de iluminación con WS2812B
- [x] Cliente embebido conectado por WebSocket
- [ ] Interfaz Web avanzada
- [ ] Panel de administración y estadísticas
- [ ] Generador inteligente de rutas (IA futura)

---

## Tecnologías Clave
- **Rust**, **Python**, **QwikCity**, **.NET**
- **PostgreSQL + PostGIS**
- **Alpine Linux**, **Raspberry Pi**
- **SignalR**, **WebSocket**
- **Supabase**, **DigitalOcean**

---

## Autor
**Julio Castro**  
Ingeniero de Software & Montañista  
Ambato, Ecuador  
