namespace ConsoleApplication1
{
    [Couple(Pair="Girl", Probability=0.7, ChildType="Girl")]
    [Couple(Pair="SmartGirl", Probability=0.5, ChildType="Girl")]
    [Couple(Pair="PrettyGirl", Probability=1, ChildType="PrettyGirl")]
    class Student : Human
    {
        public Student()
        {
            Sex = Sex.Men;
            Name = "Student";
        }
    }
}