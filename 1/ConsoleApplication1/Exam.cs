using System;

namespace ConsoleApplication1
{
    class Exam
    {
        public string Name { get; set; }
        public int Estimate { get; set; }
        public DateTime Date { get; set; }

        public Exam(string name, int estimate, DateTime date)
        {
            Name = name;
            Estimate = estimate;
            Date = date;
        }

        public Exam()
        {
            Name = "[empty]";
            Estimate = 1;
            Date = new DateTime();
        }

        public override string ToString()
        {
            return $"Name: {Name}, Estimate: {Estimate}, Date:, {Date}";
        }
    }
}