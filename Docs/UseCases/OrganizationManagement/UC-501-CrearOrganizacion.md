# Caso de Uso Expandido: UC-120

| **Campo** | **Descripción** |
|-----------|-----------------|
| **ID** | UC-120 |
| **Descripción** | Crear y configurar una nueva organización de escalada en el sistema |
| **Actores** | Usuario, Administrador, Sistema |
| **Pre Condiciones** | El usuario debe estar autenticado. El usuario debe tener permisos para crear organizaciones o ser administrador. El sistema debe tener tipos de organización configurados. |

## Pasos Básicos

1. El usuario accede a la sección "Organizaciones" del sistema
2. El usuario selecciona "Crear Nueva Organización"
3. El sistema muestra el formulario de creación de organización
4. El usuario completa la información básica:
   - Nombre de la organización (único en el sistema)
   - Nombre para mostrar (display name)
   - Tipo de organización (Gym, ClimbingClub, School, Federation, etc.)
   - Descripción de la organización
   - Email de contacto principal
   - Teléfono de contacto
   - Sitio web (opcional)
5. El usuario completa la información de ubicación:
   - Dirección física completa
   - Ciudad, provincia/estado
   - País
   - Código postal
   - Coordenadas geográficas (automáticas o manuales)
   - Zona horaria
6. El usuario configura las opciones de visibilidad:
   - Organización pública (visible en directorios)
   - Organización verificada (requiere proceso de verificación)
   - Configuración de privacidad
7. El usuario añade información adicional:
   - Fecha de fundación
   - Número de licencia o registro oficial
   - Número de identificación fiscal
   - Horarios de atención (formato JSON)
   - Enlaces a redes sociales
8. El usuario configura servicios y comodidades:
   - Servicios disponibles (alquiler equipo, clases, etc.)
   - Comodidades (estacionamiento, cafetería, tienda)
   - Certificaciones de seguridad
9. El usuario sube archivos de la organización:
   - Logo de la organización
   - Banner/imagen de portada
   - Documentos legales (licencias, seguros)
   - Manual de seguridad
10. El sistema valida toda la información ingresada
11. El sistema crea el registro de Organization en la base de datos
12. El sistema crea automáticamente al usuario como primer miembro con rol "Owner"
13. El sistema genera las instalaciones básicas predeterminadas según el tipo
14. El sistema envía notificación de organización creada
15. Si se marcó como "verificada", se inicia el proceso de verificación
16. El sistema redirige al usuario al panel de administración de la organización

## Casos de Excepción

**E1: Nombre de organización duplicado**
- **Condición**: Ya existe una organización con el mismo nombre
- **Acción**: El sistema muestra error y sugiere nombres alternativos

**E2: Información de ubicación inválida**
- **Condición**: La dirección no puede ser geocodificada
- **Acción**: El sistema solicita corrección o permite coordenadas manuales

**E3: Documentos requeridos faltantes**
- **Condición**: Para ciertos tipos de organización se requieren documentos específicos
- **Acción**: El sistema lista los documentos faltantes y permite subirlos

**E4: Límite de organizaciones excedido**
- **Condición**: El usuario ha alcanzado el límite de organizaciones que puede crear
- **Acción**: El sistema informa sobre el límite y opciones de upgrade

**E5: Error en verificación automática**
- **Condición**: Los servicios de verificación externa fallan
- **Acción**: La organización se crea sin verificar y se programa verificación manual

## Configuraciones Post-Creación

**Gestión de Miembros**:
1. El sistema crea roles básicos (Owner, Admin, Member, Guest)
2. Se configuran permisos predeterminados según el tipo de organización
3. Se habilita el sistema de invitaciones

**Configuración de Instalaciones**:
1. Se crean instalaciones básicas según el tipo:
   - Gym: Área de boulder, muro de escalada, entrenamiento
   - Club: Área de reuniones, almacén de equipo
   - Escuela: Aulas, área práctica, biblioteca
2. Cada instalación incluye configuración de capacidad y requisitos

**Integración con Tableros**:
1. Si es un gimnasio, se habilita la gestión de tableros
2. Se configuran permisos de creación y administración de tableros
3. Se establecen políticas de visibilidad de problemas

## Validaciones/Reglas de Negocio

- El nombre de organización debe ser único globalmente
- Los usuarios gratuitos pueden crear máximo 1 organización
- Los usuarios premium pueden crear hasta 5 organizaciones
- Ciertos tipos requieren verificación obligatoria (Federation, School)
- La información de contacto debe ser válida y verificable
- Los documentos legales son obligatorios para organizaciones comerciales
- Las coordenadas deben estar dentro de rangos válidos
- El timezone debe corresponder con la ubicación geográfica

## Post Condiciones

- Se crea registro en tabla Organization con estado activo
- Se crea OrganizationMember con el usuario como Owner
- Se generan OrganizationFacility predeterminadas según el tipo
- Se configuran permisos básicos del sistema
- Se registra la actividad en logs de auditoría
- El usuario recibe email de confirmación
- Si aplica, se inicia proceso de verificación
- La organización aparece en directorios (si es pública)

## Flujos de Verificación

**Verificación Automática**:
- Validación de email y teléfono
- Verificación de dirección física
- Validación de documentos mediante APIs externas

**Verificación Manual**:
- Revisión por parte del equipo de ClimbEdge
- Verificación de licencias y certificaciones
- Contacto directo con la organización

## Información Adicional

**Prioridad**: Alta
**Frecuencia de Uso**: Baja-Media
**Complejidad**: Alta
**Tiempo de Respuesta**: < 10 segundos
**Versión**: 1.0
**Fecha**: 2025-08-01

**Beneficios por Tipo de Organización**:
- **Gym**: Gestión de tableros, membresías, eventos
- **Club**: Organización de expediciones, gestión de miembros
- **School**: Programas de entrenamiento, certificaciones
- **Federation**: Gestión de competencias, rankings oficiales

**Métricas de Éxito**:
- % de organizaciones creadas exitosamente
- Tiempo promedio de proceso de verificación
- Nivel de actividad post-creación
- Satisfacción con el proceso de configuración inicial
