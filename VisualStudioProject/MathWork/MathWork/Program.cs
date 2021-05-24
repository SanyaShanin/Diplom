using System;
using System.Globalization;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace MathWork
{
    class Program
    {
        static void Main(string[] args)
        {
            Merge();
        }

        static void Merge()
        {
            Console.Write("Input directory: ");
            string dir = Console.ReadLine();
            Console.Write("Input regular expression filter: ");
            string regex = Console.ReadLine();
            Console.Write("Input output file: ");
            string name = Console.ReadLine();
            Console.Write("Input row index: ");
            int row = int.Parse(Console.ReadLine());

            Regex reg = new Regex(regex);
            List<string> filesList = new List<string>();
            DirSearch(dir, filesList);
            for(var i = 0; i < filesList.Count; i++)
            {
                if (!reg.IsMatch(filesList[i]))
                {
                    filesList.RemoveAt(i);
                    i--;
                }
            }

            var files = filesList.ToArray();
            MathWorker.Merge(files, row, name);
        }

        static void Rename()
        {
            string dir = Console.ReadLine();
            foreach (var file in Directory.GetFiles(dir))
            {
                int index = file.IndexOf(".s2p");
                if (index < 0)
                    continue;

                var symb = file[index - 2];
                if (symb != '.')
                {
                    string newname = file.Remove(index) + ".0.s2p";
                    if (!File.Exists(newname))
                        File.Move(file, newname);
                    Console.WriteLine(newname);
                }
            }
        }

        static void DirSearch(string sDir, List<string> list)
        {
            foreach (string d in Directory.GetDirectories(sDir))
            {
                foreach (string f in Directory.GetFiles(d))
                {
                    list.Add(f);
                }
                DirSearch(d, list);
            }
        }
    }
}
