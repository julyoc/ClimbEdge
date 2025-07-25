# UC-402: Sistema de Chat en Vivo

## Información General
- **ID:** UC-402
- **Nombre:** Sistema de Chat en Vivo
- **Fecha:** 2025-07-25
- **Actor Principal:** Usuario / Agente de Soporte
- **Nivel:** Usuario

## Actores
- **Usuario:** Inicia y participa en sesiones de chat
- **Agente de Soporte:** Atiende consultas en chat en vivo
- **Supervisor de Soporte:** Supervisa y gestiona las colas de chat
- **Sistema de Chat:** Gestiona las sesiones y enrutamiento

## Precondiciones
- El usuario debe tener acceso al sistema (puede ser anónimo)
- Los agentes deben estar autenticados y disponibles
- El sistema de chat debe estar operativo
- Las reglas de enrutamiento deben estar configuradas

## Flujo Básico

### Paso 1: Solicitar Chat (Usuario)
1. El usuario accede al widget de chat en el sitio web
2. El sistema verifica:
   - Disponibilidad de agentes
   - Horarios de atención
   - Cola de espera actual
3. Si hay agentes disponibles:
   - Se muestra formulario de inicio de chat
   - Usuario proporciona: nombre, email (opcional), tema de consulta
4. Si no hay agentes disponibles:
   - Se muestra tiempo estimado de espera
   - Se ofrece alternativas (crear ticket, FAQ, callback)

### Paso 2: Enrutamiento y Asignación
5. El sistema:
   - Asigna la consulta a un agente según:
     - Especialización en el tema
     - Disponibilidad actual
     - Carga de trabajo
     - Idioma preferido
6. Se coloca en cola si todos los agentes están ocupados
7. Se genera sesión de chat única con ID de seguimiento

### Paso 3: Inicio de Conversación
8. Cuando un agente está disponible:
   - Se conecta automáticamente con el usuario
   - El agente recibe contexto inicial (tema, información del usuario)
   - Se establece la sesión de chat en tiempo real
   - Ambas partes reciben confirmación de conexión

### Paso 4: Gestión de la Conversación
9. Durante la conversación:
   - Los mensajes se envían en tiempo real
   - El agente puede:
     - Enviar mensajes de texto
     - Compartir archivos o enlaces
     - Transferir a otro agente especializado
     - Escalar al supervisor
     - Usar respuestas predefinidas
     - Acceder a base de conocimiento
   - El usuario puede:
     - Enviar mensajes y archivos
     - Valorar las respuestas
     - Solicitar transferencia

### Paso 5: Uso de Herramientas de Soporte
10. El agente tiene acceso a:
    - Historial de conversaciones previas del usuario
    - Base de conocimiento interna
    - Plantillas de respuestas frecuentes
    - Herramientas de escalación
    - Sistema de tickets (para crear seguimiento)

### Paso 6: Transferencia (Si es necesario)
11. Si se requiere transferencia:
    - El agente explica la razón al usuario
    - Selecciona agente especializado disponible
    - Transfiere el contexto completo
    - Se notifica al usuario sobre el cambio
    - El nuevo agente continúa sin interrupción

### Paso 7: Resolución y Cierre
12. Al resolver la consulta:
    - El agente resume la solución proporcionada
    - Confirma que el usuario no tiene más preguntas
    - Proporciona recursos adicionales si es útil
    - Ofrece crear ticket de seguimiento si es necesario
13. El usuario confirma satisfacción y finaliza el chat

### Paso 8: Post-Chat
14. Inmediatamente después del cierre:
    - Se envía transcripción por email (si se proporcionó)
    - Se solicita calificación de la experiencia
    - Se ofrece la opción de continuar por ticket
    - Se registran métricas de la sesión

## Flujos Alternativos

### 3a: Cola de Espera
- Si no hay agentes inmediatamente disponibles:
  - El usuario entra en cola con posición y tiempo estimado
  - Se proporcionan recursos mientras espera (FAQ, artículos)
  - Se ofrece opción de callback o crear ticket
  - Se actualiza la posición en cola en tiempo real

### 6a: Desconexión Accidental
- Si se pierde la conexión:
  - El sistema intenta reconectar automáticamente
  - Se preserva el historial de la conversación
  - Se notifica al agente sobre la desconexión
  - Se ofrece al usuario continuar donde se quedó

### 7a: Escalación de Urgencia
- Si surge un problema crítico:
  - El agente puede escalar inmediatamente al supervisor
  - Se marca la sesión como prioritaria
  - Se activan protocolos de emergencia si es necesario

## Excepciones

### E1: Sistema de Chat No Disponible
- **Condición:** Fallo técnico del sistema de chat
- **Acción:** Se redirige automáticamente al sistema de tickets con mensaje explicativo

### E2: Agente Desconectado
- **Condición:** El agente pierde conexión durante la conversación
- **Acción:** Se transfiere automáticamente a otro agente con contexto completo

### E3: Usuario Inactivo
- **Condición:** El usuario no responde por tiempo prolongado
- **Acción:** Se envían advertencias y finalmente se cierra la sesión con opción de reanudar

## Postcondiciones

### Exitosa
- La consulta del usuario ha sido resuelta satisfactoriamente
- Se ha registrado la transcripción completa de la conversación
- Las métricas de rendimiento se han actualizado
- El usuario ha proporcionado calificación de satisfacción
- Se ha creado seguimiento en base de conocimiento si es aplicable

### Fallida
- La sesión se ha cerrado prematuramente pero el contexto se preserva
- Se ha creado ticket de seguimiento automáticamente
- Se han registrado las razones del fallo
- Se ha notificado al supervisor si es necesario

## Requerimientos Especiales

### Rendimiento
- Los mensajes deben enviarse en menos de 500ms
- El sistema debe soportar hasta 100 chats concurrentes
- La conexión inicial debe establecerse en menos de 10 segundos

### Seguridad
- Las conversaciones deben encriptarse en tránsito
- Los datos del usuario deben protegerse según GDPR
- Los agentes solo pueden acceder a chats asignados

### Disponibilidad
- El widget de chat debe estar disponible 24/7
- Debe funcionar en todos los navegadores principales
- Debe tener fallback para usuarios con JavaScript deshabilitado

## Notas Técnicas
- Las sesiones se almacenan en LiveChatSession
- Los mensajes se registran en ChatMessage
- Las transferencias se registran para análisis
- Se mantienen métricas en tiempo real de performance

## Criterios de Aceptación
1. Los usuarios pueden iniciar chats fácilmente desde cualquier página
2. El enrutamiento asigna eficientemente a los agentes más apropiados
3. Las conversaciones son fluidas y en tiempo real
4. Los agentes tienen todas las herramientas necesarias para brindar soporte
5. Las transferencias son transparentes para el usuario
6. El sistema maneja desconexiones y errores graciosamente
7. Las métricas de satisfacción y rendimiento se capturan automáticamente
8. La experiencia es consistente en todos los dispositivos y navegadores
