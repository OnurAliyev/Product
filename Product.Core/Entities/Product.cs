namespace Product.Core.Entities;

public class Product
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Category { get; set; }
    public decimal Price { get; set; }
    public DateTime CreatedTime { get; set; }

    public Product(int productId,string productName,string roductCategory,decimal productPrice)
    {
        Id = productId;
        Name = productName;
        Category = roductCategory;
        Price = productPrice;
        CreatedTime = DateTime.Now;
    }
}
