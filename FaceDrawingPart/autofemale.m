function autofemale()
prompt='man or female:(m,f)';
str = 'f';
if strcmp(str,'1')
elseif strcmp(str,'2')  
else
    disp('please input (1 or 2)')
end
t= abs(str)
t=categorical(t);
A=dir('sk\*.jpg');
Alen=length(A);
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
pause(3)
msgbox('Please input the number to choose the photo');
str1 = inputdlg('Please input the number to choose the photo',...
             'Your choice', [1 50])
str_val1 = str2num(str1{1})
x1 = str_val1;
Ix=It(:,:,:,x1);
close()

%{
Ñ¡È¡ÑÛ¾¦
%}

str2 = inputdlg('big or small eye,2 for big,1 for small:(2,1)',...
             'Your choice', [1 50])
str_val2 = str2num(str2{1})
eye = str_val2;
eye=categorical(eye);
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
Yan=zeros(68,68,1,3);
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
pause(3)
msgbox('Please input the number to choose the photo');
str3 = inputdlg('Please input the number to choose the photo',...
             'Your choice', [1 50])
str_val3 = str2num(str3{1})
x2 = str_val3;
Yx=Yan(:,:,:,x2);
close()


str4 = inputdlg('big or small mouth,2 for big,1 for small:(2,1)',...
             'Your choice', [1 50])
str_val4 = str2num(str4{1})
mou = str_val4-1;
mou=categorical(mou);
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
pause(3)
msgbox('Please input the number to choose the photo');
str5 = inputdlg('Please input the number to choose the photo',...
             'Your choice', [1 50])
str_val5 = str2num(str5{1})
x3 = str_val5;
Zx=Zui(:,:,:,x3);
close()

AA=dir('nose\*.jpg');
str6 = inputdlg('big or small nose,2 for big,1 for small:(2,1)',...
             'Your choice', [1 50])
str_val6 = str2num(str6{1})
biz = str_val6-1;
biz=categorical(biz);
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
Y = classify(biconvnet,T);
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
pause(3)
msgbox('Please input the number to choose the photo');
str7 = inputdlg('big or small nose,2 for big,1 for small:(2,1)',...
             'Your choice', [1 50])
str_val7 = str2num(str7{1});
x3 = str_val7;
Nx=Nubi(:,:,:,x3);
save('ronghe.mat','Ix','Yx','Zx','Nx');
close()
disp('Interaction Over, Starting Synthesize') 

load ronghe.mat
h=msgbox('Please maximize the window and use polygons to select the area of the left eye');
pause(2)
bw1= roipoly(Ix);
pause(3)
close(figure(gcf)) 
pause(2)

h=msgbox('Please maximize the window and use polygons to select the area of the right eye');
pause(2)
bw2= roipoly(Ix);
pause(3)
close(figure(gcf)) 
pause(2)

h=msgbox('Please maximize the window and use polygons to select the area of the mouth');
pause(2)
bw3= roipoly(Ix);
pause(3)
close(figure(gcf)) 
pause(2)
bw00= bw1 | bw2 | bw3 ;  
%figure, imshow(bw00),title('mask')
%pause(10)
%close(figure(gcf)) 
Stats = regionprops(bw00,'BoundingBox');
box=vertcat(Stats.BoundingBox);
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
I0=ones(size(Ix));
Yx=Yx/255;
Zx=Zx/255;

zx=box(1,3);
zy=box(1,4);
zbx=round(box(1,1));
zby=round(box(1,2));  
Zuoyan=Yx(1:34,:);
Zuoyan=imresize(Zuoyan,[zy,zx]);
I0(zby:zby+zy-1,zbx:zbx+zx-1)=Zuoyan;

yx=box(3,3);
yy=box(3,4);
ybx=round(box(3,1));
yby=round(box(3,2));
Youyan=Yx(35:68,:);
Youyan=imresize(Youyan,[yy,yx]);
I0(yby:yby+yy-1,ybx:ybx+yx-1)=Youyan;

mx=box(2,3);
my=box(2,4);
mbx=round(box(2,1));
mby=round(box(2,2));
Zui=Zx(1:50,:);
Zui=imresize(Zui,[my,mx]);
I0(mby:mby+my-1,mbx:mbx+mx-1)=Zui;
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
bw01=~bw00;
bw00=double(bw00);
bw01=double(bw01);
maska=imfilter(bw01,fspecial('gaussian',20,10),'replicate','same');
maskb=imfilter(bw00,fspecial('gaussian',20,10),'replicate','same');
re=maska.*Ix+maskb.*I0;

load ronghe.mat
h=msgbox('Please maximize the window and use polygons to select the area of the nose');
pause(2)
bw4= roipoly(Ix);
pause(3)
close(figure(gcf)) 
pause(2)

Ib=ones(size(Ix)); 
Statsb = regionprops(bw4,'BoundingBox','image');
box2=vertcat(Statsb.BoundingBox);
nx=box2(1,3);
ny=box2(1,4);
k=nx/66; 
nbx=round(box2(1,1));
nby=box2(1,2)+ny-1;
if nby>mby-5
    nby=mby-5;
end
Biz=imresize(Nx,k);
ny=size(Biz,1);
nby=round(nby+ny/4-1);
Biz=Biz/255;
Nb=roifill(re,bw4);
Ib(nby-ny+1:nby,nbx:nbx+nx-1)=Biz;
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
bw41=~bw4;
bw40=double(bw4);
bw41=double(bw41);
maska=imfilter(bw41,fspecial('gaussian',20,10),'replicate','same');
maskb=imfilter(bw40,fspecial('gaussian',20,10),'replicate','same');
re2=maska.*Nb+maskb.*Ib;
figure
%subplot(121),imshow(Ix);
%subplot(122),
imshow(re2);
saveas(gcf,'humanface.jpg')