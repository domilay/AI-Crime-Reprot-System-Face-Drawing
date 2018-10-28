% clear all
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
h=msgbox('Please maximize the window and use polygons to select the area of the mouth');
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