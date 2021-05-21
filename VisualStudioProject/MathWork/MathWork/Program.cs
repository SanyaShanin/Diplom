using System;
using System.Globalization;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathWork
{
    class Program
    {
        static void Main(string[] args)
        {
            string file0 = "";
            string file1 = "";
            double[][] data0 = new double[][] { };
            double[][] data1 = new double[][] { };
            
            Console.WriteLine("Input source file: ");
            file0 = Console.ReadLine();
            Console.WriteLine("Input data file: ");
            file1 = Console.ReadLine();

            if (!File.Exists(file0) || !File.Exists(file1))
            {
                Console.WriteLine("Invalid file or files!");
                return;
            }

            data0 = MathWorker.ReadFile(file0);
            data1 = MathWorker.ReadFile(file1);

            MathWorker.DoWork(data0, data1, "output.txt");
        }
    }
}
