% Automatized processing with s2p-files saved by Agilent Vector Network
% Analizer in Re/Im format: calculating module of S-parameters and its
% phases.
clear;
% name for the first file in the loop
[name1, FPATH, FLTIDX] = uigetfile ();
% distance between signal lines of antennas, cm
L=50e-4 ;
 % stop indicator
 st1=0;
if exist(name1,'file') 
        
else
    errordlg('File is not found. Check the file name.', 'File error');
    st1=1;
end
if st1==0 % Do we have s2p-files?
    ext=name1((length(name1)-2):length(name1));
    f1 = dir;
    for i=3:length(f1)
        f2=f1(i).name;
        if f2((length(f2)-2):length(f2))==ext
            A=importdata(f2,' ',8);
            f=A.data(:,1); 
            rS11=A.data(:,2); iS11=A.data(:,3);
            rS21=A.data(:,4); iS21=A.data(:,5); 
            rS12=A.data(:,6); iS12=A.data(:,7);
            rS22=A.data(:,8); iS22=A.data(:,9);
            t=length(f);
            f=f./1e9; % frequency in GHz
            S11mod=10*log10(rS11.^2+iS11.^2); % module of S11-parameter in dB 
            S11ph=atan(iS11./rS11)*180/pi   ; % phase of S11-parameter in degrees
            S11phEx=extender(S11ph)         ; % extended phase of S11-parameter
            S21mod=10*log10(rS21.^2+iS21.^2); % module of S21-parameter in dB 
            S21ph=atan(iS21./rS21)*180/pi   ; % phase of S21-parameter in degrees
            S21phEx=extender(S21ph)         ; % extended phase of S21-parameter
            S12mod=10*log10(rS12.^2+iS12.^2); % module of S12-parameter in dB 
            S12ph=atan(iS12./rS12)*180/pi   ; % phase of S12-parameter in degrees
            S12phEx=extender(S12ph)         ; % extended phase of S12-parameter
            S22mod=10*log10(rS22.^2+iS22.^2); % module of S22-parameter in dB 
            S22ph=atan(iS22./rS22)*180/pi   ; % phase of S22-parameter in degrees
            S22phEx=extender(S22ph)         ; % extended phase of S22-parameter
            
            name2=[f2(1:(length(f2)-4)),'_MagPh.txt'];
            fid1=fopen(name2,'w');
            fprintf(fid1,'Frequency\t |S11|\t Phase(S11)\t ExtPh(S11)\t |S21|\t Phase(S21)\t ExtPh(S21)\t |S12|\t Phase(S12)\t ExtPh(S12)\t |S22|\t Phase(S22)\t ExtPh(S22) \n');
            %fprintf(fid1,'GHz\t dB\t deg\t deg\t dB\t deg\t deg\t dB\t deg\t deg\t dB\t deg\t deg\t \n');
            for k1=1:length(f)
                fprintf(fid1,'%e\t%e\t%e\t%e\t%e\t%e\t%e\t%e\t%e\t%e\t%e\t%e\t%e\t\n',f(k1),S11mod(k1),S11ph(k1),S11phEx(k1),S21mod(k1),S21ph(k1),S21phEx(k1),S12mod(k1),S12ph(k1),S12phEx(k1),S22mod(k1),S22ph(k1),S22phEx(k1));
            end
            fclose(fid1);
        end
        
    end
end