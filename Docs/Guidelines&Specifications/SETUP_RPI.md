# 🍇 Guía de Configuración Raspberry Pi - Alpine Linux

Esta guía detalla el proceso completo de configuración de un Raspberry Pi con Alpine Linux para el proyecto ClimbEdge.

## 📋 Tabla de Contenidos

- [Instalación Inicial](#instalación-inicial)
- [Configuración del Sistema](#configuración-del-sistema)
- [Configuración de Memoria SWAP](#configuración-de-memoria-swap)
- [Configuración de ZRAM](#configuración-de-zram)
- [Configuración WiFi](#configuración-wifi)
- [Configuración SSH](#configuración-ssh)
- [Configuración del Firewall](#configuración-del-firewall)
- [Instalación de Lenguajes de Programación](#instalación-de-lenguajes-de-programación)

---

## 🚀 Instalación Inicial

### 1. Preparación de la imagen

- Utilizar la imagen **aarch64** de Alpine Linux
- Iniciar la instalación con `setup-alpine`

### 2. Configuración básica durante la instalación

| Parámetro | Valor |
|-----------|--------|
| **Usuario root** | `Cl1mb3dg3.1998` |
| **Usuario adicional** | `climbedge` con password `Cl1mb3dg3*` |
| **Teclado** | `latam` |
| **Hostname** | `climbedge.local` |

Habilita el SPI desde el archivo de configuración:

Edita /boot/config.txt:

sh
Copiar
Editar
nano /boot/config.txt
Asegúrate de que estas líneas estén activas (sin #):

ini
Copiar
Editar
dtparam=spi=on
Guarda y reinicia:

sh
Copiar
Editar
reboot
Esto habilita SPI desde el device tree overlay, que puede funcionar sin necesidad de modprobe.

---

## ⚙️ Configuración del Sistema

### 1. Habilitar repositorio community

```bash
nano /etc/apk/repositories
```

> **Nota:** Verificar que esté descomentada la línea del repositorio `community`

### 2. Actualizar sistema e instalar paquetes básicos

```bash
apk update
apk add zram-init sudo
```

### 3. Configurar sudo

```bash
# Editar archivo sudoers
nano /etc/sudoers
# Descomentar la línea del grupo sudo

# Crear grupo sudo y agregar usuario
addgroup sudo
adduser climbedge sudo

# Reiniciar el sistema
reboot
```

---

## 💾 Configuración de Memoria SWAP

### 1. Crear archivo de swap

```bash
dd if=/dev/zero of=/swapfile bs=1M count=512
```

### 2. Configurar permisos

```bash
chmod 600 /swapfile
```

### 3. Inicializar y activar swap

```bash
mkswap /swapfile
swapon /swapfile
```

### 4. Hacer el swap permanente

```bash
nano /etc/fstab
```

Agregar la siguiente línea:

```
/swapfile none swap sw 0 0
```

---

## 🔧 Configuración de ZRAM

### 1. Habilitar ZRAM en el arranque

```bash
rc-update add zram-init default
```

### 2. Configurar ZRAM

```bash
nano /etc/conf.d/zram-init
```

Modificar:

- `num_devices=3`
- `size1=256`
- `size2=256`

### 3. Reiniciar el sistema

```bash
reboot
```

### 4. Activar módulo ZRAM manualmente (si es necesario)

```bash
modprobe zram
```

---

## ✅ Verificación de ZRAM

### 🔍 1. Verificar existencia del dispositivo ZRAM

```bash
ls /dev/zram*
```

**✅ Resultado esperado:** Debe mostrar `/dev/zram0`

**❌ Si no aparece:** Cargar módulo manualmente:

```bash
modprobe zram
ls /dev/zram*
```

### 🔧 2. Verificar tamaño asignado

```bash
cat /sys/block/zram0/disksize
```

**✅ Resultado esperado:** Número como `536870912` (512MB)

**❌ Si muestra 0:** Asignar tamaño:

```bash
echo 512M > /sys/block/zram0/disksize
```

### 🧱 3. Verificar formato como swap

```bash
zramctl
```

**✅ Resultado esperado:**

```
NAME       ALGORITHM DISKSIZE DATA COMPR TOTAL STREAMS MOUNTPOINT
/dev/zram0 zstd      512M     3M   1M    2M    1       [SWAP]
```

**❌ Si no tiene [SWAP]:** Activar:

```bash
mkswap /dev/zram0
swapon /dev/zram0
```

### 📋 4. Verificar uso del sistema

```bash
swapon --show
```

**Resultado esperado:**

```
NAME        TYPE      SIZE   USED PRIO
/dev/zram0  partition 512M   10M  100
```

```bash
free -h
```

**Resultado esperado:** Mostrar `Swap: 512M` con uso o libre

---

## 📶 Configuración WiFi

### 1. Escanear redes disponibles

```bash
sudo iw dev wlan0 scan | grep SSID
```

### 2. Agregar configuración de red

```bash
wpa_passphrase "NOMBRE_RED" "CLAVE_WIFI" | sudo tee -a /etc/wpa_supplicant/wpa_supplicant.conf
```

### 3. Activar interfaz y conectar

```bash
# Activar interfaz de red
sudo ip link set wlan0 up

# Lanzar wpa_supplicant
sudo wpa_supplicant -B -i wlan0 -c /etc/wpa_supplicant/wpa_supplicant.conf

# Configurar IP automáticamente
sudo udhcpc -i wlan0
```

### 4. Verificar conexión

```bash
iw wlan0 link
```

---

## 🔐 Configuración SSH

### 1. Instalar OpenSSH

```bash
sudo apk add openssh
```

### 2. Habilitar e iniciar servicio

```bash
sudo rc-update add sshd
sudo service sshd start
```

---

## 🛡️ Configuración del Firewall

### 1. Instalar nftables

```bash
sudo apk add nftables nftables-openrc
```

### 2. Habilitar e iniciar servicio

```bash
sudo rc-update add nftables
sudo service nftables start
```

### 3. Crear reglas de firewall

Crear archivo `/etc/nftables.d/ssh.nft`:
```bash
table inet filter {
    chain input {
        tcp dport 22 accept
    }
}
```

### 4. Puertos recomendados a habilitar

| Servicio   | Puerto | Protocolo | Descripción                    |
|------------|--------|-----------|--------------------------------|
| SSH        | 22     | TCP       | Acceso remoto seguro          |
| DNS        | 53     | UDP       | Resolución de nombres         |
| NTP        | 123    | UDP       | Sincronización de hora        |
| HTTP/HTTPS | 80,443 | TCP       | Navegación web                |

### 5. Aplicar cambios

```bash
sudo nft flush ruleset
sudo nft -f /etc/nftables.nft
```

### 6. Verificar configuración

```bash
sudo nft list ruleset
```

---

## 🐍 Instalación de Lenguajes de Programación

### Python

```bash
apk add python3 py3-pip
```

### Rust

```bash
# Instalar dependencias
apk update
apk add build-base curl git

# Descargar instalador de Rust
curl --proto '=https' --tlsv1.2 -sSf https://sh.rustup.rs -o rustup.sh

# Dar permisos de ejecución
chmod +x rustup.sh

# Crear directorio temporal
mkdir $HOME/.tmp

# Ejecutar instalador
TMPDIR=$HOME/.tmp ./rustup.sh

# Exportar variables de entorno
export PATH="$HOME/.cargo/bin:$PATH"
source ~/.profile

# (Opcional) Agregar target adicional
rustup target add x86_64-unknown-linux-musl
```

---

## 📝 Notas Adicionales

- **Credenciales de acceso:** Mantener seguras las contraseñas configuradas
- **Actualizaciones:** Ejecutar `apk update && apk upgrade` periódicamente
- **Monitoreo:** Verificar el uso de memoria con `free -h` regularmente
- **Conectividad:** Comprobar la conexión WiFi con `ping google.com`

---

*Última actualización: Agosto 2025*
