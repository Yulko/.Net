namespace ConsoleApplication1
{
    [Couple(Pair="Student", Probability=0.7, ChildType="Girl")]
    [Couple(Pair="Botan", Probability=0.3, ChildType="SmartGirl")]
    class Girl : Human
    {
        public Girl()
        {
            Sex = Sex.Women;
            Name = "Girl";
        }
    }
}