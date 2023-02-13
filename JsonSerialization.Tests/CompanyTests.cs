using NUnit.Framework;

namespace JsonSerialization.Tests
{
    [TestFixture]
    public class CompanyTests : ClassTestBase
    {
        [SetUp]
        public void SetUp()
        {
            this.ClassType = typeof(Company);
        }

        [TestCase("Name", "company_name")]
        [TestCase("EstablishedYear", "company_established_year")]
        [TestCase("EmployeeCount", "company_employee_count")]
        [TestCase("CompanyType", "company_company_type")]
        [TestCase("Domains", "company_domains")]
        public new void HasJsonPropertyNameAttribute(string propertyName, string jsonName)
        {
            base.HasJsonPropertyNameAttribute(propertyName, jsonName);
        }

        [TestCase("Name", "1")]
        [TestCase("EstablishedYear", "2")]
        [TestCase("EmployeeCount", "3")]
        [TestCase("Domains", "4")]
        [TestCase("CompanyType", "5")]
        public new void HasJsonPropertyOrderAttribute(string propertyName, int order)
        {
            base.HasJsonPropertyOrderAttribute(propertyName, order);
        }

        [TestCase("IgnoreProperty")]
        public new void HasJsonIgnoreAttribute(string propertyName)
        {
            base.HasJsonIgnoreAttribute(propertyName);
        }
    }
}
