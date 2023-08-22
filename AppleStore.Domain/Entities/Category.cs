using AppleStore.Domain.Primitives;

namespace AppleStore.Domain.Entities;

public sealed class Category : BaseEntity
{
    public Category(string title,
                    string description,
                    string imgUrl) : base()
    {
        Title = title;
        Description = description;
        ImgUrl = imgUrl;
        IsDeleted = false;
        Products = new List<Product>();
        Delete();
    }

    public string Title { get; private set; }
    public string Description { get; private set; }
    public string ImgUrl { get; private set; }
    public bool IsDeleted { get; private set; }
    public List<Product>? Products { get; set; }



    public void Update(string newTitle, string newDescription, string newImgUrl)
    {
        Title = newTitle;
        Description = newDescription;
        ImgUrl = newImgUrl;

    }

    public void Delete()
    {
        IsDeleted = true;
    }
    public override bool IsValid()
    {
        throw new NotImplementedException();
    }
}
