# Sensor FSR Casero para MoonBoard

## 🧰 Materiales

- Papel aluminio **o** papel con grafito (lápiz 6B a 8B)
- Espuma fina, goma eva o cartulina (para espaciador)
- Cinta adhesiva o cinta aislante
- Cables (jumper wires)
- Multímetro (opcional, para pruebas)
- Cinta de cobre o clips para conexión

---

## ⚙️ Estructura del Sensor

El sensor consta de **tres capas**:

```
[1] Capa superior conductiva (grafito o aluminio)
[2] Espaciador (con agujero en el centro)
[3] Capa inferior conductiva (grafito o aluminio)
```

Cuando se aplica presión, las capas conductivas hacen contacto a través del agujero del espaciador, reduciendo la resistencia.

---

## 🛠 Pasos de Fabricación

1. **Capas Conductoras:**
   - Dibuja un área circular con lápiz 6B–8B en papel (repite para las dos caras).
   - Alternativa: usa papel aluminio pegado con cinta sobre cartón.

2. **Espaciador:**
   - Corta una cartulina o goma eva del tamaño de las capas conductoras.
   - Haz un agujero (3–5 mm) en el centro.

3. **Montaje:**
   - Apila las tres capas:
     ```
     Superior (conductiva)
     Espaciador (con agujero)
     Inferior (conductiva)
     ```
   - Asegura con cinta adhesiva.

4. **Conexión:**
   - Usa cinta de cobre o cables para hacer contacto con las capas superior e inferior.
   - Conecta al circuito como parte de un divisor de voltaje.

---

## 🔌 Conexión a Raspberry Pi (con ADC)

Si usas una **Raspberry Pi Zero 2 W** (sin entradas analógicas), necesitas un **conversor ADC**, por ejemplo el **MCP3008**.

### Esquema de conexión con divisor de voltaje:

```
3.3V ----> [FSR] ----+-----> Entrada ADC (ej. CH0 en MCP3008)
                     |
                  [10kΩ]
                     |
                    GND
```

- **Sin presión:** resistencia muy alta (MΩ).
- **Con presión:** resistencia baja (kΩ o menos).
- Puedes leer este valor con el MCP3008 conectado por SPI.

---

## 📌 Notas Finales

- El sensor no mide fuerza exacta, solo presencia e intensidad relativa de presión.
- Puedes ajustar la sensibilidad cambiando el valor de la resistencia en el divisor de voltaje.
- Para usar varios sensores, utiliza **multiplexores CD74HC4067** o canales del MCP3008.

---
