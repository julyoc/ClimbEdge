# Caso de Uso Expandido: UC-040

| **Campo** | **Descripción** |
|-----------|-----------------|
| **ID** | UC-040 |
| **Descripción** | Crear una nueva zona de escalada outdoor en el sistema |
| **Actores** | Guía de Montaña, Administrador de Zona, Sistema |
| **Pre Condiciones** | El usuario debe tener permisos para crear zonas. Debe tener acceso a información geográfica válida. El sistema de mapas debe estar operativo. |

## Pasos Básicos

1. El guía accede a la sección "Zonas de Escalada"
2. El guía selecciona "Crear Nueva Zona"
3. El sistema muestra el formulario de creación de zona
4. El guía ingresa información básica:
   - Nombre de la zona (único)
   - Descripción general
   - País y región
   - Tipo de escalada (deportiva, tradicional, boulder, mixta)
5. El guía establece ubicación geográfica:
   - Utiliza mapa interactivo para marcar ubicación
   - Ingresa coordenadas GPS precisas
   - Define área de cobertura de la zona
6. El guía configura información de acceso:
   - Descripción de aproximación
   - Tiempo estimado de caminata
   - Dificultad del acceso
   - Restricciones de acceso o temporadas
7. El guía añade información logística:
   - Parking disponible
   - Servicios cercanos (agua, refugios)
   - Regulaciones locales
   - Contactos de emergencia locales
8. El guía configura visibilidad:
   - Zona pública (visible para todos)
   - Zona privada (solo para invitados)
   - Zona de acceso restringido
9. El guía puede subir archivos iniciales:
   - Fotos de la zona
   - Croquis de aproximación
   - Documentos de permisos
10. El sistema valida la información ingresada
11. El sistema verifica que no exista zona duplicada en ubicación cercana
12. El sistema crea el registro ClimbZone
13. El sistema asigna al usuario como administrador de la zona
14. El sistema confirma creación exitosa

## Casos de Excepción

**E1: Zona duplicada**
- **Condición**: Ya existe una zona muy cercana geográficamente
- **Acción**: El sistema sugiere editar zona existente o justificar nueva zona

**E2: Ubicación inválida**
- **Condición**: Las coordenadas GPS no son válidas o están en área prohibida
- **Acción**: El sistema solicita corrección de ubicación

**E3: Información insuficiente**
- **Condición**: Faltan datos mínimos requeridos para la zona
- **Acción**: El sistema destaca campos faltantes y bloquea creación

**E4: Conflicto de permisos**
- **Condición**: La zona está en área con restricciones de escalada
- **Acción**: El sistema advierte sobre restricciones y solicita documentación

**E5: Error en servicio de mapas**
- **Condición**: No se puede acceder al servicio de geolocalización
- **Acción**: El sistema permite ingreso manual de coordenadas

## Validaciones/Reglas de Negocio

- El nombre de la zona debe ser único globalmente
- Las coordenadas GPS deben ser válidas y precisas
- La descripción debe tener al menos 50 caracteres
- Las zonas privadas requieren justificación
- Se debe incluir información de contacto de emergencia
- Las fotos deben cumplir políticas de contenido

## Post Condiciones

- Se crea nueva zona en ClimbZone con toda la información
- El creador es asignado como administrador de la zona
- La zona está disponible para que otros usuarios añadan rutas
- Se registra la actividad de creación en logs del sistema
- La zona aparece en búsquedas según configuración de visibilidad

## Información Adicional

**Prioridad**: Alta
**Frecuencia de Uso**: Baja (solo para nuevas zonas)
**Complejidad**: Media
**Versión**: 1.0
**Fecha**: 2025-07-25
