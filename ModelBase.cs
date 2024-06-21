using System.Text.Json;

namespace VogelLibrary
{
    public class ModelBase<T> where T : ModelBase<T>, new()
    {
        public int Id { get; set; }

        public string ToJson()
        {
            var item = this.MemberwiseClone();
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase // Ensure camelCase for properties
            };
            var model = JsonSerializer.Serialize(item, options);
            return model;
        }

        public static T FromJson(string json)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true // Ignora case sensitivity
            };

            return JsonSerializer.Deserialize<T>(json, options);
        }

    }
}
