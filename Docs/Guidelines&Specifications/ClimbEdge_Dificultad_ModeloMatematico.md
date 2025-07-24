
# 📐 Modelo Matemático de Dificultad – ClimbEdge

## 🎯 Objetivo

Calcular:

- `C`: Dificultad del **BoardConfig** (configuración del tablero), en el rango **[1, 32]**
- `D`: Dificultad final del **BoardProblem** (problema de escalada), también en el rango **[1, 32]**

---

## 1. 🧮 Cálculo de `C` – Dificultad del BoardConfig

Sea `M` el número total de presas (`BoardItem`) en el tablero.

Para cada presa `i`:

- `dᵢ`: dificultad de la presa (`BoardItem.Difficulty`)
- `tᵢ`: dificultad de la textura (`BoardItemTexture.Difficulty`)
- `mᵢ`: dificultad del material (`BoardItemTextureMaterial.Difficulty`)

La fórmula para `C` es:

$$
C = \frac{1}{M} \sum_{i=1}^{M} \left( w_1 \cdot d_i + w_2 \cdot t_i + w_3 \cdot m_i \right)
$$

Donde:

- `w₁, w₂, w₃` son pesos definidos empíricamente o por IA, y deben cumplir:

$$
w_1 + w_2 + w_3 = 1
$$

📌 Este valor se calcula una sola vez por configuración (`BoardConfig`) y puede ser almacenado.

---

## 2. 🧗‍♂️ Cálculo de `P` – Dificultad del Problema sin considerar el ángulo

Sea `N` el número de presas utilizadas en el problema (`BoardProblemItem`).

Para cada presa `j` utilizada:

- `dⱼ`, `tⱼ`, `mⱼ`: como antes, pero solo para las presas seleccionadas
- `yⱼ`: dificultad por tipo de uso (`BoardProblemItemType`) – mano, pie, start, end, etc.

Fórmula para `P`:

$$
P = \frac{1}{N} \sum_{j=1}^{N} \left( w_1 \cdot d_j + w_2 \cdot t_j + w_3 \cdot m_j + w_4 \cdot y_j \right)
$$

Donde:

- `w₁ + w₂ + w₃ + w₄ = 1`

---

## 3. 🎚️ Ajuste por Ángulo `A`

Sea `θ` el ángulo del tablero (`BoardProblemAngle.Angle` en grados).

Se define una función de ajuste no lineal `f(θ)`, por ejemplo:

$$
A = 1 + k \cdot \sin\left( \frac{\pi (\theta - 10)}{50} \right)
$$

Donde:

- `k` controla la sensibilidad del ajuste (ej. 0.2)
- `θ ∈ [10, 65]` grados (o el rango definido en tus tableros)

Esto devuelve un factor `A ∈ [0.8, 1.5]` según el caso.

---

## 4. 📏 Cálculo Final de `D` – Dificultad del Problema

Combinando todo:

$$
D = \text{clamp} \left( A \cdot (C + P),\ 1,\ 32 \right)
$$

Donde:

- `clamp(x, 1, 32)` restringe el valor resultante al rango `[1, 32]`
- `C` y `P` son definidos como se indicó previamente
- `A` es el ajuste por ángulo

---

## 🔧 Parámetros Ajustables

| Parámetro | Significado | Rango típico |
|----------|-------------|--------------|
| `w₁, w₂, w₃, w₄` | Pesos de dificultad | [0, 1], suma = 1 |
| `yⱼ` | Dificultad por tipo de uso | Definido por reglas heurísticas o IA |
| `A = f(θ)` | Ajuste por ángulo | Función continua no lineal |

---

## 🧠 Notas Finales

- El valor de `C` se basa en **todas las presas del BoardConfig**.
- El valor de `D` se calcula **solo con las presas usadas en el problema**.
- Este modelo permite ajustes finos mediante IA o pruebas empíricas.
- La normalización asegura comparabilidad entre problemas y tableros distintos.
