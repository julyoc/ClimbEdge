# Caso de Uso Expandido: UC-104

| **Campo** | **Descripción** |
|-----------|-----------------|
| **ID** | UC-104 |
| **Descripción** | Programar expedición organizacional comercial para miembros y público general |
| **Actores** | Organización, Sistema de Pagos, Sistema Meteorológico, Sistema de Permisos, Guías de Montaña |
| **Pre Condiciones** | La organización debe estar verificada en el sistema. La organización debe tener al menos un guía certificado disponible. La montaña y ruta de destino deben estar registradas. La organización debe tener configurados métodos de pago. |

## Pasos Básicos

1. La organización accede al módulo "Expediciones" en su panel administrativo
2. El sistema muestra el dashboard de expediciones con opciones de gestión
3. La organización selecciona "Nueva Expedición Organizacional"
4. El sistema presenta el wizard de creación en múltiples pasos
5. La organización completa información básica:
   - Nombre comercial de la expedición
   - Descripción marketing y técnica
   - Montaña y ruta específica
   - Fechas de inicio y fin
   - Duración total en días
   - Nivel de dificultad técnica
   - Nivel de experiencia requerido
6. La organización establece parámetros comerciales:
   - Precio por participante (diferentes monedas)
   - Descuentos por membresía de la organización
   - Política de cancelación y reembolsos
   - Depósito requerido vs. pago completo
   - Fecha límite de inscripción
   - Número mínimo para confirmar expedición
   - Número máximo de participantes
7. La organización define criterios de elegibilidad:
   - Experiencia previa requerida
   - Certificaciones médicas necesarias
   - Certificaciones técnicas requeridas
   - Restricciones de edad
   - Condición física mínima
   - Equipamiento personal obligatorio
8. La organización asigna recursos:
   - Guía principal (debe ser instructor certificado)
   - Guías asistentes
   - Personal de apoyo (médico, cocinero, etc.)
   - Vehículos de transporte
   - Equipamiento grupal proporcionado
   - Base camp y alojamientos incluidos
9. El sistema genera automáticamente un itinerario base según la ruta
10. La organización revisa y personaliza:
    - Actividades diarias
    - Puntos de aclimatación
    - Campamentos base y avanzados
    - Planes de contingencia por mal tiempo
    - Rutas de evacuación de emergencia
    - Comunicación con base y familias
11. La organización configura aspectos legales:
    - Permisos de montaña requeridos
    - Seguros incluidos en el precio
    - Waivers y documentos legales
    - Contactos de emergencia locales
    - Protocolos de evacuación médica
12. El sistema valida automáticamente:
    - Disponibilidad de guías en las fechas
    - Conflictos con otras expediciones
    - Validez de permisos para las fechas
    - Condiciones meteorológicas históricas
    - Capacidad máxima de la ruta
13. La organización revisa el resumen completo de la expedición
14. La organización confirma la creación y publicación
15. El sistema procesa la expedición:
    - Crea la expedición en estado "Programada"
    - Configura sistema de inscripciones online
    - Genera documentos automáticos (contratos, listas)
    - Activa sistema de pagos integrado
    - Programa notificaciones automáticas
16. El sistema publica la expedición según configuración:
    - Visible para miembros de la organización
    - Listado público en directorio de expediciones
    - Integración con calendario de eventos
17. El sistema envía notificaciones automáticas:
    - Email a miembros elegibles de la organización
    - Notificaciones push a usuarios con preferencias similares
    - Posts automáticos en redes sociales (si está configurado)
18. El sistema muestra confirmación con URLs de gestión y métricas

## Casos de Excepción

**E1: Expedición privada solo para miembros**
- **Condición**: La organización marca la expedición como privada
- **Acción**: El sistema configura visibilidad solo para miembros y aplica descuentos automáticos

**E2: Expedición requiere aprobación manual**
- **Condición**: La expedición tiene características de alto riesgo
- **Acción**: El sistema marca para revisión manual y notifica al equipo de seguridad

**E3: Fechas con conflictos climatológicos**
- **Condición**: Las fechas coinciden con temporada de mal tiempo histórico
- **Acción**: El sistema muestra alertas meteorológicas y sugiere fechas alternativas

**E4: Organización pierde verificación**
- **Condición**: La organización es desverificada durante el proceso
- **Acción**: El sistema bloquea la creación y redirige a proceso de re-verificación

**E5: Límite de expediciones alcanzado**
- **Condición**: La organización alcanza su límite de expediciones simultáneas
- **Acción**: El sistema sugiere actualizar plan o poner en cola

## Validaciones/Reglas de Negocio

- Solo organizaciones verificadas pueden crear expediciones públicas
- Toda expedición debe tener al menos un guía certificado asignado
- El precio debe incluir seguros mínimos obligatorios
- Expediciones de alta montaña requieren guías con certificación específica
- El número de participantes no puede exceder límites de seguridad de la ruta
- Las cancelaciones deben seguir políticas predefinidas de reembolso

## Post Condiciones

- La expedición queda programada y disponible para inscripciones
- Se configuran automáticamente los sistemas de pago
- Se generan documentos base (itinerario, lista de equipamiento, waivers)
- Se activan notificaciones automáticas a miembros elegibles
- Se establece el plan de seguridad preliminar
- Se integra con calendario organizacional y sistemas de marketing
- Se activan alertas meteorológicas y de permisos automáticas

## Información Adicional

**Prioridad**: Alta
**Frecuencia de Uso**: Media
**Complejidad**: Alta
**Versión**: 1.0
**Fecha**: 2025-07-31
