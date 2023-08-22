using AppleStore.Domain.Entities;

namespace AppleStore.Application.Output.ViewModels
{
    public sealed record ProductViewModel
    {
        public ProductViewModel(Guid id,
                                string title,
                                string description,
                                string imgUrl,
                                double price,
                                float stock,
                                Guid categoryId,
                                DateTime createAt)
        {
            Id = id;
            Title = title;
            Description = description;
            ImgUrl = imgUrl;
            Price = price;
            Stock = stock;
            CategoryId = categoryId;
            CreateAt = createAt;
        }

        public Guid Id { get; init; }
        public string Title { get; init; }
        public string Description { get; init; }
        public string ImgUrl { get; init; }
        public double Price { get; init; }
        public float Stock { get; init; }
        public Guid CategoryId { get; init; }
        public DateTime CreateAt { get; set; }

        public static ProductViewModel FromEntity(Product product)
        {
            return new ProductViewModel(product.Id,
                                        product.Title,
                                        product.Description,
                                        product.ImgUrl,
                                        product.Price,
                                        product.Stock,
                                        product.CategoryId,
                                        product.CreateAt);
        }
    }
}
