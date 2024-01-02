import numpy as np
import matplotlib.pyplot as plt

np.set_printoptions(suppress=True)

m1 = 0.15
m2 = 0.2
v0 = 70
ks = 0.01
ts = 2
k1 = 0.05
k2 = 0.001
tmax = 10
g = 9.8

stepSize = 0.25

# Functions for upward and downward motion
def funcUp(m, v, k):
  return (-m*g-v**2*k)/m

def funcDown(m, v, k):
  return (m*g-v**2*k)/m

# Euler method implementation
def euler(m, v, k, step, func):
# Euler method to approximate the next velocity
  return v + step*func(m, v, k)

# Improved Euler method (with velocity at the next step)
def eulerIV(m, v, k, step, func, vNext):
  return v + step*func(m, vNext, k)
  
def cacluateWithIV(v, m, k, times):
  isFalling = False

  for i in range(1, len(times)):
    if not isFalling:
      # Upward motion calculation until reaching t=2
      if times[i] < 2:
         # Calculate intermediate steps using Euler and Improved Euler methods
        firstStep = euler(m1+m2, v[i-1], ks, (times[i]-times[i-1])/2, funcUp)
        # Calculate the second step using Improved Euler method, incorporating the velocity at the next step
        secondStep = eulerIV(m1+m2, v[i-1], ks, (times[i]-times[i-1])/2, funcUp, firstStep)
        thirdStep = eulerIV(m1+m2, v[i-1], ks, times[i]-times[i-1], funcUp, secondStep)
        # Calculate the next velocity using the weighted sum of the intermediate steps
        v[i] = v[i-1]+((times[i]-times[i-1])/6)*(funcUp(m1+m2, v[i-1], ks)+2*funcUp(m1+m2, firstStep, ks)+
        2*funcUp(m1+m2, secondStep, ks)+funcUp(m1+m2, thirdStep, ks))
      else:
        # Continue with upward motion after t=2 using Euler and Improved Euler methods
        firstStep = euler(m, v[i-1], k, (times[i]-times[i-1])/2, funcUp)
        secondStep = eulerIV(m, v[i-1], k, (times[i]-times[i-1])/2, funcUp, firstStep)
        thirdStep = eulerIV(m, v[i-1], k, times[i]-times[i-1], funcUp, secondStep)
        # Calculate the next velocity using the weighted sum of the intermediate steps
        v[i] = v[i-1]+((times[i]-times[i-1])/6)*(funcUp(m, v[i-1], k)+2*funcUp(m, firstStep, k)+
        2*funcUp(m, secondStep, k)+funcUp(m, thirdStep, k))

      if np.sign(v[i]) == -1:
        isFalling = True
        print("max height time:", times[i])
    else:
      if times[i] < 2:
        firstStep = euler(m1+m2, v[i-1], ks, (times[i]-times[i-1])/2, funcDown)
        secondStep = eulerIV(m1+m2, v[i-1], ks, (times[i]-times[i-1])/2, funcDown, firstStep)
        thirdStep = eulerIV(m1+m2, v[i-1], ks, times[i]-times[i-1], funcDown, secondStep)

        v[i] = v[i-1]+((times[i]-times[i-1])/6)*(funcDown(m1+m2, v[i-1], ks)+2*funcDown(m1+m2, firstStep, ks)+
        2*funcDown(m1+m2, secondStep, ks)+funcDown(m1+m2, thirdStep, ks))
      else:
        firstStep = euler(m, v[i-1], k, (times[i]-times[i-1])/2, funcDown)
        secondStep = eulerIV(m, v[i-1], k, (times[i]-times[i-1])/2, funcDown, firstStep)
        thirdStep = eulerIV(m, v[i-1], k, times[i]-times[i-1], funcDown, secondStep)

        v[i] = v[i-1]+((times[i]-times[i-1])/6)*(funcDown(m, v[i-1], k)+2*funcDown(m, firstStep, k)+
        2*funcDown(m, secondStep, k)+funcDown(m, thirdStep, k))

#step 0.25
stepCount = (int)(tmax/stepSize)
times = np.linspace(0, tmax, stepCount)

v1 = np.empty(stepCount)
v2 = np.empty(stepCount)
v1[0] = v2[0] = v0

cacluateWithIV(v1, m1, k1, times)
cacluateWithIV(v2, m2, k2, times)

#step 0.5
# stepCount1 = (int)(stepCount/2)
# times1 = np.linspace(0, tmax, stepCount1)

# v11 = np.empty(stepCount1)
# v21 = np.empty(stepCount1)
# v11[0] = v21[0] = v0

# cacluateWithIV(v11, m1, k1, times1)
# cacluateWithIV(v21, m2, k2, times1)

# step 0.66
stepCount2 = (int)(tmax/0.66)
times2 = np.linspace(0, tmax, stepCount2)

v12 = np.empty(stepCount2)
v22 = np.empty(stepCount2)
v12[0] = v22[0] = v0

cacluateWithIV(v12, m1, k1, times2)
cacluateWithIV(v22, m2, k2, times2)

#presicion check
# Create an array for smaller time steps for precision check
timesSmallerStep = np.array([0, times[1]/2, times[1]])
# Create an array to store velocities for the precision check
vSmallerStep = np.empty(3)
# Set initial velocity for the precision check
vSmallerStep[0] = v0


# Calculate velocities with a smaller time step for precision check using the calculateWithIV function
cacluateWithIV(vSmallerStep, m1, k1, timesSmallerStep)
print("v1 presicion:", vSmallerStep[2] - v1[1])

#plots
# plt.plot(times, v1, label='v1 step=0.25')
# plt.plot(times, v2, label='v2 step=0.25')

# plt.plot(times1, v11, label='v1 step=0.5')
# plt.plot(times1, v21, label='v2 step=0.5')

plt.plot(times2, v12, label='v1 step=0.66')
plt.plot(times2, v22, label='v2 step=0.66')



plt.grid()
plt.legend()
plt.show()