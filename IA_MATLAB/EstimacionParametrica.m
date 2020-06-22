clc, clear, close all;

t=[1:1:10];
y=10*sin(t)+7.5*exp(t)+15*cos(t);

a=0;b=0;c=0;
theta=[a;b;c];
Psi(1,:)=sin(t);
Psi(2,:)=exp(t);
Psi(3,:)=cos(t);
P=eye(3,3)*1000;
for i=1:100
    e=y'-Psi'*theta;
    theta=theta+P*Psi*(eye(10)+Psi'*P*Psi)^(-1)*e;
    P=P-P*Psi*(eye(10)+Psi'*P*Psi)^(-1)*Psi'*P;
end
theta