import re
import sys
import sympy as sp
from sympy.parsing.sympy_parser import (
    parse_expr,
    standard_transformations,
    implicit_multiplication_application,
    convert_xor)
import numpy as np
import matplotlib.pyplot as plt
from mpl_toolkits.mplot3d import Axes3D
import scipy

x, t, xp, tp = sp.symbols('x t xp tp', real=True)
r = sp.Abs(x - xp)
H = sp.Heaviside

# Prepare sympy parsing transformations

transformations = (
    standard_transformations
    + (convert_xor, implicit_multiplication_application,)
)

# Local dictionary for parsing
local_dict = {
    'x': x,
    't': t,
    'xp': xp,
    'tp': tp,
    'r': r,
    'H': H,
    'Abs': sp.Abs
}

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
        'u': None,
        'initial_cond': None,
        'boundary_cond': None
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
        elif key == 'Initial Conditions':
            parsed['initial_cond'] = [parse_expr(e.strip(), transformations=transformations, local_dict=local_dict) for e in expr_str.split(',')]
        elif key == 'Boundary Conditions':
            parsed['boundary_cond'] = [parse_expr(e.strip(), transformations=transformations, local_dict=local_dict) for e in expr_str.split(',')]
        else:
            # For u
            parsed[key] = parse_expr(expr_str, transformations=transformations, local_dict=local_dict)

    # Substitute numeric parameters into symbolic expressions
    subs_dict = {k: parsed[k] for k in ('a', 'b', 'c', 'T') if parsed[k] is not None}
    for sym_key in ('u'):
        if isinstance(parsed[sym_key], sp.Expr):
            parsed[sym_key] = parsed[sym_key].subs(subs_dict)
    if parsed['initial_cond']:
        parsed['initial_cond'] = [expr.subs(subs_dict) for expr in parsed['initial_cond']]
    if parsed['boundary_cond']:
        parsed['boundary_cond'] = [expr.subs(subs_dict) for expr in parsed['boundary_cond']]

    return parsed

def write_output(y, eps, filename='output.txt'):
    """
    Writes the variable y (numpy array, sympy Matrix, or single expression) to a text file.
    Optionally writes eps on a separate line at the end.
    Each row of a 2D array or Matrix is written as space-separated values.
    Single scalar or sympy Expr is written as its string representation.
    """
    with open(filename, 'w') as f:
        try:
            # Handle numpy arrays or sympy Matrices
            for row in y:
                f.write(' '.join(str(val) for val in row) + '\n')
        except TypeError:
            # y is not iterable: write directly
            f.write(str(y) + '\n')
        if eps:
            f.write('\n# eps value\n')
            f.write(str(eps) + '\n')

        # Якщо передано eps — дописуємо його в кінець


# Example usage:
with open('input.txt') as f:
     data = f.read()
params = parse_input_data(data)

a = params['a']
b = params['b']
c = params['c']
T = params['T']
u = params['u']
initial_cond = params['initial_cond']
boundary_cond = params['boundary_cond']

#print(G)


#c = 2

G = H(t - tp - r / c) / (2 * c)

#a, b = 0, 9
#T = 5
nT=-T
def L0(eq, i): return sp.diff(eq, t, i)
def Lg(eq, i): return sp.diff(eq, x, i)


M0, Mg = 2, 2
Mgl=int(Mg/2)
Mgr=Mg-Mgl
R0, Rg = len(initial_cond), len(boundary_cond)
L = b - a
#S0 x (-t;0)
x0_vals = [(b+a)*(m+1)/(M0+1) for m in range(M0)]
t0_vals = [(nT)*(m+1)/(M0+1) for m in range(M0)]
#(R\S0) x (0;T)

xg_valsl = [a - L * (m+1) / (Mgl + 1) for m in range(Mgl)]
xg_valsr = [b + L * (m+1) / (Mgr + 1) for m in range(Mgr)]
xg_vals = xg_valsl + xg_valsr

#xg_vals = [(b+2*b)*(m+1)/4 for m in range(Mg)]

tg_vals = [(T)*(m+1)/(Mg+1) for m in range(Mg)]


B11 = []
for i in range(R0):
    row = []
    for x_m in x0_vals:
        g = G.subs({xp: x_m, tp: 0})
        gt = L0(g, i)
        row.append(gt.subs(t, 0).simplify())
    B11.append(row)


