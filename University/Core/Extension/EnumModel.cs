namespace University.Core.Extension;

public class EnumModel<TId>
{
    public required TId Id { get; set; }
    public string? Title { get; set; }
}