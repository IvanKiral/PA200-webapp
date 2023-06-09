using Newtonsoft.Json;
using PA200_webapp.models.MongoDB;
using PA200_webapp.Utils;

namespace PA200_webapp.models.RequestModels;

public class AddTeacherToClassRequestModel
{
    [JsonConverter(typeof(CustomDateTimeConverter))]
    public DateTime From { get; set; }
    [JsonConverter(typeof(CustomDateTimeConverter))]
    public DateTime To { get; set; }
}