using CleanArchMVC.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMVC.Domain.Entities
{
    public sealed class Category : EntityBase
    {
        public ICollection<Product> Products { get; set; }

        public Category(string name) 
        {
            ValidateDomain(name);
        }

        public Category(int id, string name) 
        {
            DomainExceptionsValidations.When(id < 0, "Invalid id value");
            Id = id;
            ValidateDomain(name);
        }

        public void Update(string name)
        {
            ValidateDomain(name);
            Name = name;
        }

        private void ValidateDomain(string name)
        {
            DomainExceptionsValidations.When(string.IsNullOrEmpty(name), "Invalid name is required.");

            DomainExceptionsValidations.When(name.Length < 3, "Invalid name, too short, minium 3 charecteres.");

            Name = name;
        }

    }
}
