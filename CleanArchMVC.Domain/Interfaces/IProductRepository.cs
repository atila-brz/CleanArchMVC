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
        Task<Product> UpdateeProductAsync(Product category);
        Task<Product> RemoveProductAsync(Product category);
    }
}
