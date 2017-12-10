using System;

namespace ConsoleApplication1
{
    class Person {
        private string _name;
        private string _secondName;
        private DateTime _date;

        public Person(string name, string secondName, DateTime date) {
            Name = name;
            SecondName = secondName;
            Date = date;
        }

        public Person() {
            Name = "[empty]";
            SecondName = "[empty]";
            Date = new DateTime();
        }
    
        public string Name {
            get { return _name; }
            set { _name = value; }
        }

        public string SecondName {
            get { return _secondName; }
            set { _secondName = value; }
        }

        public DateTime Date
        {
            set
            {
                _date = value;
            }
            get { return _date; }
        }

        public int Year {
            set {
                DateTime temp = Date;
                Date = new DateTime(value, temp.Month, temp.Day); 
            }
            get { return Date.Year; }
        }

        public override string ToString() {
            return $"Name: {Name}, SecondName: {SecondName}, birthday: {Date}";
        }

        public string ToShortString() {
            return $"Name: {Name}, SecondName: {SecondName}";
        }
    }
}