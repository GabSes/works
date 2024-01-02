import numpy as np
# Function to perform polynomial approximation using NumPy's polyfit
def approximate(x, y, n):
     # Fit a polynomial of degree n to the given data points
    function = np.poly1d(np.polyfit(x, y, n))
     # Return the approximating polynomial function
    return function
