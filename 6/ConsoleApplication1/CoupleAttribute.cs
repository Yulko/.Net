using System;

namespace ConsoleApplication1
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    internal class CoupleAttribute : Attribute
    {
        public string ChildType { get; set; }
        public string Pair { get; set; }
        public double Probability { get; set; }
    }
}