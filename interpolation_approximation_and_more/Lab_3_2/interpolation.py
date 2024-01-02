import numpy as np

# Function to generate Chebyshev points in a given range
def chebyshev_range(count, start, end):
    range_x = []
    for i in range(count):
        # Compute Chebyshev points using the formula
        temp = (end + start) / 2 + (end - start) / 2 * np.cos((2 * i + 1) * np.pi / (2 * count))
        range_x.append(temp)

    return range_x

# Function U for Hermite interpolation spline
def U(start, end, x):
    return (1 - 2 * (1 / (start - end)) * (x - start)) * ((x - end) / (start - end)) ** 2

# Function V for Hermite interpolation spline
def V(start, end, x):
    return (x - start) * ((x - end) / (start - end)) ** 2

# Function to perform Hermite interpolation spline on given data points
def hermite_interpolation_spline(range_x, range_y):
    # Calculate slopes between consecutive points
    range_dy = points_slopes(range_x, range_y)

    def spline_function(x):
        # Find the index of x in the sorted range_x
        index = np.searchsorted(range_x, x)
        try:
            # Evaluate the Hermite interpolation spline at the given point x
            result = U(range_x[index - 1], range_x[index], x) * range_y[index - 1] + V(range_x[index - 1],
                                                                                       range_x[index],
                                                                                       x) * range_dy[index - 1] \
                     + U(range_x[index], range_x[index - 1], x) * range_y[index] \
                     + V(range_x[index], range_x[index - 1], x) * range_dy[index]
        except TypeError:
            return None
        return result

    return spline_function

# Function to calculate slope between two points
def slope(x1, y1, x2, y2):
    return (y2 - y1) / (x2 - x1)

# Function to calculate slopes between consecutive points
def points_slopes(range_x, range_y):
    slopes = []
    for i in range(len(range_x) - 1):
         # Check for missing values and append None if any are found
        if range_x[i] is None or range_x[i + 1] is None or range_y[i] is None or range_y[i + 1] is None:
            slopes.append(None)
        else:
            slopes.append(slope(range_x[i], range_y[i], range_x[i + 1], range_y[i + 1]))
    # Duplicate the last slope to match the length of range_x
    slopes.append(slopes[-1])
    return slopes