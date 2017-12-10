using System;

namespace ConsoleApplication1
{
    class StudentListHandlerEventArgs : EventArgs
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public Student Stud { get; set; }

        public StudentListHandlerEventArgs()
        {
            Name = "[empty]";
            Type = "[empty]";
            Stud = null;
        }

        public StudentListHandlerEventArgs(string name, string type, Student student)
        {
            Name = name;
            Type = type;
            Stud = student;
        }
        public override string ToString()
        {
            return $"Name of collection: {Name}\nType: {Type}\nStudent: {Stud}\n";
        }
    }
}