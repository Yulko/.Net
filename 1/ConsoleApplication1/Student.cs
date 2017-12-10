using System;

namespace ConsoleApplication1
{
    class Student
    {
        private Person _person;
        private Education _education;
        private int _number;
        private Exam[] _exam;

        public Student(Person person, Education education, int number)
        {
            Person = person;
            Educat = education;
            Number = number;
        }
        public Student()
        {
            Person = new Person();
            Educat = Education.Master;
            Number = 0;
        }

        public Person Person
        {
            set
            { _person = value;  }
            get { return _person; }
        }

        public Education Educat
        {
            set { _education = value; }
            get { return _education; }
        }

        public int Number
        {
            set { _number = value; }
            get { return _number; }
        }

        public Exam[] Exam
        {
            set { _exam = value; }
            get { return _exam; }
        }

        public double GetAverage() {
            if (Exam != null && Exam.Length > 0) {
                double sum = 0;

                for (int i = 0; i < Exam.Length && Exam[i] != null; i++) {
                    sum += Exam[i].Estimate;
                }

                return sum / Exam.Length;
            }
            return 0;
        }

        public bool this[Education education]
        {
            get
            {
                return Educat == education;
            }
        }

        public void AddExams(params Exam[] exam)
        {
            int n = 0, i = 0, j;

            if (Exam != null) { n = Exam.Length; }
            if (exam != null) { n += exam.Length; }

            Exam[] temp = new Exam[n];

            if (Exam != null)
            {
                while (i < Exam.Length && Exam[i] != null)
                {
                    temp[i] = Exam[i];
                    i++;
                }
            }

            if (exam != null)
            {
                for (j = 0; j < exam.Length && exam[j] != null; i++, j++)
                {
                    temp[i] = exam[j];
                }
            }

            Exam = temp;
        }

        public override string ToString()
        {
            string str;

            str = $" {Person} \n {Educat} \n {Number} \n";

            if (Exam != null)
            {
                for (int i = 0; i < Exam.Length && Exam[i] != null; i++)
                {
                    str += Exam[i] + "\n";
                }
            }

            return str;
        }

        public string ToShortString()
        {
            return $"{Person} \n {Educat} \n {GetAverage()} \n {Number}";
        }
    }
}