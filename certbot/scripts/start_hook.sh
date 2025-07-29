#!/bin/sh
MARKER="/etc/letsencrypt/.initialized"

if [ ! -f "$MARKER" ]; then
  echo ">> Primera ejecución: emitiendo certificado y generando PFX"
  certbot certonly --webroot --webroot-path=/var/www/certbot \
    --email ${CERT_EMAIL} --agree-tos --no-eff-email \
    -d ${APP_DOMAIN} -d www.${APP_DOMAIN}
  /scripts/post_hook.sh
  touch "$MARKER"
else
  echo ">> Certbot-init ya se ejecutó anteriormente, omitiendo"
fi