# Caso de Uso Expandido: UC-101

| **Campo** | **Descripción** |
|-----------|-----------------|
| **ID** | UC-101 |
| **Descripción** | Crear nueva expedición a montaña |
| **Actores** | Montañista, Guía de Montaña, Organizador de Expediciones, Sistema |
| **Pre Condiciones** | El usuario debe estar autenticado. Debe existir al menos una montaña y ruta registrada en el sistema. El usuario debe tener permisos para crear expediciones. |

## Pasos Básicos

1. El organizador accede al módulo de expediciones
2. El sistema muestra la opción "Crear Nueva Expedición"
3. El organizador selecciona "Crear Nueva Expedición"
4. El sistema muestra el formulario de creación con las siguientes secciones:
   - Información básica
   - Selección de montaña y ruta
   - Fechas y duración
   - Límites de participantes
   - Configuración de costos
5. El organizador completa la información básica:
   - Nombre de la expedición
   - Descripción detallada
   - Tipo de actividad (montañismo, escalada, etc.)
6. El organizador selecciona la montaña objetivo del catálogo disponible
7. El sistema muestra las rutas disponibles para la montaña seleccionada
8. El organizador selecciona la ruta específica (opcional)
9. El organizador establece las fechas:
   - Fecha de inicio
   - Fecha de finalización
   - Duración planificada en días
10. El organizador configura los límites de participantes:
    - Número mínimo de participantes
    - Número máximo de participantes
    - Nivel de experiencia requerido
11. El organizador establece información de costos:
    - Costo por participante
    - Moneda
    - Qué incluye el costo
12. El organizador configura opciones adicionales:
    - Si se requiere permiso especial
    - Si se requiere seguro obligatorio
    - Si la expedición es pública o privada
    - Fecha límite de registro
13. El sistema valida toda la información ingresada
14. El sistema crea la expedición con estado "Planificación"
15. El sistema genera automáticamente un plan de seguridad básico
16. El sistema asigna al organizador como líder de la expedición
17. El sistema muestra confirmación de creación exitosa
18. El sistema redirige al panel de gestión de la expedición

## Casos de Excepción

**E1: Información requerida faltante**
- **Condición**: No se han completado todos los campos obligatorios
- **Acción**: El sistema resalta los campos faltantes y muestra mensajes de error específicos

**E2: Fechas inválidas**
- **Condición**: La fecha de inicio es posterior a la fecha de fin, o las fechas son anteriores a la fecha actual
- **Acción**: El sistema muestra error de validación y solicita corrección de fechas

**E3: Límites de participantes inválidos**
- **Condición**: El número mínimo es mayor que el máximo, o los números son negativos
- **Acción**: El sistema muestra error de validación y solicita corrección

**E4: Montaña o ruta no disponible**
- **Condición**: La montaña o ruta seleccionada no está disponible por restricciones temporales o permisos
- **Acción**: El sistema informa sobre las restricciones y sugiere alternativas

**E5: Usuario sin permisos suficientes**
- **Condición**: El usuario no tiene permisos para crear expediciones en la ubicación seleccionada
- **Acción**: El sistema informa sobre los permisos requeridos y opciones para obtenerlos

## Validaciones/Reglas de Negocio

- **R1**: El nombre de la expedición debe ser único para el organizador
- **R2**: La fecha de inicio debe ser al menos 48 horas después de la fecha actual
- **R3**: La duración máxima de una expedición es de 365 días
- **R4**: El número mínimo de participantes debe ser al menos 1
- **R5**: El número máximo de participantes no puede exceder 50 personas
- **R6**: Si se requiere permiso, debe proporcionarse información de contacto con las autoridades
- **R7**: El costo debe ser un valor positivo o cero (expediciones gratuitas)
- **R8**: El nivel de experiencia requerido debe coincidir con la dificultad de la ruta
- **R9**: Las expediciones públicas son visibles para todos los usuarios registrados
- **R10**: Las expediciones privadas solo son visibles por invitación

## Post Condiciones

- Se crea un nuevo registro de expedición en la base de datos
- Se genera automáticamente un plan de seguridad básico
- Se crea un itinerario vacío listo para planificación
- Se establecen las configuraciones de equipamiento por defecto según el tipo de actividad
- Se envía notificación al organizador confirmando la creación
- Si la expedición es pública, se puede mostrar en las búsquedas de otros usuarios

## Notas Técnicas

- El sistema debe validar la disponibilidad de la montaña en las fechas seleccionadas
- Se debe verificar si se requieren permisos especiales según la ubicación y temporada
- El sistema debe calcular automáticamente factores de riesgo basados en la ruta y fechas
- Se debe integrar con sistemas meteorológicos para alertas tempranas
- Todas las acciones deben quedar registradas en logs de auditoría

## Criterios de Aceptación

1. ✅ El formulario de creación debe cargar en menos de 3 segundos
2. ✅ Todas las validaciones deben ejecutarse en tiempo real
3. ✅ La expedición creada debe aparecer inmediatamente en el panel del organizador
4. ✅ Se debe enviar confirmación por email al organizador
5. ✅ El sistema debe soportar la creación simultánea de múltiples expediciones
6. ✅ Los campos de fecha deben incluir selector de calendario
7. ✅ La selección de montaña debe incluir filtros por región, dificultad y temporada
