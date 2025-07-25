# Caso de Uso Expandido: UC-041

| **Campo** | **Descripción** |
|-----------|-----------------|
| **ID** | UC-041 |
| **Descripción** | Documentar una ruta de escalada con información detallada, fotos y croquis |
| **Actores** | Guía de Montaña, Escalador Experimentado, Sistema |
| **Pre Condiciones** | Debe existir una zona de escalada. El usuario debe tener permisos para añadir rutas. La ruta debe existir físicamente. |

## Pasos Básicos

1. El usuario accede a la zona de escalada correspondiente
2. El usuario selecciona "Añadir Nueva Ruta"
3. El sistema muestra el formulario de documentación de ruta
4. El usuario ingresa información básica:
   - Nombre de la ruta
   - Descripción detallada
   - Graduación/dificultad según escala local
   - Número de largos (pitches)
   - Longitud total aproximada
5. El usuario documenta características técnicas:
   - Tipo de escalada (deportiva, tradicional, mixta)
   - Tipo de roca y características geológicas
   - Protección requerida (friends, fisureros, cintas)
   - Anclajes de reunión
6. El usuario añade información histórica:
   - Primera ascensión y escaladores
   - Fecha de apertura
   - Repeticiones notables
   - Evolución de la graduación
7. El usuario documenta acceso específico:
   - Ubicación exacta del inicio
   - Aproximación desde parking
   - Identificación visual de la ruta
8. El usuario añade información de seguridad:
   - Peligros específicos (piedras sueltas, hielo)
   - Condiciones recomendadas
   - Épocas prohibidas o desaconsejadas
   - Equipamiento de seguridad necesario
9. El usuario sube documentación visual:
   - Fotos de la ruta marcada
   - Croquis detallado del recorrido
   - Fotos de reuniones y descuelgues
   - Videos de secciones clave (opcional)
10. El usuario añade información de descenso:
    - Tipo de descenso (rapel, caminando, combinado)
    - Longitud de cuerdas necesarias
    - Anclajes de rapel
11. El sistema valida completitud de información
12. El sistema crea registro en ClimbRoute
13. El sistema almacena archivos en ClimbRouteFile
14. El sistema confirma documentación exitosa

## Casos de Excepción

**E1: Ruta duplicada**
- **Condición**: Ya existe una ruta con nombre similar en la misma zona
- **Acción**: El sistema sugiere revisar rutas existentes o usar nombre diferenciado

**E2: Graduación controvertida**
- **Condición**: La graduación difiere significativamente del consenso
- **Acción**: El sistema permite documentar pero marca para revisión

**E3: Información de seguridad insuficiente**
- **Condición**: Faltan datos críticos de seguridad para ruta peligrosa
- **Acción**: El sistema requiere completar información antes de publicar

**E4: Archivos demasiado grandes**
- **Condición**: Las fotos o videos exceden límites de tamaño
- **Acción**: El sistema comprime automáticamente o solicita archivos menores

**E5: Conflicto de autoría**
- **Condición**: Se disputa quién realizó la primera ascensión
- **Acción**: El sistema permite documentar múltiples versiones y marca para revisión

## Validaciones/Reglas de Negocio

- La graduación debe corresponder a escalas válidas reconocidas
- Se requiere información mínima de seguridad para rutas expuestas
- Las fotos deben mostrar claramente el recorrido de la ruta
- La información de primera ascensión debe ser verificable cuando posible
- Los croquis deben seguir estándares de simbología reconocidos

## Post Condiciones

- La ruta queda completamente documentada en el sistema
- Otros escaladores pueden acceder a toda la información
- La ruta aparece en búsquedas y listados de la zona
- Se establece base de datos para futuras ascensiones
- La documentación contribuye al conocimiento colectivo de escalada

## Información Adicional

**Prioridad**: Alta
**Frecuencia de Uso**: Media
**Complejidad**: Alta
**Versión**: 1.0
**Fecha**: 2025-07-25
