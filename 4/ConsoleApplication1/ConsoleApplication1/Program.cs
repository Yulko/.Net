using System;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Journal journal1 = new Journal();
            Journal journal2 = new Journal();
            StudentCollection coll1 = new StudentCollection();
            StudentCollection coll2 = new StudentCollection();
            Student[] st;
            Exam[] exam;
            Test[] test;

            coll1.StudentCountChanged += journal1.OnStudentCountChanged;
            coll1.StudentReferenceChanged += journal1.OnStudentReferenceChanged;

            coll2.StudentCountChanged += journal1.OnStudentCountChanged;
            coll2.StudentReferenceChanged += journal1.OnStudentReferenceChanged;

            coll1.StudentCountChanged += journal2.OnStudentCountChanged;
            coll1.StudentReferenceChanged += journal2.OnStudentReferenceChanged;

            coll1.Name = "coll1";
            st = new Student[3];

            st[0] = new Student(new Person("ivan", "ivan", new DateTime(33, 5, 5)), Education.Bachelor, 100);

            exam = new Exam[2];
            exam[0] = new Exam("Java", 4, new DateTime());
            exam[1] = new Exam("C#", 4, new DateTime());

            test = new Test[2];
            test[0] = new Test("Phyton", true);
            test[1] = new Test("Java", true);

            st[0].AddExam(exam);
            st[0].AddTest(test);

            st[1] = new Student(new Person("abc", "abc", new DateTime(4, 4, 4)), Education.Master, 100);

            exam = new Exam[2];
            exam[0] = new Exam("Java", 2, new DateTime());
            exam[1] = new Exam("C#", 2, new DateTime());

            test = new Test[2];
            test[0] = new Test("Phyton", true);
            test[1] = new Test("Java", true);

            st[1].AddExam(exam);
            st[1].AddTest(test);

            st[2] = new Student(new Person("wer", "wer", new DateTime(1, 1, 1)), Education.Bachelor, 100);

            exam = new Exam[2];
            exam[0] = new Exam("Java", 3, new DateTime());
            exam[1] = new Exam("C#", 3, new DateTime());

            test = new Test[2];
            test[0] = new Test("Phyton", true);
            test[1] = new Test("Java", true);

            st[2].AddExam(exam);
            st[2].AddTest(test);

            coll1.AddStudents(st);

            coll2.Name = "cool2";

            coll2.AddDefaults();

            coll1.Remove(1);

            coll1[1] = st[0];

           Console.WriteLine("\n\nFirst:\n\n" + journal1 + "\n\nSecond:\n\n" + journal2);
        }
    }
}