# UC-401: Gestionar Tickets de Soporte

## Información General
- **ID:** UC-401
- **Nombre:** Gestionar Tickets de Soporte
- **Fecha:** 2025-07-25
- **Actor Principal:** Usuario / Agente de Soporte
- **Nivel:** Usuario

## Actores
- **Usuario:** Crea y actualiza tickets de soporte
- **Agente de Soporte:** Gestiona y resuelve tickets
- **Supervisor de Soporte:** Supervisa y escala tickets
- **Sistema de Notificaciones:** Envía notificaciones de estado

## Precondiciones
- El usuario debe estar autenticado (para crear tickets)
- Los agentes deben tener credenciales y permisos adecuados
- El sistema de categorización debe estar configurado
- Las reglas de SLA deben estar definidas

## Flujo Básico

### Paso 1: Crear Ticket (Usuario)
1. El usuario accede al sistema de soporte
2. El sistema presenta el formulario de creación de ticket
3. El usuario proporciona:
   - Asunto del problema
   - Descripción detallada
   - Categoría (selección de lista)
   - Prioridad sugerida
   - Archivos adjuntos (opcional)
4. El sistema valida la información y genera número de ticket único

### Paso 2: Categorización y Asignación Automática
5. El sistema:
   - Asigna automáticamente la categoría si no se especificó
   - Determina la prioridad basada en reglas predefinidas
   - Asigna el ticket a un agente disponible según:
     - Especialización del agente
     - Carga de trabajo actual
     - Disponibilidad horaria
6. Se genera notificación al agente asignado

### Paso 3: Gestión por Agente
7. El agente recibe la notificación y accede al ticket
8. El agente puede:
   - Revisar detalles completos del ticket
   - Cambiar prioridad o categoría si es necesario
   - Agregar notas internas para el equipo
   - Solicitar información adicional al usuario
   - Proporcionar respuesta o solución
   - Cambiar estado del ticket

### Paso 4: Comunicación con Usuario
9. Cuando el agente responde:
   - El sistema envía notificación al usuario
   - El usuario puede responder o proporcionar información adicional
   - Todas las comunicaciones quedan registradas en el historial
   - El estado del ticket se actualiza automáticamente

### Paso 5: Seguimiento y Escalación
10. El sistema monitorea constantemente:
    - Tiempo de primera respuesta vs SLA
    - Tiempo total de resolución vs SLA
    - Inactividad del ticket
11. Si se exceden los SLA o criterios de escalación:
    - Se escalada automáticamente al supervisor
    - Se notifica a las partes relevantes
    - Se ajusta la prioridad si es necesario

### Paso 6: Resolución
12. Cuando el agente resuelve el problema:
    - Marca el ticket como "Resuelto"
    - Proporciona resumen de la solución
    - Incluye pasos tomados y recomendaciones
13. El sistema notifica al usuario sobre la resolución

### Paso 7: Cierre y Evaluación
14. El usuario puede:
    - Confirmar que el problema está resuelto
    - Solicitar reapertura si persiste el problema
    - Proporcionar calificación de satisfacción
    - Agregar comentarios sobre el servicio
15. El ticket se cierra automáticamente tras período definido

## Flujos Alternativos

### 3a: Reasignación de Ticket
- Si el agente asignado no puede atender el ticket:
  - El agente puede transferir a otro agente especializado
  - El supervisor puede reasignar manualmente
  - El sistema registra el cambio y notifica a todos los involucrados

### 5a: Escalación Manual
- Si el agente considera necesaria la escalación:
  - Puede escalar manualmente al supervisor
  - Debe proporcionar justificación
  - El supervisor revisa y decide las acciones

### 7a: Reapertura de Ticket
- Si el usuario no está satisfecho con la resolución:
  - Puede reabrir el ticket dentro del período permitido
  - Se asigna nuevamente (posiblemente a otro agente)
  - Se registra como nueva interacción

## Excepciones

### E1: Información Insuficiente
- **Condición:** El ticket carece de información suficiente para proceder
- **Acción:** El agente solicita información adicional y el ticket entra en estado "Pendiente de Usuario"

### E2: Agente No Disponible
- **Condición:** No hay agentes disponibles para la categoría del ticket
- **Acción:** El ticket entra en cola de espera y se notifica al supervisor

### E3: Problema Crítico
- **Condición:** El ticket reporta un problema crítico del sistema
- **Acción:** Se escala inmediatamente y se activan protocolos de emergencia

## Postcondiciones

### Exitosa
- El ticket está resuelto y cerrado
- El usuario está satisfecho con la resolución
- La solución está documentada para referencia futura
- Las métricas de SLA se han cumplido
- El conocimiento se ha actualizado si es aplicable

### Fallida
- El ticket permanece abierto con estado apropiado
- Se han documentado las razones del fallo
- Se han tomado medidas correctivas
- Se ha notificado a los supervisores si es necesario

## Requerimientos Especiales

### Rendimiento
- Los tickets deben asignarse en menos de 5 minutos
- Las notificaciones deben enviarse en tiempo real
- La interfaz debe cargar en menos de 3 segundos

### Seguridad
- Solo el usuario creador y agentes asignados pueden ver detalles completos
- Las notas internas solo son visibles para el equipo de soporte
- Todos los accesos quedan registrados en auditoría

### Disponibilidad
- El sistema debe estar disponible 24/7
- Debe soportar múltiples agentes concurrentes
- Las interrupciones no deben afectar tickets en proceso

## Notas Técnicas
- Los tickets se almacenan en la entidad SupportTicket
- Los mensajes se registran en TicketMessage
- Los archivos adjuntos se gestionan en TicketAttachment
- Las reglas de escalación se configuran en EscalationRule

## Criterios de Aceptación
1. Los usuarios pueden crear tickets fácilmente con toda la información necesaria
2. Los tickets se asignan automáticamente de manera eficiente
3. Los agentes tienen todas las herramientas necesarias para gestionar tickets
4. Las escalaciones funcionan automática y manualmente según sea necesario
5. Las comunicaciones entre usuario y agente son fluidas y están registradas
6. Los SLA se monitorean y cumplen consistentemente
7. El proceso de cierre y evaluación es sencillo para los usuarios
8. Las métricas y reportes están disponibles para mejora continua
