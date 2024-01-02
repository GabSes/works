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

stepSize = 0.025

# Functions for upward and downward motion
def funcUp(m, v, k):
  return (-m*g-v**2*k)/m

def funcDown(m, v, k):
  return (m*g-v**2*k)/m

# Euler method
def euler(m, v, k, step, func):
  # Euler method to approximate the next velocity
  return v + step*func(m, v, k)

# Function to calculate velocity using Euler method  
def cacluateWithEuler(v, m, k, times):
  isFalling = False

  for i in range(1, len(times)):
    if not isFalling:
      # Upward motion calculation until reaching t=2  
      if times[i] < 2:
        v[i] = euler(m1+m2, v[i-1], ks, times[i]-times[i-1], funcUp)
      else:
        # Continue with upward motion after t=2
        v[i] = euler(m, v[i-1], k, times[i]-times[i-1], funcUp)
      # Check for change in velocity sign to detect the start of falling
      if np.sign(v[i]) == -1:
        isFalling = True
        print("max height time:", times[i], np.abs(v[i]*times[i]))
    else:
      # Downward motion calculation
      if times[i] < 2:
        # If time is less than 2, use combined masses (m1 + m2) and spring constant ks
        v[i] = euler(m1+m2, v[i-1], ks, times[i]-times[i-1], funcDown)
      else:
        # If time is greater than or equal to 2, use individual mass m and spring constant k
        v[i] = euler(m, v[i-1], k, times[i]-times[i-1], funcDown)

#step 0.025
stepCount = (int)(tmax/stepSize)
times = np.linspace(0, tmax, stepCount)

v1 = np.empty(stepCount)
v2 = np.empty(stepCount)
v1[0] = v2[0] = v0

cacluateWithEuler(v1, m1, k1, times)
cacluateWithEuler(v2, m2, k2, times)

#step 0.5
stepCount1 = (int)(stepCount/20)
times1 = np.linspace(0, tmax, stepCount1)

v11 = np.empty(stepCount1)
v21 = np.empty(stepCount1)
v11[0] = v21[0] = v0

cacluateWithEuler(v11, m1, k1, times1)
cacluateWithEuler(v21, m2, k2, times1)

#step 0.51
stepCount2 = (int)(tmax/0.51)
times2 = np.linspace(0, tmax, stepCount2)

v12 = np.empty(stepCount2)
v22 = np.empty(stepCount2)
v12[0] = v22[0] = v0

cacluateWithEuler(v12, m1, k1, times2)
cacluateWithEuler(v22, m2, k2, times2)

#presicion check
# Create an array for smaller time steps for precision check
timesSmallerStep = np.array([0, times[1]/2, times[1]])
# Create an array to store velocities for the precision check
vSmallerStep = np.empty(3)
# Set initial velocity for the precision check
vSmallerStep[0] = v0


# Calculate velocities with a smaller time step for precision check
cacluateWithEuler(vSmallerStep, m1, k1, timesSmallerStep)
# Print the precision of v1 compared to the regular time step
print("v1 presicion:", vSmallerStep[2] - v1[1])

#plots
# plt.plot(times, v1, label='v1 step=0.025')
# plt.plot(times, v2, label='v2 step=0.025')

#plt.plot(times1, v11, label='v1 step=0.5')
#plt.plot(times1, v21, label='v2 step=0.5')

plt.plot(times2, v12, label='v1 step=0.51')
plt.plot(times2, v22, label='v2 step=0.51')



plt.grid()
plt.legend()
plt.show()