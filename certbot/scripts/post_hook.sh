#!/bin/sh
openssl pkcs12 -export \
  -inkey "/etc/letsencrypt/live/${APP_DOMAIN}/privkey.pem" \
  -in "/etc/letsencrypt/live/${APP_DOMAIN}/cert.pem" \
  -certfile "/etc/letsencrypt/live/${APP_DOMAIN}/chain.pem" \
  -out "/certs/${APP_DOMAIN}.pfx" -passout pass:"${CERT_PASSWORD}"
echo "Certificado convertido a PFX y guardado en /certs/${APP_DOMAIN}.pfx"
echo "Recuerda cambiar 'tu-dominio.com' y 'tuPassword' por tus valores reales."
echo "El archivo PFX se encuentra en /certs/${APP_DOMAIN}.pfx"
echo "Puedes copiarlo a tu máquina local con: docker cp climbedge-certbot:/certs/${APP_DOMAIN}.pfx ."
echo "¡Listo para usar en tu aplicación o servidor!"
echo "Recuerda que el archivo PFX contiene tanto el certificado como la clave privada,
y es importante mantenerlo seguro." 