using System;

namespace ConsoleApplication1
{
    class Person : IDateAndCopy
    {
        protected string _name;
        protected string _secondName;
        protected DateTime _date;

        public Person(string name, string secondName, DateTime date)
        {
            Name = name;
            SecondName = secondName;
            Date = date;
        }

        public Person()
        {
            Name = "[empty]";
            SecondName = "[empty]";
            Date = new DateTime();
        }
    
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string SecondName
        {
            get { return _secondName; }
            set { _secondName = value; }
        }

        public DateTime Date
        {
            set { _date = value; }
            get { return _date; }
        }

        public int Year
        {
            set
            {
                DateTime temp = Date;
                Date = new DateTime(value, temp.Month, temp.Day); 
            }
            get { return Date.Year; }
        }

        public override string ToString()
        {
            return $"Name: {Name}, SecondName: {SecondName}, birthday: {Date}.";
        }

        public string ToShortString()
        {
            return $"Name: {Name}, SecondName: {SecondName}.";
        }

        public override bool Equals(object obj)
        {
            if (obj == null) { return false; }

            Person temp = (Person)obj;

            return Name.Equals(temp.Name) && SecondName.Equals(temp.SecondName) && Date.Equals(temp.Date);
        }

        public static bool operator ==(Person person1, Person person2)
        {
            return ((object)person1 != null && person1.Equals(person2));
        }

        public static bool operator !=(Person person1, Person person2)
        {
            return !(person1 == person2);
        }

        public override int GetHashCode()
        {
            return new { Name, SecondName, Date }.GetHashCode();
        }

        public virtual object DeepCopy()
        {
            return MemberwiseClone();
        }
    };  
}