B12 = []
for i in range(R0):
    row = []
    for m in range(Mg):
        x_m, t_m = xg_vals[m], tg_vals[m]
        g = G.subs({xp: x_m, tp: t_m})
        gt = L0(g, i)
        row.append(gt.subs(t, 0))
    B12.append(row)


B21 = []
for i in range(Rg):
    row = []
    for x_m in x0_vals:
        g = G.subs({xp: x_m, tp: 0})
        row.append(Lg(g, i).simplify())
    B21.append(row)


B22 = []
for i in range(Rg):
    row = []
    for m in range(Mg):
        x_m, t_m = xg_vals[m], tg_vals[m]
        g = G.subs({xp: x_m, tp: t_m})
        row.append(Lg(g, i).simplify())
    B22.append(row)


B11_mat = sp.Matrix(B11)
B12_mat = sp.Matrix(B12)
B21_mat = sp.Matrix(B21)
B22_mat = sp.Matrix(B22)

'''
#B_top = B11_mat.row_join(B12_mat)
#B_bot = B21_mat.row_join(B22_mat)
#B = B_top.col_join(B_bot)
'''
'''
#sp.pprint(B11_mat)
#sp.pprint(B12_mat)
#sp.pprint(B21_mat)
#sp.pprint(B22_mat)
'''


#Gp = 1 / (2 * c)
Gp = H(t - tp - r / c) / (2 * c)
#u = 2*t*x**3 - 2*x**2 - c*(2*t**3*x - 2*t**2 +6)
n=50
x_v=np.linspace(a,b,n)
t_v=np.linspace(0,T,n)
deltax=(b-a)/n
deltat=(T)/n
res=0
for i in range(n):
    Gp_sub = Gp.subs({tp: t_v[i], xp: x_v[i]})
    res+=u*Gp.subs({tp: t_v[i], xp: x_v[i]})*deltat*deltax
y_inf=res
#tp_upper = sp.Piecewise((t - r / c, t - r / c > 0), (0, True))
#inner_integral = sp.integrate(Gp * u, (tp, 0, tp_upper))
#y_inf = sp.integrate(inner_integral, (xp, 0, 2))
#print("y_inf(x, t) =")
#sp.pprint(sp.simplify(y_inf))

Y0 = []
Yg = []

for i in range(len(initial_cond)):
    y_inf0=y_inf.subs(t,0)
    Y0.append(initial_cond[i] - L0(y_inf0, i))
for i in range(len(boundary_cond)):
    Yg.append(boundary_cond[i] - Lg(y_inf, i))
Y0=sp.Matrix(Y0)
Yg=sp.Matrix(Yg)
#sp.pprint(Yg)

def intg(B_i,B_j):
    values=[]
    m=B_i.T*B_j
    ms=m.shape
    for i in range(ms[0]):
        row=[]
        for j in range(ms[1]):
            #val=sp.integrate(m[i,j],(x,0,1))
            expr_values = [m[i, j].subs(x, x_val) for x_val in x_v]
            val = np.sum(expr_values) * deltax
            row.append(val)
        values.append(row)
    return values


def intg2(B_i,B_j):
    values=[]
    m=B_i.T*B_j
    ms=m.shape
    for i in range(ms[0]):
        row=[]
        for j in range(ms[1]):
           # expr = sp.lambdify(x, m[i, j], modules=["numpy"])
           # f_l = sp.lambdify((t, x), m[i,j], modules=["numpy", {"Heaviside": lambda x: np.heaviside(x, 1)}])
            #val,_=integrate.dblquad(f_l,0, 5, lambda x: 0, lambda x: 2, epsabs=1e-6, epsrel=1e-6)
            #val = sp.integrate(m[i,j],(t,0,5))
            #val1= sp.integrate(val,(x,0,1))
            expr_values = []
            for t_val in t_v:
                for x_val in x_v:
                   expr_values.append(m[i, j].subs({x: x_val, t: t_val}))
            val = np.sum(expr_values) * deltax * deltat
            row.append(val)
        values.append(row)
    return values


P11 = sp.Matrix(intg(B11_mat,B11_mat))+sp.Matrix(intg2(B21_mat,B21_mat))
#sp.pprint(P11)
P12 = sp.Matrix(intg(B11_mat,B12_mat))+sp.Matrix(intg2(B21_mat,B22_mat))
#sp.pprint(P12)
P21 = sp.Matrix(intg(B12_mat,B11_mat))+sp.Matrix(intg2(B22_mat,B21_mat))
#sp.pprint(P21)
P22 = sp.Matrix(intg(B12_mat,B12_mat))+sp.Matrix(intg2(B22_mat,B22_mat))
#sp.pprint(P22)


