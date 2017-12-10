using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication1
{
    class Human : IHasName
    {
        private static Random random = new Random();
        public Sex Sex { get; set; }
        public string Name { get; set; }

        public static Human CreateHuman()
        {
            switch (random.Next(1, 5))
            {
                case 1: return new Student();
                case 2: return new Botan();
                case 3: return new Girl();
                case 4: return new SmartGirl();
                default: return new PrettyGirl();
            }
        }

        public static IHasName Couple(Human x, Human y)
        {
            Console.WriteLine($"Type #1: {x.GetType().Name}, Type #2: {y.GetType().Name}.");

            if (x.Sex == y.Sex) { throw new SexException("Equals = true.\n"); }

            CoupleAttribute xCouple = x.GetCoupleAttribute().SingleOrDefault(temp => temp.Pair == y.GetType().Name);
            CoupleAttribute yCouple = y.GetCoupleAttribute().SingleOrDefault(temp => temp.Pair == x.GetType().Name);

            bool xAcces = xCouple?.Probability >= random.NextDouble();
            bool yAcces = yCouple?.Probability >= random.NextDouble();

            if (xAcces && yAcces)
            {
                try
                {


                    IHasName res = (IHasName)Activator.CreateInstance(Type.GetType(x.GetType().Namespace + "." + xCouple.ChildType));

                    var stringMethod = y.GetType().GetMethods(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public).FirstOrDefault(temp => temp.ReturnType == typeof(string));

                    string name = (string) stringMethod?.Invoke(y, null);

                    var nameProp = res.GetType().GetProperty("Name");
                    var surnameProp = res.GetType().GetProperty("Surname");
                    var sexProp = res.GetType().GetProperty("Sex");

                    nameProp.SetValue(res, name);

                    if (surnameProp != null)
                    {
                        string surName = x.Sex == Sex.Men ? x.Name : y.Name;

                        surName += (Sex)sexProp.GetValue(res) == Sex.Men ? "ович" : "овна";
                        surnameProp.SetValue(res, surName);
                    }

                    return res;
                }catch(Exception e) { Console.WriteLine(e.Message); }
            }

            return null;
        }

        public IEnumerable<CoupleAttribute> GetCoupleAttribute()
        {
            foreach (CoupleAttribute c in GetType().GetCustomAttributes(typeof(CoupleAttribute), false))
            {
                yield return c;
            }
        }
    }
}