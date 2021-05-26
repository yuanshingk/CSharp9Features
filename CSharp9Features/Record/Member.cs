namespace CSharp9Features.Record
{
    // Inheritance
    public record Member(string FirstName, string LastName) : Person(FirstName, LastName)
    {
        public string Id { get; init; }
        public ContactInformation ContactInformation { get; set; }
    }
}
