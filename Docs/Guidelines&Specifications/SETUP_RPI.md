# Configuración de rpi

con el programa oficial del Raspberry Pi Imager, puedes configurar fácilmente tu Raspberry Pi. Sigue estos pasos:

1. Descarga e instala el Raspberry Pi Imager desde el sitio web oficial.
2. Inserta la tarjeta microSD en tu computadora.
3. Abre el Raspberry Pi Imager y selecciona el sistema operativo que deseas instalar (Raspberry Pi OS Lite 64 bits).
4. Elige la opción de configuración avanzada (puedes habilitar SSH y configurar la red Wi-Fi aquí).
5. Aquí mismo ponemos el hostname "climbedge" y el usuario climbedge y la clave Cl1mb3dg3*.
6. Elige la tarjeta microSD como destino y haz clic en "Escribir".
7. Una vez completada la escritura, inserta la tarjeta microSD en tu Raspberry Pi y enciéndela.

## Configuración inicial

Una vez que tu Raspberry Pi esté encendida, sigue estos pasos para completar la configuración inicial:

1. Conéctate a la red Wi-Fi configurada durante la instalación.
2. Abre una terminal y actualiza el sistema con los siguientes comandos:

   ```bash
   sudo apt update
   sudo apt upgrade
   ```

3. Instala cualquier software adicional que necesites para tu proyecto.
4. Para conectarse a través del hostname:

   ```bash
   ssh climbedge@climbedge.local
   ```

   Ingresa la contraseña `Cl1mb3dg3*` cuando se te solicite.

## Configurar screen waveshare

[Instrucciones para configurar la pantalla Waveshare](https://www.waveshare.com/wiki/2.13inch_e-Paper_HAT_Manual#Working_With_Raspberry_Pi)

1. Instalamos las dependencias necesarias:

   ```bash
   sudo apt-get update
   sudo apt-get install python3-pip
   sudo apt-get install python3-dev
   sudo apt-get install python3-pil
   sudo apt-get install python3-numpy
   sudo apt-get install python3-spidev
   sudo apt install python3-gpiozero
   ```

Sigue las instrucciones en el enlace para completar la configuración de la pantalla Waveshare.

alli dentro de la carpeta python revisar los ejemplos proporcionados para familiarizarte con el uso de la pantalla.

## Configurar para neopixel (leds)

ejecutar el comando `sudo nano /boot/firmware/config.txt` alli aniadir o modificar 

```bash
dtparam=audio=off
core_freq_min=250
```

Creo un env de python para poder instalar las dependencias `python3 -m venv --system-site-packages servenv`

```bash
source servenv/bin/activate
pip install rpi_ws281x adafruit-circuitpython-neopixel
```

ingresar en `ledenv/pyvenv.cfg`
y cambiar: `include-system-site-packages = false` a `include-system-site-packages = true`
