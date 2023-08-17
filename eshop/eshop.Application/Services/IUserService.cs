using eshop.Infrastructure.Entities;

namespace eshop.Application.Services
{
    public interface IUserService
    {
        User ValidateUser(string userName, string password);

    }
}
