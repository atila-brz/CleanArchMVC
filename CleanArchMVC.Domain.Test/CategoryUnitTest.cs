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
        public void CreateCategory_NegativeIdValue_DomainExceptionsInvalidId()
        {
            Action action = () => new Category(-1, "Category Name");

            action.Should()
                .Throw<DomainExceptionsValidations>()
                .WithMessage("Invalid id value");
        }

        [Fact(DisplayName = "Create Category With Category Name Null")]
        public void CreateCategory_WithNullParameters_DomainExceptionsRequiredName()
        {
            Action action = () => new Category(1, null);

            action.Should()
                .Throw<DomainExceptionsValidations>()
                .WithMessage("Invalid name is required.");
        }

        [Fact(DisplayName = "Create category with category name less than 3")]
        public void CreateCategory_ShortNameValue_DomainExceptionsShortName()
        {
            Action action = () => new Category(1, "Ca");

            action.Should()
                .Throw<DomainExceptionsValidations>()
                .WithMessage("Invalid name, too short, minium 3 charecteres.");
        }

        [Fact(DisplayName = "Create category with category name less than 3")]
        public void CreateCategory_MissingNameValue_DomainExceptionsRequiredName()
        {
            Action action = () => new Category(1, "");

            action.Should()
                .Throw<DomainExceptionsValidations>()
                .WithMessage("Invalid name is required.");
        }
    }
}