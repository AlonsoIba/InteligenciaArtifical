clc, clear , close all;
A=[1 2 0;3 1 0; 0 5 1];

detA = det(A)
invA = inv(A)
cofactorA = transpose(detA*invA)