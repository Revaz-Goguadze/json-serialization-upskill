# JSON Serialization

Beginner level task for practicing JSON serialization.

Estimated time to complete the task - 1h.

The task requires .NET 6 SDK installed.


## Task Description

JSON Serialization in .NET is the process of converting the state of an object, that is, the values of its properties, into a form that can be stored or transmitted, Read [JSON Serialization](https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/overview) article before starting the task.


### 1. Customize JSON Properties.

Read the [How to customize property names and values with System.Text.Json](https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/customize-properties) article.

Apply attributes to the properties of the [Employee](JsonSerialization/Employee.cs) class to set the JSON property name and the order of serialized properties.

| Property Name | JSON Property Name | JSON Property Order |
|---------------|--------------------|---------------------|
| Id            | employee_id        | 1                   |
| Name          | employee_name      | 4                   |
| Age           | employee_age       | 3                   |
| Role          | employee_role      | 2                   |

Apply the [JsonPropertyName](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.serialization.jsonpropertynameattribute) attributes to set the name of individual properties.

```cs
public class Employee
{
    [JsonPropertyName("employee_name")]
    public string? Name { get; set; }

    ...
}
```

Apply the [JsonPropertyOrder](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.serialization.jsonpropertyorderattribute) attributes to specify the property order that is present in the JSON when serializing.

```cs
public class Employee
{
    [JsonPropertyName("employee_name")]
    [JsonPropertyOrder(4)]
    public string? Name { get; set; }

    ...
}
```


### 1.1. Serialization of Object to Json.

Implement the [SerializeObjectToJson](JsonSerialization/JsonSerializationOperations.cs#L10) method, so it could return JSON string. Use the [Serialize](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.jsonserializer.serialize) method that returns JSON string from object.


### 1.2. Deserialization of Json to Object.

Implement the [DeserializeJsonToObject](JsonSerialization/JsonSerializationOperations.cs#L16) method, so it could return object. Use the [Deserialize](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.jsonserializer.deserialize) method that returns JSON string from object.


#### 2. Customize JSON Properties

Apply attributes to the properties of the [Company](JsonSerialization/Company.cs) class to set the JSON property name and the order of serialized properties.

| Property Name   | JSON Property Name       | JSON Property Order | JSON Ignore|
|-----------------|--------------------------|---------------------|------------|
| Name            | company_name             | 1                   | No         |
| EstablishedYear | company_established_year | 2                   | No         |
| EmployeeCount   | company_employee_count   | 3                   | No         |
| Domains         | company_domains          | 4                   | No         |
| CompanyType     | company_company_type     | 5                   | No         |
| IgnoreProperty  |                          |                     | Yes        |


#### 2.1. Serialization of Object to Json with Enum and Dictonories properties.

Implement the [SerializeCompanyObjectToJson](JsonSerialization/JsonSerializationOperations.cs#L22) method, so it could return Json string. Use the [Serialize](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.jsonserializer.serialize) method that returns Json string from object.


#### 2.2. Deserialization of Json to Object with Enum and Dictonories properties.

Implement the [DeserializeCompanyJsonToObject](JsonSerialization/JsonSerializationOperations.cs#L28) method, so it could return object. Use the [Deserialize](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.jsonserializer.deserialize) method that returns Json string from object.


#### 2.3. Serialize the Dictionary properties by using the JsonNamingPolicy class options to convert Pascal case naming to Camel case attributes.

Implement the [SerializeDictionary](JsonSerialization/JsonSerializationOperations.cs#L34) method, so it could return dictionary attributes in Camel case. [JsonNamingPolicy](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.jsonnamingpolicy) this used to convert a string-based name to another format, such as a camel-casing format.


#### 2.4. Serialize the Enum properties by using the JsonStringEnumConverter class to Converts enumeration values to and from strings.

Implement the [SerializeEnum](JsonSerialization/JsonSerializationOperations.cs#L44) method, so it could return enum attributes. [JsonStringEnumConverter](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.serialization.jsonstringenumconverter) this used to Converts enumeration values to and from strings.


##### See also

* C# Language Reference
  * https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/overview
  * https://learn.microsoft.com/en-us/dotnet/standard/serialization/
  * https://learn.microsoft.com/en-us/dotnet/api/system.text.json
  * https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/configure-options?pivots
  * https://learn.microsoft.com/en-us/dotnet/standard/serialization/examples-of-xml-serialization
  * https://learn.microsoft.com/en-us/dotnet/standard/serialization/how-to-serialize-an-object
  * https://learn.microsoft.com/en-us/dotnet/standard/serialization/how-to-deserialize-an-object
