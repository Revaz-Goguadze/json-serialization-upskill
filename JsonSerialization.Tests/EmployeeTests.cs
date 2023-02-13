using NUnit.Framework;

namespace JsonSerialization.Tests
{
    [TestFixture]
    public class EmployeeTests : ClassTestBase
    {
        [SetUp]
        public void SetUp()
        {
            this.ClassType = typeof(Employee);
        }

        [TestCase("Id", "employee_id")]
        [TestCase("Name", "employee_name")]
        [TestCase("Age", "employee_age")]
        [TestCase("Role", "employee_role")]
        public new void HasJsonPropertyNameAttribute(string propertyName, string jsonName)
        {
            base.HasJsonPropertyNameAttribute(propertyName, jsonName);
        }

        [TestCase("Id", "1")]
        [TestCase("Name", "4")]
        [TestCase("Age", "3")]
        [TestCase("Role", "2")]
        public new void HasJsonPropertyOrderAttribute(string propertyName, int order)
        {
            base.HasJsonPropertyOrderAttribute(propertyName, order);
        }
    }
}
