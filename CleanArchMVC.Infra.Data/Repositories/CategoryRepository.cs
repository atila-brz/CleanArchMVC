using CleanArchMVC.Domain.Entities;
using CleanArchMVC.Domain.Interfaces;
using CleanArchMVC.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMVC.Infra.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {

        private AplicationDbContext _Categorycontext;

        public CategoryRepository(AplicationDbContext context)
        {
            _Categorycontext = context;
        }

        public async Task<Category> CreateCategoryAsync(Category category)
        {
            try
            {
                _Categorycontext.Add(category);
                await _Categorycontext.SaveChangesAsync();

                return category;
            }
            catch
            {
                return null;
            }
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            try
            {
                return await _Categorycontext.Categories.ToListAsync();
            }
            catch
            {
                return null;
            }
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            try
            {
                return await _Categorycontext.Categories.FindAsync(id);
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> RemoveCategoryAsync(Category category)
        {
            try
            {
                _Categorycontext.Categories.Remove(category);
                await _Categorycontext.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Category> UpdateCategoryAsync(Category category)
        {
            try
            {
                _Categorycontext.Categories.Update(category);
                await _Categorycontext.SaveChangesAsync();

                return category;
            }
            catch
            {
                return category;
            }
        }
    }
}
