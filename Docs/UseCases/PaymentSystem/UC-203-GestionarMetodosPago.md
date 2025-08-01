# Caso de Uso Expandido: UC-092

| **Campo** | **Descripción** |
|-----------|-----------------|
| **ID** | UC-092 |
| **Descripción** | Gestionar métodos de pago del usuario para suscripciones y servicios pay-per-use |
| **Actores** | Usuario, Sistema de Pago, Sistema |
| **Pre Condiciones** | El usuario debe estar autenticado. El sistema de pagos (Stripe, PayPal) debe estar disponible. El usuario debe tener permisos para gestionar métodos de pago. |

## Pasos Básicos

1. El usuario accede a la sección "Mi Cuenta" > "Métodos de Pago"
2. El sistema muestra la lista de métodos de pago existentes:
   - Tipo de método (tarjeta de crédito, débito, PayPal, etc.)
   - Últimos 4 dígitos (para tarjetas)
   - Fecha de expiración
   - Estado (activo/inactivo)
   - Indicador de método predeterminado
3. El usuario selecciona "Agregar Nuevo Método de Pago"
4. El sistema muestra las opciones disponibles:
   - Tarjeta de Crédito/Débito
   - PayPal
   - Transferencia Bancaria
   - Otros proveedores configurados
5. El usuario selecciona el tipo de método deseado
6. El sistema redirige al proveedor de pagos correspondiente:
   - Para tarjetas: formulario seguro de Stripe/PayPal
   - Para PayPal: autenticación OAuth
   - Para transferencia: formulario de datos bancarios
7. El usuario completa la información requerida en el proveedor
8. El proveedor valida la información y genera un token seguro
9. El sistema recibe el token del proveedor y valida la respuesta
10. El sistema almacena el método de pago:
    - Crea registro en PaymentMethod con token seguro
    - NO almacena información sensible (números completos, CVV)
    - Guarda solo metadatos necesarios (últimos 4 dígitos, expiración)
11. El sistema verifica el método realizando una autorización de $1
12. Si la verificación es exitosa, el método queda disponible
13. El usuario puede configurar el nuevo método como predeterminado
14. El sistema confirma la adición exitosa del método de pago

## Casos de Excepción

**E1: Información de pago inválida**
- **Condición**: El proveedor rechaza la información proporcionada
- **Acción**: El sistema muestra el error específico y permite corregir

**E2: Método de pago duplicado**
- **Condición**: El mismo método ya está registrado
- **Acción**: El sistema informa sobre la duplicación y no crea registro

**E3: Límite de métodos excedido**
- **Condición**: El usuario ha alcanzado el límite máximo de métodos (5)
- **Acción**: El sistema sugiere eliminar métodos antiguos antes de agregar nuevos

**E4: Proveedor de pagos no disponible**
- **Condición**: El servicio de Stripe/PayPal no responde
- **Acción**: El sistema muestra mensaje de error temporal y sugiere reintentar

**E5: Falla en verificación**
- **Condición**: La autorización de $1 falla
- **Acción**: El sistema marca el método como no verificado y solicita verificación manual

## Operaciones Adicionales

**Editar Método de Pago**:
1. Usuario selecciona método existente y "Editar"
2. Sistema permite modificar solo datos no sensibles (nombre, dirección de facturación)
3. Para cambios críticos, se requiere re-verificación con el proveedor

**Eliminar Método de Pago**:
1. Usuario selecciona método y "Eliminar"
2. Sistema verifica que no tenga suscripciones activas asociadas
3. Si es método predeterminado, sistema solicita seleccionar nuevo predeterminado
4. Sistema marca como inactivo y notifica al proveedor

**Establecer como Predeterminado**:
1. Usuario selecciona método y "Establecer como predeterminado"
2. Sistema actualiza el método anterior y establece el nuevo
3. Se notifica el cambio para futuras transacciones

## Validaciones/Reglas de Negocio

- Máximo 5 métodos de pago activos por usuario
- Solo un método puede ser predeterminado
- Los métodos vencidos se marcan automáticamente como inactivos
- No se almacena información sensible en la base de datos local
- Todos los métodos deben pasar verificación antes de usarse
- Los métodos vinculados a suscripciones activas no pueden eliminarse
- Se requiere re-autenticación para operaciones sensibles

## Post Condiciones

- Se crea/actualiza registro en PaymentMethod
- El token seguro queda almacenado y asociado al usuario
- El método está disponible para futuros pagos
- Se registra la actividad en logs de auditoría
- El usuario recibe confirmación por email (opcional)
- Las suscripciones pueden usar el nuevo método
- El método aparece en la lista de opciones de pago

## Flujos de Seguridad

**Verificación de Identidad**:
- Para métodos de alto valor, se puede requerir verificación adicional
- Validación de dirección de facturación
- Verificación de código postal/ZIP

**Detección de Fraude**:
- El sistema monitorea patrones sospechosos
- Bloqueo temporal de métodos con actividad inusual
- Notificación automática de cambios importantes

## Información Adicional

**Prioridad**: Alta
**Frecuencia de Uso**: Media
**Complejidad**: Alta
**Tiempo de Respuesta**: < 10 segundos (incluyendo validación externa)
**Versión**: 1.0
**Fecha**: 2025-08-01

**Consideraciones de Seguridad**:
- Cumplimiento PCI DSS para manejo de datos de tarjetas
- Cifrado de extremo a extremo
- Tokenización de información sensible
- Auditoría completa de todas las operaciones

**Integraciones Requeridas**:
- Stripe API para tarjetas de crédito/débito
- PayPal SDK para pagos PayPal
- Sistema de notificaciones para confirmaciones
- Sistema de auditoría para logging de transacciones
