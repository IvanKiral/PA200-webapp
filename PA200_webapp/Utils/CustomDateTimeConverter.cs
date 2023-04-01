using Newtonsoft.Json.Converters;

namespace PA200_webapp.Utils;

public class CustomDateTimeConverter: IsoDateTimeConverter
{
    public CustomDateTimeConverter()
    {
        DateTimeFormat = "yyyy-MM-dd";
    }

}