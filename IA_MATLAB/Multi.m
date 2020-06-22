clc, clear all;

m = readmatrix('RGBCSV.csv') ;

rojo=m(1:21,1:3);
verde=m(22:42,1:3);
amarillo=m(43:63,1:3);
azul=m(64:84,1:3);

P=[255,0,0];


fr= normpdf(P,mean(rojo),cov(rojo))
fv= normpdf(P,mean(verde),cov(verde))
fa= normpdf(P,mean(amarillo),cov(amarillo))
fb= normpdf(P,mean(azul),cov(azul))

%f2=exp(-((P-mu)*inv(cov(x))*(P-mu)')/2)/sqrt((2*pi)^1*det(cov(x)))


