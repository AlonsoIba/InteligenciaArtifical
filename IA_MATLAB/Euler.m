clc,clear,close all;
K=1;z=0.1;wn=1;
G=tf([K*wn^2],[1 2*z*wn wn^2])
[y,t]=step(G);
y=y(1:2:end);
t=t(1:2:end);
%y=y(1:2:end);
%t=t(1:2:end);
[n r]=size(y);
ypto=zeros(n-1,1);
for k=2:n-2
    ypto(k-1)=(y(k+1)-y(k-1))/(2*(t(k+1)-t(k)));
end
ypto2=zeros(n-1,1);
for k=2:n-2
    ypto2(k-1)=(y(k+1)-2*y(k)+y(k-1))/(t(k+1)-t(k))^2;
end
U=ones(n-1,1);
y=y(2:end)';
t=t(2:end);

figure
plot(t,y)
hold on
plot(t,ypto)
hold on
plot(t,ypto2)
legend("y","ypto","ypto2");


%phi=[ypto2 ypto U];
Psi(1,:)=ypto2;
Psi(2,:)=ypto;
Psi(3,:)=U;
a=0;b=0;c=0;
theta=[a ; b ;c];
P=eye(3,3)*10e2;

for i=1:10000
    e=y'-Psi'*theta;
    theta=theta+P*Psi*(eye(size(t,1))+Psi'*P*Psi)^(-1)*e;
    P=P-P*Psi*(eye(size(t,1))+Psi'*P*Psi)^(-1)*Psi'*P;
end
theta
wne=sqrt(-theta(1));
ze=-theta(2)*wne/2;
Ke=theta(3);
ye=(-ypto2/wne^2-2*ze*ypto/wne+Ke*U);
A=Ke
B=Ke/sqrt(1-ze^2)
C=ze*wne
D=wne.*(sqrt(1-ze^2))
E=atan((sqrt(1-ze^2))/ze)
yp=A-B.*exp(-C.*t).*sin(D.*t+E);

figure
plot(t,y,'o')
hold on
plot(t,Psi'*theta)
hold on
plot(t,yp)







