clear all; close all; clc;

% Nusiskaitome duomenis
S = shaperead('ne_10m_admin_0_countries.shp')

id = -1; % konkreèios ðalies ID
for i = 1:size(S,1)
    if strcmp(S(i).NAME_EN,'Lithuania')
        id = i;
        break; 
    end
end
if (id == -1)
    'tokios ðalies nëra, pasitikrinkite pavadinimà'
end
% nupieðiame ðalies kontûrà pagal duotus taðkus
figure(1); grid on; hold on;
title(S(id).NAME_EN);
plot(S(id).X, S(id).Y);

% S(id).X, S(id).Y - taðkai, kuriuos galima naudoti ðalies kontûro
% vaizdavimui (pvz. iðsivesti juos á txt ar csv failà)

csvwrite('X.txt',S(id).X)
csvwrite('Y.txt',S(id).Y)