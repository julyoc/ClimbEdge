-- Script de verificación de extensiones
-- Verifica que todas las extensiones estén instaladas y funcionando

-- Conectar a la base de datos principal
\c climbedge;

-- Verificar pgcrypto
SELECT 'pgcrypto funciona correctamente' as test_pgcrypto, 
       encode(digest('test', 'sha256'), 'hex') as hash_test;

-- Verificar PostGIS
SELECT 'PostGIS funciona correctamente' as test_postgis,
       postgis_version() as postgis_version,
       ST_AsText(ST_Point(-74.006, 40.7128)) as coordinates_test;

-- Verificar pg_cron
SELECT 'pg_cron funciona correctamente' as test_pgcron,
       count(*) as total_jobs
FROM cron.job;

-- Mostrar todas las extensiones instaladas
SELECT extname as extension_name, 
       extversion as version,
       'Instalada correctamente' as status
FROM pg_extension 
WHERE extname IN ('pgcrypto', 'postgis', 'postgis_topology', 'pg_cron')
ORDER BY extname;
