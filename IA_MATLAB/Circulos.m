clc, clear, close all;



P=[ 2.5 2.5	0	5	2.5	2.5	1.25	3.75;
    0	5	2.5	2.5	1.25	3.75	2.5	2.5]


T=[ 0   0   0   0   1   1   1   1];



W=zeros(1,2);%%2*rand(1,7)-1;
b=0;%2*rand(1)-1;
for epocas=1:1
for q=1:8
    e(q)=T(q)-hardlim((W*P(:,q))^2+b);
    W=W+e(q)*P(:,q)';
    b=b+e(q);
end
end
W
b
e



