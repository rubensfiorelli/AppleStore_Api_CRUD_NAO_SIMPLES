using AppleStore.Domain.Primitives;

namespace AppleStore.Domain.Entities;

public sealed class Product : BaseEntity
{
    public Product(string title,
                   string description,
                   string imgUrl,
                   double price,
                   float stock,
                   Guid categoryId) : base()
    {
        Title = title;
        Description = description;
        ImgUrl = imgUrl;
        Price = price;
        Stock = stock;
        IsDeleted = false;
        CategoryId = categoryId;
        Delete();
    }

    public string Title { get; private set; }
    public string Description { get; private set; }
    public string ImgUrl { get; private set; }
    public double Price { get; private set; }
    public float Stock { get; private set; }
    public bool IsDeleted { get; private set; }
    public Guid CategoryId { get; private set; }
    public Category? Category { get; set; }


    public void Delete()
    {
        IsDeleted = true;
    }

    public void Update(string newTitle, string newDescription, string newImgUrl, double newPrice, float newStock)
    {
        Title = newTitle;
        Description = newDescription;
        ImgUrl = newImgUrl;
        Price = newPrice;
        Stock = newStock;
    }

    public override bool IsValid()
    {
        throw new NotImplementedException();
    }
}
