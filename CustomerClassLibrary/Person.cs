namespace CustomerClassLibrary
{
    public abstract class Person
    {
        protected Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
