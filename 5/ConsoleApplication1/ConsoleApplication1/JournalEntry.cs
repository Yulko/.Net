namespace ConsoleApplication1
{
    class JournalEntry
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public Student Stud { get; set; }

        public JournalEntry()
        {
            Name = "[empty]";
            Type = "[empty]";
            Stud = null;
        }

        public JournalEntry(StudentListHandlerEventArgs args)
        {
            Name = args.Name;
            Type = args.Type;
            Stud = args.Stud;
        }
        public override string ToString()
        {
            return $"Name of collection: {Name}\n Type: {Type}\n Student: {Stud}\n";
        }
    }
}