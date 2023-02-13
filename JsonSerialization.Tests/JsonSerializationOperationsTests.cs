using NUnit.Framework;
using NUnit.Framework.Internal;

[assembly: CLSCompliant(false)]

namespace JsonSerialization.Tests
{
    [TestFixture]
    public class JsonSerializationOperationsTests
    {
        private static readonly object[][] SerializeEmployeeToJsonData = new object[][]
        {
            new object[] { new Employee { Id = 1, Name = "Sharath", Age = 22, Role = "Junior Software Engineer" }, @"{""employee_id"":1,""employee_role"":""Junior Software Engineer"",""employee_age"":22,""employee_name"":""Sharath""}" },
        };

        private static readonly object[][] DeserializeEmployeeJsonToObjectData = new object[][]
        {
            new object[] { @"{""employee_id"":1,""employee_name"":""Sharath"",""employee_age"":22,""employee_role"":""Junior Software Engineer""}", new Employee { Id = 1, Name = "Sharath", Age = 22, Role = "Junior Software Engineer" } },
        };

        private static readonly object[][] SerializeCompanyToJsonData = new object[][]
        {
            new object[] { new Company { Name = "EPAM", EstablishedYear = 1993, EmployeeCount = 38000, CompanyType = CompanyType.SoftwareServices, Domains = new Dictionary<string, int>() { { "CloudComputing", 1 }, { "JavaTechnologies", 2 }, { "ArtificialIntelligence", 3 } } }, @"{""company_name"":""EPAM"",""company_established_year"":1993,""company_employee_count"":38000,""company_domains"":{""CloudComputing"":1,""JavaTechnologies"":2,""ArtificialIntelligence"":3},""company_company_type"":1}" },
        };

        private static readonly object[][] DeserializeCompanyJsonToObjectData = new object[][]
        {
            new object[] { @"{""company_name"":""EPAM"",""company_established_year"":1993,""company_employee_count"":38000,""company_domains"":{""CloudComputing"":1,""JavaTechnologies"":2,""ArtificialIntelligence"":3},""company_company_type"":1}", new Company { Name = "EPAM", EstablishedYear = 1993, EmployeeCount = 38000, CompanyType = CompanyType.SoftwareServices, Domains = new Dictionary<string, int>() { { "CloudComputing", 1 }, { "JavaTechnologies", 2 }, { "ArtificialIntelligence", 3 } } } },
        };

        private static readonly object[][] SerializeCompanyDomainToJsonData = new object[][]
        {
            new object[] { new Company { Name = "EPAM", EstablishedYear = 1993, EmployeeCount = 38000, CompanyType = CompanyType.SoftwareServices, Domains = new Dictionary<string, int>() { { "CloudComputing", 1 }, { "JavaTechnologies", 2 }, { "ArtificialIntelligence", 3 } } }, @"{""cloudComputing"":1,""javaTechnologies"":2,""artificialIntelligence"":3}" },
        };

        private static readonly object[][] SerializeCompanyTypeToObjectData = new object[][]
        {
            new object[] { new Company { Name = "EPAM", EstablishedYear = 1993, EmployeeCount = 38000, CompanyType = CompanyType.SoftwareServices, Domains = new Dictionary<string, int>() { { "CloudComputing", 1 }, { "JavaTechnologies", 2 }, { "ArtificialIntelligence", 3 } } }, @"{""company_name"":""EPAM"",""company_established_year"":1993,""company_employee_count"":38000,""company_domains"":{""CloudComputing"":1,""JavaTechnologies"":2,""ArtificialIntelligence"":3},""company_company_type"":""softwareServices""}" },
        };

        [TestCaseSource(nameof(SerializeEmployeeToJsonData))]
        public void SerializeObjectToJson_ReturnsJson(object obj, string expected)
        {
            // Act
            string actual = JsonSerializationOperations.SerializeObjectToJson(obj);

            // Arrange
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCaseSource(nameof(DeserializeEmployeeJsonToObjectData))]
        public void DeserializeJsonToObject_WithEmployeeJson_ReturnsObject(string json, Employee expected)
        {
            // Act
            Employee? actual = JsonSerializationOperations.DeserializeJsonToObject<Employee>(json);

            // Arrange
            Assert.That(actual, Is.Not.Null);
            Assert.That(actual!.Id, Is.EqualTo(expected.Id));
            Assert.That(actual!.Name, Is.EqualTo(expected.Name));
            Assert.That(actual!.Age, Is.EqualTo(expected.Age));
            Assert.That(actual!.Role, Is.EqualTo(expected.Role));
        }

        [TestCaseSource(nameof(SerializeCompanyToJsonData))]
        public void SerializeCompanyToJson_ReturnsJson(object obj, string expected)
        {
            // Act
            string actual = JsonSerializationOperations.SerializeCompanyObjectToJson(obj);

            // Arrange
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCaseSource(nameof(DeserializeCompanyJsonToObjectData))]
        public void DeserializeJsonToObject_WithCompanyJson_ReturnsObject(string json, Company expected)
        {
            // Act
            Company? actual = JsonSerializationOperations.DeserializeCompanyJsonToObject<Company>(json);

            // Arrange
            Assert.That(actual, Is.Not.Null);
            Assert.That(actual!.Name, Is.EqualTo(expected.Name));
            Assert.That(actual!.EstablishedYear, Is.EqualTo(expected.EstablishedYear));
            Assert.That(actual!.EmployeeCount, Is.EqualTo(expected.EmployeeCount));
            Assert.That(actual!.CompanyType, Is.EqualTo(expected.CompanyType));
            CollectionAssert.AreEqual(actual!.Domains, expected.Domains);
        }

        [TestCaseSource(nameof(SerializeCompanyDomainToJsonData))]
        public void SerializeCompanyDomainDictionaryToJson_ReturnsJson(Company obj, string expected)
        {
            string actual = JsonSerializationOperations.SerializeDictionary(obj);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCaseSource(nameof(SerializeCompanyTypeToObjectData))]
        public void SerializeCompanyTypeEnumToJson_ReturnsJson(Company obj, string expected)
        {
            string actual = JsonSerializationOperations.SerializeEnum(obj);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
