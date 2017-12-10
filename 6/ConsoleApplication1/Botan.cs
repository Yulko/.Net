namespace ConsoleApplication1
{
    [Couple(Pair=nameof(Girl), Probability=0.7, ChildType="SmartGirl")]
    [Couple(Pair="SmartGirl", Probability=0.8, ChildType="Book")]
    [Couple(Pair="PrettyGirl", Probability=1, ChildType="PrettyGirl")]
    class Botan : Human
    {
        public Botan()
        {
            Sex = Sex.Men;
            Name = "Botan";
        }
    }
}