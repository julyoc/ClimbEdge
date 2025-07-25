# Caso de Uso Expandido: UC-062

| **Campo** | **Descripción** |
|-----------|-----------------|
| **ID** | UC-062 |
| **Descripción** | Iluminar las presas de un problema específico en el tablero físico usando LEDs |
| **Actores** | Usuario, Sistema Cloud, Sistema Embebido |
| **Pre Condiciones** | El hardware debe estar conectado y operativo. Debe existir un problema válido seleccionado. Los LEDs WS2812B deben estar funcionando. |

## Pasos Básicos

1. El usuario selecciona un problema y solicita visualización en tablero físico
2. El sistema cloud valida que el problema corresponda al tablero conectado
3. El sistema cloud prepara datos de iluminación:
   - Extrae posiciones de presas del problema
   - Asigna colores según tipo de presa:
     * Verde brillante: presas de inicio
     * Rojo brillante: presas de finalización
     * Azul: presas de mano
     * Amarillo: presas de pie
     * Violeta: zonas de descanso
4. El sistema cloud envía comando de iluminación vía WebSocket:
   - ID del problema
   - Array de posiciones y colores
   - Modo de iluminación (estático/animado)
   - Intensidad de brillo
5. El sistema embebido recibe y valida el comando
6. El sistema embebido mapea posiciones lógicas a direcciones físicas de LEDs
7. El sistema embebido configura la tira de LEDs WS2812B:
   - Apaga todos los LEDs previamente encendidos
   - Calcula dirección específica de cada LED
   - Prepara datos RGB para cada posición
8. El sistema embebido ejecuta la iluminación:
   - Envía datos a la tira de LEDs WS2812B
   - Verifica que todos los LEDs respondan correctamente
   - Aplica efectos visuales si están configurados
9. Si modo secuencial está activado:
   - Ilumina presas paso a paso según secuencia
   - Pausa entre cada paso para visualización clara
   - Permite control de velocidad de animación
10. El sistema embebido confirma iluminación exitosa al cloud
11. El usuario puede ver el problema iluminado físicamente
12. El sistema mantiene iluminación hasta nuevo comando o timeout

## Casos de Excepción

**E1: LEDs defectuosos**
- **Condición**: Algunos LEDs no responden o muestran colores incorrectos
- **Acción**: El sistema identifica LEDs problemáticos y continúa con los funcionales

**E2: Problema incompatible**
- **Condición**: El problema tiene presas que no existen en hardware actual
- **Acción**: El sistema ilumina presas disponibles y notifica incompatibilidades

**E3: Pérdida de conexión durante iluminación**
- **Condición**: Se pierde WebSocket mientras se ejecuta comando
- **Acción**: El sistema embebido mantiene última iluminación y reintenta conexión

**E4: Sobrecarga de comandos**
- **Condición**: Se reciben múltiples comandos de iluminación muy rápido
- **Acción**: El sistema embebido ejecuta último comando recibido y descarta anteriores

**E5: Falla de alimentación**
- **Condición**: No hay suficiente energía para todos los LEDs
- **Acción**: El sistema reduce brillo automáticamente y alerta sobre el problema

## Validaciones/Reglas de Negocio

- Solo se pueden iluminar presas que existen físicamente en el tablero
- La iluminación debe corresponder exactamente al problema seleccionado
- Los colores deben seguir el estándar establecido del sistema
- La iluminación se apaga automáticamente después de 10 minutos sin actividad
- Solo un problema puede estar iluminado a la vez por tablero

## Post Condiciones

- Las presas del problema están claramente iluminadas en el tablero físico
- El usuario puede identificar visualmente el recorrido del problema
- El sistema está listo para detectar intentos de escalada
- La iluminación permanece activa hasta nuevo comando
- Se registra la actividad de iluminación en logs del sistema

## Información Adicional

**Prioridad**: Alta
**Frecuencia de Uso**: Alta
**Complejidad**: Media
**Tiempo de Respuesta**: < 2 segundos desde comando hasta iluminación
**Versión**: 1.0
**Fecha**: 2025-07-25
