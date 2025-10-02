using System;
using System.IO;

namespace MyApp
{
    public class MyClass
    {
        static void Main()
        {
            string path = @"C:\Users\" + Environment.UserName + @"\AppData\Roaming\ATAS\Indicators\cache\tradeneon";
            string filter = @"*ES*";

            Console.WriteLine("begin ...");
            Console.WriteLine("");

            var mc = new MyClass();
            string result = mc.GetLatestFileName(path, filter);

            Console.WriteLine("Filename: " + result);
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
