using System;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo con = new ConsoleKeyInfo();
            Human h1, h2;

            do
            {
                try
                {
                    h1 = Human.CreateHuman();
                    h2 = Human.CreateHuman();

                    IHasName res = Human.Couple(h1, h2);

                    if(res != null)
                    {
                        string surname = "";
                        var surnameProp = res.GetType().GetProperty("Surname");

                        if(surnameProp != null)
                        {
                            surname = (string)surnameProp.GetValue(res);
                        }

                        Console.WriteLine($"{res.GetType().Name}. {res.Name}. {surname}\n");
                    }
                    else
                    {
                        Console.WriteLine("Bad!\n");
                    }
                }catch(SexException e)
                {
                    Console.WriteLine(e.Message);
                }

                con = Console.ReadKey();
            } while (con.Key != ConsoleKey.Q && con.Key != ConsoleKey.F10);
        }
    }
}