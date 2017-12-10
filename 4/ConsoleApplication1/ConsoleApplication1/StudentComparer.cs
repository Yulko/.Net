using System.Collections.Generic;

namespace ConsoleApplication1
{
    class StudentComparer : IComparer<Student>
    {
        Value value;

        public StudentComparer(Value value)
        {
            this.value = value;
        }

        public int Compare(Student x, Student y)
        {
            switch (value)
            {
                case Value.Average: return x.Average.CompareTo(y.Average);
                case Value.Date: return x.Date.CompareTo(y.Date);
                default: return x.SecondName.CompareTo(y.SecondName);
            }   
        }
    }
}