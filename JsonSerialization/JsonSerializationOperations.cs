using System;
using System.Text.Json;
using System.Text.Json.Serialization;

[assembly: CLSCompliant(true)]

namespace JsonSerialization
{
    public static class JsonSerializationOperations
    {
        public static string SerializeObjectToJson(object obj)
        {
            // Serialize the provided object to JSON.
            return JsonSerializer.Serialize(obj);
        }

        public static T? DeserializeJsonToObject<T>(string json)
        {
            // Deserialize the JSON string to an object of type T.
            return JsonSerializer.Deserialize<T>(json);
        }

        public static string SerializeCompanyObjectToJson(object obj)
        {
            // Serialize the provided object to JSON with custom options.
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                Converters = { new JsonStringEnumConverter() },
            };
            return JsonSerializer.Serialize(obj, options);
        }

        public static T? DeserializeCompanyJsonToObject<T>(string json)
        {
            // Deserialize the JSON string to an object of type T with custom options.
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                Converters = { new JsonStringEnumConverter() },
            };
            return JsonSerializer.Deserialize<T>(json, options);
        }

        public static string SerializeDictionary(Company obj)
        {
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase, // Serialize keys in camelCase
            };

            // Create a new dictionary with modified keys (lowercase first letter)
            var modifiedDictionary = new Dictionary<string, int>();
#pragma warning disable CA1062
            foreach (var kvp in obj.Domains!)
#pragma warning restore CA1062
            {
#pragma warning disable CA1304
                var modifiedKey = char.ToLower(kvp.Key[0]) + kvp.Key.Substring(1);
#pragma warning restore CA1304
                modifiedDictionary[modifiedKey] = kvp.Value;
            }

            return JsonSerializer.Serialize(modifiedDictionary, options);
        }

        public static string SerializeEnum(Company obj)
        {
            // Serialize the CompanyType enum property to JSON.
#pragma warning disable CA1062
            return JsonSerializer.Serialize(obj.CompanyType);
#pragma warning restore CA1062
        }
    }
}
