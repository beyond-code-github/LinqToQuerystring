namespace LinqToQuerystring.IntegrationTests.WebApi
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net.Http.Formatting;
    using System.Net.Http.Headers;

    public class CsvMediaTypeFormatter : BufferedMediaTypeFormatter
    {
        public CsvMediaTypeFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/csv"));
            MediaTypeMappings.Add(new QueryStringMapping("format", "csv", "text/csv"));
        }

        public override bool CanReadType(Type type)
        {
            return false;
        }

        public override bool CanWriteType(Type type)
        {
            return true;
        }

        public override void WriteToStream(
            Type type,
            object value,
            Stream writeStream,
            System.Net.Http.HttpContent content)
        {
            var itemType = type.GetGenericArguments()[0];
            var stringWriter = new StringWriter();

            stringWriter.WriteLine(string.Join<string>(",", itemType.GetProperties().Select(x => x.Name)));

            foreach (var obj in (IEnumerable<object>)value)
            {
                var vals = obj.GetType().GetProperties().Select(pi => new { Value = pi.GetValue(obj, null) });
                var valueLine = string.Empty;

                foreach (var val in vals)
                {
                    if (val.Value != null)
                    {
                        var _val = val.Value.ToString();

                        //Check if the value contans a comma and place it in quotes if so
                        if (_val.Contains(",")) _val = string.Concat("\"", _val, "\"");

                        //Replace any \r or \n special characters from a new line with a space
                        if (_val.Contains("\r")) _val = _val.Replace("\r", " ");
                        if (_val.Contains("\n")) _val = _val.Replace("\n", " ");

                        valueLine = string.Concat(valueLine, _val, ",");
                    }
                    else
                    {
                        valueLine = string.Concat(string.Empty, ",");
                    }
                }

                stringWriter.WriteLine(valueLine.TrimEnd(','));
            }

            var streamWriter = new StreamWriter(writeStream);
            streamWriter.Write(stringWriter.ToString());
        }

        public override void SetDefaultContentHeaders(
            Type type,
            HttpContentHeaders headers,
            MediaTypeHeaderValue mediaType)
        {
            base.SetDefaultContentHeaders(type, headers, mediaType);
            headers.ContentType = new MediaTypeHeaderValue("text/csv");
            headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            headers.ContentDisposition.FileName = "fields.csv";
        }
    }
}
