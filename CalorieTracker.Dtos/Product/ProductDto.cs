namespace CalorieTracker.Dtos.Product;

public class ProductDto
{
    public Guid UserId { get; set; }
    public string Name { get; set; } = null!;
    public float ProteinPerHundredGram { get; set; }
    public float FatPerHundredGram { get; set; }
    public float CarbsPerHundredGram { get; set; }
    public short CaloriesPerHundredGram { get; set; }
}
