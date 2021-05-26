namespace CSharp9Features.Record
{
    public class RecordDemo
    {
        public Member CreateMember()
        {
            // positional syntax
            Member member = new("John", "Doe")
            {
                // Override constructor set Firstname
                FirstName = "Jane",
                Id = "id1",
                ContactInformation = new()
                {
                    Address = "123 Street A, Block 2",
                    PhoneNumber = "123-4400-334"
                }
            };

            // Setting init-only property is not allowed
            // member.LastName = "Jane";

            member.ContactInformation = new()
            {
                Address = "321 Street B, Block 9",
                PhoneNumber = "123-8883-244"
            };

            // Mutable properties
            member.ContactInformation.PhoneNumber = "321-9999-000";

            return member;
        }

        public Member CreateMemberWith(Member member)
        {
            // nondestructive mutation
            return member with { Id = "id2" };
        }

        public Member CloneMemberWith(Member member)
        {
            return member with { };
        }

        public Person ClonePersonWith(Member member)
        {
            return member with { };
        }

        public Person CreatePerson(Member member)
        {
            return new(member.FirstName, member.LastName);
        }

        public CopyCatMember CreateCopyCatMember(Member member)
        {
            return new(member.FirstName, member.LastName);
        }
    }
}
