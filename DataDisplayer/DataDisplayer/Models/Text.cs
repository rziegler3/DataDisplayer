namespace DataDisplayer.Models;

public class Text
{
    public long Id { get; set; }
    public Topic? Topic { get; set; }
    public Format? Format { get; set; }
    public string TextContent { get; set; } = string.Empty;
    public int Position { get; set; }
}
