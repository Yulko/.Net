using System;

namespace ConsoleApplication1
{
    class Program3
    {
        static void Main(string[] args)
        {
            Person person1 = new Person("Dima", "Hoyan", new DateTime());
            Person person2 = new Person("Dima", "Hoyan", new DateTime());

            Console.WriteLine((person1 == person2) + "\n" + person1.GetHashCode() + " " + person2.GetHashCode());

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////

            Student student = new Student();

            Exam [] exam = new Exam[2];
            exam[0] = new Exam("Java", 5, new DateTime());
            exam[1] = new Exam("C#", 3, new DateTime());

            Test[] test = new Test[2];
            test[0] = new Test("Phyton", true);
            test[1] = new Test("Java", true);

            student.AddExam(exam);
            student.AddTest(test);

            Console.WriteLine("\n" + student);

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            Console.WriteLine("\n" + student.Person);

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            Student copy = (Student)student.DeepCopy();

            student.Person = person1;
            student.Number = 101;
            student.Educat = Education.Bachelor;
            student.Test.Add(new Test("[test]", false));
            student.Exam.Add(new Exam("Phyton", 4, new DateTime()));

            Console.WriteLine("\n" + copy + "\n" + student);

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            try
            {
                student.Number = 10;
            }
            catch (Exception e) { Console.WriteLine(e.Message); }

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            Console.WriteLine();

            foreach (Exam temp in student.MyItr(3))
            {
                Console.WriteLine(temp);
            }
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            Console.WriteLine();

            foreach (object temp in student.Enumerator())
            {
                Console.WriteLine(temp);
            }

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            Console.WriteLine();

            foreach (object temp in student)
            {
                Console.WriteLine(temp);
            }

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            Console.WriteLine();

            foreach (object temp in student.PassExamAndTest())
            {
                Console.WriteLine(temp);
            }

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            Console.WriteLine();

            foreach (Test temp in student.PassTest())
            {
                Console.WriteLine(temp);
            }

            Console.WriteLine();
        }
    }
}