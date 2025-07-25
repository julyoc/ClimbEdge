# Casos de Uso - Gestión de Problemas

Este módulo contiene los casos de uso para la gestión completa de problemas de escalada en ClimbEdge, incluyendo creación manual, generación con IA, validación y visualización.

## Visión General

El sistema de gestión de problemas es el corazón de la experiencia de escalada en ClimbEdge, proporcionando:
- Creación manual de problemas con herramientas intuitivas
- Generación automática de problemas usando inteligencia artificial
- Sistema de validación y moderación comunitaria
- Visualización interactiva con hardware LED
- Base de datos completa de problemas categorizados

## Casos de Uso Incluidos

### UC-020: Crear Problema Manual
**Actor Principal:** Usuario, Entrenador  
**Descripción:** Permite crear problemas de escalada manualmente seleccionando presas y definiendo características.  
**Complejidad:** Media  
**Prioridad:** Alta  

### UC-021: Generar Problema con IA
**Actor Principal:** Usuario Premium, Sistema IA  
**Descripción:** Generación automática de problemas usando modelos de inteligencia artificial entrenados.  
**Complejidad:** Alta  
**Prioridad:** Media  

### UC-022: Validar Problema
**Actor Principal:** Moderador, Comunidad  
**Descripción:** Sistema de validación y moderación de problemas creados por la comunidad.  
**Complejidad:** Media  
**Prioridad:** Media  

### UC-023: Visualizar Problema
**Actor Principal:** Usuario, Sistema Embebido  
**Descripción:** Visualización de problemas en el tablero usando LEDs y interface digital.  
**Complejidad:** Media  
**Prioridad:** Alta  

## Actores Principales

- **Usuario:** Escalador que crea y intenta problemas
- **Entrenador:** Especialista que crea problemas para entrenamiento
- **Usuario Premium:** Usuario con acceso a funciones avanzadas de IA
- **Moderador:** Usuario que valida y modera problemas
- **Sistema IA:** Inteligencia artificial para generación automática
- **Sistema Embebido:** Hardware que visualiza problemas con LEDs

## Entidades Principales

- **BoardProblem:** Problema principal con metadatos
- **BoardProblemItem:** Presas individuales que componen el problema
- **BoardProblemItemType:** Tipos de presas (inicio, fin, mano, pie)
- **BoardProblemAngle:** Ángulos del tablero para el problema
- **BoardProblemTag:** Etiquetas de categorización
- **FootRule:** Reglas de uso de pies específicas

## Tipos de Problemas

### Por Dificultad
- **Principiante (V0-V2):** Problemas de iniciación
- **Intermedio (V3-V5):** Problemas de desarrollo técnico
- **Avanzado (V6-V8):** Problemas de alta dificultad
- **Elite (V9+):** Problemas de nivel competitivo

### Por Estilo
- **Técnico:** Problemas que requieren técnica específica
- **Fuerza:** Problemas que enfatizan fuerza física
- **Resistencia:** Problemas largos que requieren resistencia
- **Explosivo:** Problemas con movimientos dinámicos
- **Equilibrio:** Problemas que requieren control corporal

### Por Enfoque de Entrenamiento
- **Finger Strength:** Enfoque en fuerza de dedos
- **Core:** Problemas que trabajan el core
- **Footwork:** Enfoque en trabajo de pies
- **Dynamic:** Movimientos dinámicos y coordinación
- **Mental:** Problemas que requieren estrategia

## Sistema de Creación Manual

### Interface de Diseño
- **Grid Visual:** Representación visual del tablero
- **Selección de Presas:** Click/touch para seleccionar presas
- **Tipo de Presa:** Asignación de roles (inicio, fin, intermedio)
- **Previsualización:** Vista previa del problema completo

### Herramientas de Creación
- **Brush Tool:** Selección múltiple de presas
- **Sequence Tool:** Definición de secuencia de movimientos
- **Mirror Tool:** Espejado horizontal de problemas
- **Template Tool:** Uso de plantillas predefinidas

### Metadatos del Problema
- **Nombre y Descripción:** Información básica
- **Dificultad Estimada:** Escala V o francesa
- **Tags:** Etiquetas de categorización
- **Ángulo del Tablero:** Inclinación requerida
- **Reglas de Pies:** Reglas específicas de footwork

## Sistema de Generación con IA

### Modelos Disponibles
- **Style Transfer:** Generación basada en estilo de problemas existentes
- **Difficulty Prediction:** Predicción automática de dificultad
- **Movement Pattern:** Análisis de patrones de movimiento
- **Aesthetic Generator:** Generación enfocada en estética visual

