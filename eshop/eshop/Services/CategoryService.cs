using eshop.Data;
using eshop.Models;

namespace eshop.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AkbankDbContext akbankDbContext;

        public CategoryService(AkbankDbContext akbankDbContext)
        {
            this.akbankDbContext = akbankDbContext;
        }

        public List<Category> GetCategories()
        {
            return akbankDbContext.Categories.ToList();
        }
    }
}
