namespace IPTV.Big.Heart.DTOs.BindingModels.User
{
    public class CreateRoleBindingModel
    {
        public CreateRoleBindingModel(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
    }
}
