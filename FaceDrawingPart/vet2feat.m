load 'vet.mat';
A=dir('sk\*.jpg');
Alen=length(A);
%处理性别
nlen=20;
ind=randperm(Alen,nlen);
T=zeros(256,256,1,nlen);
Tc=cell(nlen,1);
 for j=1:nlen
    filename=strcat('sk\',A(ind(j)).name);
    temp=imread(filename);
    temp=imresize(temp,[256,256]);
    T(:,:,:,j)=im2double(temp);
    Tc{j}=A(ind(j)).name;
end
load skconvnet.mat
Y = classify(skconvnet,T);
It=zeros(256,256,1,3);
index=find(Y==t);
index=index(1:3);
figure
set(gcf,'outerposition',get(0,'screensize'));
grid on 
for i=1:3
    X=T(:,:,1,index(i));
    It(:,:,1,i)=X;
    subplot(1,3,i)
    imshow(X)
    nm=strcat('No',num2str(i),[32],Tc{index(i)});
    title(nm)
end
pause(5)
msgbox('please input the number to select the best example');
prompt='please input the number to select the best example';
x1 = input(prompt);
Ix=It(:,:,:,x1);

%处理眼睛（注意先确定性别再分类）
ind=randperm(Alen,4*nlen);
T=zeros(68,68,1,nlen);
Tyc=cell(nlen,2);
k=1;
i=1;
while k<=nlen
    fname=strcat('dyan\',A(ind(i)).name);
    flag=lower(fname(6));
    flag=abs(flag);
    flag=categorical(flag);
    if flag==t
        T(:,:,:,k)=imread(fname);
        Tyc{k}=strcat(A(ind(i)).name);
        k=k+1;
    end
    i=i+1;
end
load yanconvnet.mat
Y = classify(yanconvnet,T);
Yan=zeros(68,68,01,3);
index=find(Y==eye);
index=index(1:3);
figure
set(gcf,'outerposition',get(0,'screensize'));
grid on
for i=1:3
    fname=strcat('yan\',Tyc{index(i)});
    X=imread(fname);
    Yan(:,:,1,i)=T(:,:,1,index(i));
    subplot(3,1,i)
    imshow(X)
    nm=strcat('No',num2str(i),[32],Tyc{index(i)});
    title(nm)
end
pause(2)
msgbox('please input the number to select the best example of eyes');
prompt='please input the number to select the best example of eyes';
x2 = input(prompt);
Yx=Yan(:,:,:,x2);

%处理嘴巴分类
ind=randperm(Alen,4*nlen);
T=zeros(100,100,1,nlen);
Tzc=cell(nlen,1);
k=1;
i=1;
while k<=nlen
    fname=strcat('szui\',A(ind(i)).name);
    flag=lower(fname(6));
    flag=abs(flag);
    flag=categorical(flag);
    if flag==t
        T(:,:,:,k)=imread(fname);
        Tzc{k}=A(ind(i)).name;
        k=k+1;
    end
    i=i+1;
end
load zuiconvnet.mat
Y = classify(zuiconvnet,T);
Zui=zeros(100,100,1,3);
index=find(Y==mou);
index=index(1:3);
figure
set(gcf,'outerposition',get(0,'screensize'));
grid on
for i=1:3
    fname=strcat('zui\',Tzc{index(i)});
    X=imread(fname);
    Zui(:,:,1,i)=T(:,:,1,index(i));
    subplot(3,1,i)
    imshow(X)
    nm=strcat('No',num2str(i),[32],Tzc{index(i)});
    title(nm)
end
pause(2)
msgbox('please input the number to select the best example of mourh');
prompt='please input the number to select the best example of mouth';
x3 = input(prompt);
Zx=Zui(:,:,:,x3);

%处理鼻子
AA=dir('nose\*.jpg');
ind=randperm(Alen,4*nlen);
T=zeros(66,66,1,nlen);
Tbc=cell(nlen,1);
k=1;
i=1;
while k<=nlen
    fname=strcat('nose\',AA(ind(i)).name);
    flag=lower(fname(6));
    flag=abs(flag);
    flag=categorical(flag);
    if flag==t
        temp=imread(fname);
        temp=temp(:,:,1);
        T(:,:,:,k)=imresize(temp,[66,66]);
        Tbc{k}=AA(ind(i)).name;
        k=k+1;
    end
    i=i+1;
end
load biconvnet.mat
Y = classify(biconvnet,im2double(T));
Nubi=zeros(66,66,1,3);
index=find(Y==biz);
index=index(1:3);
figure
set(gcf,'outerposition',get(0,'screensize'));
grid on
for i=1:3
    fname=strcat('nose\',Tbc{i});
    X=imread(fname);
    Nubi(:,:,1,i)=T(:,:,1,index(i));
    subplot(3,1,i)
    imshow(X)
    nm=strcat('No',num2str(i),[32],Tbc{index(i)});
    title(nm)
end
pause(2)
msgbox('please input the number to select the best example of nose');
prompt='please input the number to select the best example of nose';
x3 = input(prompt);
Nx=Nubi(:,:,:,x3);
save('ronghe.mat','Ix','Yx','Zx','Nx');

