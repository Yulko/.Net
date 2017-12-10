using System;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student();
            Console.WriteLine(student.ToShortString() + "\n");

            Console.WriteLine(student[Education.Master]);
            Console.WriteLine(student[Education.Bachelor]);
            Console.WriteLine(student[Education.SecondEducation] + "\n");

            student.Educat = Education.Bachelor;

            Person person = new Person("Ivan", "Koksov", new DateTime());
            student.Person = person;
            student.Number = 5;
            Console.WriteLine(student + "\n");
			
            Exam[] exam = new Exam[3];
            exam[0] = new Exam("c#", 5, new DateTime(2016, 9, 16));
            exam[1] = new Exam("java", 5, new DateTime(2016, 9, 16));
            exam[2] = new Exam("pyton", 5, new DateTime(2016, 9, 16));
            student.AddExams(exam);
            Console.WriteLine(student + "\n");

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////    

            int n, m, i, j, nActual, nAll = 0, count = 0, time;

            Console.WriteLine("Enter n and m(('n','m') or ('n' 'm')).");

            string str = Console.ReadLine();
            string[] arr = str.Split(' ', ',');

            n = Int32.Parse(arr[0]);
            m = Int32.Parse(arr[1]);

            nActual = n * m;

            while (nAll < nActual) { nAll += ++count; }

            Console.WriteLine("n = " + n + ", m = " + m + ", count = " + count);
       
            Exam[] ex1 = new Exam[n * m];
            Exam[,] ex2 = new Exam[n, m];
            Exam[][] ex3 = new Exam[count][];
            Exam[][] ex4 = new Exam[n][];

            for (i = 0; i < ex3.Length - 1; i++)
            {
                ex3[i] = new Exam[i + 1];
            }

            ex3[i] = new Exam[nActual - nAll + count];

            for (i = 0; i < ex3.Length; i++)
            {
                for (j = 0; j < ex3[i].Length; j++)
                {
                    ex3[i][j] = new Exam();
                }  
            }

            time = Environment.TickCount;

            for (i = 0; i < ex3.Length; i++)
            {
                for (j = 0; j < ex3[i].Length; j++)
                {
                    ex3[i][j].Name = "default";
                }
            }

            Console.WriteLine(Environment.TickCount - time);

            for (i = 0; i < n; i++)
            {
                ex4[i] = new Exam[m]; 
            }

            for (i = 0; i < ex4.Length; i++)
            {
                for (j = 0; j < ex4[i].Length; j++)
                {
                    ex4[i][j] = new Exam();
                }
            }

            time = Environment.TickCount;

            for (i = 0; i < ex4.Length; i++)
            {
                for (j = 0; j < ex4[i].Length; j++)
                {
                    ex4[i][j].Name = "default";
                }
            }

            Console.WriteLine(Environment.TickCount - time); 

            for (i = 0; i < ex1.Length; i++)
            {
                ex1[i] = new Exam();
            }

            time = Environment.TickCount;

            for (i = 0; i < ex1.Length; i++)
            {
                ex1[i].Name = "default";
            }

            Console.WriteLine(Environment.TickCount - time);
            
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < m; j++)
                {
                    ex2[i, j] = new Exam();
                }
            }

            time = Environment.TickCount;

            for (i = 0; i < n; i++)
            {
                for (j = 0; j < m; j++)
                {
                    ex2[i, j].Name = "default";
                }
            }

            Console.WriteLine(Environment.TickCount - time);

            //////////////////////////////////////////////////////



 
            
        }



    }
}