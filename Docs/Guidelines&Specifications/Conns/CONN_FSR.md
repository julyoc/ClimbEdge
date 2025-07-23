# Conexión de 216 Sensores FSR Caseros en Matriz a Raspberry Pi Zero 2 W

## 🎯 Objetivo

Conectar 216 sensores FSR caseros a una Raspberry Pi Zero 2 W usando un enfoque de **matriz de escaneo** para reducir la cantidad de hardware necesario y optimizar el cableado.

---

## 🧩 Estructura de la Matriz

Organizamos los sensores en una matriz de:

- **18 filas** (controladas por GPIOs de la Raspberry Pi)
- **12 columnas** (leídas a través de un ADC MCP3008)

Esto permite:

```
18 filas × 12 columnas = 216 sensores
```

Cada sensor FSR se ubica en el cruce entre una fila y una columna.

---

## 🛠️ Materiales Necesarios

| Componente               | Cantidad | Descripción |
|--------------------------|----------|-------------|
| Raspberry Pi Zero 2 W    | 1        | Controlador principal |
| MCP3008 (ADC SPI de 8ch) | 1        | Conversión analógica-digital |
| CD74HC4067 (MUX 16:1)    | 1 (opcional) | Para multiplexar columnas si usas más de 8 |
| FSR caseros              | 216      | Uno por cada cruce fila/columna |
| Resistencias de 10kΩ     | 12       | Una por cada columna (pull-down) |
| Cables Dupont            | muchos   | Para conexiones físicas |
| Protoboard o PCB matriz  | 1        | Para organización de la matriz |

---

## 🧱 Conexión Física de los Sensores

Cada sensor FSR se conecta **entre una salida digital (fila)** y una **entrada analógica (columna)**.

### 🧱 Organización física:

- Crea una rejilla de alambre o pistas donde:
    - Horizontalmente tienes 18 líneas (Filas).
    - Verticalmente tienes 12 líneas (Columnas).
- En cada cruce va un FSR casero conectado entre la fila y la columna.

### ⚡ Parte eléctrica:

🔵 Columnas (12 canales analógicos):

- Cada columna conecta a una entrada analógica del MCP3008 (CH0 a CH7).
- Como el MCP3008 solo tiene 8 canales, puedes usar:
    - 👉 Directo: solo 8 columnas = 144 sensores.
    - 👉 Con CD74HC4067: multiplexas las 12 columnas → solo 1 canal al MCP3008.

🔵 Filas (18 canales digitales):

- Cada fila conecta a un GPIO de la Raspberry Pi (por ejemplo, GPIO2 a GPIO19).
- Cada fila se activa poniendo su GPIO en HIGH, y se lee el voltaje en las columnas.
    - 👉 Directo: solo 18 columnas = 18 pines GPIO
    - 👉 Multiplexado: usa un CD74HC4067 para leer más columnas con menos GPIOs (ej. 4 GPIOs para 16 columnas, se usan 2).

### 🔌 Esquema por sensor:

```
GPIO salida (fila) ─────┬────[ FSR ]────┬──── Entrada columna
                        │               │
                        │            [Resistencia 10kΩ]
                        │               │
                        └───────────────┴────── GND
```

- La fila se pone en HIGH (3.3V) al escanear.
- El MCP3008 mide el voltaje en la columna.
- Si se presiona el sensor, la resistencia baja y el voltaje sube → detectado.

---

## 📐 Organización de Pines

### Filas (GPIO OUT)

- Usar 18 GPIOs disponibles del RPi para controlar cada fila (por ejemplo GPIO2 a GPIO19).
- O un CD74HC4067 para multiplexar las 18 filas

### Columnas (Entradas Analógicas)

Usar:

- MCP3008 CH0–CH7 directamente para 8 columnas.
- O un CD74HC4067 para multiplexar las 12 columnas a una sola entrada del MCP3008.

Cada columna debe tener una resistencia de 10kΩ a GND para formar un divisor de voltaje.

---

## 🔄 Secuencia de Escaneo

1. Activar una fila (poner su GPIO en HIGH).
2. Leer todas las columnas (usando MCP3008).
3. Guardar el valor leído de cada columna.
4. Desactivar la fila (poner en LOW).
5. Repetir para todas las filas.

---

## 🧠 Lógica de Lectura (Pseudocódigo)

```python
for fila in range(18):
    activar_gpio_fila(fila)
    time.sleep(0.01)  # estabilización
    for columna in range(12):
        valor = leer_adc(columna)  # vía CHx o MUX
        matriz[fila][columna] = valor
    desactivar_gpio_fila(fila)
```

---

## 🧠 Ventajas del Método de Matriz

✅ Reduce drásticamente la cantidad de multiplexores necesarios.  
✅ Requiere solo 1 MCP3008 y opcionalmente 2 CD74HC4067.  
✅ Más limpio en cableado y más escalable.  
✅ Compatible con lectura en tiempo real y bajo consumo.

---

## 📌 Consideraciones Finales

- Si usas todos los pines GPIO disponibles, puedes añadir expansores (como MCP23017 vía I2C).
- Asegúrate de tener buen contacto entre el sensor FSR y las líneas.
- Puedes usar `RPi.GPIO` o `gpiozero` para controlar las filas y `spidev` para leer el MCP3008.
