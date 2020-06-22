clc,clear,close all;
t=[1:1:10];
y=t.^2';
[n r]=size(y);
ypto=zeros(n-2,1);
for k=3:n-1
    ypto(k-1)=(y(k)-y(k-2))/(2*(t(k)-t(k-2)));
end
ypto
