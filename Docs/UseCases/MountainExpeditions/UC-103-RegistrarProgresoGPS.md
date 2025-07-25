# Caso de Uso Expandido: UC-103

| **Campo** | **Descripción** |
|-----------|-----------------|
| **ID** | UC-103 |
| **Descripción** | Registrar progreso diario durante expedición con tracking GPS |
| **Actores** | Montañista, Guía de Montaña, Participante, Sistema GPS, Sistema |
| **Pre Condiciones** | La expedición debe estar en estado "En Progreso". El usuario debe estar registrado como participante. Debe tener un dispositivo GPS configurado. El día de itinerario debe estar activo. |

## Pasos Básicos

1. El participante inicia sesión en la app móvil al comenzar el día
2. El sistema muestra el itinerario del día actual con:
   - Actividades planificadas
   - Waypoints de referencia
   - Condiciones meteorológicas actualizadas
   - Estado del grupo
3. El participante activa el tracking GPS para el día
4. El sistema comienza a registrar la ubicación cada 30 segundos
5. El sistema muestra la ruta planificada vs ruta real en tiempo real
6. Durante el recorrido, el participante registra waypoints importantes:
   - Inicio de actividad
   - Paradas para descanso
   - Comidas
   - Puntos de interés
   - Problemas o incidentes
   - Llegada a destino
7. En cada waypoint, el participante puede añadir:
   - Foto del lugar
   - Notas de texto
   - Condiciones del terreno
   - Condiciones meteorológicas
   - Estado físico del grupo
   - Tiempo de permanencia
8. El sistema registra automáticamente:
   - Coordenadas GPS precisas
   - Elevación actual
   - Timestamp
   - Velocidad de movimiento
   - Distancia recorrida
   - Tiempo en movimiento vs tiempo total
9. El sistema calcula métricas en tiempo real:
   - Distancia total recorrida
   - Ganancia/pérdida de elevación
   - Velocidad promedio
   - Tiempo estimado de llegada
   - Desviación de la ruta planificada
10. Al finalizar el día, el participante:
    - Detiene el tracking GPS
    - Completa el resumen del día
    - Califica la dificultad real vs planificada
    - Añade observaciones generales
    - Reporta el estado del equipamiento
11. El sistema procesa y valida el track del día:
    - Elimina puntos GPS erróneos
    - Suaviza la ruta para mayor precisión
    - Calcula estadísticas finales
    - Verifica la coherencia con waypoints
12. El sistema sincroniza la información:
    - Sube el track a la base de datos
    - Actualiza el progreso de la expedición
    - Notifica al organizador/guía
    - Comparte información con el resto del grupo (según configuración)
13. El sistema actualiza automáticamente:
    - El itinerario de días futuros si es necesario
    - Las estimaciones de tiempo y dificultad
    - El presupuesto si hay cambios significativos
    - Los planes de contingencia

## Casos de Excepción

**E1: Pérdida de señal GPS**
- **Condición**: El dispositivo pierde señal GPS por períodos prolongados
- **Acción**: El sistema mantiene registros de tiempo y permite añadir waypoints manuales con coordenadas aproximadas

**E2: Desviación significativa de ruta**
- **Condición**: El track real se desvía más de 500m de la ruta planificada
- **Acción**: El sistema envía alerta al guía y solicita confirmación de la nueva ruta

**E3: Emergencia médica**
- **Condición**: Se registra un waypoint de emergencia
- **Acción**: El sistema activa protocolo de emergencia, envía coordenadas exactas a servicios de rescate y notifica a contactos de emergencia

**E4: Condiciones meteorológicas adversas**
- **Condición**: Se reportan condiciones peligrosas
- **Acción**: El sistema sugiere activar planes de contingencia y notifica a toda la expedición

**E5: Fallo del dispositivo GPS**
- **Condición**: El dispositivo GPS presenta fallos técnicos
- **Acción**: El sistema permite registro manual de waypoints y switching a dispositivo de respaldo

**E6: Datos inconsistentes**
- **Condición**: Los datos GPS muestran inconsistencias (teleportación, velocidades imposibles)
- **Acción**: El sistema filtra automáticamente datos anómalos y solicita verificación manual

## Validaciones/Reglas de Negocio

- **R1**: El tracking debe activarse dentro de 1 hora del inicio planificado del día
- **R2**: Debe registrarse al menos un waypoint cada 4 horas durante actividades activas
- **R3**: Los waypoints de emergencia requieren confirmación doble
- **R4**: El tracking debe mantenerse activo durante todas las actividades de riesgo
- **R5**: La precisión GPS debe ser inferior a 10 metros para waypoints críticos
- **R6**: Los datos deben sincronizarse cada vez que hay conexión disponible
- **R7**: El track diario no puede exceder 24 horas continuas
- **R8**: Cada día debe tener waypoints de inicio y fin obligatorios
- **R9**: Las fotos deben incluir metadatos de ubicación
- **R10**: Los reportes de emergencia deben incluir coordenadas exactas y descripción detallada

## Post Condiciones

- El track GPS del día queda almacenado con todas las métricas calculadas
- Los waypoints registrados están disponibles para futuros usuarios de la ruta
- El progreso de la expedición se actualiza automáticamente
- Las estadísticas del participante se actualizan
- Se genera un resumen diario para el guía/organizador
- Los datos contribuyen a la base de conocimiento de la ruta
- Se actualizan las estimaciones para días futuros del itinerario

## Notas Técnicas

- El sistema debe funcionar en modo offline con sincronización posterior
- Los datos GPS deben almacenarse en formato estándar (GPX/KML)
- El tracking debe optimizar el consumo de batería
- Se debe mantener backup local de todos los datos críticos
- La compresión de datos debe mantener la precisión requerida
- El sistema debe soportar múltiples participantes registrando simultáneamente

## Criterios de Aceptación

1. ✅ La app debe funcionar completamente offline por al menos 48 horas
2. ✅ El tracking GPS debe tener precisión inferior a 5 metros en condiciones normales
3. ✅ La batería debe durar al menos 12 horas con tracking activo
4. ✅ Los waypoints deben guardarse localmente inmediatamente
5. ✅ La sincronización debe completarse en menos de 2 minutos con buena conexión
6. ✅ El sistema debe detectar automáticamente waypoints de inicio/fin de actividades
7. ✅ Las alertas de emergencia deben enviarse en menos de 30 segundos
8. ✅ Los datos deben exportarse en formatos estándar para análisis posterior
