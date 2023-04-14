using CleanArchMVC.Domain.Entities;
using CleanArchMVC.Domain.Validations;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMVC.Domain.Test
{
    public class ProductUnitTest
    {
        [Fact]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m,
                99, "product image");
            action.Should()
                .NotThrow<DomainExceptionsValidations>();
        }

        [Fact]
        public void CreateProduct_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Product(-1, "Product Name", "Product Description", 9.99m,
                99, "product image");

            action.Should().Throw<DomainExceptionsValidations>()
                .WithMessage("Invalid Id value.");
        }

        [Fact]
        public void CreateProduct_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Product(1, "Pr", "Product Description", 9.99m, 99,
                "product image");
            action.Should().Throw<DomainExceptionsValidations>()
                 .WithMessage("Name is invalid, too short, minimum 3 characteres.");
        }

        [Fact]
        public void CreateProduct_LongImageName_DomainExceptionLongImageName()
        {

            char myChar = 'x';
            string repeatedChar = new String(myChar, 251);

            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m,
                99, repeatedChar);

            action.Should()
                .Throw<DomainExceptionsValidations>()
                 .WithMessage("Invalid image name, too long, maximum 250 characters.");
        }

        [Fact]
        public void CreateProduct_NullImageName_NoNullReferenceException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m,
                99, null);

            action.Should()
                .NotThrow<NullReferenceException>();
        }

        [Fact]
        public void CreateProduct_WithNullImageName_NoDomainException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, null);
            action.Should().NotThrow<DomainExceptionsValidations>();
        }

        [Fact]
        public void CreateProduct_WithEmptyImageName_NoDomainException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, "");
            action.Should().NotThrow<DomainExceptionsValidations>();
        }

        [Fact]
        public void CreateProduct_InvalidPriceValue_DomainException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", -9.99m,
                99, "");
            action.Should().Throw<DomainExceptionsValidations>()
                 .WithMessage("Invalid price value.");
        }

        [Theory]
        [InlineData(-5)]
        public void CreateProduct_InvalidStockValue_ExceptionDomainNegativeValue(int value)
        {
            Action action = () => new Product(1, "Pro", "Product Description", 9.99m, value,
                "product image");
            action.Should().Throw<DomainExceptionsValidations>()
                   .WithMessage("Invalid stock value.");
        }
    }
}
