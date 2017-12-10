using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication1
{
    class Journal
    {
        private List <JournalEntry> list = new List<JournalEntry>();

        public void OnStudentReferenceChanged(object sourse, StudentListHandlerEventArgs args)
        {
            list.Add(new JournalEntry(args));
        }

        public void OnStudentCountChanged(object sourse, StudentListHandlerEventArgs args)
        {
            list.Add(new JournalEntry(args));
        }

        public override string ToString()
        {
            var str = new StringBuilder();

            if (list.Count > 0)
            {
                foreach (JournalEntry st in list)
                {
                    str.Append(st.ToString());
                }
            }

            return str.ToString();
        }
    }
}