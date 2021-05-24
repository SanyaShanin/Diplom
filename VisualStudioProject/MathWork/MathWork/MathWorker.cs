using System;
using System.IO;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathWork
{
    class MathWorker
    {
        static public void DoWork(double[][] A, double[][] B, string filename)
        {
            double[] rS11 = new double[A.Length],
                     iS11 = new double[A.Length],
                     rS21 = new double[A.Length],
                     iS21 = new double[A.Length],
                     rS12 = new double[A.Length],
                     iS12 = new double[A.Length],
                     rS22 = new double[A.Length],
                     iS22 = new double[A.Length],
                     rS11max = new double[A.Length],
                     iS11max = new double[A.Length],
                     rS21max = new double[A.Length],
                     iS21max = new double[A.Length],
                     rS12max = new double[A.Length],
                     iS12max = new double[A.Length],
                     rS22max = new double[A.Length],
                     iS22max = new double[A.Length],

                     S21mod = new double[A.Length],
                     S21ph  = new double[A.Length],
                     S21cph = new double[A.Length],
                     S12mod = new double[A.Length],
                     S12ph  = new double[A.Length],
                     S12cph = new double[A.Length],

                     S12phc = new double[A.Length],
                     S21phc = new double[A.Length],

                     S21cphc = new double[A.Length],
                     S12cphc = new double[A.Length],

                     f = new double[A.Length];

            int k = 0, n = 0, k1 = 0, n1 = 0;
            int kd = 0, nd = 0, k1d = 0, n1d = 0;

            string textoutput = "";

            for (var i = 0; i < A.Length; i++)
            {
                f[i]        = A[i][0] / 1000000000; // Frequency in GHz
                rS11[i]     = A[i][1];
                iS11[i]     = A[i][2];
                rS21[i]     = A[i][3];
                iS21[i]     = A[i][4];
                rS12[i]     = A[i][5];
                iS12[i]     = A[i][6];
                rS22[i]     = A[i][7];
                iS22[i]     = A[i][8];
                rS11max[i]  = B[i][1];
                iS11max[i]  = B[i][2];
                rS21max[i]  = B[i][3];
                iS21max[i]  = B[i][4];
                rS12max[i]  = B[i][5];
                iS12max[i]  = B[i][6];
                rS22max[i]  = B[i][7];
                iS22max[i]  = B[i][8];

                S21mod[i] = 10 * Math.Log10(Math.Pow(rS21[i]-rS21max[i], 2) + Math.Pow(iS21[i] - iS21max[i], 2));
                S21ph[i] = Math.Atan((iS21[i] - iS21max[i])/(rS21[i]-rS21max[i])) * 180 / Math.PI;
                S21cph[i] = Math.Atan((iS21[i] / rS21[i] - iS21max[i] / rS21max[i]) / (1 + (iS21[i] / rS21[i]) * (iS21max[i] / rS21max[i]))) * 180 / Math.PI;

                S12mod[i] = 10 * Math.Log10(Math.Pow(rS12[i] - rS12max[i], 2) + Math.Pow(iS12[i] - iS12max[i], 2)); // module of S12-parameter in dB
                S12ph[i] = Math.Atan((iS12[i] - iS12max[i]) / (rS12[i] - rS12max[i])) * 180 / Math.PI; // phase of S12-parameter in degrees
                S12cph[i] = Math.Atan((iS12[i] / rS12[i] - iS12max[i] / rS12max[i]) / (1 + (iS12[i] / rS12[i]) * (iS12max[i] / rS12max[i]))) * 180 / Math.PI;

                if (i >= 1)
                {
                    if (S21ph[i] - S21ph[i - 1] > 130)
                    {
                        k = k + 1;
                    }
                    if (S21ph[i] - S21ph[i - 1] < -130)
                    {
                        n = n + 1;
                    }
                    S21phc[i] = S21ph[i] - 180 * k + 180 * n;

                    if (S12ph[i] - S12ph[i - 1] > 130)
                    {
                        k1 = k1 + 1;
                    }
                    if (S12ph[i] - S12ph[i - 1] < -130) {
                        n1 = n1 + 1;
                    }
                    S12phc[i] = S12ph[i] - 180 * k1 + 180 * n1;

                    if (S21cph[i] - S21cph[i - 1] > 130) {
                        kd = kd + 1;
                    }
                    if (S21cph[i] - S21cph[i - 1] < -130) {
                        nd = nd + 1;
                    }
                    S21cphc[i] = S21cph[i] - 180 * kd + 180 * nd;

                    if (S12cph[i] - S12cph[i - 1] > 130) {
                        k1d = k1d + 1;
                    }
                    if (S12cph[i] - S12cph[i - 1] < -130)
                    {
                        n1d = n1d + 1;
                    }
                    S12cphc[i] = S12cph[i] - 180 * k1d + 180 * n1d;
                }
                else
                {
                    S21phc[i] = S21ph[i];
                    S12phc[i] = S21ph[i];
                    S21cphc[i] = S21cph[i];
                    S12cphc[i] = S21cph[i];
                }
                //a=[f, S21mod, S21ph, S21phc, S21cph, S21cphc, S12mod, S12ph, S12phc, S12cph, S12cphc];
                textoutput += "\n" + f[i].ToString(CultureInfo.InvariantCulture) + "\t" + S21mod[i].ToString(CultureInfo.InvariantCulture) + "\t" + S21ph[i].ToString(CultureInfo.InvariantCulture) + "\t" + S21phc[i].ToString(CultureInfo.InvariantCulture) + "\t" + S21cph[i].ToString(CultureInfo.InvariantCulture) + "\t" + S21cphc[i].ToString(CultureInfo.InvariantCulture) + "\t" + S12mod[i].ToString(CultureInfo.InvariantCulture) + "\t" + S12ph[i].ToString(CultureInfo.InvariantCulture) + "\t" + S12phc[i].ToString(CultureInfo.InvariantCulture) + "\t" + S12cph[i].ToString(CultureInfo.InvariantCulture) + "\t" + S12cphc[i].ToString(CultureInfo.InvariantCulture);
            }

            string output = "Frequency \t |S21| \t Phase(S21) \t ExtPhase(S21) \t CorPhase(S21)\t ExtCorPhase(S21)\t |S12| \t Phase(S12)\t ExtPhase(S12) \t CorPhase(S12)\t ExtCorPhase(S12)\n" +
                            "GHz \t dB \t deg \t deg \t deg\t deg\t dB \t deg \t deg \t deg\t deg" +
                            textoutput;

            File.WriteAllText(filename, output);
        }
        
        static public void Merge(string[] files, int row, string savefile, int offset = 2)
        {
            double[][][] datas = new double[files.Length][][];

            string output = "Frequency\t";
            for (var i = 0; i < files.Length; i++)
            {
                datas[i] = ReadFile(files[i], offset);
                output += files[i] + "\t";
            }
            output += "\n";
            
            for(var i = 0; i < datas[0].Length; i++)
            {
                string[] line = new string[files.Length + 1];
                for(var j = 0; j < files.Length; j++)
                {
                    line[j + 1] = datas[j][i][row].ToString(CultureInfo.InvariantCulture);
                }
                line[0] = (datas[0][i][0]).ToString(CultureInfo.InvariantCulture);
                output += string.Join("\t", line) + "\n";
            }

            output = "" +
                     output;

            File.WriteAllText(savefile, output);
        }
        
        static public double[][] ReadFile(string filename, int offset = 8)
        {
            string[] lines;
            var content = File.ReadAllText(filename);
            lines = content.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            int index = 0;
            double[][] data = new double[lines.Length - offset][];
            for (var i = offset; i < lines.Length; i++)
            {
                var line = lines[i];
                var rawline = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                var rawdata = new double[rawline.Length];
                for (var j = 0; j < rawdata.Length; j++)
                {
                    string parse = rawline[j];
                    double value = Double.Parse(parse, CultureInfo.InvariantCulture);
                    rawdata[j] = value;
                }
                data[index] = rawdata;
                index++;
            }

            return data;
        }
    }
}

/*
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

% saving
nam=[name(1:length(name)-4),'_cor0.txt'] ;
fid=fopen(nam,'w');
fprintf(fid,'Frequency \t |S21| \t Phase(S21) \t ExtPhase(S21) \t CorPhase(S21)\t ExtCorPhase(S21)\t |S12| \t Phase(S12)\t ExtPhase(S12) \t CorPhase(S12)\t ExtCorPhase(S12)\n');
fprintf(fid,'GHz \t dB \t deg \t deg \t deg\t deg\t dB \t deg \t deg \t deg\t deg\n');
fclose(fid);
a=[f, S21mod, S21ph, S21phc, S21cph, S21cphc, S12mod, S12ph, S12phc, S12cph, S12cphc];
save(nam,'a','-ascii','-tabs','-append');
*/