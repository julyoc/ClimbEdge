# Caso de Uso Expandido: UC-301

| **Campo** | **Descripción** |
|-----------|-----------------|
| **ID** | UC-301 |
| **Descripción** | Configurar preferencias de notificaciones del usuario |
| **Actores** | Usuario, Sistema |
| **Pre Condiciones** | El usuario debe estar autenticado. El sistema de notificaciones debe estar operativo. |

## Pasos Básicos

1. El usuario accede a su perfil desde el menú principal
2. El sistema muestra las opciones del perfil
3. El usuario selecciona "Configuración de Notificaciones"
4. El sistema muestra las categorías de notificaciones disponibles:
   - Seguridad y cuenta
   - Actividad de tableros
   - Expediciones y montañismo
   - Pagos y suscripciones
   - Marketing y promociones
   - Actualizaciones del sistema
5. Para cada categoría, el sistema muestra:
   - Descripción de los tipos de notificaciones incluidas
   - Canales disponibles (Email, Push, SMS, In-App)
   - Estado actual de cada canal (habilitado/deshabilitado)
   - Frecuencia de notificaciones
   - Horarios permitidos
6. El usuario configura las preferencias por categoría:
   - Activa/desactiva canales específicos
   - Establece frecuencia (inmediata, diaria, semanal)
   - Define horarios de no molestar
   - Configura filtros específicos
7. Para notificaciones de seguridad:
   - El sistema muestra que son obligatorias por motivos de seguridad
   - Permite configurar solo el canal (email siempre habilitado)
   - Permite añadir canales adicionales para mayor seguridad
8. Para notificaciones de expediciones:
   - El usuario puede configurar alertas por:
     - Cambios en itinerario
     - Condiciones meteorológicas
     - Emergencias del grupo
     - Actualizaciones de otros participantes
   - Define prioridad de notificaciones según tipo de expedición
9. Para notificaciones de marketing:
   - El usuario puede optar por recibir:
     - Promociones y descuentos
     - Nuevas funcionalidades
     - Eventos y competencias
     - Newsletter semanal
   - Puede seleccionar frecuencia máxima
10. El usuario configura horarios globales:
    - Horario de no molestar (excepto emergencias)
    - Zona horaria de referencia
    - Días de la semana activos
    - Configuración específica para fines de semana
11. El usuario configura canales de notificación:
    - Verifica/actualiza dirección de email
    - Confirma número de teléfono para SMS
    - Autoriza notificaciones push en dispositivos
    - Configura sonidos y vibraciones específicas
12. El sistema valida las configuraciones:
    - Verifica que al menos un canal esté habilitado para notificaciones críticas
    - Confirma que los datos de contacto sean válidos
    - Valida que los horarios configurados sean coherentes
13. El usuario guarda las configuraciones
14. El sistema aplica inmediatamente las nuevas preferencias
15. El sistema envía una notificación de confirmación usando los canales configurados
16. El sistema muestra mensaje de éxito con resumen de cambios aplicados

## Casos de Excepción

**E1: Datos de contacto inválidos**
- **Condición**: El email o teléfono proporcionados no son válidos
- **Acción**: El sistema resalta los campos con error y solicita corrección antes de guardar

**E2: Configuración inconsistente**
- **Condición**: El usuario intenta deshabilitar todos los canales para notificaciones críticas
- **Acción**: El sistema advierte sobre la importancia de las notificaciones de seguridad y requiere al menos un canal activo

**E3: Límites de frecuencia excedidos**
- **Condición**: La configuración resultaría en demasiadas notificaciones por hora
- **Acción**: El sistema sugiere configuraciones optimizadas y muestra estimación de volumen de notificaciones

**E4: Fallo en verificación de canal**
- **Condición**: No se puede verificar un canal de notificación (email bounces, SMS fallos)
- **Acción**: El sistema marca el canal como no verificado y solicita actualización de datos

**E5: Permisos de push denegados**
- **Condición**: El usuario no ha autorizado notificaciones push en su dispositivo
- **Acción**: El sistema muestra instrucciones específicas del dispositivo para habilitar permisos

## Validaciones/Reglas de Negocio

- **R1**: Las notificaciones de seguridad no pueden deshabilitarse completamente
- **R2**: Al menos un canal debe estar activo para notificaciones críticas
- **R3**: Los horarios de no molestar no aplican a notificaciones de emergencia
- **R4**: Los datos de contacto deben verificarse antes de activar el canal
- **R5**: La frecuencia de notificaciones de marketing está limitada a máximo 1 por día
- **R6**: Los cambios se aplican inmediatamente sin requerir confirmación adicional
- **R7**: Se debe mantener historial de cambios en preferencias
- **R8**: Los usuarios premium pueden tener configuraciones más granulares
- **R9**: Las preferencias se sincronizan en todos los dispositivos del usuario
- **R10**: Se debe respetar las regulaciones locales sobre notificaciones

## Post Condiciones

- Las nuevas preferencias quedan guardadas en la base de datos
- Se actualiza inmediatamente el perfil de notificaciones del usuario
- Se envía confirmación de cambios a través de los canales configurados
- Las próximas notificaciones respetan las nuevas configuraciones
- Se registra el cambio en el historial de configuraciones
- Se sincronizan las preferencias en todos los dispositivos del usuario

## Notas Técnicas

- Implementar validación en tiempo real de direcciones de email
- Usar servicios de verificación de números telefónicos
- Integrar con APIs de push notifications (FCM, APNS)
- Mantener cache de preferencias para respuesta rápida
- Implementar fallback entre canales en caso de fallos
- Usar flags de feature para habilitar nuevos tipos de notificaciones

## Criterios de Aceptación

1. ✅ Los cambios deben aplicarse inmediatamente sin necesidad de recargar
2. ✅ La interfaz debe mostrar claramente el estado actual de cada configuración
3. ✅ Debe incluir estimación de frecuencia de notificaciones basada en configuración
4. ✅ Los canales deben verificarse automáticamente al configurarlos
5. ✅ Debe permitir importar/exportar configuraciones para backup
6. ✅ La configuración debe ser accesible desde dispositivos móviles
7. ✅ Debe mostrar preview de notificaciones con la configuración actual
8. ✅ Los cambios deben sincronizarse en tiempo real en todos los dispositivos
