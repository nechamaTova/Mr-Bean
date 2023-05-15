using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductRepository : IProductRepository
    {
        Store214089435Context _Store214089435;

        public ProductRepository(Store214089435Context Store214089435)
        {
            this._Store214089435 = Store214089435;
        }
        public async Task<IEnumerable<Product>> GetProducts(IEnumerable<string>? categories, string? name, int? minPrice, int? maxPrice)
        {
            return await _Store214089435.Products.Include(p => p.Category).Where(p =>
                (categories.Count()==0?true:!categories.Contains(p.Category.CategoryName)) &&
                (name == null || p.ProductName.Contains(name)) && 
                (minPrice == null || p.Price >= minPrice) && 
                (maxPrice == null || p.Price <= maxPrice))
                .OrderBy(p=>p.Price).ToListAsync();
        }
        public async Task<Product> GetProductById(int id)
        {
            Product? product = await _Store214089435.Products.FindAsync(id);//.Include(p => p.Category);
            return product != null ? product : null;
        }
        public async Task<Product> addProduct(Product product)
        {
            await _Store214089435.Products.AddAsync(product);
            await _Store214089435.SaveChangesAsync();
            return product;
        }
    }
}
