using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        Store214089435Context _Store214089435;

        public CategoryRepository(Store214089435Context Store214089435)
        {
            this._Store214089435 = Store214089435;
        }
        public async Task<IEnumerable<Category>> GetCategories()
        {
            var categories = await _Store214089435.Categories.ToListAsync();
            return categories;
        }
        public async Task<Category> addCategory(Category category)
        {
            await _Store214089435.Categories.AddAsync(category);
            await _Store214089435.SaveChangesAsync();
            return category;
        }
    }
}
