using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectManager.Models;
using Microsoft.EntityFrameworkCore;

namespace ProjectManager.Services
{
    public class ProductServices : iProductServices
    {
        private readonly DataContext _context;
        public ProductServices(DataContext context)
        {
            _context = context;
        }
        public List<Product> GetProducts()
        {
            return _context.Products.Include(x=>x.Category).ToList();
        }

        public void CreateProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            var exitedProduct = GetProductByID(product.id);
            if (exitedProduct == null) return;
            exitedProduct.Name = product.Name;
            exitedProduct.Quantity = product.Quantity;
            exitedProduct.Price = product.Price;
            exitedProduct.Slug = product.Slug;
            exitedProduct.CategoryId = product.CategoryId;
            _context.Update(exitedProduct);
            _context.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var exitedProduct = GetProductByID(id);
            if (exitedProduct == null) return;
            _context.Products.Remove(exitedProduct);
            _context.SaveChanges();
        }

        public Product? GetProductByID(int id)
        {
            return _context.Products.FirstOrDefault(p => p.id == id);
        }

        public List<Category> GetCategories()
        {
             return _context.Category.ToList();
        }
    }
}