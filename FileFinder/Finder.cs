using System;
using System.Collections.Generic;
using System.IO;

namespace Finder
{
    class FileFinder
    {
        string path = "";
        string value = "";
        readonly List<string> pathList = new List<string>();
        readonly List<string> dirList = new List<string>();
        public void Finder()
        {
            while (path != null && (Directory.Exists(path)==false))
            {
                Console.WriteLine("please enter a path");
                path = Console.ReadLine();
            }
            if (path != null && path.EndsWith(@"\")==false)
            {
               path+=@"\"; 
            }
            Getdirectories(path);
            foreach (string dir in dirList)
            {
                Console.WriteLine(dir);
            }
            Console.WriteLine();

            Console.WriteLine("plaese enter a search paramater");
            value = Console.ReadLine();
            GetFilePath(value);

            if (pathList.Count==0)
            {
                Console.WriteLine("No files were found");
            }
            else
            {
                foreach (string currentPath in pathList)
                {
                    Console.WriteLine(currentPath);
                } 
            }
            

            Console.ReadLine();
         
        }

        internal void Getdirectories(string getPath)
        {

                //dirList.Add(Directory.GetDirectories(path).ToList().ToString());
            try
            {
                if (Directory.GetDirectories(getPath).Length > 0)
                {
                    foreach (var dir in Directory.GetDirectories(getPath))
                    {
                        dirList.Add(dir);
                        Getdirectories(dir);
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine(getPath +"was unaccesible");
            }
            catch (PathTooLongException)
            {
                Console.WriteLine("path was to long");
            }
               

        }

        internal void GetFilePath(string getValue)
        {
            getValue += "*";
            string searchParamater = "*" + getValue + "*";
            foreach (string dir in dirList)
            {
                try
                {
                    string[] paths = Directory.GetFiles(dir, searchParamater);
                    if (paths.Length > 0)
                    {
                        foreach (var p in paths)
                        {
                            pathList.Add(p);
                        }
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    Console.WriteLine(path + "was unaccesible");
                }
                catch (PathTooLongException)
                {
                    Console.WriteLine("path was to long");
                }
            }
        }
    }
}
