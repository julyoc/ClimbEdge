# Caso de Uso Expandido: UC-071

| **Campo** | **Descripción** |
|-----------|-----------------|
| **ID** | UC-071 |
| **Descripción** | Monitorear el estado y rendimiento del sistema ClimbEdge en tiempo real |
| **Actores** | Administrador Sistema, Sistema de Monitoreo, Sistema |
| **Pre Condiciones** | El administrador debe tener permisos de monitoreo. Los agentes de monitoreo deben estar instalados y configurados. El dashboard de monitoreo debe estar operativo. |

## Pasos Básicos

1. El administrador accede al dashboard de monitoreo del sistema
2. El sistema muestra el estado general con indicadores de salud:
   - Estado de servicios (API, Base de Datos, Cache)
   - Estado de hardware conectado
   - Métricas de rendimiento en tiempo real
3. El administrador selecciona la vista de métricas detalladas
4. El sistema muestra métricas específicas:
   - CPU y memoria de servidores
   - Latencia de respuesta de APIs
   - Throughput de base de datos
   - Conexiones WebSocket activas
   - Estado de dispositivos embebidos
5. El administrador configura alertas y umbrales:
   - Umbrales de CPU (>80%)
   - Umbrales de memoria (>85%)
   - Umbrales de latencia (>500ms)
   - Umbrales de errores (>5% en 5min)
6. El sistema monitorea continuamente las métricas
7. Cuando se supera un umbral:
   - El sistema genera una alerta automática
   - Se notifica al administrador vía email/SMS
   - Se registra el evento en logs de monitoreo
8. El administrador puede ver trending histórico:
   - Gráficos de rendimiento por período
   - Patrones de uso por horarios
   - Comparativas con períodos anteriores
9. El administrador puede exportar reportes de estado
10. El sistema mantiene dashboards actualizados en tiempo real

## Casos de Excepción

**E1: Servicio crítico caído**
- **Condición**: Un servicio esencial deja de responder
- **Acción**: El sistema activa alertas críticas y procedimientos de escalamiento

**E2: Alto volumen de errores**
- **Condición**: Se detecta un incremento anormal en la tasa de errores
- **Acción**: El sistema alerta y sugiere revisión de logs específicos

**E3: Pérdida de conectividad con hardware**
- **Condición**: Múltiples dispositivos embebidos se desconectan
- **Acción**: El sistema verifica conectividad de red y alerta sobre posibles problemas

**E4: Degradación de rendimiento**
- **Condición**: Las métricas muestran degradación sostenida
- **Acción**: El sistema sugiere acciones correctivas y escalamiento automático si está configurado

**E5: Fallo en sistema de monitoreo**
- **Condición**: Los agentes de monitoreo dejan de reportar
- **Acción**: El sistema activa monitoreo secundario y notifica del problema

## Validaciones/Reglas de Negocio

- Las métricas deben actualizarse cada 10 segundos como máximo
- Las alertas críticas deben enviarse inmediatamente
- Se debe mantener histórico de métricas por al menos 90 días
- Los umbrales deben ser configurables por tipo de métrica
- Solo administradores autorizados pueden modificar configuraciones de monitoreo
- Se debe registrar toda actividad de configuración para auditoría

## Post Condiciones

- El estado del sistema es monitoreado continuamente
- Las alertas configuradas están activas y funcionando
- Se mantiene un registro histórico de todas las métricas
- Los reportes de estado están disponibles para consulta
- Los administradores están informados de cualquier anomalía
- Se pueden tomar acciones correctivas basadas en la información recopilada

## Información Adicional

**Prioridad**: Crítica
**Frecuencia de Uso**: Continua (24/7)
**Complejidad**: Alta
**Tiempo de Respuesta**: < 10 segundos para alertas críticas
**Versión**: 1.0
**Fecha**: 2025-07-25
