namespace IPTV.Big.Heart.Services.Database.User.Interfaces
{
    using System.Threading.Tasks;
    using IPTV.Big.Heart.Database.Models.User;
    using IPTV.Big.Heart.DTOs.BindingModels.User;
    using IPTV.Big.Heart.Services.Database.Interfaces;

    public interface IUserService : IBaseDatabaseService<User>
    {
        public string HashPassword(string password);

        public User GetUserByEmail(string email);

        public User GetUserByUsername(string username);

        string Login(LoginBindingModel model);

        //Task<string> GenerateToken(UserAuthModel user);
    }
}
