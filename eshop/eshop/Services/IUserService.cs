using eshop.Models;

namespace eshop.Services
{
    public interface IUserService
    {
        User ValidateUser(string userName, string password);

    }
}
