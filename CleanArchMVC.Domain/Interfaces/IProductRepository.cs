using CleanArchMVC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMVC.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task<Product> GetProductCategoryAsync(int id);
        Task<Product> CreateProductAsync(Product category);
        Task<Product> UpdateProductAsync(Product category);
        Task<bool> RemoveProductAsync(Product category);
    }
}
