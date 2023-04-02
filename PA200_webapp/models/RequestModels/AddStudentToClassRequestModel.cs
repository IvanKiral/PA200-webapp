using Newtonsoft.Json;
using PA200_webapp.Utils;

namespace PA200_webapp.models.RequestModels;

public class AddStudentToClassRequestModel
{
    public int UserId { get; set; }
    [JsonConverter(typeof(CustomDateTimeConverter))]
    public DateTime From { get; set; }
    [JsonConverter(typeof(CustomDateTimeConverter))]
    public DateTime To { get; set; }
}