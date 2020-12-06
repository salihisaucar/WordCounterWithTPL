using Example.Thread.TPL.Abstracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Example.Thread.TPL.Concretes
{
    class SourceDataReader : ISourceDataReader
    {
        public string path { get; set; }

        public SourceDataReader(string filePath)
        {
            path = filePath;
        }
        public string Read()
        {
            CheckAppParameters();

            string text = System.IO.File.ReadAllText(path);
            return text.Replace(System.Environment.NewLine, " ");

        }

        private void CheckAppParameters()
        {
            void ExitApp()
            {
                System.Threading.Thread.Sleep(1000);
                Environment.Exit(-1);
            }

            if (String.IsNullOrEmpty(path))
            {
                Console.WriteLine("The 'path' parameter must be given Before running the application. The application will be closed in a second. Please try again.");
                ExitApp();
            }
            if (!File.Exists(path))
            {
                Console.WriteLine("The file path that you have is wrong or the file was removed.The application will be closed in a second. Please try again.");
                ExitApp();
            }

            


        }
    }
}
