using Example.Thread.TPL.Abstracts;
using Example.Thread.TPL.AppEntity;
using Example.Thread.TPL.Helpers;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Example.Thread.TPL.Concretes
{
    class WordCounter : IWordCounter
    {
        BlockingCollection<string> inputQueue = new BlockingCollection<string>();

        private string _text { get; set; }

        public WordCounter(ISourceDataReader sourceDataReader)
        {
            this._text = sourceDataReader.Read();
        }
        public void Run(int threadCount)
        {
            List<Task> tasks = new List<Task>();
            for (int i = 0; i < threadCount; i++)
            {
                Task task = Task.Factory.StartNew(() => { Worker(); }, TaskCreationOptions.LongRunning);
                tasks.Add(task);

            }

            SetQueueList();
            Task.WaitAll(tasks.ToArray());

            var result = MainEntity.ThreadList;
            ApplicationResult.WriteAppResult();

        }
        void SetQueueList()
        {
            string source = _text;
            string[] parts = source.Split(new char[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
            MainEntity.SentenceCount = parts.Length;

            for (int i = 0; i < parts.Length; i++)
            {
                inputQueue.Add(parts[i]);
            }
            inputQueue.CompleteAdding();
        }

        void Worker()
        {
            ThreadHelper.InformThread("worker");
            foreach (var workItem in inputQueue.GetConsumingEnumerable())
            {
                ThreadHelper.CalculateWord(workItem);
            }
        }
    }
}
