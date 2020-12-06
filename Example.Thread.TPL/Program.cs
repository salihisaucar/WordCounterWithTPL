using Example.Thread.TPL.Abstracts;
using Example.Thread.TPL.Concretes;
using System;

namespace Example.Thread.TPL
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().RunApp();
        }
        void RunApp()
        {
            string filePath = @"C:\Users\salih.ucar\source\repos\Example.Thread.TPL\Example.Thread.TPL\ApplicationFile\Test.txt";
            int threadCount = 5;
            IWordCounter wordCounter = new WordCounter(new SourceDataReader(filePath));
            wordCounter.Run(threadCount);
        }
    }
}