def rhs1(B_i):
    values = []
    m = B_i.T*Y0
    ms=m.shape
    for i in range(ms[0]):
        #values.append(sp.integrate(m[i,0],(x, 0, 1)))
        expr_values = [m[i, 0].subs(x, x_val) for x_val in x_v]
        val = np.sum(expr_values) * deltax
        values.append(val)
    return values

def rhs2(B_i):
    values = []
    m = B_i.T * Yg
    ms = m.shape
    for i in range(ms[0]):
        #val = sp.integrate(m[i,0], (t, 0, 5))
        #val1 = sp.integrate(val, (x, 0, 1))
        expr_values = []
        for t_val in t_v:
            for x_val in x_v:
                expr_values.append(m[i, 0].subs({x: x_val, t: t_val}))

        val = np.sum(expr_values) * deltax * deltat
        values.append(val)
    return values

By1=np.array(rhs1(B11_mat))+np.array(rhs2(B21_mat))
By2=np.array(rhs1(B12_mat))+np.array(rhs2(B22_mat))
#sp.pprint(By1)
#sp.pprint(By2)
By=sp.Matrix(By1).col_join(sp.Matrix(By2))

P_top = P11.row_join(P12)
P_bot = P21.row_join(P22)
P = P_top.col_join(P_bot)


# Замінити існуючий блок з P.det()
if(P.det() < 1e-9):
    print(f"INPUT_REQUIRED {M0 + Mg}")
    sys.stdout.flush()  # Важливо для негайного виведення
    input_line = sys.stdin.readline().strip()
    # Розділити введені значення та перетворити на float
    elements = list(map(float, input_line.split(',')))
    v = sp.Matrix(elements)
    #v = sp.zeros(M0 + Mg, 1)
else:
    v = sp.zeros(M0 + Mg, 1)

pP=sp.Matrix.pinv(P)
u_vec = pP*By + v - pP*P*v

u0=u_vec[0:M0,0]
ug=u_vec[M0:M0+Mg,0]

y0=0
for i in range(M0):
    y0 += G.subs({xp: x0_vals[i], tp: 0})*u0[i]
yg = 0
for i in range(Mg):
    yg += G.subs({xp: xg_vals[i], tp: tg_vals[m]})*ug[i]

#print(y0)
#print(yg)
y = (y_inf+y0+yg).simplify()
#sp.pprint(y)

def rhs11():
    values = []
    m = Y0.T*Y0
    ms=m.shape
    for i in range(ms[0]):
        #values.append(sp.integrate(m[i,0],(x, 0, 1)))
        expr_values = [m[i, 0].subs(x, x_val) for x_val in x_v]
        val = np.sum(expr_values)*deltax
        values.append(val)
    return values

def rhs22():
    values = []
    m = Yg.T * Yg
    ms = m.shape
    for i in range(ms[0]):
        #val = sp.integrate(m[i,0], (t, 0, 5))
        #val1 = sp.integrate(val, (x, 0, 1))
        expr_values = []
        for t_val in t_v:
            for x_val in x_v:
                expr_values.append(m[i, 0].subs({x: x_val, t: t_val}))

        val = np.sum(expr_values) * deltax * deltat
        values.append(val)
    return values

eps=sp.Matrix(rhs11())+sp.Matrix(rhs22())-By.T*pP*By

#sp.pprint(eps.evalf())


write_output(y, eps[0,0], 'output.txt')

'''

print(G)
print(a)
print(b)
print(c)
print(T)
print(u)
print(initial_cond)
print(boundary_cond)


# інтеграли помінять на суми Дарбу


'''
'''
x_pl = np.linspace(a, b, 10)
t_pl = np.linspace(0, T, 10)
x_grid, t_grid = np.meshgrid(x_pl, t_pl)


y_grid = np.array([[y.subs({x: x_val, t: t_val}) for x_val, t_val in zip(x_row, t_row)]
                   for x_row, t_row in zip(x_grid, t_grid)])


fig = plt.figure()
ax = fig.add_subplot(111, projection='3d')


ax.plot_surface(x_grid, t_grid, y_grid, cmap='viridis')


ax.set_xlabel('X')
ax.set_ylabel('T')
ax.set_zlabel('Y(x,t)')

fig.savefig('plot.png')


plt.show()
'''