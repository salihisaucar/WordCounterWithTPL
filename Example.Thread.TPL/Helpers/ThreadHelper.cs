using Example.Thread.TPL.AppEntity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Example.Thread.TPL.Helpers
{
    class ThreadHelper
    {
        private static readonly object _locker = new object();
        public static void CalculateWord(string sentence)
        {
            string[] words = sentence.Split(new char[] { ' ', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];
                UpdateWordCount(word);
            }
            InformThread("CalculateWord");
        }

        public static void InformThread(string whereFrom)
        {
            lock (_locker)
            {
                int threadId = System.Threading.Thread.CurrentThread.ManagedThreadId;

                if (MainEntity.ThreadList == null)
                    MainEntity.ThreadList = new Hashtable();

                if (!MainEntity.ThreadList.ContainsKey(threadId))
                {
                    MainEntity.ThreadList.Add(threadId, 0);
                }
                else
                {
                    if (whereFrom == "CalculateWord")
                    {
                        int newValue = (int)MainEntity.ThreadList[threadId] + 1;
                        MainEntity.ThreadList[threadId] = newValue;
                    }
                }
            }

        }

        private static void UpdateWordCount(string word)
        {
            lock (_locker)
            {
                if (MainEntity.WordList == null)
                    MainEntity.WordList = new Hashtable();

                if (!MainEntity.WordList.ContainsKey(word))
                {
                    MainEntity.WordList.Add(word, 1);
                }
                else
                {
                    int newValue = (int)MainEntity.WordList[word] + 1;
                    MainEntity.WordList[word] = newValue;
                }
            }

        }
    }
}
