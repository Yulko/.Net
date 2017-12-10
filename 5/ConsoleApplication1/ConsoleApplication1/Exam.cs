using System;

namespace ConsoleApplication1
{
    [Serializable]
    class Exam : IDateAndCopy
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
            Estimate = 0;
            Date = new DateTime();
        }

        public override string ToString()
        {
            return $"Name: {Name}, Estimate: {Estimate}, Date: {Date}.";
        }

        public override bool Equals(object obj)
        {
            if (obj == null) { return false; }

            Exam temp = (Exam)obj;

            return Name.Equals(temp.Name) && Estimate.Equals(temp.Estimate) && Date.Equals(temp.Date);
        }

        public static bool operator ==(Exam exam1, Exam exam2)
        {
            return ((object)exam1 != null && exam1.Equals(exam2));
        }

        public static bool operator !=(Exam exam1, Exam exam2)
        {
            return !(exam1 == exam2); 
        }

        public override int GetHashCode()
        {
            return new { Name, Estimate, Date }.GetHashCode();
        }

        public object DeepCopy()
        {
            return MemberwiseClone();
        }
    }
}