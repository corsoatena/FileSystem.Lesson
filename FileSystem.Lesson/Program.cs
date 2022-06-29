using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileSystem.Lesson
{
    internal class Program
    {
        static void Main(string[] args)
        {

            SimpleFileDelete(@"C:\CorsoAtena1\", "Corso.txt"); 
            //string MySystem = "W";
            //string myDirectory = "downloads";

            //if (MySystem.Equals("W"))
            //{
            //    SpecialPath("C:", myDirectory);
            //    SpecialDirectory();

            //}
            //else
            //{
            //    SpecialPath("home", myDirectory);
            //    SpecialDirectory();

            //}
        }
        static void SpecialPath(string RootPath, String MyDir) // Path  = percorso LOCAL  -> REMOTE path -> SERVER , URL 
        {
            string myPath=  $"{RootPath}{Path.DirectorySeparatorChar}{MyDir}";

            Console.WriteLine(myPath);
            // C:\users\bruno\ -> Windows 
            // Home/Bruno/miofile/ -> UNIX + MacOS
        }
        static void SpecialDirectory()
        {  
            string SpecialDir = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            Console.WriteLine(SpecialDir);
        }
        static void SplitPath()
        {
            string myDirectory = Directory.GetCurrentDirectory(); 
            Console.WriteLine(myDirectory);
            string[] splitedPath = myDirectory.Split(Path.DirectorySeparatorChar);

            foreach (var item in splitedPath)
            {
                int counter = 1;
                Console.Write(counter + "-"); 
                Console.WriteLine(item);
                counter++; 
            }
             JoinPath(splitedPath); 
        }
        static void JoinPath(string[] _path)
        {   
            
            var path =  Path.Combine(_path);
            Console.Write("JOINED STRINGS: ");
            Console.WriteLine(path);
        } 
        static void GetFileExtention() 
        {
            var fExt = Path.GetExtension("vendita.json"); 
        }
        static void GetDirInfo()
        {
            string path = Directory.GetCurrentDirectory(); // -> trova il Path 
            DirectoryInfo dInfos = new DirectoryInfo(path);

            //foreach (var info in dInfos.GetDirectories())
            //{
            //    Console.WriteLine(info.Parent);
            //}

            foreach (var item in dInfos.GetFiles())
            {
                Console.WriteLine(item.Name);

            }
        }
        static void SearchInDirectory()
        {
            var files = Directory.EnumerateFiles(Directory.GetCurrentDirectory(), 
                "*.txt",
                SearchOption.AllDirectories);

            foreach (var file in files)
                Console.WriteLine(file);
        }
        static void FindOrCreate(String path)
        {
            DirectoryInfo info = new DirectoryInfo(path);   

            if(info.Exists)
            {
                Console.WriteLine(info.FullName);
                Console.WriteLine(info.Name);
                Console.WriteLine(info.Parent);
            }
            else
            {
                info.Create();
                Console.WriteLine(info.FullName);
                Console.WriteLine(info.Name);
                Console.WriteLine(info.Parent);
            }   
        }
        static void CreateFile(string FileName)
        {
            File.Create(FileName);
        }
        static void WriteOnFile(string path, string FileName)
        {
            List<string> mytext = new List<string>()
            {
                "Heello by Bruno",
                "Heello by marco",
                "Heello by Maria"
            };

            File.AppendAllLines(Path.Combine(path, FileName), mytext);
        }
        static void ReadOnFile(string path, string FileName)
        {
            var texd = File.ReadAllText(Path.Combine(path, FileName));
            Console.WriteLine(texd);
        } 
        static void SimpleFileMove(string SrcPath, string destPath, string Filename)
        {
            string Src = Path.Combine(SrcPath, Filename);
            string dest = Path.Combine(destPath, Filename);
            File.Move(Src, dest);
        }
        static void SimpleFileCopy(string SrcPath, string destPath, string Filename)
        {
            string Src = Path.Combine(SrcPath, Filename);
            string dest = Path.Combine(destPath, Filename);
            File.Copy(Src, dest,true); 
        }
        static void SimpleFileDelete(string SrcPath, string Filename)
        {
           
            File.Delete(Path.Combine(SrcPath, Filename));
            
        }


    } 
   
}
