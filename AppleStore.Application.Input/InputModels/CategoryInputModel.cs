using AppleStore.Domain.Entities;

namespace AppleStore.Application.Input.InputModels
{
    public sealed record CategoryInputModel
    {
        public CategoryInputModel(string title, string description, string imgUrl)
        {
            Title = title;
            Description = description;
            ImgUrl = imgUrl;
        }

        public string Title { get; init; }
        public string Description { get; init; }
        public string ImgUrl { get; init; }

        public Category ToEntity()
            => new Category(Title, Description, ImgUrl);

    }
}
