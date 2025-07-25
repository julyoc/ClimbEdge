# Caso de Uso Expandido: UC-302

| **Campo** | **Descripción** |
|-----------|-----------------|
| **ID** | UC-302 |
| **Descripción** | Enviar notificación automática del sistema |
| **Actores** | Sistema, Proveedor de Email, Servicio Push, Proveedor SMS, Usuario (receptor) |
| **Pre Condiciones** | Debe existir un evento que active una notificación. El usuario destinatario debe tener configuradas sus preferencias. Los servicios de notificación deben estar operativos. |

## Pasos Básicos

1. Se produce un evento en el sistema que requiere notificación:
   - Cambio en estado de expedición
   - Actividad nueva en tablero compartido
   - Procesamiento de pago
   - Actualización de seguridad
   - Condiciones meteorológicas adversas
2. El sistema identifica el tipo de evento y la categoría de notificación correspondiente
3. El sistema determina los usuarios que deben ser notificados:
   - Para eventos de expedición: participantes y organizadores
   - Para actividad de tablero: miembros del tablero
   - Para pagos: usuario propietario de la cuenta
   - Para seguridad: usuario afectado y administradores
4. Para cada usuario destinatario:
   - El sistema consulta sus preferencias de notificación
   - Verifica si la categoría de notificación está habilitada
   - Valida los horarios de no molestar (excepto emergencias)
   - Determina los canales activos para esa categoría
5. El sistema selecciona la plantilla de notificación apropiada:
   - Identifica la plantilla por tipo de evento
   - Selecciona idioma según preferencias del usuario
   - Carga el template para cada canal (email, push, SMS)
6. El sistema personaliza el contenido de la notificación:
   - Sustituye variables dinámicas con datos específicos del evento
   - Personaliza saludo con nombre del usuario
   - Incluye enlaces específicos y call-to-actions relevantes
   - Adapta el formato según el canal de entrega
7. Para notificaciones de emergencia o alta prioridad:
   - El sistema bypasea horarios de no molestar
   - Utiliza todos los canales disponibles del usuario
   - Aplica retry automático más agresivo
   - Notifica a contactos de emergencia si está configurado
8. El sistema programa la notificación en la cola de envío:
   - Asigna prioridad según tipo de evento
   - Establece tiempo de retry en caso de fallo
   - Programa envío inmediato o diferido según configuración
9. El sistema procesa la cola de notificaciones:
   - Selecciona notificaciones por prioridad
   - Respeta límites de rate limiting de proveedores
   - Distribuye carga entre múltiples workers
10. Para cada canal, el sistema envía la notificación:
    - **Email**: A través del proveedor de email configurado
    - **Push**: Via FCM para Android, APNS para iOS
    - **SMS**: A través del proveedor de SMS
    - **In-App**: Almacena en base de datos para mostrar en app
11. El sistema recibe confirmaciones de entrega:
    - Registra confirmaciones de envío de cada proveedor
    - Actualiza estado de notificación en base de datos
    - Registra métricas de entrega y apertura
12. En caso de fallos de entrega:
    - El sistema programa reintentos automáticos
    - Escala la frecuencia de reintentos gradualmente
    - Intenta canales alternativos si están disponibles
    - Marca como fallida después del máximo de reintentos
13. El sistema actualiza estadísticas:
    - Incrementa contadores de notificaciones enviadas
    - Registra métricas de rendimiento de cada canal
    - Actualiza tasas de entrega y apertura
    - Registra logs detallados para auditoría

## Casos de Excepción

**E1: Usuario sin preferencias configuradas**
- **Condición**: Un usuario no ha configurado sus preferencias de notificación
- **Acción**: El sistema utiliza configuración por defecto y envía notificación solicitando configurar preferencias

**E2: Todos los canales fallan**
- **Condición**: Ningún canal de notificación funciona para un usuario específico
- **Acción**: El sistema guarda la notificación como in-app y notifica a administradores sobre el problema

**E3: Rate limiting del proveedor**
- **Condición**: Se exceden los límites de envío del proveedor de notificaciones
- **Acción**: El sistema distribuye envíos en el tiempo y utiliza proveedores alternativos

**E4: Plantilla de notificación faltante**
- **Condición**: No existe plantilla para el tipo de evento específico
- **Acción**: El sistema utiliza una plantilla genérica y registra el evento para crear plantilla específica

**E5: Datos insuficientes para personalización**
- **Condición**: Faltan datos necesarios para personalizar la notificación
- **Acción**: El sistema envía versión genérica y registra los datos faltantes para corrección

**E6: Usuario deshabilitó categoría pero es crítica**
- **Condición**: Notificación crítica para usuario que deshabilitó esa categoría
- **Acción**: El sistema envía por canales de emergencia y registra override de preferencias

## Validaciones/Reglas de Negocio

- **R1**: Las notificaciones de emergencia no respetan horarios de no molestar
- **R2**: Máximo 3 reintentos por canal antes de marcar como fallida
- **R3**: Las notificaciones in-app se mantienen 30 días antes de archivarse
- **R4**: Rate limiting: máximo 10 notificaciones por minuto por usuario (excepto emergencias)
- **R5**: Los logs de notificaciones se mantienen 12 meses para análisis
- **R6**: Notificaciones duplicadas en ventana de 5 minutos se consolidan
- **R7**: Los usuarios premium tienen prioridad en cola de envío
- **R8**: Notificaciones de marketing respetan opt-out global
- **R9**: Se debe mantener audit trail completo de todas las notificaciones
- **R10**: Los datos personales en notificaciones deben cumplir GDPR

## Post Condiciones

- La notificación queda registrada en base de datos con estado final
- Se actualizan métricas de entrega y rendimiento del sistema
- El usuario recibe la notificación en los canales configurados
- Se registran logs detallados para análisis posterior
- Se actualizan contadores de notificaciones del usuario
- Las métricas de engagement se actualizan para optimización futura

## Notas Técnicas

- Implementar circuit breaker para proveedores de notificación
- Usar async processing para envío de notificaciones masivas
- Implementar dead letter queue para notificaciones fallidas
- Usar template engine robusto para personalización
- Implementar monitoring en tiempo real de todos los canales
- Usar CDN para assets de notificaciones (imágenes, etc.)

## Criterios de Aceptación

1. ✅ Las notificaciones críticas deben enviarse en menos de 30 segundos
2. ✅ El sistema debe procesar al menos 1000 notificaciones por minuto
3. ✅ La tasa de entrega debe ser superior al 98% para emails
4. ✅ Los reintentos deben escalar exponencialmente hasta 24 horas máximo
5. ✅ Las notificaciones in-app deben aparecer inmediatamente
6. ✅ El sistema debe soportar notificaciones en múltiples idiomas
7. ✅ Los logs deben incluir tiempo completo de procesamiento
8. ✅ Las métricas deben actualizarse en tiempo real en dashboard de administración
