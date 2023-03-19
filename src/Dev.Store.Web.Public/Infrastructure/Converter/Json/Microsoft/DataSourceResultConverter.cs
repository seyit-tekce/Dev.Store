using Kendo.Mvc.UI;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Dev.Store.Infrastructure.Converter.Json.Microsoft
{
    public class DataSourceResultConverter : JsonConverter<Kendo.Mvc.UI.DataSourceResult>

    {
        public override DataSourceResult Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (string.IsNullOrEmpty(reader.GetString())) return null;



            var customOption = JsonSerializerOptionsHelper.Create(options, new DataSourceResultConverter());
            customOption.PropertyNamingPolicy = null;
            return JsonSerializer.Deserialize<DataSourceResult>(reader.GetString(), customOption);
        }

        public override void Write(Utf8JsonWriter writer, DataSourceResult value, JsonSerializerOptions options)
        {
            var customOption = JsonSerializerOptionsHelper.Create(options, x => x == this);
            customOption.PropertyNamingPolicy = null;
            System.Text.Json.JsonSerializer.Serialize(writer, value, customOption);
        }
    }
}
