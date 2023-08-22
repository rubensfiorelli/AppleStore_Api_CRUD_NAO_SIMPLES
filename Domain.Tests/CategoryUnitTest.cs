using AppleStore.Domain.Entities;
using FluentAssertions;

namespace Domain.Tests
{
    public class CategoryUnitTest
    {
        [Fact]
        public void Category_ResultObjectvalid_State()
        {
            Action action = () => new Category("Title", "Description", "ImgUrl");
            action.Should()
                  .NotThrow<AppDomainUnloadedException>();

        }

        [Fact]
        public void Category_ResultObjectInvalid_State()
        {
            Action action = () => new Category("Title", "Description", "ImgUrl");
            action.Should()
                  .Throw<AppDomainUnloadedException>();

        }
    }
}