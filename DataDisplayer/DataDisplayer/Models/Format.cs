namespace DataDisplayer.Models;

public class Format
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int TextSize { get; set; }
    public int SpaceBefore { get; set; }
    public int SpaceAfter { get; set; }
    public bool UnderLined { get; set; }
    public bool IsBold { get; set; }
    public bool IsBulletPoint { get; set; }
}
