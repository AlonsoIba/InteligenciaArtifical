%%Ecuación 1
clc,clear,close all;
t=[0:0.1:10]';
a=2.4947;
b=8.0309;
y=a*sin(t)+b*cos(t);
phi=[sin(t) cos(t)];
[m,p]=size(phi);
[r theta1]=Fmincuad(y,phi);
figure
plot(r)
title('Estiamción de parámetros')
legend('a','b')
figure
plot(y)
hold on
plot(phi*theta1)
title('Respuesta real y estimada')
legend('Respuesta real','Respuesta estimada')

%Ecuación 2
a=2.4387;
b=9.2160;
y=a*t.^2+b*sqrt(t);
phi=[t.^2 sqrt(t)];
[m,p]=size(phi);
[r theta2]=Fmincuad(y,phi);
figure
plot(r)
title('Estiamción de parámetros')
legend('a','b')
figure
plot(y)
hold on
plot(phi*theta2)
legend('Respuesta real','Respuesta estimada')

%Ecuación 3
global u;
ti=0;
h=0.001;
tf=5;
ts=ti:h:tf;

condiciones_iniciales=[0];
[t,x]=ode45('ejemplo1',ts,condiciones_iniciales);
xp=ejemplo1(t,x);

phi=[sin(x),x.^2,u];
[m,p]=size(phi);
[r theta3]=Fmincuad(xp,phi); 
pl=phi*theta3;
figure
plot(r)
title('Estiamción de parámetros')
legend('a','b','c')

figure
plot(xp)
hold on
plot(pl)
title('Respuesta real y estimada')

legend('Respuesta real','Respuesta estimada')