using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaVirtual.API.Utilities
{
    public class DateConverter : DateTimeConverterBase
    {
        private TimeZoneInfo _timeZoneInfo;
        private string _dateFormat;

        public DateConverter(string dateFormat, TimeZoneInfo timeZoneInfo)
        {
            _dateFormat = dateFormat;
            _timeZoneInfo = timeZoneInfo;
        }
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTime);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(TimeZoneInfo.ConvertTimeFromUtc(Convert.ToDateTime(value), _timeZoneInfo).ToString(_dateFormat));
            writer.Flush();
        }
    }
}