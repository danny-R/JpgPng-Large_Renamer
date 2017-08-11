
using System;
using System.IO;

namespace ReNamer
{
    class Start
    {
        public static void Main(string[] args)
        {
            TextReader read = Console.In;
            TextWriter write = Console.Out;
            string str;

            string[] temppath;
            string[] dpath = new string[25];
            int id;  

            if (!File.Exists("JpgPng-Large_Renamer_path.txt"))
            {
                write.WriteLine("Not Found \"JpgPng-Large_Renamer_path.txt\".\nPlease push Enter(Return) key for exit...");
                read.ReadLine();
                return;
            }

            try
            {
                temppath = File.ReadAllLines("JpgPng-Large_Renamer_path.txt");
            }
            catch (Exception e)
            {
                write.WriteLine("!!! ERROR !!!");
                write.WriteLine(e.ToString());
                read.ReadLine();
                return;
            }

            write.WriteLine("jpg-large to jpg/png-large to png");

            id = 0;
            foreach (string path in temppath)
            {
                if (Directory.Exists(path))
                {
                    dpath[id] = path;
                    write.WriteLine(dpath[id]);
                    id++;
                }
            }
            if(id == 0)
            {
                write.WriteLine("Valid Path not exist.\nPlase push Enter(Return) key for exit...");
                read.ReadLine();
                return;
            }

            write.WriteLine("These is VALID PATH, Rename is ready, OK?\n start::'y'or'Y'and Enter(Return)\n exit ::other key or not input key and Enter");
            str = read.ReadLine();

            if (str.Equals("y") || str.Equals("Y"))
            {
                foreach(string spath in dpath)
                {
                    if(id == 0) { break; }
                    id--;

                    write.Write("# ");
                    write.WriteLine(spath + " ------");

                    // .jpg-large
                    foreach (string FileName in Directory.GetFiles(spath, "*.jpg-large"))
                    {
                        write.WriteLine(FileName);
                        str = FileName.Replace(".jpg-large", ".jpg");
                        File.Move(FileName, str);
                    }
                    // .png-large
                    foreach (string FileName in Directory.GetFiles(spath, "*.png-large"))
                    {
                        write.WriteLine(FileName);
                        str = FileName.Replace(".png-large", ".png");
                        File.Move(FileName, str);
                    }
                    write.WriteLine("Rename End.\n");
                }
                
            }
            else
            {
                return;
            }
            write.WriteLine("Plase push Enter(Return) key for exit...");
            read.ReadLine();
            return;
        }
    }
}