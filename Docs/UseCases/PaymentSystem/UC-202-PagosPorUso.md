# Caso de Uso Expandido: UC-202

| **Campo** | **Descripción** |
|-----------|-----------------|
| **ID** | UC-202 |
| **Descripción** | Procesar pago por uso de servicios premium (Pay-Per-Use) |
| **Actores** | Usuario, Sistema de IA, Sistema de Pago, Proveedor de Pago |
| **Pre Condiciones** | El usuario debe estar autenticado. El servicio pay-per-use debe estar disponible. El usuario debe tener un método de pago válido configurado. El saldo de créditos (si aplica) debe ser insuficiente para el servicio. |

## Pasos Básicos

1. El usuario accede a una funcionalidad premium que requiere pago por uso:
   - Generar problema con IA
   - Análisis avanzado de progreso
   - Exportar datos detallados
   - Funcionalidades de guía premium
2. El sistema verifica el tipo de cuenta del usuario:
   - Si es premium con créditos suficientes: procede directamente
   - Si es gratuito o sin créditos: inicia proceso de pago
3. El sistema muestra la información del servicio:
   - Descripción detallada del servicio
   - Costo por unidad de uso
   - Estimación de consumo para la solicitud actual
   - Tiempo estimado de procesamiento
4. El sistema calcula el costo total:
   - Unidades de servicio requeridas
   - Precio unitario actual
   - Impuestos aplicables
   - Descuentos por volumen (si aplican)
5. El sistema presenta el resumen de costos:
   - Desglose detallado del cálculo
   - Costo total a cobrar
   - Método de pago que se utilizará
   - Términos específicos del servicio
6. El usuario revisa la información y confirma el pago
7. El sistema registra la solicitud de servicio en estado "Pendiente de Pago"
8. El sistema procesa el pago:
   - Envía solicitud al proveedor de pago
   - Valida la respuesta de autorización
   - Registra la transacción con ID único
9. Si el pago es autorizado exitosamente:
   - El sistema actualiza el estado a "Pagado"
   - Se inicia el procesamiento del servicio solicitado
   - Se registra el consumo en la cuenta del usuario
10. El sistema ejecuta el servicio premium:
    - Para IA: envía solicitud al modelo correspondiente
    - Para análisis: procesa los datos requeridos
    - Para exportación: genera los archivos solicitados
11. Durante el procesamiento:
    - El sistema muestra el progreso en tiempo real
    - Actualiza el estado del servicio
    - Registra métricas de uso y rendimiento
12. Al completarse el servicio:
    - Se marcan las unidades como "Consumidas"
    - Se entrega el resultado al usuario
    - Se genera la micro-factura del servicio
    - Se actualiza el historial de uso
13. El sistema envía notificación de finalización:
    - Confirmación de servicio completado
    - Enlace a los resultados
    - Resumen de consumo y costo
    - Enlace a la factura

## Casos de Excepción

**E1: Pago rechazado**
- **Condición**: El proveedor rechaza el pago por fondos insuficientes u otro motivo
- **Acción**: El sistema cancela la solicitud de servicio y notifica al usuario con opciones para reintentar

**E2: Fallo en el servicio después del pago**
- **Condición**: El pago se procesa exitosamente pero el servicio falla al ejecutarse
- **Acción**: El sistema reembolsa automáticamente el pago y registra el incidente para análisis

**E3: Servicio parcialmente completado**
- **Condición**: El servicio se completa parcialmente debido a limitaciones técnicas
- **Acción**: El sistema cobra proporcionalmente y ofrece completar el resto sin costo adicional

**E4: Exceso de demanda del servicio**
- **Condición**: El servicio no está disponible por alta demanda
- **Acción**: El sistema coloca la solicitud en cola y notifica el tiempo estimado de espera

**E5: Cambio de precios durante el proceso**
- **Condición**: Los precios del servicio cambian mientras se procesa el pago
- **Acción**: Se honra el precio mostrado inicialmente al usuario

**E6: Timeout del proveedor de pago**
- **Condición**: El proveedor de pago no responde en tiempo razonable
- **Acción**: El sistema cancela la transacción y permite reintentar

## Validaciones/Reglas de Negocio

- **R1**: El precio mostrado al usuario debe mantenerse durante 15 minutos
- **R2**: No se puede procesar el mismo servicio múltiples veces simultáneamente
- **R3**: Los servicios de IA tienen límites de uso por hora para prevenir abuso
- **R4**: Se debe registrar el consumo exacto para facturación precisa
- **R5**: Los reembolsos automáticos deben procesarse en caso de fallo del servicio
- **R6**: El historial de uso debe mantenerse por al menos 12 meses
- **R7**: Los precios pueden incluir descuentos por volumen acumulativo
- **R8**: Se debe notificar al usuario sobre consumos que excedan umbrales predefinidos
- **R9**: Los servicios premium deben tener SLA garantizado
- **R10**: Se debe mantener audit trail completo de todas las transacciones

## Post Condiciones

- Se registra la transacción de pago por uso en el sistema
- Se actualiza el saldo de servicios consumidos del usuario
- Se genera micro-factura del servicio específico
- Se entrega el resultado del servicio al usuario
- Se actualiza el historial de uso y métricas del usuario
- Se registra la actividad para análisis de uso futuro
- Se actualiza el estado del método de pago usado

## Notas Técnicas

- Implementar circuit breaker para servicios externos críticos
- Usar async processing para servicios de larga duración
- Implementar rate limiting para prevenir abuso
- Usar caching inteligente para optimizar costos de servicios repetitivos
- Implementar monitoring en tiempo real de todos los servicios pay-per-use
- Mantener métricas detalladas para optimización de precios

## Criterios de Aceptación

1. ✅ El cálculo de costos debe ser transparente y detallado
2. ✅ El pago debe procesarse en menos de 10 segundos
3. ✅ Los servicios de IA deben entregar resultados en menos de 2 minutos
4. ✅ Los fallos de servicio deben reembolsarse automáticamente en menos de 5 minutos
5. ✅ El sistema debe soportar micropagos desde $0.01 USD
6. ✅ Los usuarios deben poder ver su historial completo de consumo
7. ✅ Las micro-facturas deben generarse automáticamente
8. ✅ El sistema debe alertar sobre gastos que excedan $10 USD en una hora
