from interpolation import hermite_interpolation_spline, np, chebyshev_range
import matplotlib.pyplot as plt

x_range = [1998, 1999, 2000, 2001, 2002, 2003, 2004, 2005, 2006, 2007, 2008, 2009, 2010, 2011, 2012, 2013, 2014, 2015, 2016, 2017, 2018]
y_range = [282380.0049, 288709.9915, 290820.0073, 284140.0146, 280480.011, 302570.0073, 318700.0122, 322739.9902, 337250, 349820.0073, 354269.989, 333820.0073, 339609.9854, 350250, 355299.9878, 364480.011, 363149.9939, 370000, 373329.9866, 377209.9915, 375100.0061]

# Perform Hermite interpolation spline on the given data
interpol_f = hermite_interpolation_spline(x_range, y_range)

# Generate Chebyshev points for smoother interpolation curve
range_x = chebyshev_range(1000, 1998, 2018)
range_y = [interpol_f(_x) for _x in range_x]

plt.plot(x_range, y_range, 'g', label='Greenhouse gas emissions')
plt.plot(range_x, range_y, 'b', label='Argentina emissions interpolation')

plt.xticks(x_range)
plt.xlabel('Year')
plt.ylabel('Gas emissions')

plt.title("Argentina greenhouse gas emissions")
plt.grid(True)
plt.legend()
plt.show()