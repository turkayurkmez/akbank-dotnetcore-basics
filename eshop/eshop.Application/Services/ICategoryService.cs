using eshop.Infrastructure.Entities;

namespace eshop.Application.Services
{
    public interface ICategoryService
    {
        List<Category> GetCategories();

    }
}
