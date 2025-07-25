# Caso de Uso Expandido: UC-011

| **Campo** | **Descripción** |
|-----------|-----------------|
| **ID** | UC-011 |
| **Descripción** | Configurar las propiedades técnicas y características de un tablero de escalada |
| **Actores** | Propietario de Tablero, Administrador de Tablero, Sistema |
| **Pre Condiciones** | El tablero debe existir en el sistema. El usuario debe tener permisos de administración en el tablero. El tablero no debe tener sesiones activas durante la configuración. |

## Pasos Básicos

1. El propietario accede a la configuración del tablero desde "Mis Tableros"
2. El sistema muestra la interfaz de configuración con las secciones:
   - Configuración básica
   - Dimensiones y diseño
   - Tipos de presas
   - Ángulos disponibles
   - Configuración de hardware
3. El propietario configura las dimensiones básicas:
   - Número de columnas (4-20)
   - Número de filas (4-20)
   - Ancho total del tablero (en metros)
   - Alto total del tablero (en metros)
4. El propietario define el espaciado entre presas:
   - Espaciado horizontal (10-50 cm)
   - Espaciado vertical (10-50 cm)
   - Tipo de cuadrícula (regular o escalonada)
   - Offset para cuadrícula escalonada
5. El propietario configura los ángulos disponibles:
   - Añade ángulos específicos (ej: 20°, 30°, 45°)
   - Define descripciones para cada ángulo
   - Establece el ángulo por defecto
6. El propietario configura tipos de presas disponibles:
   - Selecciona tipos predefinidos (regletas, cantos, romos)
   - Define dificultad base por tipo
   - Asigna iconos a cada tipo
7. El propietario configura texturas y materiales:
   - Asocia texturas disponibles
   - Define materiales de las presas
   - Establece multiplicadores de dificultad
8. El sistema valida que la configuración sea coherente
9. El sistema recalcula las posiciones de todas las presas
10. El sistema actualiza la configuración en BoardConfig
11. El sistema regenera los BoardItems según nueva configuración
12. El sistema confirma que la configuración ha sido guardada

## Casos de Excepción

**E1: Configuración inválida**
- **Condición**: Las dimensiones o espaciados resultan en configuración imposible
- **Acción**: El sistema muestra errores específicos y sugiere valores válidos

**E2: Sesión activa**
- **Condición**: Hay usuarios escalando en el tablero durante la configuración
- **Acción**: El sistema bloquea cambios y muestra cuando estará disponible

**E3: Hardware incompatible**
- **Condición**: La nueva configuración no es compatible con el hardware conectado
- **Acción**: El sistema advierte sobre incompatibilidades y permite continuar o cancelar

**E4: Problemas existentes incompatibles**
- **Condición**: Hay problemas creados que se vuelven inválidos con la nueva configuración
- **Acción**: El sistema lista problemas afectados y permite migrarlos o eliminarlos

## Validaciones/Reglas de Negocio

- Las dimensiones mínimas son 4x4 y máximas 20x20
- El espaciado debe permitir al menos 15cm entre centros de presas
- Debe existir al menos un ángulo configurado
- Los tipos de presas deben tener dificultad entre 1 y 10
- Los cambios de configuración invalidan problemas incompatibles
- Se requiere confirmación para cambios que afecten problemas existentes

## Post Condiciones

- La configuración del tablero se actualiza en BoardConfig
- Se regeneran todos los BoardItems según nueva configuración
- Los problemas existentes se validan contra nueva configuración
- El hardware conectado recibe la nueva configuración
- Se registra la actividad de configuración en logs
- El tablero está listo para crear nuevos problemas

## Información Adicional

**Prioridad**: Alta
**Frecuencia de Uso**: Baja (solo al configurar inicialmente)
**Complejidad**: Alta
**Versión**: 1.0
**Fecha**: 2025-07-25
