using ProjectManager.Models;
namespace ProjectManager.Services
{
    public interface iProductServices1
    {
        List<Product> GetProducts();
        List<Category> GetCategories();
    }

    public interface iProductServices
    {
        List<Product> GetProducts();
        Product? GetProductByID(int id);
        void CreateProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int id);
        List<Category> GetCategories();

    }
}