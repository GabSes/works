import matplotlib.pyplot as plt
import numpy as np
from approximation import approximate

x_range = [1998, 1999, 2000, 2001, 2002, 2003, 2004, 2005, 2006, 2007, 2008, 2009, 2010, 2011, 2012, 2013, 2014, 2015, 2016, 2017, 2018]
y_range = [282380.0049, 288709.9915, 290820.0073, 284140.0146, 280480.011, 302570.0073, 318700.0122, 322739.9902, 337250, 349820.0073, 354269.989, 333820.0073, 339609.9854, 350250, 355299.9878, 364480.011, 363149.9939, 370000, 373329.9866, 377209.9915, 375100.0061]

# Perform polynomial approximation on the given data
approximation_f = approximate(x_range, y_range, 5)
print(approximation_f)

# Plotting the original data and the polynomial approximation curve
plt.plot(x_range, y_range, 'g', label='Greenhouse gas emissions')
plt.plot(np.arange(x_range[0], x_range[-1], 0.1),
         [approximation_f(_x) for _x in np.arange(x_range[0], x_range[-1], 0.1)],
         'b', label='Argentina emissions approximation')

plt.xlabel('Year')
plt.ylabel('Gas emissions')
plt.title("Argentina greenhouse gas emissions")

plt.grid(True)
plt.legend()
plt.show()