using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    delegate void StudentListHandler(object sourse, StudentListHandlerEventArgs args);

    class StudentCollection
    {
        private List<Student> _students;
        public string Name { get; set; }

        public List<Student> Students
        {
            get { return _students; }
            set { _students = value; }
        }

        public StudentCollection()
        {
            _students = new List<Student>();
        }

        public bool Remove(int j)
        {
            var st = Students?.ElementAtOrDefault(j);
            var result = st != null;

            if (result)
            {
                Students.RemoveAt(j);
                StudentCountChanged?.Invoke(this, new StudentListHandlerEventArgs(Name, "Remove student.", st));
            }

            return result;
        }

        public Student this[int i]
        {
            get
            {
                if (i < 0 || Students == null || Students.Count < i) return null;
                return Students[i];
            }
            set
            {
                if (i > -1 && Students != null && Students.Count > i)
                {
                    Students[i] = value;
                    StudentReferenceChanged?.Invoke(this, new StudentListHandlerEventArgs(Name, "Reference student.", value));
                }
            }
        }
        
        public event StudentListHandler StudentCountChanged;

        public event StudentListHandler StudentReferenceChanged;

        public void AddDefaults()
        {
            Student st;

            if (Students == null) { Students = new List<Student>(); }

            for(int i = 0; i < 5; i++)
            {
                st = TestCollections.CreateStudent(i);
                Students.Add(st);
                StudentCountChanged?.Invoke(this, new StudentListHandlerEventArgs(Name, "Add new student.", st));
            }
        }

        public void AddStudents(params Student[] students)
        {
            if (students == null || students.Length < 1) { return; }

            if (Students == null) { Students = new List<Student>(); }
 
            Student st;

            for (int i = 0; i < students.Length; i++)
            {
                st = students[i];
                if (st != null)
                {
                    Students.Add(st);
                    StudentCountChanged?.Invoke(this, new StudentListHandlerEventArgs(Name, "Add new student.", st));
                }
            } 
        }

        public override string ToString()
        {
            var str = new StringBuilder();

            if (Students != null)
            {
                foreach (Student temp in Students)
                {
                    str.Append(temp);
                }
            }

            return str.ToString();
        }

        public string ToShortString()
        {
            var str = new StringBuilder();

            if (Students != null)
            {
                foreach (Student temp in Students)
                {
                    str.Append(temp.ToShortString() + " " + temp.Test.Count + " " + temp.Exam.Count);
                }
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