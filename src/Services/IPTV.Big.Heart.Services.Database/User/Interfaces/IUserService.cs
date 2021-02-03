namespace IPTV.Big.Heart.Services.Database.User.Interfaces
{
    using IPTV.Big.Heart.Database.Models.User;
    using IPTV.Big.Heart.Services.Database.Interfaces;

    public interface IUserService : IBaseDatabaseService<User>
    {
        public string HashPassword(string password);

        public User GetUserByEmail(string email);
    }
}
