namespace DotNet8Authentication.Entities
{
    public class News
    {
        public int id { get; set; }
        public required string Title { get; set; } = string.Empty;
        public required string Caption {  get; set; } = string.Empty;
        public required string Body { get; set; } = string.Empty;


    }
}
