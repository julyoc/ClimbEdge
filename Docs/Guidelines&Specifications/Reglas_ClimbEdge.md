# 📐 Reglas del Board - ClimbEdge

**Fecha:** 2025-07-25

Este documento establece las reglas básicas para el uso del sistema ClimbEdge, adaptado del estándar MoonBoard y Kilter Board, optimizado para entrenamientos personalizados con tableros físicos y sensores FSR.

---

## 🧗 Reglas Generales de Escalada

### Inicio del Problema
- Todos los problemas inician **desde la colchoneta** (sit-start).
- El inicio debe realizarse con ambas manos en las presas marcadas como "start":
  - Si hay **una sola presa de inicio**, ambas manos deben comenzar en ella (posición matched).
  - Si hay **dos presas de inicio**, se inicia con una mano en cada una.

### Finalización del Problema
- Se considera completado el problema cuando el usuario sostiene la presa de llegada (top) durante **al menos 2 segundos en control**.
- Si hay **dos presas top**, ambas manos deben estar en ellas simultáneamente (matched).
- La finalización será detectada por presión simultánea en sensores FSR en las presas "top".

---

## 👣 Reglas de Pies

- Existen diferentes modos de pies configurables por software:
  1. **Feet follow hands**: solo se permite usar las presas activadas para manos.
  2. **Feet follow hands + footholds adicionales**: se permiten también las presas marcadas exclusivamente para pies.
  3. **Only footholds**: solo se permiten presas específicas de pies.
  4. **Footless**: no se permite usar pies (solo manos).
- Los modos de pies son definidos en cada `BoardProblem` y visualizados mediante iluminación LED.

---

## 💡 Reglas de Iluminación

- Las presas activas se iluminan con colores definidos por tipo:
  - 🟢 Inicio
  - 🔵 Presas intermedias
  - 🟣 Finalización (top)
  - 🟡 Presas de pie (si aplica)
- Toda interacción fuera de las presas activas se considera “dab” y anula el intento (puede ser validado por sensores o visión artificial).

---

## ⚙️ Validación del Movimiento

- La validación de intentos se realiza mediante:
  - Lectura de sensores FSR por presión mínima.
  - Duración de contacto sostenido.
  - Presas utilizadas (según ID y función: mano/pie/top/start).
- En futuras versiones puede añadirse visión por cámara como sistema adicional de validación.

---

## 📏 Reglas Técnicas del Tablero

- El ángulo del tablero se encuentra dentro de un rango variable (ej. **10° a 65°**) y debe ser registrado en la configuración del `BoardConfig`.
- Solo se permiten problemas con presas de inicio situadas en **fila 6 o inferior** para mantener consistencia con estándares MoonBoard.
- Cada problema es generado automáticamente o manualmente en base a:
  - Dificultad del tablero (`C`)
  - Ángulo del tablero (`A`)
  - Presas disponibles (`BoardItem`)
  - Texturas, materiales y tipo de uso (mano/pie/start/top)

---

## ✅ Consideraciones Adicionales

- El sistema registra cada intento del usuario (`UserSession`) y calcula progreso con base en éxito, tiempo de resolución y dificultad.
- Las rutas pueden tener distintos modos de puntuación según:
  - Tiempo de resolución
  - Cantidad de intentos
  - Movimiento eficiente (IA futura)

---

## 🧠 Futuras Reglas (IA y personalización)

- Generación dinámica de problemas con IA personalizada.
- Detección de forma y cuerpo mediante cámaras (visión computacional).
- Recomendación de rutas adaptadas al nivel de progreso del usuario.

---

## 🧑‍💻 Creado por
**Julio Castro**  
Proyecto: ClimbEdge  
Raspberry Pi + LED WS2812B + FSR Matrix + WebSocket + QwikCity SSR  
