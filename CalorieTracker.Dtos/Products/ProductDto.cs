using System.Reflection.Metadata.Ecma335;

namespace CalorieTracker.Dtos.Products;

public class ProductDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public float ProteinPerHundredGram { get; set; }
    public float FatPerHundredGram { get; set; }
    public float CarbsPerHundredGram { get; set; }
    public short CaloriesPerHundredGram { get; set; }
}
