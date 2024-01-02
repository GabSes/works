import matplotlib.pyplot as plt
import numpy as np

def func(x):
    y = np.exp(-x*x)*np.sin(x*x)*(x-3)
    return y 

def base(name,X,n,x):
  N =len(X)
  if name == 'mononom':
    B=np.power(x,n);

  elif name == 'Lagrange':
    B=np.ones(x.shape, dtype=float)
    # Compute the Lagrange base function
    for i in range (N):
      if i != n: B=B*(x-X[i])/(X[n]-X[i])
  
  elif name == 'Cebysev':
    # Rescale the points to Chebyshev points
    a=X[0];
    b=X[len(X)-1]
    x=2*x/(b-a)-(b+a)/(b-a)
    # Initialize the Chebyshev base functions
    T=np.zeros((N,len(x)),dtype=float);
    T[0,:]=np.ones(x.size,dtype=float); 
    # Special case for n=0
    if n == 0: B=T[0,:]; return B  
    # Special case for n=1
    T[1,:]=x;
    if n == 1: B=T[1,:]; return B
    # Compute Chebyshev base functions using recurrence relation
    for i in range (1,n): 
        T[i+1,:]=2*x*T[i,:]-T[i-1,:];
    B=T[n,:];

  elif name ==  'Newton':
     T=np.zeros((N,len(x)),dtype=float);
     T[0,:]=np.ones(x.size,dtype=float)
      # Compute Newton base functions using recurrence relation
     for i in range (0,n): T[i+1,i+1:len(x)]=  T[i,i+1:len(x)]*(x[i+1:len(x)]-X[i]);
     B=T[n,:]  

  return B

fig=plt.figure(1); 
ax=fig.add_subplot(1, 1, 1);
ax.set_xlabel('x');
ax.set_ylabel('y');
ax.grid()

#------------------------Atsitiktiniai taskai----------------

#X=np.array([-1, -0.8, -0.5, -0.2, 0.2, 0.8]);

#------------------------Cebysev metodu apskaiciuoti taskai--

a=-3;
b=2;
xxx=np.linspace(-3, 2, 6);
X = np.empty_like(xxx)


# Calculate Chebyshev points
for i in range(6):
    #print("i = ", i)
    temp=np.cos((np.pi*(2*i+1))/12)
    #print(temp)
    X[i]=temp
print(X)

#------------------------Programa----------------------------
Y = np.empty_like(X)
for i in range(X.size):
    Y[i] = func(X[i])

plt.plot(X,Y,'bo')
N=len(X)
A=np.zeros((N,N),dtype=float)
#name='mononom' 
#name='Lagrange'
name='Cebysev'
#name='Newton'

# Compute the interpolation coefficients
for i in range (N) :
  A[:,i]=base(name,X,i,X)
print('A',A)
coeff=np.linalg.solve(A,Y)  

# Generate points for the interpolation curve
xxx=np.linspace(X[0],X[N-1],1000)
yyy=np.zeros(xxx.size,dtype=float)

# Evaluate the interpolation curve
for i in range (N):
    yyy+=base(name,X,i,xxx)*coeff[i]

plt.plot(xxx,yyy,'b-')

# Plot the actual function
yyy2=np.empty_like(xxx)
for i in range(xxx.size):
    yyy2[i] = (func(xxx[i]))

plt.plot(xxx,yyy2,'g-')

# Plot the absolute difference between the curve and the function
yyy3=np.empty_like(xxx)
for i in range(xxx.size):
    yyy3[i] = abs(yyy[i]) - abs(yyy2[i])

plt.plot(xxx,yyy3,'r-')

ax.set_title(name)
plt.show()