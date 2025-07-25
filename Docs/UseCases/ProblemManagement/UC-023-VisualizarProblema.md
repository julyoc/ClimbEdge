# Caso de Uso Expandido: UC-023

| **Campo** | **Descripción** |
|-----------|-----------------|
| **ID** | UC-023 |
| **Descripción** | Visualizar un problema de escalada en diferentes formatos y perspectivas |
| **Actores** | Usuario, Sistema Embebido, Sistema |
| **Pre Condiciones** | Debe existir un problema de escalada válido. El usuario debe tener acceso al tablero. El tablero debe estar configurado correctamente. |

## Pasos Básicos

1. El usuario selecciona un problema específico desde la lista de problemas
2. El sistema muestra la información básica del problema:
   - Nombre y descripción
   - Dificultad y ángulo
   - Creador y fecha de creación
   - Estadísticas (intentos, completados)
3. El usuario selecciona el modo de visualización deseado:
   - Vista 2D del tablero
   - Vista 3D renderizada
   - Iluminación en tablero físico (si disponible)
   - Vista de secuencia paso a paso
4. Para vista 2D:
   - El sistema muestra representación gráfica del tablero
   - Las presas se marcan con colores según su función:
     * Verde: presas de inicio
     * Rojo: presas de finalización  
     * Azul: presas de mano
     * Amarillo: presas de pie
     * Violeta: zonas de descanso
5. Para vista 3D:
   - El sistema renderiza modelo tridimensional del tablero
   - El usuario puede rotar y hacer zoom
   - Se muestran ángulos de alcance y distancias
6. Para iluminación física (si hardware disponible):
   - El sistema envía comando al hardware embebido
   - Los LEDs WS2812B se iluminan según el problema
   - Se puede mostrar secuencia animada paso a paso
7. El usuario puede interactuar con la visualización:
   - Hacer clic en presas para ver detalles
   - Alternar entre vista completa y secuencial
   - Exportar imagen o captura de pantalla
8. El sistema muestra información adicional:
   - Etiquetas y características del problema
   - Comentarios de otros escaladores
   - Videos o fotos de ascensiones exitosas

## Casos de Excepción

**E1: Hardware no conectado**
- **Condición**: Se solicita iluminación pero el tablero no está conectado
- **Acción**: El sistema muestra solo visualización digital y notifica estado hardware

**E2: Problema con configuración incompleta**
- **Condición**: Al problema le faltan datos para visualización completa
- **Acción**: El sistema muestra lo disponible y marca campos faltantes

**E3: Error en renderizado 3D**
- **Condición**: Falla la generación del modelo tridimensional
- **Acción**: El sistema vuelve a vista 2D y registra el error

**E4: Conflicto de hardware**
- **Condición**: Otro usuario está usando el tablero para visualización
- **Acción**: El sistema informa sobre la ocupación y permite reservar turno

**E5: Presas no encontradas**
- **Condición**: Algunas presas del problema no existen en la configuración actual
- **Acción**: El sistema marca presas problemáticas y sugiere actualizar problema

## Validaciones/Reglas de Negocio

- Solo usuarios con acceso al tablero pueden visualizar sus problemas
- La iluminación física tiene prioridad sobre sesiones activas
- Los colores de visualización deben ser consistentes en todo el sistema
- Las exportaciones de imagen respetan las configuraciones de privacidad
- La visualización 3D requiere navegador compatible con WebGL

## Post Condiciones

- El usuario comprende completamente el problema visualizado
- Si se usa hardware, los LEDs muestran el problema correctamente
- La visualización ayuda al usuario a planificar su intento
- Se registra la actividad de visualización para estadísticas
- El problema está listo para ser intentado por el usuario

## Información Adicional

**Prioridad**: Alta
**Frecuencia de Uso**: Muy Alta
**Complejidad**: Media
**Tiempo de Respuesta**: < 3 segundos para vista 2D, < 10 segundos para 3D
**Versión**: 1.0
**Fecha**: 2025-07-25
