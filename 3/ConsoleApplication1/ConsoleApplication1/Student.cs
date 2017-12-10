using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication1
{
    class Student : Person, IEnumerable, IDateAndCopy
    {
        private Education _education;
        private int _number;
        private List<Test> _test;
        private List<Exam> _exam;

        public Student(Person person, Education education, int number) : base(person.Name, person.SecondName, person.Date)
        {
            Educat = education;
            Number = number;
            Test = new List<Test>();
            Exam = new List<Exam>();
        }
        public Student() : base()
        {
            Educat = Education.Master;
            Number = 100;
            Test = new List<Test>();
            Exam = new List<Exam>();
        }

        public Person Person
        {
            get { return new Person(Name, SecondName, Date); }
            set
            {
                Name = value.Name;
                SecondName = value.SecondName;
                Date = value.Date;
            }
        }

        public double Average
        {
            get
            {
                if (Exam != null && Exam.Count > 0)
                {
                    double sum = 0;

                    foreach (Exam temp in Exam) { sum += temp.Estimate; }

                    return sum / Exam.Count;
                }

                return 0;
            }
        }

        public List<Exam> Exam
        {
            get { return _exam; }
            set { _exam = value; }
        }

        public void AddExam(params Exam[] exam)
        {
            if (exam != null)
            {
                if (Exam == null) { Exam = new List<Exam>(); }

                for(int i = 0; i < exam.Length; i++)
                {
                    if (exam[i] != null) { Exam.Add(exam[i]); }   
                }
            }  
        }

        public List<Test> Test
        {
            get { return _test; }
            set { _test = value; }
        }

        public void AddTest(params Test[] test)
        { 
            if (test != null)
            {
                if (Test == null) { Test = new List<Test>(); }

                for (int i = 0; i < test.Length; i++)
                {
                    if (test[i] != null) { Test.Add(test[i]); }
                }
            }
        }

        public override string ToString()
        {
            var str = new StringBuilder($" {Person} \n {Educat} \n {Number} \n Exam: \n");

            foreach (Exam temp in Exam) { str.Append(temp + "\n"); }

            str.Append(" Test: \n");

            foreach (Test temp in Test) { str.Append(temp + "\n"); }

            return str.ToString();
        }

        public new string ToShortString()
        {
            return $"{Person} \n {Educat} \n {Average} \n {Number}";
        }

        public new object DeepCopy()
        {
            Student temp = (Student)MemberwiseClone();

            temp.Exam = new List<Exam>();

            foreach (Exam exam in Exam) { temp.Exam.Add((Exam)exam.DeepCopy()); }

            temp.Test = new List<Test>();

            foreach (Test test in Test) { temp.Test.Add((Test)test.DeepCopy()); }

            return temp;
        }

        public Education Educat
        {
            set { _education = value; }
            get { return _education; }
        }

        public int Number
        {
            set
            {
                if (value > 99 && value < 700)
                {
                    _number = value;
                }
                else
                {
                    throw new Exception(" Error! 99 > x > 700");
                }
            }
            get { return _number; }
        }

        public new DateTime Date
        {
            get { return base.Date; }
            set { base.Date = value; }
        }

        public bool this[Education education]
        {
            get { return Educat == education; }
        }

        public IEnumerable Enumerator()
        {
            foreach (Exam temp in Exam) { yield return temp; }

            foreach (Test temp in Test) { yield return temp; }
        }

        public IEnumerable MyItr(double x)
        {
            foreach (Exam temp in Exam)
            {
                if (temp.Estimate > x) { yield return temp; }
            }
        }

        public IEnumerable PassExamAndTest()
        {
            foreach (Exam temp in Exam)
            {
                if (temp.Estimate > 2) { yield return temp; }
            }

            foreach (Test temp in Test)
            {
                if (temp.Pass) { yield return temp; }
            }
        }

        public IEnumerable PassTest()
        {
            foreach (Test temp in Test)
            {
                if (temp.Pass)
                {
                    foreach (Exam exam in Exam)
                    {
                        if (exam.Name.Equals(temp.Name) && exam.Estimate > 2)
                        {
                            yield return temp;
                            break;
                        }
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public StudentEnumerator GetEnumerator()
        {
            return new StudentEnumerator(this);
        }

        public override bool Equals(object obj)
        {
            if (obj == null) { return false; }

            Student temp = (Student)obj;

            if (!Person.Equals(temp.Person) || !Educat.Equals(temp.Educat) || !Number.Equals(temp.Number) 
                || Exam.Count != temp.Exam.Count || Test.Count != temp.Test.Count)
            {
                return false;
            }

            for(int i = 0; i < Exam.Count; i++)
            {
                if (!Exam[i].Equals(temp.Exam[i])) { return false; }
            }

            for (int i = 0; i < Test.Count; i++)
            {
                if (!Test[i].Equals(temp.Test[i])) { return false; }
            }

            return true;
        }

        public static bool operator ==(Student student1, Student student2)
        {
            return ((object)student1 != null && student1.Equals(student2));
        }

        public static bool operator !=(Student student1, Student student2)
        {
            return !(student1 == student2);
        }

        public override int GetHashCode()
        {
            return new { Educat, Number, Exam, Test, Person }.GetHashCode();
        }
    }
}