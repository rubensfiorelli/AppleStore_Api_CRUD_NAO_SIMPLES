using AppleStore.Domain.Entities;

namespace AppleStore.Application.Input.InputModels
{
    public sealed record ProductInputModel
    {
        public ProductInputModel(string title,
                                 string description,
                                 string imgUrl,
                                 double price,
                                 float stock,
                                 Guid categoryId)
        {
            Title = title;
            Description = description;
            ImgUrl = imgUrl;
            Price = price;
            Stock = stock;
            CategoryId = categoryId;
        }

        public string Title { get; init; }
        public string Description { get; init; }
        public string ImgUrl { get; init; }
        public double Price { get; init; }
        public float Stock { get; init; }
        public Guid CategoryId { get; init; }

        public Product ToEntity()
            => new Product(Title, Description, ImgUrl, Price, Stock, CategoryId);
    }
}
