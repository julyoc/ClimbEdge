# Caso de Uso Expandido: UC-010

| **Campo** | **Descripción** |
|-----------|-----------------|
| **ID** | UC-010 |
| **Descripción** | Crear un nuevo tablero de escalada en el sistema |
| **Actores** | Propietario de Tablero, Sistema |
| **Pre Condiciones** | El usuario debe estar autenticado y tener permisos para crear tableros. El sistema debe tener configuraciones de tablero disponibles. |

## Pasos Básicos

1. El usuario accede a la sección "Mis Tableros" del sistema
2. El usuario selecciona la opción "Crear Nuevo Tablero"
3. El sistema muestra el formulario de creación de tablero
4. El usuario ingresa la información básica del tablero:
   - Nombre del tablero (único para el usuario)
   - Descripción del tablero
   - Visibilidad (Público, Privado, Protegido, Oculto)
5. El usuario selecciona una configuración de tablero predeterminada o crea una personalizada:
   - Dimensiones (columnas x filas)
   - Tipo de cuadrícula (regular o escalonada)
   - Espaciado entre presas
   - Ángulos disponibles
6. El sistema valida la información ingresada
7. El sistema crea el registro del tablero en la base de datos
8. El sistema asigna automáticamente al usuario como propietario del tablero
9. El sistema crea la configuración del tablero (BoardConfig)
10. El sistema genera las posiciones de las presas según la configuración
11. El sistema crea los elementos del tablero (BoardItem) para cada posición
12. El sistema muestra mensaje de confirmación de creación exitosa
13. El sistema redirige al usuario a la página de configuración del tablero

## Casos de Excepción

**E1: Nombre de tablero duplicado**
- **Condición**: El usuario ya tiene un tablero con el mismo nombre
- **Acción**: El sistema muestra error y solicita un nombre diferente

**E2: Configuración inválida**
- **Condición**: Las dimensiones o configuraciones son inválidas
- **Acción**: El sistema muestra los errores específicos y permite corregir

**E3: Límite de tableros excedido**
- **Condición**: El usuario ha alcanzado el límite de tableros permitidos
- **Acción**: El sistema muestra mensaje informativo y opciones de upgrade

**E4: Error en creación de elementos**
- **Condición**: Falla al generar las presas del tablero
- **Acción**: El sistema revierte la creación y muestra mensaje de error

## Validaciones/Reglas de Negocio

- El nombre del tablero debe ser único por usuario
- Las dimensiones mínimas son 4x4 y máximas 20x20
- El espaciado entre presas debe estar entre 10cm y 50cm
- Solo se permiten 5 tableros por usuario en plan básico
- La descripción no puede exceder 500 caracteres
- Los tableros públicos son visibles para todos los usuarios

## Post Condiciones

- Se crea un nuevo registro en la tabla Board
- Se crea la configuración asociada en BoardConfig
- Se generan todos los BoardItem según las dimensiones
- El usuario es asignado como propietario con rol Owner
- Se registra la actividad en los logs del sistema
- El tablero está disponible para configuración adicional

## Información Adicional

**Prioridad**: Alta
**Frecuencia de Uso**: Media
**Complejidad**: Alta
**Versión**: 1.0
**Fecha**: 2025-07-25
