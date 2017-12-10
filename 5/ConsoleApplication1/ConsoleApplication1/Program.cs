using System;
using System.IO;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Student st = new Student();
            
            Console.WriteLine((Student)st.DeepCopy() + "\n" + st);

            Console.WriteLine("Enter file name.");
            
            string Filename = "D:/hello.dat"; //Console.ReadLine();
            
            if (File.Exists(Filename))
            {
                st.Load(Filename);
            }
            else
            {
                Console.WriteLine("File not exist!");
                st.Save(Filename);
            }

            Console.WriteLine(st);

            st.AddFromConsole();

            st.Save(Filename);

            Console.WriteLine(st);

            st.AddFromConsole();

            Student.Save(Filename, st);
            
            Console.WriteLine(st);
        }
    }
}