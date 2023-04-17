using CleanArchMVC.Domain.Entities;
using CleanArchMVC.Domain.Interfaces;
using CleanArchMVC.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMVC.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private AplicationDbContext _productContext;
        public ProductRepository(AplicationDbContext _context) 
        {
            _productContext = _context;
        }
        public async Task<Product> CreateProductAsync(Product category)
        {
            try
            {
                _productContext.Products.Add(category);
                await _productContext.SaveChangesAsync();
                return category;

            }catch
            {
                return null;
            }
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            try
            {
                return await _productContext.Products.FindAsync(id);

            }catch
            {
                return null;
            }
        }

        public async Task<Product> GetProductCategoryAsync(int id)
        {
            try
            {
                return await _productContext.Products.Include(c => c.Category).SingleOrDefaultAsync(c => c.Id == id);
            }
            catch
            {
                return null;
            }
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            try
            {
                return await _productContext.Products.ToListAsync();
            }catch
            {
                return null;
            }
        }

        public async Task<bool> RemoveProductAsync(Product category)
        {
            try
            {
                _productContext.Products.Remove(category);
                await _productContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Product> UpdateProductAsync(Product category)
        {
            try
            {
                _productContext.Products.Update(category);
                await _productContext.SaveChangesAsync();
                return category;
            }
            catch
            {
                return category;
            }
        }
    }
}
