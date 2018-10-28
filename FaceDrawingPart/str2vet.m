data='man with big eye,big mouth,big nose';
%处理文本描述
data=lower(data);
data=strrep(data,',',' ');
Nc = split(data,' ');
strlen=numel(Nc);
xingbie1={'man','men','nan','male','boy'};
xingbie2={'woman','women','nv','nu','female','girl','lady'};
%匹配性别的描述
for i=1:strlen
    if  ismember(Nc{i},xingbie1)
        t=abs('m');
    elseif ismember(Nc{i},xingbie2)
        t=abs('f');
    end
end
t=categorical(t);
%处理特征
tyan={'eye','yanjing','yan'};
tzui={'mouth','zui','kou','zuiba'};
tbi={'bi','bizi','nose','biliang'};
tezheng={'da','xiao','big','small'};
da={'da','big'};
xiao={'xiao','small'};
k=1;
for i=2:strlen
    if  ismember(Nc{i},tyan)
        tempyan=Nc(k:i-1);
        k=i+1;
    elseif ismember(Nc{i},tzui)
        tempzui=Nc(k:i-1);
        k=i+1;
    elseif ismember(Nc{i},tbi)
        tempbi=Nc(k:i-1);
        k=k+1;
    end
end

for i=1:numel(tempyan)
    if ismember(tempyan{i},da)
        eye=categorical(2);
    elseif ismember(tempyan{i},xiao)
        eye=categorical(1);
    end
end

for i=1:numel(tempzui)
    if ismember(tempzui{i},da)
        mou=categorical(1);
    elseif ismember(tempzui{i},xiao)
        mou=categorical(0);
    end
end

for i=1:numel(tempbi)
    if ismember(tempbi{i},da)
        biz=categorical(1);
    elseif ismember(tempbi{i},xiao)
        biz=categorical(0);
    end
end
save('vet.mat','t','eye','mou','biz'); 
