using CleanArchMVC.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMVC.Domain.Entities
{
    public sealed class Product : EntityBase
    {
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public Product(string name, string description, decimal price, int stock, string image) 
        { 
            ValidateDomain(name, description, price, stock, image);
        }

        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionsValidations.When(id < 0, "Invalid id value.");
            ValidateDomain(name, description, price, stock, image);
        }

        public void Update(int categoryId, string name, string description, decimal price, int stock, string image)
        {
            ValidateDomain(name, description, price, stock, image);
            CategoryId = categoryId;
        }

        private void ValidateDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionsValidations.When(stock < 0, "Invalid stock value.");

            DomainExceptionsValidations.When(price < 0, "Invalid price value.");

            DomainExceptionsValidations.When(string.IsNullOrEmpty(name), "Name is invalid. Name is required.");

            DomainExceptionsValidations.When(name.Length < 3, "Name is invalid, too short, minimum 3 characteres.");

            DomainExceptionsValidations.When(string.IsNullOrEmpty(description), "Description is invalid. Description is required.");
                
            DomainExceptionsValidations.When(description.Length < 5, "Description is invalid, too short, minimum 3 characteres.");

            DomainExceptionsValidations.When(image?.Length > 250, "Invalid image name, too long, maximum 250 characters.");

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }

    }
}
