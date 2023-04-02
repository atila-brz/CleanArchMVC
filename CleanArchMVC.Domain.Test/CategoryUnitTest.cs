using CleanArchMVC.Domain.Entities;
using CleanArchMVC.Domain.Validations;
using FluentAssertions;

namespace CleanArchMVC.Domain.Test
{
    public class CategoryUnitTest
    {
        [Fact(DisplayName = "Create Category With Valid State")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Category Name");

            action.Should()
                .NotThrow<DomainExceptionsValidations>();
        }

        [Fact(DisplayName = "Create Category With ID Negative")]
        public void CreateCategory_WithValidParameters_DomainExceptionsInvalidId()
        {
            Action action = () => new Category(-1, "Category Name");

            action.Should()
                .Throw<DomainExceptionsValidations>()
                .WithMessage("Invalid id value");
        }
    }
}