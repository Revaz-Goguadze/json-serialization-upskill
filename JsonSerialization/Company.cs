using System.Text.Json.Serialization;

namespace JsonSerialization
{
    public class Company
    {
        public string? Name { get; set; }

        public int EstablishedYear { get; set; }

        public int EmployeeCount { get; set; }

        public Dictionary<string, int>? Domains { get; set; }

        public CompanyType CompanyType { get; set; }

        public string? IgnoreProperty { get; set; }
    }
}