### Parámetros de Generación
- **Target Difficulty:** Dificultad objetivo del problema
- **Style Preference:** Estilo de escalada preferido
- **Movement Type:** Tipo de movimientos deseados
- **Density:** Densidad de presas en el problema
- **Symmetry:** Nivel de simetría del diseño

### Proceso de Generación
1. **Input Parameters:** Usuario define parámetros deseados
2. **Model Selection:** Sistema selecciona modelo apropiado
3. **Generation:** IA genera múltiples opciones
4. **Filtering:** Filtrado por viabilidad y calidad
5. **Presentation:** Mostrar opciones al usuario
6. **Refinement:** Permitir ajustes manuales

## Sistema de Validación

### Validación Automática
- **Geometric Validation:** Verificación de viabilidad geométrica
- **Difficulty Consistency:** Consistencia de dificultad estimada
- **Safety Check:** Verificación de seguridad del problema
- **Uniqueness:** Detección de duplicados

### Validación Comunitaria
- **Peer Review:** Revisión por otros usuarios
- **Test Attempts:** Intentos de validación práctica
- **Rating System:** Sistema de calificación comunitaria
- **Feedback Collection:** Recolección de comentarios

### Criterios de Validación
- **Climbability:** El problema debe ser escalable
- **Fair Difficulty:** La dificultad debe estar bien calibrada
- **Clear Rules:** Las reglas deben estar claras
- **Safety:** No debe presentar riesgos de seguridad

## Visualización de Problemas

### Hardware LEDs
- **Color Coding:** Códigos de color para tipos de presa
- **Animation:** Efectos visuales para guiar al escalador
- **Brightness Control:** Ajuste de intensidad según ambiente
- **Sequence Display:** Mostrar secuencia de movimientos

### Interface Digital
- **3D Visualization:** Vista tridimensional del problema
- **Movement Analysis:** Análisis de movimientos requeridos
- **Difficulty Breakdown:** Desglose de dificultad por sección
- **Alternative Views:** Vistas desde diferentes ángulos

## Flujos de Trabajo Típicos

### Creación de Problema
1. Seleccionar tablero y ángulo
2. Definir metadatos básicos (nombre, dificultad)
3. Seleccionar presas usando herramientas de diseño
4. Asignar tipos a cada presa (inicio, fin, intermedio)
5. Configurar reglas de pies
6. Previsualizar con LEDs
7. Guardar y publicar

### Generación con IA
1. Definir parámetros de generación
2. Seleccionar modelo de IA apropiado
3. Generar múltiples opciones
4. Revisar y seleccionar favorita
5. Realizar ajustes manuales si es necesario
6. Validar con previsualización
7. Guardar y compartir

### Validación Comunitaria
1. Problema se publica para validación
2. Comunidad intenta el problema
3. Se recolectan ratings y feedback
4. Moderadores revisan comentarios
5. Se ajusta dificultad si es necesario
6. Problema se marca como validado
7. Entra en base de datos oficial

## Métricas y Analytics

### Calidad de Problemas
- **Success Rate:** Porcentaje de completion por dificultad
- **Rating Average:** Calificación promedio de la comunidad
- **Attempt Frequency:** Frecuencia de intentos
- **Validation Time:** Tiempo hasta validación completa

### Uso del Sistema
- **Creation Rate:** Problemas creados por período
- **AI vs Manual:** Proporción de problemas por método
- **Popular Styles:** Estilos de problema más populares
- **User Engagement:** Engagement con problemas creados

### Performance de IA
- **Generation Success:** Tasa de éxito de generaciones
- **Quality Score:** Calidad de problemas generados
- **Model Accuracy:** Precisión de predicción de dificultad
- **User Satisfaction:** Satisfacción con problemas de IA

## Consideraciones Técnicas

### Performance
- **Real-time Visualization:** Visualización en tiempo real con LEDs
- **Fast Generation:** Generación rápida con IA (< 30 segundos)
- **Efficient Storage:** Almacenamiento eficiente de problemas
- **Quick Search:** Búsqueda rápida en base de datos

### Escalabilidad
- **Batch Processing:** Procesamiento en lotes para validación
- **Distributed AI:** IA distribuida para generación masiva
- **Caching:** Cache de problemas populares
- **CDN:** Distribución global de contenido visual

### Calidad
- **Duplicate Detection:** Detección automática de duplicados
- **Quality Metrics:** Métricas automáticas de calidad
- **Continuous Learning:** Mejora continua de modelos de IA
- **Community Moderation:** Moderación comunitaria efectiva
