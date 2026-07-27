import re
import sympy as sp
import numpy as np
import matplotlib.pyplot as plt
from fontTools.unicodedata import block
from mpl_toolkits.mplot3d import Axes3D

x, t, xp, tp = sp.symbols('x t xp tp', real=True)
r = sp.Abs(x - xp)
H = sp.Heaviside


def parse_input_data(data):
    """
    Parses parameter definitions from a string and returns a dict of sympy expressions.

    Supports:
    - '^' as exponent (converted to '**')
    - absolute value notation |expr| -> Abs(expr)
    - H(...) as Heaviside
    """
    parsed = {
        'a': None,
        'b': None,
        'c': None,
        'T': None,
    }

    for raw_line in data.strip().splitlines():
        line = raw_line.strip()
        if not line or ':' not in line:
            continue
        key, value = map(str.strip, line.split(':', 1))
        # Prepare string: replace '^', replace |...|
        expr_str = value.replace('^', '**')
        expr_str = re.sub(r"\|([^|]+)\|", r"Abs(\1)", expr_str)

        # Parse numeric or symbolic
        if key in ('a', 'b', 'c', 'T'):
            parsed[key] = float(expr_str) if ('.' in expr_str) else int(expr_str)

    return parsed

with open('input.txt') as f:
     data = f.read()
params = parse_input_data(data)

a = params['a']
b = params['b']
c = params['c']
T = params['T']


def read_until_eps(filename):
    """
    Зчитує вміст файлу до коментаря "# eps value" включно.

    Parameters:
    filename (str): Ім'я файлу для зчитування.

    Returns:
    str: Частина виразу до "# eps value" (не включаючи наступний блок).
    """
    expression_lines = []
    with open(filename, 'r', encoding='utf-8') as f:
        for line in f:
            if '# eps value' in line:
                break
            expression_lines.append(line.strip())
    return ' '.join(expression_lines)

filename = 'output.txt'
y_expr_str = read_until_eps(filename)





y_expr_str = y_expr_str.replace('^', '**')
y_expr_str = re.sub(r"\|([^|]+)\|", r"Abs(\1)", y_expr_str)
y_expr = sp.sympify(y_expr_str, locals={'H': H, 'Abs': sp.Abs, 'x': x, 't': t, 'xp': xp, 'tp': tp})

# Створюємо функцію від x і t
y_func = sp.lambdify((x, t), y_expr, modules=['numpy', {'H': lambda z: np.heaviside(z, 1), 'Abs': np.abs}])

def y2_func(x, t):
    return t * x - t * t * x * x + (1/3) * t**3 * x**3 + 3 * x**4



x_pl = np.linspace(a, b, 100)
t_pl = np.linspace(0, T, 100)
x_grid, t_grid = np.meshgrid(x_pl, t_pl)


#y_grid = np.array([[y.subs({x: x_val, t: t_val}) for x_val, t_val in zip(x_row, t_row)]
#                   for x_row, t_row in zip(x_grid, t_grid)])
y_grid = y_func(x_grid, t_grid)
y2_grid = y2_func(x_grid, t_grid)

fig1 = plt.figure()
ax1 = fig1.add_subplot(111, projection='3d')
ax1.plot_surface(x_grid, t_grid, y_grid, cmap='viridis')
ax1.set_xlabel('X')
ax1.set_ylabel('T')
ax1.set_zlabel('Y₁')

# Вікно 2 — графік Y₂(x, t)
fig2 = plt.figure()
ax2 = fig2.add_subplot(111, projection='3d')
ax2.plot_surface(x_grid, t_grid, y2_grid, cmap='plasma')
ax2.set_xlabel('X')
ax2.set_ylabel('T')
ax2.set_zlabel('Y₂')
plt.show(block=True)
