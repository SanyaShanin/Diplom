using System;
using System.IO;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpinWaveToolsFramework
{
    class MathWorker
    {
        static public void DoWork(double[][] A, double[][] B, string filename, string comment = "")
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
                     S21ph = new double[A.Length],
                     S21cph = new double[A.Length],
                     S12mod = new double[A.Length],
                     S12ph = new double[A.Length],
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
                f[i] = A[i][0] / 1000000000; // Frequency in GHz
                rS11[i] = A[i][1];
                iS11[i] = A[i][2];
                rS21[i] = A[i][3];
                iS21[i] = A[i][4];
                rS12[i] = A[i][5];
                iS12[i] = A[i][6];
                rS22[i] = A[i][7];
                iS22[i] = A[i][8];
                rS11max[i] = B[i][1];
                iS11max[i] = B[i][2];
                rS21max[i] = B[i][3];
                iS21max[i] = B[i][4];
                rS12max[i] = B[i][5];
                iS12max[i] = B[i][6];
                rS22max[i] = B[i][7];
                iS22max[i] = B[i][8];

                S21mod[i] = 10 * Math.Log10(Math.Pow(rS21[i] - rS21max[i], 2) + Math.Pow(iS21[i] - iS21max[i], 2));
                S21ph[i] = Math.Atan((iS21[i] - iS21max[i]) / (rS21[i] - rS21max[i])) * 180 / Math.PI;
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
                    if (S12ph[i] - S12ph[i - 1] < -130)
                    {
                        n1 = n1 + 1;
                    }
                    S12phc[i] = S12ph[i] - 180 * k1 + 180 * n1;

                    if (S21cph[i] - S21cph[i - 1] > 130)
                    {
                        kd = kd + 1;
                    }
                    if (S21cph[i] - S21cph[i - 1] < -130)
                    {
                        nd = nd + 1;
                    }
                    S21cphc[i] = S21cph[i] - 180 * kd + 180 * nd;

                    if (S12cph[i] - S12cph[i - 1] > 130)
                    {
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

            string output = comment + "Frequency \t |S21| \t Phase(S21) \t ExtPhase(S21) \t CorPhase(S21)\t ExtCorPhase(S21)\t |S12| \t Phase(S12)\t ExtPhase(S12) \t CorPhase(S12)\t ExtCorPhase(S12)\n" +
                            "GHz \t dB \t deg \t deg \t deg\t deg\t dB \t deg \t deg \t deg\t deg" +
                            textoutput;

            File.WriteAllText(filename, output);
        }
        static public void DoWork(string A, string B, string filename, string comment = "")
        {
            var dataA = ReadFile(A);
            var dataB = ReadFile(B);
            DoWork(dataA, dataB, filename, comment);
        }
        static public double[][] ReadFile(string filename, int offset = 8)
        {
            string[] lines;
            var content = File.ReadAllText(filename);
            lines = content.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            int index = 0;
            double[][] data = new double[lines.Length - 8][];
            for (var i = offset; i < lines.Length; i++)
            {
                var line = lines[i];
                var rawline = line.Split(' ');
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
