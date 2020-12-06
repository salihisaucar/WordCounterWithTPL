using Example.Thread.TPL.AppEntity;
using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace Example.Thread.TPL.Helpers
{
    class ApplicationResult
    {
        public static void WriteAppResult()
        {
            Console.WriteLine($"Application Sentence Count : {GetSentenceCount()}");
            Console.WriteLine($"Application Average Of WordCount : {GetAverageOfWordCount()}");
            WriteTreadCountDetail();
            WriteSortedWordListDesc();
        }

        static int GetSentenceCount()
        {
            return MainEntity.SentenceCount;
        }

        static double GetAverageOfWordCount()
        {
            double sentenceCount = MainEntity.SentenceCount;
            double wordCount = 0;

            ICollection keyColl = MainEntity.WordList.Keys;

            foreach (string key in keyColl)
            {
                wordCount += (int)MainEntity.WordList[key];

            }

            return wordCount / sentenceCount;
        }

        static void WriteTreadCountDetail()
        {
            ICollection keyColl = MainEntity.ThreadList.Keys;

            foreach (int threadId in keyColl)
            {
                Console.WriteLine($"ThreadId : {threadId} Count : {MainEntity.ThreadList[threadId]}");
            }
        }

        static void WriteSortedWordListDesc()
        {
            ICollection source = MainEntity.WordList;

            var result = MainEntity.WordList.Cast<DictionaryEntry>().OrderBy(entry => entry.Value).ToList();

            for (int i = result.Count - 1; i >= 0; i--)
            {
                Console.WriteLine($"{result[i].Key} {result[i].Value} ");
            }
        }



    }
}
