clc, clear, close all;
%%Red neuronal dos capas para XOR
P=[ 0,0,1,1;
    0,1,0,1];

T=[ 1,0,0,1];

W1= zeros(2,2);
%2*rand(2,2)-1;
b1=[-0.5;-1.5];
%2*rand(2,1)-1;
W2= [1 -1];
%2*rand(2,2)-1;
b2=0.5;
%2*rand(2,1)-1;
e=zeros(4,1);

f1=zeros(2,1);

[filas renglones]=size(P);
for epocas=1:100
for i=1:renglones
       e(i)=T(i)-hardlim((W1(1,:)*P(:,i)+b1(1))*(W1(2,:)*P(:,i)+b1(2)))
       W1=W1+e(i)*P(:,i)'

end
end
