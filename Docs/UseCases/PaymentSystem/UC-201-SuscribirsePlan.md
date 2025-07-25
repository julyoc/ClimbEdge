# Caso de Uso Expandido: UC-201

| **Campo** | **Descripción** |
|-----------|-----------------|
| **ID** | UC-201 |
| **Descripción** | Suscribirse a plan premium |
| **Actores** | Usuario, Sistema de Pago, Proveedor de Pago (Stripe/PayPal), Sistema Contable |
| **Pre Condiciones** | El usuario debe estar autenticado. Debe existir al menos un plan activo disponible. El usuario no debe tener una suscripción activa al mismo plan. |

## Pasos Básicos

1. El usuario accede a la sección "Planes y Suscripciones" desde su perfil
2. El sistema muestra los planes disponibles con:
   - Características incluidas en cada plan
   - Precios y períodos de facturación
   - Comparativa entre planes
   - Promociones activas
3. El usuario selecciona el plan deseado
4. El sistema muestra el resumen del plan seleccionado:
   - Detalles completos del plan
   - Precio y frecuencia de facturación
   - Fecha de inicio de la suscripción
   - Próxima fecha de facturación
   - Funcionalidades que se habilitarán
5. El usuario confirma la selección del plan
6. El sistema redirige al proceso de configuración de método de pago
7. Si el usuario no tiene métodos de pago registrados:
   - El sistema muestra el formulario de añadir método de pago
   - El usuario ingresa los datos de la tarjeta o selecciona PayPal
   - El sistema valida el método de pago con el proveedor
   - El sistema guarda el método de pago como predeterminado
8. Si el usuario tiene métodos de pago existentes:
   - El sistema muestra los métodos disponibles
   - El usuario selecciona el método de pago preferido
9. El sistema presenta el resumen final de la suscripción:
   - Plan seleccionado
   - Método de pago
   - Importe total
   - Términos y condiciones
10. El usuario revisa y acepta los términos y condiciones
11. El usuario confirma la suscripción
12. El sistema procesa el pago:
    - Envía solicitud de pago al proveedor
    - Valida la respuesta del proveedor
    - Registra la transacción en el sistema
13. Si el pago es exitoso:
    - El sistema crea la suscripción con estado "Activa"
    - Se establece la fecha de próxima facturación
    - Se habilitan inmediatamente las funcionalidades del plan
    - Se genera la factura inicial
    - Se envía confirmación por email
14. El sistema actualiza el perfil del usuario:
    - Cambia el tipo de cuenta a Premium
    - Actualiza los límites y funcionalidades disponibles
    - Actualiza la interfaz para mostrar funcionalidades premium
15. El sistema programa la próxima renovación automática
16. El usuario es redirigido al dashboard con las nuevas funcionalidades habilitadas

## Casos de Excepción

**E1: Pago rechazado**
- **Condición**: El proveedor de pago rechaza la transacción
- **Acción**: El sistema muestra el motivo del rechazo y permite reintentar con otro método de pago

**E2: Método de pago inválido**
- **Condición**: Los datos del método de pago son incorrectos o la tarjeta está vencida
- **Acción**: El sistema solicita verificar los datos o añadir un nuevo método de pago

**E3: Usuario ya tiene suscripción activa**
- **Condición**: El usuario intenta suscribirse teniendo ya una suscripción activa al mismo plan
- **Acción**: El sistema ofrece cambiar de plan o gestionar la suscripción existente

**E4: Plan no disponible**
- **Condición**: El plan seleccionado fue desactivado durante el proceso
- **Acción**: El sistema informa sobre la no disponibilidad y muestra planes alternativos

**E5: Error en facturación**
- **Condición**: El pago se procesa pero falla la generación de factura
- **Acción**: El sistema completa la suscripción y programa la generación de factura para reintento

**E6: Fallo de conectividad**
- **Condición**: Se pierde conexión durante el procesamiento del pago
- **Acción**: El sistema verifica el estado del pago con el proveedor y sincroniza el estado

## Validaciones/Reglas de Negocio

- **R1**: Un usuario solo puede tener una suscripción activa por vez
- **R2**: El cambio de plan requiere prorateo del período actual
- **R3**: La suscripción se activa inmediatamente tras el pago exitoso
- **R4**: Las funcionalidades premium se habilitan en tiempo real
- **R5**: La renovación automática está habilitada por defecto
- **R6**: Se debe enviar recordatorio 7 días antes de la renovación
- **R7**: El usuario puede cancelar hasta 24 horas antes de la renovación
- **R8**: Los precios mostrados deben incluir impuestos aplicables
- **R9**: Se debe mantener historial completo de todas las transacciones
- **R10**: Los reembolsos deben procesarse automáticamente si aplican

## Post Condiciones

- Se crea una nueva suscripción activa en la base de datos
- Se procesa el pago inicial y se registra la transacción
- Se genera y envía la factura por email
- Se habilitan las funcionalidades premium en la cuenta del usuario
- Se programa la próxima renovación automática
- Se actualiza el perfil del usuario para reflejar el estado premium
- Se envían notificaciones de confirmación al usuario
- Se registra la actividad en los logs de auditoría

## Notas Técnicas

- Integración con Stripe y PayPal para procesamiento de pagos
- Implementar webhook para recibir confirmaciones de pago
- Usar tokenización para almacenar métodos de pago de forma segura
- Implementar retry logic para reintentos automáticos de pagos fallidos
- Encriptar toda información sensible de pago
- Cumplir con estándares PCI DSS para manejo de datos de tarjetas

## Criterios de Aceptación

1. ✅ El proceso completo debe completarse en menos de 2 minutos
2. ✅ Las funcionalidades premium deben habilitarse inmediatamente
3. ✅ La confirmación por email debe enviarse en menos de 5 minutos
4. ✅ El sistema debe soportar múltiples métodos de pago simultáneamente
5. ✅ Todos los errores deben mostrar mensajes claros y accionables
6. ✅ La factura debe generarse automáticamente en formato PDF
7. ✅ El sistema debe funcionar con conexiones lentas (3G)
8. ✅ Debe mantener el estado de la transacción en caso de interrupciones
