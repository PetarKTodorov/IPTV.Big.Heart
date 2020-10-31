namespace IPTV.Big.Heart.Database.Models.User
{
    public class UserRoleMapping: BaseModel
    {
        public int RoleId { get; set; }
        public Role Role { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
    }
}
