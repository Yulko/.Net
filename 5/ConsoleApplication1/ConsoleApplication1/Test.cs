using System;

namespace ConsoleApplication1
{
    [Serializable]
    class Test : IDateAndCopy
    {
        public string Name { get; set; }
        public bool Pass { get; set; }
        public DateTime Date { get; set; }

        public Test()
        {
            Name = "[default]";
            Pass = false;
        }

        public Test(string name, bool pass)
        {
            Name = name;
            Pass = pass; 
        }

        public override string ToString()
        {
            return $"Test {Name} is {Pass}.";
        }

        public object DeepCopy()
        {
            return MemberwiseClone();
        }

        public override bool Equals(object obj)
        {
            if (obj == null) { return false; }

            Test temp = (Test)obj;

            return Name.Equals(temp.Name) && Pass.Equals(temp.Pass);
        }

        public static bool operator ==(Test test1, Test test2)
        {
            return ((object)test1 != null && test1.Equals(test2));
        }

        public static bool operator !=(Test test1, Test test2)
        {
            return !(test1 == test2);
        }

        public override int GetHashCode()
        {
            return new { Name, Pass }.GetHashCode();
        }
    }
}