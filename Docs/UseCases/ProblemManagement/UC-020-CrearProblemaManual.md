# Caso de Uso Expandido: UC-020

| **Campo** | **Descripción** |
|-----------|-----------------|
| **ID** | UC-020 |
| **Descripción** | Crear un problema de escalada manualmente en un tablero |
| **Actores** | Creador de Problemas, Sistema Embebido, Sistema |
| **Pre Condiciones** | El usuario debe tener permisos de creación en el tablero. El tablero debe estar configurado con presas disponibles. El hardware del tablero debe estar conectado (opcional). |

## Pasos Básicos

1. El usuario accede al tablero donde desea crear el problema
2. El usuario selecciona "Crear Nuevo Problema"
3. El sistema muestra la interfaz de creación de problemas con vista del tablero
4. El usuario ingresa información básica del problema:
   - Nombre del problema
   - Descripción (opcional)
   - Nivel de dificultad estimado
   - Ángulo del tablero para el problema
5. El usuario selecciona el modo de definición de presas
6. El usuario define las presas de inicio:
   - Hace clic en las presas que serán puntos de partida
   - El sistema las marca visualmente como "inicio"
7. El usuario define las presas de finalización:
   - Selecciona las presas que marcan el final del problema
   - El sistema las marca como "fin"
8. El usuario define las presas intermedias:
   - Selecciona presas que se pueden usar como manos
   - Selecciona presas que se pueden usar como pies
   - Marca presas como zonas de descanso (opcional)
9. El usuario configura la secuencia (opcional):
   - Define el orden específico de algunas presas
   - Marca presas obligatorias vs opcionales
10. El sistema calcula automáticamente la dificultad basada en el modelo matemático
11. El usuario revisa y ajusta la dificultad si es necesario
12. El usuario añade etiquetas descriptivas (técnico, potencia, resistencia, etc.)
13. El usuario guarda el problema
14. El sistema valida que el problema tenga al menos inicio y fin
15. El sistema almacena el problema en la base de datos
16. El sistema muestra confirmación de creación exitosa

## Casos de Excepción

**E1: Problema incompleto**
- **Condición**: No se han definido presas de inicio o fin
- **Acción**: El sistema muestra error y destaca las secciones faltantes

**E2: Problema imposible**
- **Condición**: Las presas seleccionadas hacen el problema físicamente imposible
- **Acción**: El sistema muestra advertencia y sugiere revisión

**E3: Nombre duplicado**
- **Condición**: Ya existe un problema con el mismo nombre en el tablero
- **Acción**: El sistema solicita un nombre diferente

**E4: Error de conectividad hardware**
- **Condición**: Se pierde conexión con el tablero durante la creación
- **Acción**: El sistema permite continuar sin vista en tiempo real

**E5: Tablero sin configurar**
- **Condición**: El tablero no tiene presas configuradas
- **Acción**: El sistema redirige a configuración de tablero

## Validaciones/Reglas de Negocio

- Debe tener al menos una presa de inicio y una de fin
- Las presas de inicio y fin no pueden ser las mismas
- La dificultad calculada debe estar entre 1 y 32
- El nombre del problema debe ser único en el tablero
- Máximo 50 presas por problema
- Las presas deben ser alcanzables según las reglas de escalada

## Post Condiciones

- Se crea un nuevo registro en BoardProblem
- Se crean los registros correspondientes en BoardProblemItem
- Se genera BoardProblemAngle con la dificultad calculada
- El problema está disponible para ser intentado por usuarios
- Se registra la actividad de creación en los logs
- El problema puede ser visualizado en el tablero

## Información Adicional

**Prioridad**: Alta
**Frecuencia de Uso**: Alta
**Complejidad**: Alta
**Versión**: 1.0
**Fecha**: 2025-07-25
