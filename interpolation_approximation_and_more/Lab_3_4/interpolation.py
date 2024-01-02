import numpy as np
import matplotlib.pyplot as plt

def f(x):
    """
    Original function to be interpolated.
    """
    return (np.log(x) / (np.sin(2 * x) + 1.5)) - (x / 7)

def haar_wavelet(x):
    """
    Haar wavelet function used in Haar interpolation spline.
    """
    if 0 <= x < 0.5:
        return 1
    elif 0.5 <= x < 1:
        return -1
    else:
        return 0

def haar_interpolation_spline(range_x, range_y):
    """
    Perform Haar interpolation spline on given data points.
    """
    def haar_spline_function(x):
        # Evaluate the Haar interpolation spline at the given point x
        result = 0
        for i in range(len(range_x)):
            # Calculate the contribution of each Haar wavelet at the current x
            result += range_y[i] * haar_wavelet(2 * (x - range_x[i]))
        return result

    return haar_spline_function

def parametric_interpolation(fx, fy, range_t):
    """
    Generate parametric interpolation for given functions.
    """
    x_results = []
    y_results = []
    for t in range_t:
        # Evaluate x and y coordinates at each time point using the given functions
        x_results.append(fx(t))
        y_results.append(fy(t))
    return x_results, y_results

if __name__ == "__main__":
    step = 0.1
    count = 100
    start = 1
    end = 5

    # Generate a range of x values
    range_x = np.linspace(start, end, count)
    # Evaluate the original function at each x value
    range_y = [f(x) for x in range_x]

    # Perform Haar interpolation spline
    ff = haar_interpolation_spline(range_x, range_y)

    # Generate parametric interpolation for the function
    xx, yy = parametric_interpolation(ff, ff, np.arange(start, end, step))

    # Plot the results
    plt.plot(range_x, range_y, 'b', label="Original Function")
    plt.plot(xx, yy, 'g', label="Haar Interpolation")
    plt.scatter(range_x, range_y, label=f"{count} Points")
    plt.title('Function Interpolation with Haar Wavelet')
    plt.legend()
    plt.show()
