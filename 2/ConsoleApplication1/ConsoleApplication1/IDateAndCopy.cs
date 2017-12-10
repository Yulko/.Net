using System;

namespace ConsoleApplication1
{
    interface IDateAndCopy
    {
        object DeepCopy();
        DateTime Date { get; set; }
    }
}