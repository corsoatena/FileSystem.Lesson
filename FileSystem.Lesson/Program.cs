using System;
using System.IO;
using System.Text;

namespace FileSystem.Lesson
{
    internal class Program
    {
        static void Main(string[] args)
        {

            FindOrCreate(@"C:\CorsoAtena"); // C:\Download\miofile
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
    }
}
