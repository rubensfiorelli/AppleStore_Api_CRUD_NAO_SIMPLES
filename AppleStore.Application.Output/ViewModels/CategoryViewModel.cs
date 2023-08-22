using AppleStore.Domain.Entities;

namespace AppleStore.Application.Output.ViewModels
{
    public sealed record CategoryViewModel
    {
        public CategoryViewModel(Guid id,
                                 string title,
                                 string description,
                                 string imgUrl,
                                 DateTime createAt)
        {
            Id = id;
            Title = title;
            Description = description;
            ImgUrl = imgUrl;
            CreateAt = createAt;
        }

        public Guid Id { get; init; }
        public string Title { get; init; }
        public string Description { get; init; }
        public string ImgUrl { get; init; }
        public DateTime CreateAt { get; init; }

        public static CategoryViewModel FromEntity(Category category)
        {
            return new CategoryViewModel(category.Id,
                                         category.Title,
                                         category.Description,
                                         category.ImgUrl,
                                         category.CreateAt);
        }

    }
}
