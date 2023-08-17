using eshop.Infrastructure.Entities;

namespace eshop.Application.Services
{
    public class UserService : IUserService
    {
        private List<User> users;

        public UserService()
        {
            users = new List<User>()
            {
                 new(){ Id=1, UserName="turkay", Password="123", Role="Admin", Name="Türkay", Email="a@bc.com"},
                 new(){ Id=2, UserName="oznur", Password="123", Role="Editor", Name="Öznur", Email="a@bc.com"},
                 new(){ Id=3, UserName="sina", Password="123", Role="Client", Name="Sina", Email="a@bc.com"},

            };
        }

        public User ValidateUser(string userName, string password)
        {
            return users.FirstOrDefault(u => u.UserName == userName && u.Password == password);
        }
    }
}
