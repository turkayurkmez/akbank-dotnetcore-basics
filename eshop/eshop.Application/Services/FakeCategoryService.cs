using eshop.Infrastructure.Entities;


namespace eshop.Application.Services
{
    public class FakeCategoryService : ICategoryService
    {
        private List<Category> _categories;
        public FakeCategoryService()
        {
            _categories = new List<Category>
            {
                 new(){ Id=1, Name="Elektronik"},
                 new(){ Id=2, Name="Giyim"},
                 new(){ Id=3, Name="Kozmetik"}
            };
        }


        public List<Category> GetCategories()
        {
            return _categories;
        }
    }
}
