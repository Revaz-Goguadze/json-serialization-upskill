using System.Text.Json.Serialization;

namespace JsonSerialization
{
    public class Employee
    {
        [JsonPropertyName("employee_id")]
        [JsonPropertyOrder(1)]
        public int Id { get; set; }

        [JsonPropertyName("employee_name")]
        [JsonPropertyOrder(4)]
        public string? Name { get; set; }

        [JsonPropertyName("employee_age")]
        [JsonPropertyOrder(3)]
        public int Age { get; set; }

        [JsonPropertyName("employee_role")]
        [JsonPropertyOrder(2)]
        public string? Role { get; set; }
    }
}
