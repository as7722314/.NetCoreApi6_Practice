using WebRest2Application.Models;

namespace WebRest2Application.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll();
        Product GetById(int id);
        void Create(Product product);
        void Update(Product product);
        void Delete(Product product);
    }

    public class ProductService : IProductService   
    {
        private readonly TestContext _testContext;
        public ProductService(TestContext testContext)
        {
            _testContext = testContext;
        }
        public IEnumerable<Product> GetAll()
        {
            return _testContext.Products.OrderByDescending(a=>a.Id);
        }
        public Product GetById(int id)
        {
            var product = _testContext.Products.Find(id);
            if (product == null)
            {
                throw new KeyNotFoundException("Product not found");
            }
            return product;
        }
        public void Create(Product product)
        {
            _testContext.Products.Add(product);
            _testContext.SaveChanges();
        }

        public void Update(Product product)
        {
            try
            {
                _testContext.Products.Update(product);
                _testContext.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("系統發生錯誤");
            }
        }
        public void Delete(Product product)
        {
            _testContext.Products.Remove(product);
            _testContext.SaveChanges();
        }
    }
}
