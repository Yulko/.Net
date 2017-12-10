using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication1
{
    class TestCollections
    {
        private List<Person> person;
        private List<string> str;
        private Dictionary<Person, Student> PersonStudent;
        private Dictionary<string, Student> StringStudent;

        public static Student CreateStudent(int n)
        {
            string hash = n.GetHashCode().ToString();
            Education education;

            switch(n % 3)
            {
                case 1: education = Education.Master; break;
                case 2: education = Education.SecondEducation; break;
                default: education = Education.Bachelor; break; 
            }
            
            Student student = new Student(new Person(hash, hash, new DateTime(n % 2016 + 1, n % 12 + 1, n % 27 + 1)), education, 100 + n % 100);

            return student;
        }

        public TestCollections(int count)
        {
            if (count < 1) { throw new Exception("Size is not correct!"); }

            person = new List<Person>();
            str = new List<string>();
            PersonStudent = new Dictionary<Person, Student>();
            StringStudent = new Dictionary<string, Student>();

            for(int i = 0; i < count; i++)
            {
                Student st = CreateStudent(i);

                person.Add(st.Person);
                
                str.Add(st.ToString());

                StringStudent.Add(st.ToString(), st);
                
                PersonStudent.Add(st.Person, st);              
            }
        }

        public string Timer()
        {
            Student first, middle, last, none = new Student();
            int n = person.Count;
            StringBuilder rez = new StringBuilder("");

            first = middle = last = null;

            PersonStudent.TryGetValue(person[0], out first);

            PersonStudent.TryGetValue(person[n / 2], out middle);

            PersonStudent.TryGetValue(person[n - 1], out last);

            rez.Append("\n First: \n");

            int time = Environment.TickCount;
            string toString = first.ToString();

            for (int i = 0; i < 1000000; i++) { person.Contains(first.Person); }

            rez.Append("List person: " + (Environment.TickCount - time) + "\n");
            time = Environment.TickCount;

            for (int i = 0; i < 1000000; i++) { str.Contains(toString); }

            rez.Append("list string: " + (Environment.TickCount - time) + "\n");
            time = Environment.TickCount;

            for (int i = 0; i < 1000000; i++) { PersonStudent.ContainsKey(first.Person); }

            rez.Append("PersonStudent: " + (Environment.TickCount - time) + "\n");
            time = Environment.TickCount;

            for (int i = 0; i < 1000000; i++) { StringStudent.ContainsKey(toString); }

            rez.Append("StringStudent: " + (Environment.TickCount - time) + "\n");

            rez.Append("\n Middle: \n");

            time = Environment.TickCount;
            toString = middle.ToString();

            for (int i = 0; i < 1000000; i++) { person.Contains(middle.Person); }

            rez.Append("List person: " + (Environment.TickCount - time) + "\n");
            time = Environment.TickCount;

            for (int i = 0; i < 1000000; i++) { str.Contains(toString); }

            rez.Append("list string: " + (Environment.TickCount - time) + "\n");
            time = Environment.TickCount;

            for (int i = 0; i < 1000000; i++) { PersonStudent.ContainsKey(middle.Person); }

            rez.Append("PersonStudent: " + (Environment.TickCount - time) + "\n");
            time = Environment.TickCount;

            for (int i = 0; i < 1000000; i++) { StringStudent.ContainsKey(toString); }

            rez.Append("StringStudent: " + (Environment.TickCount - time) + "\n");
            time = Environment.TickCount;

            rez.Append("\n Last: \n");

            time = Environment.TickCount;
            toString = last.ToString();

            for (int i = 0; i < 1000000; i++) { person.Contains(last.Person); }

            rez.Append("List person: " + (Environment.TickCount - time) + "\n");
            time = Environment.TickCount;

            for (int i = 0; i < 1000000; i++) { str.Contains(toString); }

            rez.Append("list string: " + (Environment.TickCount - time) + "\n");
            time = Environment.TickCount;

            for (int i = 0; i < 1000000; i++) { PersonStudent.ContainsKey(last.Person); }

            rez.Append("PersonStudent: " + (Environment.TickCount - time) + "\n");
            time = Environment.TickCount;

            for (int i = 0; i < 1000000; i++) { StringStudent.ContainsKey(toString); }

            rez.Append("StringStudent: " + (Environment.TickCount - time) + "\n");
            time = Environment.TickCount;

            rez.Append("\n None: \n");

            time = Environment.TickCount;
            toString = none.ToString();

            for (int i = 0; i < 1000000; i++) { person.Contains(none.Person); }

            rez.Append("List person: " + (Environment.TickCount - time) + "\n");
            time = Environment.TickCount;

            for (int i = 0; i < 1000000; i++) { str.Contains(toString); }

            rez.Append("list string: " + (Environment.TickCount - time) + "\n");
            time = Environment.TickCount;

            for (int i = 0; i < 1000000; i++) { PersonStudent.ContainsKey(none.Person); }

            rez.Append("PersonStudent: " + (Environment.TickCount - time) + "\n");
            time = Environment.TickCount;

            for (int i = 0; i < 1000000; i++) { StringStudent.ContainsKey(toString); }

            rez.Append("StringStudent: " + (Environment.TickCount - time) + "\n");

            return rez.ToString();
        }
    }
}