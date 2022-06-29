using System;
using System.IO;

namespace FileSystem.Lesson
{
    internal class Program
    {
        static void Main(string[] args)
        {

            SplitPath(); 
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
                Console.WriteLine(item);
            }
        }
    }
}
