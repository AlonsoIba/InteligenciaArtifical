% Autor: Erik Zamora Gómez
% Fecha 31/07/2015
% Este código es distribuido bajo la licencia CC BY-NC-SA
clear, close all, clc

% Patrones de aprendizaje y objetivos
 P=[ 1   2   3   4   5   6  ;
     7   8   7   1   2   1  ];
 T=[ -1 -1  -1   1   1   1 
     -1 -1  -1  1   1   1   ];
[Q1 Q2] =size(P) ;       %Q1 #  salidas

n1 = 2;  %Numero de neuronas en la capa oculta
ep = 1;   % Ventana de valores iniciales
% Valores iniciales
W1 = ep*(2*rand(n1,2)-1)
b1 = ep*(2*rand(n1,1)-1);
W2 = ep*(2*rand(2,n1)-1)
b2 = ep*(2*rand(n1,1)-1);
alfa = 0.01;

a1=zeros(Q1,Q2);
a2=zeros(Q1,Q2);

    for q = 1:Q2
        for k = 1:Q1
        a1(k,q) = tansig(W1(k,:)*P(:,q) + b1(k));
        a2(k,q) = tansig(W2(k,:)*a1(:,q) + b2(k));
        % Retropropagación de la sensibilidades
        e(k,q) = T(k,q)-a2(k,q)
        s2(k,q) = -2*(1-a2(k,q)^2)*e(k)
        s1(k,q) = diag(1-a1(k).^2)*W2(k)'*s2(k)
%         % Actualización de pesos sinapticos y polarizaciones
%         W2 = W2 - alfa*s2(k)*a1(k)';
%         b2 = b2(k) - alfa*s2(k);
%         W1 = W1 - alfa*s1(k)*P(:,q)';
%         b1 = b1(k) - alfa*s1(k);  
%         % Sumando el error cuadratico 
        end
        
     end

