using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Models;
using ProjectManager.Services;
namespace DOTNET.ProjectManager.Controllersce
{
    public class ProductController : Controller
    {
        // public List<Product> Products {get;set;}
        private readonly DataContext _context;
        private readonly iProductServices _productServices;
        // public ProductController(DataContext context)
        // {
        //     _context = context;
        // }
       public ProductController(iProductServices productServices)
        {
            _productServices = productServices;
        }


        // public ProductController()
        // {
        //     // Products = new List<Product>() {
        //     //     new Product {id = 1 , Name = "Ihone 10", Price = 500, Quantity = 30},
        //     //     new Product {id = 2 , Name = "Ihone 11", Price = 600, Quantity = 40},
        //     //     new Product {id = 3 , Name = "Ihone 12", Price = 700, Quantity = 50},
        //     //     new Product {id = 4 , Name = "Ihone 13", Price = 800, Quantity = 60},
        //     //     new Product {id = 5 , Name = "Ihone 14", Price = 900, Quantity = 70},
        //     // };
        // }
        public IActionResult Index()
        {
            // var categories = new List<string>() {
            //     "start",
            //     "duyen",d
            // };
            // ViewBag.categories = categories;
            // ViewBag['Categoris'] = categories;
             var products = _productServices.GetProducts();
            return View(products);
        }
        public IActionResult Create()
        {
            var categories = _productServices.GetCategories();
            return View(categories);
        }
        public IActionResult Save(Product product) {
            if (product.id==0) {
                 _productServices.CreateProduct(product);
            }
            else {
                _productServices.UpdateProduct(product);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id) {
            var product = _productServices.GetProductByID(id);
            if(product==null) return RedirectToAction("Create");
            ViewBag.Product = product;
            var categories = _productServices.GetCategories();
            return View(categories);
        }
        public IActionResult Delete(int id) {
            _productServices.DeleteProduct(id);
            return RedirectToAction("Index");
        }
    }
}