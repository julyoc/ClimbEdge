# Caso de Uso Expandido: UC-030

| **Campo** | **Descripción** |
|-----------|-----------------|
| **ID** | UC-030 |
| **Descripción** | Iniciar una sesión de escalada en un tablero o zona específica |
| **Actores** | Escalador, Sistema Embebido, Sistema |
| **Pre Condiciones** | El usuario debe estar autenticado. Debe tener acceso al tablero o zona seleccionada. El hardware del tablero debe estar operativo (para tableros físicos). |

## Pasos Básicos

1. El usuario accede a la sección "Nueva Sesión" desde el dashboard
2. El sistema muestra las opciones disponibles:
   - Tableros disponibles (propios y compartidos)
   - Zonas de escalada registradas
3. El usuario selecciona el tipo de sesión:
   - Sesión en tablero indoor
   - Sesión en zona de escalada outdoor
4. El usuario selecciona el tablero o zona específica
5. Si es un tablero con hardware:
   - El sistema verifica la conectividad con el hardware
   - El sistema establece conexión WebSocket con el dispositivo embebido
6. El usuario configura parámetros de la sesión:
   - Objetivo de la sesión (entrenamiento, evaluación, diversión)
   - Duración estimada
   - Notas iniciales (opcional)
7. El usuario confirma el inicio de sesión
8. El sistema crea el registro de UserSession
9. El sistema registra la hora de inicio (StartedAt)
10. Si hay hardware conectado:
    - El sistema envía comando de inicialización al dispositivo
    - El hardware confirma estado operativo
11. El sistema muestra la interfaz de sesión activa
12. El sistema habilita el tracking de progreso
13. El sistema muestra los problemas disponibles para intentar
14. El usuario puede comenzar a escalar

## Casos de Excepción

**E1: Hardware no disponible**
- **Condición**: El tablero físico no responde o está desconectado
- **Acción**: El sistema permite continuar en modo virtual sin tracking automático

**E2: Tablero ocupado**
- **Condición**: Otro usuario tiene una sesión activa en el mismo tablero
- **Acción**: El sistema muestra mensaje y permite unirse como observador o esperar

**E3: Sin permisos de acceso**
- **Condición**: El usuario no tiene permisos para acceder al tablero/zona
- **Acción**: El sistema muestra mensaje de acceso denegado y sugiere solicitar acceso

**E4: Sesión previa no cerrada**
- **Condición**: El usuario tiene una sesión anterior sin finalizar
- **Acción**: El sistema pregunta si desea continuar la sesión anterior o iniciar nueva

**E5: Zona no disponible**
- **Condición**: La zona de escalada está marcada como cerrada o inaccesible
- **Acción**: El sistema muestra información de estado y fechas de reapertura

## Validaciones/Reglas de Negocio

- Solo se permite una sesión activa por usuario
- Las sesiones en tableros físicos requieren hardware operativo
- Las sesiones automáticamente se marcan como finalizadas después de 4 horas de inactividad
- El usuario debe confirmar la ubicación para sesiones outdoor
- Se requiere conectividad a internet para sincronización de datos

## Post Condiciones

- Se crea un registro activo en UserSession con StartedAt definido
- El hardware del tablero está sincronizado y listo (si aplica)
- El usuario puede intentar problemas y registrar progreso
- El sistema monitorea la actividad durante la sesión
- Se inicializa el tracking de tiempo y rendimiento
- La sesión aparece en el historial del usuario

## Información Adicional

**Prioridad**: Alta
**Frecuencia de Uso**: Muy Alta
**Complejidad**: Media
**Versión**: 1.0
**Fecha**: 2025-07-25
