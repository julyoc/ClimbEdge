# Caso de Uso Expandido: UC-070

| **Campo** | **Descripción** |
|-----------|-----------------|
| **ID** | UC-070 |
| **Descripción** | Configurar parámetros globales y reglas de negocio del sistema ClimbEdge |
| **Actores** | Administrador Sistema, Sistema |
| **Pre Condiciones** | El administrador debe tener permisos de sistema. Debe existir acceso a configuraciones globales. El sistema debe estar operativo. |

## Pasos Básicos

1. El administrador accede al panel de administración del sistema
2. El sistema muestra las categorías de configuración disponibles:
   - Configuraciones generales
   - Escalas de dificultad
   - Tipos de elementos y materiales
   - Configuraciones de IA
   - Límites y restricciones
   - Integraciones externas
3. El administrador selecciona "Configuraciones Generales":
   - Nombre del sistema y versión
   - URLs de servicios externos
   - Configuración de email y notificaciones
   - Límites de almacenamiento y archivos
4. El administrador configura "Escalas de Dificultad":
   - Añade nuevas escalas de dificultad
   - Modifica conversiones entre escalas
   - Establece equivalencias IRCRA
   - Configura escalas por defecto por región
5. El administrador gestiona "Tipos de Elementos":
   - Define nuevos tipos de presas
   - Configura texturas y materiales disponibles
   - Establece multiplicadores de dificultad
   - Añade iconografía y descripciones
6. El administrador configura "Parámetros de IA":
   - Límites de uso de recursos computacionales
   - Parámetros de entrenamiento por defecto
   - Configuración de modelos activos
   - Límites de generación por usuario
7. El administrador establece "Límites del Sistema":
   - Máximo tableros por usuario
   - Máximo problemas por tablero
   - Límites de tamaño de archivos
   - Límites de sesiones concurrentes
8. El administrador configura "Integraciones":
   - APIs de servicios de mapas
   - Servicios de almacenamiento de archivos
   - Sistemas de autenticación externos
   - Webhooks y notificaciones
9. El administrador valida configuraciones:
   - Prueba conectividad con servicios externos
   - Verifica coherencia entre configuraciones
   - Valida formatos y rangos de valores
10. El sistema aplica las nuevas configuraciones
11. El sistema notifica servicios afectados sobre cambios
12. El sistema registra cambios en log de auditoría

## Casos de Excepción

**E1: Configuración inválida**
- **Condición**: Los valores ingresados no cumplen validaciones
- **Acción**: El sistema destaca errores específicos y previene guardado

**E2: Conflicto con configuraciones existentes**
- **Condición**: Nueva configuración es incompatible con datos existentes
- **Acción**: El sistema muestra conflictos y sugiere migración de datos

**E3: Falla en servicios externos**
- **Condición**: No se puede validar conectividad con servicios configurados
- **Acción**: El sistema permite guardar pero marca servicios como no validados

**E4: Límites muy restrictivos**
- **Condición**: Los nuevos límites afectarían usuarios existentes
- **Acción**: El sistema calcula impacto y solicita confirmación explícita

**E5: Error en aplicación de cambios**
- **Condición**: Falla al aplicar configuraciones en servicios activos
- **Acción**: El sistema revierte cambios y mantiene configuración anterior

## Validaciones/Reglas de Negocio

- Los cambios críticos requieren confirmación de múltiples administradores
- Las configuraciones deben mantener compatibilidad con versiones anteriores
- Los límites no pueden ser menores a valores mínimos operativos
- Las escalas de dificultad deben tener correspondencia IRCRA válida
- Todos los cambios deben documentarse con justificación

## Post Condiciones

- Las nuevas configuraciones están activas en todo el sistema
- Todos los servicios reflejan los cambios aplicados
- Se mantiene registro completo de cambios para auditoría
- Los usuarios experimentan el comportamiento según nuevas configuraciones
- El sistema opera según los nuevos parámetros establecidos

## Información Adicional

**Prioridad**: Crítica
**Frecuencia de Uso**: Baja (cambios esporádicos)
**Complejidad**: Alta
**Tiempo de Respuesta**: Variable según alcance de cambios
**Versión**: 1.0
**Fecha**: 2025-07-25
