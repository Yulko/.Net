using System.Collections;
using System.Collections.Generic;

namespace ConsoleApplication1
{
    class StudentEnumerator : IEnumerator<string>
    {
        private ArrayList _list;
        private int position = -1;
        private object _cur;

        public StudentEnumerator(Student student)
        {
            _list = new ArrayList();

            foreach (Test test in student.Test)
            {
                foreach (Exam exam in student.Exam)
                {
                    if (exam.Name.Equals(test.Name))
                    {
                        _list.Add(test.Name);
                        break;
                    }
                }           
            }
        }

        public string Current
        {
            get { return (string)_list[position]; }
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        public void Dispose() { }

        public bool MoveNext()
        {
            if (++position >= _list.Count)
            {
                return false;
            }
            else
            {
                _cur = _list[position];
            }

            return true; 
        }

        public void Reset()
        {
            position = -1;
        }
    }
}