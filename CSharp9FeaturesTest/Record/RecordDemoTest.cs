using CSharp9Features.Record;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharp9FeaturesTest.Record
{
    [TestClass]
    public class RecordDemoTest
    {
        private RecordDemo sut;
        private Member expectedMember; 

        [TestInitialize]
        public void Initialize()
        {
            sut = new RecordDemo();
            expectedMember = new("Jane", "Doe")
            {
                Id = "id1",
                ContactInformation = new()
                {
                    Address = "321 Street B, Block 9",
                    PhoneNumber = "321-9999-000"
                }
            };
        }

        [TestMethod]
        public void CreateMember_ValueEqualTrue()
        {   
            var result = sut.CreateMember();

            Assert.AreEqual(expectedMember, result);
        }

        [TestMethod]
        public void CreateMember_ReferenceEqualFalse()
        {
            var result = sut.CreateMember();

            Assert.IsFalse(ReferenceEquals(expectedMember, result));
        }

        [TestMethod]
        public void CreateMemberWith_InitOnlyFieldMutated()
        {
            var result = sut.CreateMemberWith(expectedMember);

            Assert.AreNotEqual(expectedMember, result);
            Assert.AreEqual("id1", expectedMember.Id);
            Assert.AreEqual("id2", result.Id);
        }

        [TestMethod]
        public void CloneMemberWith_ValueEqualTrue()
        {
            var result = sut.CloneMemberWith(expectedMember);

            Assert.AreEqual(expectedMember, result);
        }

        [TestMethod]
        public void CloneMemberWith_ReferenceEqualFalse()
        {
            var result = sut.CloneMemberWith(expectedMember);

            Assert.IsFalse(ReferenceEquals(expectedMember, result));
        }

        [TestMethod]
        public void ClonePersonWith_ValueEqualTrue()
        {
            var result = sut.ClonePersonWith(expectedMember);

            // Although record type is not the same but using `with` keyword will create same value
            Assert.AreEqual(expectedMember, result);
        }

        [TestMethod]
        public void CreatePerson_ValueEqualFalse()
        {
            var result = sut.CreatePerson(expectedMember);

            Assert.AreNotEqual(expectedMember, result);
        }

        [TestMethod]
        public void CreateCopyCatMember_ValueEqualFalse()
        {
            var result = sut.CreateCopyCatMember(expectedMember);

            Assert.AreNotEqual(expectedMember, result);
        }
    }
}
