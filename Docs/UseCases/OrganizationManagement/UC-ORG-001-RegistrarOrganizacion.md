# Caso de Uso Expandido: UC-ORG-001

| **Campo** | **Descripción** |
|-----------|-----------------|
| **ID** | UC-ORG-001 |
| **Descripción** | Registrar nueva organización de escalada en el sistema ClimbEdge |
| **Actores** | Usuario, Sistema de Notificaciones, Sistema de Validación |
| **Pre Condiciones** | El usuario debe estar autenticado en el sistema. El usuario debe tener un perfil completo. El nombre de la organización no debe existir en el sistema. |

## Pasos Básicos

1. El usuario accede a la sección "Crear Organización"
2. El sistema muestra el formulario de registro de organización
3. El usuario completa la información básica:
   - Nombre de la organización (obligatorio)
   - Nombre para mostrar (opcional)
   - Descripción
   - Tipo de organización (Gym, Club, Escuela, etc.)
   - Email de contacto
   - Teléfono
   - Sitio web (opcional)
4. El usuario completa la información de ubicación:
   - Dirección
   - Ciudad
   - Provincia/Estado
   - País
   - Código postal
   - Coordenadas (opcional, autocompletado por dirección)
5. El usuario especifica configuraciones adicionales:
   - Zona horaria
   - Horarios de atención
   - Servicios y comodidades
6. El usuario sube documentos opcionales:
   - Logo de la organización
   - Banner/imagen de portada
   - Documentos legales (licencias, seguros)
7. El usuario revisa la información ingresada
8. El usuario acepta los términos y condiciones
9. El usuario confirma el registro
10. El sistema valida la información ingresada
11. El sistema crea la organización con estado "Pendiente de Verificación"
12. El sistema asigna al usuario como propietario de la organización
13. El sistema envía confirmación por email
14. El sistema notifica al equipo de verificación
15. El sistema muestra mensaje de éxito con instrucciones de verificación

## Casos de Excepción

**E1: Nombre de organización duplicado**
- **Condición**: El nombre de la organización ya existe en el sistema
- **Acción**: El sistema muestra error "El nombre de organización ya está en uso" y sugiere nombres alternativos

**E2: Datos incompletos o inválidos**
- **Condición**: Faltan datos obligatorios o hay errores de validación
- **Acción**: El sistema muestra los errores específicos y resalta los campos con problemas

**E3: Error en la carga de archivos**
- **Condición**: Falla la carga de imágenes o documentos
- **Acción**: El sistema muestra error específico del archivo y permite continuar sin el archivo o reintentar

**E4: Error del sistema**
- **Condición**: Falla técnica durante el proceso
- **Acción**: El sistema guarda la información como borrador y permite reintentar más tarde

**E5: Usuario no autorizado**
- **Condición**: El usuario no tiene permisos suficientes
- **Acción**: El sistema muestra mensaje de acceso denegado y redirige a la página de inicio

## Validaciones/Reglas de Negocio

- El nombre de la organización debe ser único en el sistema
- Solo usuarios con perfil completo pueden crear organizaciones
- Todas las organizaciones inician en estado "Pendiente de Verificación"
- El creador de la organización se convierte automáticamente en propietario
- Los tipos de organización válidos son: Gym, ClimbingClub, School, Federation, Association, Guide_Service, Retailer
- Logo máximo 5MB (JPG/PNG), Banner máximo 10MB (JPG/PNG)
- Documentos máximo 20MB total por organización

## Post Condiciones

- Se crea un nuevo registro en la tabla Organization con estado "Pendiente de Verificación"
- Se crea un registro en OrganizationMember asignando al creador como propietario
- Se envía email de confirmación al usuario
- Se notifica al equipo de verificación para revisión
- Se registra la actividad en los logs del sistema
- El usuario puede acceder al panel básico de gestión de la organización

## Información Adicional

**Prioridad**: Alta
**Frecuencia de Uso**: Baja
**Complejidad**: Media
**Versión**: 1.0
**Fecha**: 2025-07-31
