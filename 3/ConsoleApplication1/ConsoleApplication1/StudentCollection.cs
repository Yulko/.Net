using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class StudentCollection
    {
        private List<Student> _students;

        public List<Student> Students
        {
            get { return _students; }
            set { _students = value; }
        }

        public void AddDefaults()
        {
            if (Students == null) { Students = new List<Student>(); }

            for(int i = 0; i < 5; i++)
            {
                Students.Add(TestCollections.CreateStudent(i));
            }
        }

        public void AddStudents(params Student[] students)
        {
            if (students != null)
            {
                if (Students == null) { Students = new List<Student>(); }

                Students.AddRange(students);            
            }
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder("");

            foreach(Student temp in Students)
            {
                str.Append(temp);
            }

            return str.ToString();
        }

        public string ToShortString()
        {
            StringBuilder str = new StringBuilder(string.Empty);

            foreach (Student temp in Students)
            {
                str.Append(temp.ToShortString() + " " + temp.Test.Count + " " + temp.Exam.Count);
            }

            return str.ToString();
        }

        public void SortListBySecondName()
        {
            Students.Sort();
        }

        public void SortListByDate()
        {
            Students.Sort(new Person());
        }

        public void SortListByAverage()
        {
            Students.Sort(new StudentComparer(Value.Average));
        }

        public double Max
        {
            get
            {
                return Students.Max(temp => temp.Average);
            }
        }

        public IEnumerable<Student> MasterStudent
        {
            get
            {
                return Students.Where(temp => temp.Educat == Education.Master);
            }
        }

        public List<Student> AverageMarkGroup(double value)
        {
            return Students.Where(temp => temp.Average == value).ToList();
        }
    }
}