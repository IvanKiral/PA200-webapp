namespace PA200_webapp.models.MongoDB;

public class School: BaseDocument
{
    public string Name { get; set; }
    public Wall Wall { get; set; } = new Wall();
}