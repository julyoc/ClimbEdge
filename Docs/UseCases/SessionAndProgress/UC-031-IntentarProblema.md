# Caso de Uso Expandido: UC-031

| **Campo** | **Descripción** |
|-----------|-----------------|
| **ID** | UC-031 |
| **Descripción** | Intentar resolver un problema de escalada durante una sesión activa |
| **Actores** | Escalador, Sistema Embebido, Sistema |
| **Pre Condiciones** | Debe existir una sesión activa de escalada. El problema debe estar disponible y validado. El tablero debe estar operativo (para hardware físico). |

## Pasos Básicos

1. El escalador selecciona un problema de la lista disponible durante su sesión
2. El sistema muestra los detalles del problema seleccionado
3. El escalador confirma que desea intentar el problema
4. El sistema registra el inicio del intento en UserSessionProgress
5. Si hay hardware conectado:
   - El sistema envía comando de iluminación al tablero
   - Los LEDs muestran las presas del problema según colores establecidos
   - Se activa el tracking automático de toques
6. El escalador comienza a escalar:
   - Toca las presas según la secuencia del problema
   - El sistema embebido detecta cada toque (si aplica)
   - Se registra timestamp de cada movimiento
7. Durante el intento, el sistema monitorea:
   - Tiempo transcurrido
   - Presas tocadas vs secuencia esperada
   - Violaciones de reglas (toques no permitidos)
8. El escalador puede:
   - Completar el problema exitosamente
   - Caerse o fallar en el intento
   - Abandonar voluntariamente el intento
9. Al finalizar el intento:
   - El sistema registra el resultado (completado/fallido)
   - Se calcula tiempo total utilizado
   - Se registra el progreso alcanzado
10. El sistema pregunta al escalador:
    - Tipo de tick (onsight, flash, redpoint, etc.)
    - Evaluación de dificultad percibida
    - Comentarios sobre el problema
11. El sistema actualiza estadísticas del escalador y del problema
12. El escalador puede iniciar nuevo intento o seleccionar otro problema

## Casos de Excepción

**E1: Hardware desconectado durante intento**
- **Condición**: Se pierde conexión con tablero físico durante escalada
- **Acción**: El sistema permite continuar en modo manual y registra intento sin tracking automático

**E2: Problema modificado durante intento**
- **Condición**: El problema cambia mientras el escalador lo está intentando
- **Acción**: El sistema permite completar con configuración original o abortar intento

**E3: Sesión interrumpida**
- **Condición**: La sesión se cierra inesperadamente durante el intento
- **Acción**: El sistema guarda progreso parcial y permite resumir al reconectar

**E4: Sensor defectuoso**
- **Condición**: Algunos sensores no detectan toques correctamente
- **Acción**: El sistema permite corrección manual y marca sensores problemáticos

**E5: Tiempo excesivo**
- **Condición**: El intento supera tiempo máximo razonable (30 minutos)
- **Acción**: El sistema pregunta si continuar o marcar como intento extendido

## Validaciones/Reglas de Negocio

- Un escalador puede intentar el mismo problema múltiples veces por sesión
- Los intentos deben seguir las reglas específicas del problema
- El tiempo se cuenta desde primera presa hasta finalización o caída
- Solo se permiten toques en presas autorizadas del problema
- Los intentos completados actualizan estadísticas personales inmediatamente

## Post Condiciones

- Se registra el intento en UserSessionProgress con resultado y detalles
- Se actualizan estadísticas del escalador y del problema
- El sistema está listo para siguiente intento o problema
- Se mantiene histórico de todos los intentos para análisis posterior
- Las estadísticas globales del problema se actualizan

## Información Adicional

**Prioridad**: Crítica
**Frecuencia de Uso**: Muy Alta
**Complejidad**: Alta
**Tiempo de Respuesta**: Tiempo real durante escalada
**Versión**: 1.0
**Fecha**: 2025-07-25
