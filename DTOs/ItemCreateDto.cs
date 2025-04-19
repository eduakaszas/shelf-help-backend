public class ItemCreateDto
{
    public string Name { get; set; }
    public int Count { get; set; }
    public DateTime? ExpirationDate { get; set; }
    public float ConsumptionRate { get; set; }
    public string? Category { get; set; }
}
