using System;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentCollection coll = new StudentCollection();
            int n;
            bool f;
            Student [] st = new Student[3];

            st[0] = new Student(new Person("ivan", "ivan", new DateTime(33, 5, 5)), Education.Bachelor, 100);

            Exam[] exam = new Exam[2];
            exam[0] = new Exam("Java", 4, new DateTime());
            exam[1] = new Exam("C#", 4, new DateTime());

            Test[] test = new Test[2];
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

            coll.AddStudents(st);

            Console.WriteLine("\n" + coll.ToString());

            coll.SortListByAverage();

            Console.WriteLine("\n" + coll.ToString());

            coll.SortListBySecondName();

            Console.WriteLine("\n" + coll.ToString());

            coll.SortListByDate();

            Console.WriteLine("\n" + coll.ToString());

            Console.WriteLine("\n" + coll.Max + "\n");

            foreach(Student temp in coll.MasterStudent)
            {
                Console.WriteLine(temp);
            }

            Console.WriteLine("\n");

            foreach (Student temp in coll.AverageMarkGroup(3))
            {
                Console.WriteLine(temp);
            }

            Console.WriteLine("\n Enter n! \n");

            while (true)
            {
                f = int.TryParse(Console.ReadLine(), out n);
                if (f)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Not correct!");
                }
            }

            try
            {
                TestCollections t = new TestCollections(n);
                Console.WriteLine(t.Timer());
            }
            catch(Exception e) { Console.WriteLine(e.Message); }   
        }
    }
}