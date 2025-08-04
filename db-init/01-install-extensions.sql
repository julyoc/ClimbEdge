-- Script de inicialización para instalar extensiones en PostgreSQL
-- Este script se ejecuta automáticamente cuando se crea la base de datos

-- Conectar a la base de datos principal
\c climbedge;

-- Instalar extensión pgcrypto para funciones criptográficas
CREATE EXTENSION IF NOT EXISTS pgcrypto;

-- Instalar extensión PostGIS para datos geoespaciales
CREATE EXTENSION IF NOT EXISTS postgis;
CREATE EXTENSION IF NOT EXISTS postgis_topology;

-- Instalar extensión pg_cron para tareas programadas
CREATE EXTENSION IF NOT EXISTS pg_cron;

-- Verificar que las extensiones se instalaron correctamente
SELECT extname, extversion FROM pg_extension WHERE extname IN ('pgcrypto', 'postgis', 'postgis_topology', 'pg_cron');

-- Mostrar mensaje de confirmación
DO $$
BEGIN
    RAISE NOTICE 'Extensiones instaladas correctamente:';
    RAISE NOTICE '- pgcrypto: Funciones criptográficas';
    RAISE NOTICE '- postgis: Datos geoespaciales';
    RAISE NOTICE '- postgis_topology: Topología geoespacial';
    RAISE NOTICE '- pg_cron: Tareas programadas';
END $$;
