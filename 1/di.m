% Loading the S2P file with main data and the S2P file obtained at maximum current in the electromagnet
clear;
[name, FPATH, FLTIDX] = uigetfile ();
[nameMax, FPATHMax, FLTIDXMax] = uigetfile ();
%name='H2_3.9-4.7GHZ_I3A_M25DBM_IF0.2_AV5.S2P'; % main file name
%nameMax='H2_3.9-4.7GHZ_I10A_M25DBM_IF0.2_AV0.S2P' ; % name of the file with data obtained at high currents
L=200e-4 ; % distance between signal lines of antennas, cm
A=importdata(name,' ',8)   ; 
B=importdata(nameMax,' ',8);
f=A.data(:,1); 
rS11=A.data(:,2); iS11=A.data(:,3);   rS11max=B.data(:,2); iS11max=B.data(:,3);
rS21=A.data(:,4); iS21=A.data(:,5);   rS21max=B.data(:,4); iS21max=B.data(:,5);
rS12=A.data(:,6); iS12=A.data(:,7);   rS12max=B.data(:,6); iS12max=B.data(:,7);
rS22=A.data(:,8); iS22=A.data(:,9);   rS22max=B.data(:,8); iS22max=B.data(:,9);
t=length(f);
f=f./1e9; % frequency in GHz
S21mod=10*log10((rS21-rS21max).^2+(iS21-iS21max).^2); % module of S21-parameter in dB when signal at higher field is substracted
S21ph=atan((iS21-iS21max)./(rS21-rS21max))*180/pi   ; % phase of S21-parameter in degrees
S21cph=atan((iS21./rS21-iS21max./rS21max)./(1+(iS21./rS21).*(iS21max./rS21max)))*180/pi;
%S21cph is calculated as angle a=a21-a21(Hmax) =>
%tan(a)=tan(a21-a21(Hmax))=(tan(a21)-tan(a21(Hmax))/(1+tan(a21)*tan(a21(Hmax))
S12mod=10*log10((rS12-rS12max).^2+(iS12-iS12max).^2); % module of S12-parameter in dB
S12ph=atan((iS12-iS12max)./(rS12-rS12max))*180/pi   ; % phase of S12-parameter in degrees
S12cph=atan((iS12./rS12-iS12max./rS12max)./(1+(iS12./rS12).*(iS12max./rS12max)))*180/pi;
k=0; n=0; k1=0; n1=0;
S21phc=zeros(t,1); S12phc=zeros(t,1);   % extended phase
S21phc(1)=S21ph(1); S12phc(1)=S12ph(1);
for i=2:t
    if S21ph(i)-S21ph(i-1)>130  
        k=k+1 ;
    end
    if S21ph(i)-S21ph(i-1)<-130
        n=n+1 ;
    end
    S21phc(i)=S21ph(i)-180*k;
    S21phc(i)=S21phc(i)+180*n;
       if S12ph(i)-S12ph(i-1)>130
        k1=k1+1 ;
       end
    if S12ph(i)-S12ph(i-1)<-130
        n1=n1+1 ;
    end
    S12phc(i)=S12ph(i)-180*k1;
    S12phc(i)=S12phc(i)+180*n1;
end
k=0; n=0; k1=0; n1=0;
S21cphc=zeros(t,1); S12cphc=zeros(t,1);     % extended corrected phase
S21cphc(1)=S21cph(1); S12cphc(1)=S12cph(1);
for i=2:t
    if S21cph(i)-S21cph(i-1)>130  
        k=k+1 ;
    end
    if S21cph(i)-S21cph(i-1)<-130
        n=n+1 ;
    end
    S21cphc(i)=S21cph(i)-180*k;
    S21cphc(i)=S21cphc(i)+180*n;
       if S12cph(i)-S12cph(i-1)>130
        k1=k1+1 ;
       end
    if S12cph(i)-S12cph(i-1)<-130
        n1=n1+1 ;
    end
    S12cphc(i)=S12cph(i)-180*k1;
    S12cphc(i)=S12cphc(i)+180*n1;
end
k21=(-S21phc.*(pi/180))./L;
k12=(-S12phc.*(pi/180))./L;
k21c=(-S21cphc.*(pi/180))./L;
k12c=(-S12cphc.*(pi/180))./L;
% plotting
scrsz=get(0,'ScreenSize'); % ScreenSize is a four-element vector: [left, bottom, width, height]
figure('OuterPosition',[1 scrsz(4)/16 scrsz(3)/2 (scrsz(4)*15/16)]);
ax1=subplot(2,1,1);
plot(f,S21mod, '-bs', 'LineWidth', 2, 'MarkerSize',2);
hold on ;
plot(f, S12mod,'-rs','LineWidth', 2,'MarkerSize',2) ;
title('\bf |S_{21}| and |S_{12}| vs. frequency ', 'FontSize', 12) ;
xlabel('\bf Frequency, GHz', 'FontSize', 12) ;
ylabel('\bf |S_{21}|, |S_{12}| dB','FontSize', 12) ;
legend('S_{21}','S_{12}'); legend('boxoff');
grid on ;
ax2=subplot(2,1,2);
plot(f,S12cph, '-k', 'LineWidth', 2, 'MarkerSize',2); 
hold on ;
plot(f,S21cph, '-b', 'LineWidth', 2, 'MarkerSize',2);
plot(f, S12cphc,'-g','LineWidth', 2,'MarkerSize',2) ;
plot(f, S21cphc,'-y','LineWidth', 2,'MarkerSize',2) ;
%plot(f,S12cph, '-k', 'LineWidth', 2, 'MarkerSize',2);
%plot(f, S21cphc,'-b','LineWidth', 2,'MarkerSize',2) ;
%plot(f, S12cphc,'-g','LineWidth', 2,'MarkerSize',2) ;
title('\bf Phase of S_{21} and S_{12} vs. frequency ', 'FontSize', 12) ;
xlabel('\bf Frequency, GHz', 'FontSize', 12) ;
ylabel('\bf Phase(S_{21}), Phase(S_{12}), deg','FontSize', 12) ;
legend('S_{12}(Phase)','S_{21}(Phase)','S_{12}(ExCorPh)','S_{21}(ExCorPh)'); legend('boxoff');
grid on ;
linkaxes([ax1,ax2],'x');
%figure('OuterPosition',[scrsz(3)/2 scrsz(4)/2 scrsz(3)/2 scrsz(4)/2]);
%plot(k21,f,'-bs','LineWidth', 1,'MarkerSize',1);
%hold on;
%plot(k12,f,'-rs','LineWidth', 1,'MarkerSize',1);
%grid on;
%title('\bf Dispersion characteristic ', 'FontSize', 12) ;
%xlabel('\bf Wavevector, cm^{-1}', 'FontSize', 12) ;
%ylabel('\bf Frequency, GHz','FontSize', 12) ;
% saving
nam=[name(1:length(name)-4),'_cor0.txt'] ;
fid=fopen(nam,'w');
fprintf(fid,'Frequency \t |S21| \t Phase(S21) \t ExtPhase(S21) \t CorPhase(S21)\t ExtCorPhase(S21)\t |S12| \t Phase(S12)\t ExtPhase(S12) \t CorPhase(S12)\t ExtCorPhase(S12)\n');
fprintf(fid,'GHz \t dB \t deg \t deg \t deg\t deg\t dB \t deg \t deg \t deg\t deg\n');
fclose(fid);
a=[f, S21mod, S21ph, S21phc, S21cph, S21cphc, S12mod, S12ph, S12phc, S12cph, S12cphc];
save(nam,'a','-ascii','-tabs','-append');
%nam1=[name(1:length(name)-4),'_dispersion.txt'] ;
%fid1=fopen(nam1,'w');
%fprintf(fid1,'k21 \t k12 \t Cor-k21 \t Cor-k12 \t Frequency \t LinedPhase(S21) \t LinedPhase(S12) \t LinedCorPhase(S21) \t LinedCorPhase(S12) \n');
%fprintf(fid1,'cm^-1 \t cm^-1 \t cm^-1 \t cm^-1 \t GHz \t deg \t deg \n');
%fclose(fid1);
%b=[k21, k12, k21c, k12c, f, S21phc, S12phc, S21cphc, S12cphc];
%save(nam1,'b','-ascii','-tabs','-append');