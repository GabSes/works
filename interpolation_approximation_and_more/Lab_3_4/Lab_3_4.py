import matplotlib.pyplot as plt
from interpolation import parametric_interpolation, haar_interpolation_spline
import shapefile
from shapely import geometry
import numpy as np

def getData():
    # Load shapefile data
    shape = shapefile.Reader("ne_10m_admin_0_countries.shp")

    # Find the index of Argentina in the shapefile
    id = -1
    for i in range(len(shape)):
        feature = shape.shapeRecords()[i]
        if feature.record.NAME_EN == "Argentina":
            id = i
            break

    if id == -1:
        print("Tokios šalies nėra")
    else:
        print("id: " + str(id))

    # Retrieve coordinates for the largest area
    feature = shape.shapeRecords()[id]
    print(feature.record.NAME_EN)
    largestAreaID = 0
    if feature.shape.__geo_interface__['type'] == 'MultiPolygon':
        area = 0
        for i in range(len(feature.shape.__geo_interface__['coordinates'])):
            points = feature.shape.__geo_interface__['coordinates'][i][0]
            polygon = geometry.Polygon(points)
            if polygon.area > area:
                area = polygon.area
                largestAreaID = i
        xxyy = feature.shape.__geo_interface__['coordinates'][largestAreaID][0]
    else:
        xxyy = feature.shape.__geo_interface__['coordinates'][0]

    xy = list(zip(*xxyy))
    X = xy[0]
    Y = xy[1]
    return X, Y

step = 0.1  # Graph's precision

# Get data points for Argentina's border
x_range, y_range = getData()
x_range = x_range[0::20]
y_range = y_range[0::20]

# Number of interpolation points
n = int(len(x_range) - 1)
# Time points
t = range(n + 1)

# Perform Haar interpolation spline on X and Y coordinates
ff = haar_interpolation_spline(x_range, y_range)

# Generate parametric interpolation for the border
xx, yy = parametric_interpolation(ff, ff, np.arange(0, n, step))

# Set specific x and y axis limits
plt.xlim(-75, -40)
plt.ylim(-60, -20)

# Plot interpolation points and country's border line
plt.scatter(x_range, y_range, label=f"{n} Interpolation points", zorder=2)
plt.plot(xx, yy, 'g', label="Country's border", zorder=1)

plt.title('Argentina')
plt.legend()

# Set the size of the plot
plt.gcf().set_size_inches(8, 6)

plt.show()

