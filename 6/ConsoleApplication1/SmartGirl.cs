namespace ConsoleApplication1
{
    [Couple(Pair="Student", Probability=0.2, ChildType="Girl")]
    [Couple(Pair="Botan", Probability=0.5, ChildType="Book")]
    sealed class SmartGirl : Human
    {
        public string Surname { get; set; }
        public SmartGirl()
        {
            Sex = Sex.Women;
            Name = "SmartGirl";
            Surname = "Smart";
        }
    }
}