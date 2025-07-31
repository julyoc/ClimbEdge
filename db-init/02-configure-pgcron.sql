-- Configuración adicional para pg_cron
-- Este script configura pg_cron para funcionar correctamente

-- Conectar a la base de datos principal
\c climbedge;

-- Configurar pg_cron para usar la base de datos actual
SELECT cron.schedule('cleanup-logs', '0 2 * * *', 'DELETE FROM logs WHERE timestamp < NOW() - INTERVAL ''30 days''');

-- Verificar la configuración de pg_cron
SELECT * FROM cron.job;

-- Mensaje de confirmación
DO $$
BEGIN
    RAISE NOTICE 'pg_cron configurado correctamente';
    RAISE NOTICE 'Tarea de ejemplo programada: limpieza de logs diaria a las 2:00 AM';
END $$;
