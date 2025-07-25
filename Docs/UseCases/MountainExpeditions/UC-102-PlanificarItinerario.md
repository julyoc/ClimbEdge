# Caso de Uso Expandido: UC-102

| **Campo** | **Descripción** |
|-----------|-----------------|
| **ID** | UC-102 |
| **Descripción** | Planificar itinerario detallado de expedición |
| **Actores** | Guía de Montaña, Organizador de Expediciones, Sistema |
| **Pre Condiciones** | Debe existir una expedición creada. El usuario debe tener rol de organizador o guía en la expedición. La montaña y ruta deben estar definidas. |

## Pasos Básicos

1. El organizador accede al panel de gestión de la expedición
2. El sistema muestra el resumen de la expedición y las opciones de gestión
3. El organizador selecciona "Planificar Itinerario"
4. El sistema muestra el planificador de itinerario con:
   - Timeline de días de expedición
   - Biblioteca de actividades predefinidas
   - Mapa interactivo de la ruta
   - Panel de configuración diaria
5. El organizador selecciona el primer día de la expedición
6. El sistema muestra el formulario de planificación diaria:
   - Tipo de actividad principal
   - Ubicación de inicio y fin
   - Elevaciones de inicio y fin
   - Distancia estimada
   - Duración estimada
   - Nivel de dificultad
   - Dependencia del clima
7. El organizador define las actividades del día:
   - Hora de inicio
   - Actividades secuenciales
   - Puntos de control (waypoints)
   - Paradas para descanso
   - Ubicación de pernocte
8. El sistema calcula automáticamente:
   - Tiempo total estimado
   - Ganancia/pérdida de elevación
   - Distancia total
   - Consumo calórico estimado
9. El organizador añade información logística:
   - Alojamiento requerido
   - Transporte necesario
   - Comidas planificadas
   - Equipamiento específico del día
10. El organizador configura planes alternativos:
    - Plan B por mal clima
    - Plan de emergencia
    - Puntos de evacuación
11. El sistema valida la coherencia del itinerario:
    - Tiempos realistas
    - Progresión lógica de ubicaciones
    - Disponibilidad de alojamiento
12. El organizador repite el proceso para cada día de la expedición
13. El sistema genera un presupuesto automático basado en el itinerario
14. El organizador revisa el itinerario completo
15. El sistema permite ajustes y optimizaciones
16. El organizador confirma y guarda el itinerario
17. El sistema genera documentos de planificación
18. El sistema actualiza el estado de la expedición a "Programada"

## Casos de Excepción

**E1: Itinerario incoherente**
- **Condición**: Los tiempos, distancias o ubicaciones no son lógicamente consistentes
- **Acción**: El sistema muestra advertencias específicas y sugiere correcciones

**E2: Recursos no disponibles**
- **Condición**: El alojamiento o transporte planificado no está disponible en las fechas seleccionadas
- **Acción**: El sistema sugiere alternativas y permite replanificación

**E3: Sobreestimación de capacidades**
- **Condición**: El itinerario excede las capacidades típicas del grupo objetivo
- **Acción**: El sistema muestra alertas de riesgo y recomienda ajustes

**E4: Restricciones temporales**
- **Condición**: Algunas rutas o ubicaciones tienen restricciones estacionales
- **Acción**: El sistema informa sobre las restricciones y bloquea fechas no válidas

**E5: Presupuesto excedido**
- **Condición**: Los costos del itinerario superan el presupuesto definido
- **Acción**: El sistema resalta los elementos más costosos y sugiere alternativas económicas

## Validaciones/Reglas de Negocio

- **R1**: Cada día debe tener al menos una actividad principal definida
- **R2**: Los puntos de inicio y fin de días consecutivos deben ser coherentes geográficamente
- **R3**: La duración diaria no debe exceder 16 horas de actividad
- **R4**: Debe haber al menos 8 horas de descanso entre días de alta intensidad
- **R5**: Los puntos de evacuación deben estar máximo a 6 horas de marcha
- **R6**: El itinerario debe incluir al menos 1 día de contingencia para expediciones >7 días
- **R7**: Cada día debe especificar el equipamiento de seguridad requerido
- **R8**: Las comidas deben proporcionar al menos 3000 kcal/día por participante
- **R9**: Debe existir un plan de comunicación para cada día
- **R10**: Los waypoints críticos deben tener coordenadas GPS precisas

## Post Condiciones

- El itinerario detallado queda guardado y asociado a la expedición
- Se genera automáticamente una lista de equipamiento consolidada
- Se crea un presupuesto detallado basado en las actividades planificadas
- Se establecen los puntos de control y waypoints en el sistema GPS
- Se generan documentos imprimibles del itinerario
- Los participantes pueden acceder a una vista del itinerario (según permisos)
- Se activan alertas automáticas basadas en condiciones meteorológicas

## Notas Técnicas

- El sistema debe integrar con APIs meteorológicas para alertas climáticas
- Los cálculos de tiempo deben considerar el nivel de experiencia del grupo
- Se debe mantener historial de versiones del itinerario
- La información GPS debe ser compatible con dispositivos estándar
- El sistema debe permitir importar/exportar itinerarios en formatos estándar (GPX, KML)

## Criterios de Aceptación

1. ✅ El planificador debe cargar el mapa interactivo en menos de 5 segundos
2. ✅ Los cálculos automáticos deben actualizarse en tiempo real
3. ✅ El sistema debe soportar itinerarios de hasta 60 días
4. ✅ Debe permitir copiar días similares para agilizar la planificación
5. ✅ Los documentos generados deben incluir mapas y elevaciones
6. ✅ El sistema debe validar automáticamente la factibilidad del itinerario
7. ✅ Debe permitir colaboración entre múltiples organizadores
8. ✅ Los cambios deben notificarse automáticamente a los participantes confirmados
