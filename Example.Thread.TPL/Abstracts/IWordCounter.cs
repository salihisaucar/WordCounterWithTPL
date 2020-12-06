using System;
using System.Collections.Generic;
using System.Text;

namespace Example.Thread.TPL.Abstracts
{
    interface IWordCounter
    {
        void Run(int threadCount);
    }
}
