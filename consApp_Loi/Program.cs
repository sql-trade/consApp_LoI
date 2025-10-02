using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace MyApp
{
    public class MyClass
    {
        static void Main()
        {
            string path = @"C:\Users\" + Environment.UserName + @"\AppData\Roaming\ATAS\Indicators\cache\tradeneon";
            string filter = @"*ES*";

            int ii = 0;

            //-----
            Console.WriteLine("begin ...");
            Console.WriteLine("");

            var mc = new MyClass();
            string latestFileName = mc.GetLatestFileName(path, filter);


            //string[,] allValues = { {"","","","","" } };

            string[] allLines = File.ReadAllLines(latestFileName);


            //----- output

            Console.WriteLine("Filename: " + latestFileName);
            Console.WriteLine("");

            foreach (string line in allLines)
            //for (int i = 0; i < allLines.GetLength(0); i++)
            {
                  Console.WriteLine(line);
            }

            Console.WriteLine("");
            Console.WriteLine("habe fertig.");
        }

        public string GetLatestFileName(string DirectoryName, string FileMask)
        {
            DateTime newestDate = DateTime.MinValue;
            int newestIndex = 0;
            FileInfo[] Files = (new DirectoryInfo(DirectoryName)).GetFiles(FileMask);
            for (int i = 0; i < Files.Length; i++)
            {
                if (newestDate < Files[i].LastWriteTime)
                {
                    newestDate = Files[i].LastWriteTime;
                    newestIndex = i;
                }
            }
            return (Files.Length > 0) ? Files[newestIndex].FullName : null;
        }
    }
}
