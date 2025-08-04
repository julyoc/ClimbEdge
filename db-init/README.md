# Database Extensions - ClimbEdge

Este directorio contiene los scripts de inicialización para PostgreSQL que instalan y configuran las extensiones necesarias para ClimbEdge.

## Extensiones Instaladas

### 1. **pgcrypto**
- **Propósito**: Funciones criptográficas para PostgreSQL
- **Uso en ClimbEdge**: 
  - Encriptación de datos sensibles
  - Generación de hashes para passwords
  - Funciones de UUID

### 2. **PostGIS**
- **Propósito**: Extensión geoespacial para PostgreSQL
- **Uso en ClimbEdge**:
  - Almacenamiento de coordenadas de montañas
  - Cálculo de distancias entre rutas
  - Mapeo de zonas de escalada
  - Tracks GPS de rutas

### 3. **pg_cron**
- **Propósito**: Programador de tareas para PostgreSQL
- **Uso en ClimbEdge**:
  - Limpieza automática de logs
  - Tareas de mantenimiento de base de datos
  - Procesamiento batch de datos

## Scripts de Inicialización

1. **01-install-extensions.sql**: Instala todas las extensiones
2. **02-configure-pgcron.sql**: Configura pg_cron con tareas básicas
3. **03-verify-extensions.sql**: Verifica que las extensiones funcionan correctamente

## Configuración Docker

La imagen `postgis/postgis:17-3.5-alpine` incluye:
- PostgreSQL 17
- PostGIS 3.5
- Todas las dependencias necesarias

Los scripts se ejecutan automáticamente cuando se crea el contenedor por primera vez.

## Verificación

Después de levantar el contenedor, puedes verificar las extensiones con:

```sql
SELECT extname, extversion FROM pg_extension;
```

## Notas

- Los scripts se ejecutan en orden alfabético
- Las extensiones solo se instalan si no existen (IF NOT EXISTS)
- pg_cron requiere permisos especiales que se configuran via POSTGRES_INITDB_ARGS
