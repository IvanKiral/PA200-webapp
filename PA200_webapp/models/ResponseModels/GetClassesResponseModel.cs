namespace PA200_webapp.models.ResponseModels;

public class GetClassesResponseModel
{
    public IEnumerable<MongoDB.Class> Classes { get; set; }
}