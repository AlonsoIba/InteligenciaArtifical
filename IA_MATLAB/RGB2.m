clc,clear,close all;
m = readmatrix('RGBCSV.csv') ;

P=m(:,1:3);
T=m(:,4:6);

P=P';
T=P;


W=zeros(3,3)
b=zeros(3,1);
[filas columnas]=size(P);
e=ones(filas,columnas);
for epocas=1:1
for i=1:columnas
    for j=1:filas
        e(j,i)=T(j,i)-W(j,:)*P(:,i)+b(j)*logsig(W(j,:)*P(:,i)+b(j));
        W=W+e(:,i)*P(:,i)'
        b(j)=b(j)+e(j,i);
    end
end
end

W
b
e

