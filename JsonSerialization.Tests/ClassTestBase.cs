using System.Reflection;
using System.Text.Json.Serialization;
using NUnit.Framework;

namespace JsonSerialization.Tests
{
    public abstract class ClassTestBase
    {
        protected Type ClassType { get; set; } = default!;

        protected void HasJsonPropertyNameAttribute(string propertyName, string jsonName)
        {
            PropertyInfo? propertyInfo = this.ClassType.GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance);

            Assert.That(propertyInfo, Is.Not.Null);

            JsonPropertyNameAttribute? attribute = propertyInfo!.GetCustomAttribute<JsonPropertyNameAttribute>();

            Assert.That(attribute, Is.Not.Null);
            Assert.That(attribute!.Name, Is.EqualTo(jsonName));
        }

        protected void HasJsonPropertyOrderAttribute(string propertyName, int order)
        {
            PropertyInfo? propertyInfo = this.ClassType.GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance);

            Assert.That(propertyInfo, Is.Not.Null);

            JsonPropertyOrderAttribute? attribute = propertyInfo!.GetCustomAttribute<JsonPropertyOrderAttribute>();

            Assert.That(attribute, Is.Not.Null);
            Assert.That(attribute!.Order, Is.EqualTo(order));
        }

        protected void HasJsonIgnoreAttribute(string propertyName)
        {
            PropertyInfo? propertyInfo = this.ClassType.GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance);

            Assert.That(propertyInfo, Is.Not.Null);

            JsonIgnoreAttribute? attribute = propertyInfo!.GetCustomAttribute<JsonIgnoreAttribute>();

            Assert.That(attribute, Is.Not.Null);
        }
    }
}
