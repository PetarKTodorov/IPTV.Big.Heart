namespace IPTV.Big.Heart.Services.Database.User.Interfaces
{
    using System.Threading.Tasks;
    using IPTV.Big.Heart.Database.Models.User;
    using IPTV.Big.Heart.DTOs.BindingModels.User;
    using IPTV.Big.Heart.Services.Database.Interfaces;

    public interface IUserService : IBaseDatabaseService<User>
    {
        string HashPassword(string password, string passwordSalt);

        string GeneratePasswordSalt();

        User GetUserByEmail(string email);

        User GetUserByUsername(string username);

        Task<string> Login(LoginBindingModel model);

        Task<string> Register(RegisterBindingModel model);
    }
}
