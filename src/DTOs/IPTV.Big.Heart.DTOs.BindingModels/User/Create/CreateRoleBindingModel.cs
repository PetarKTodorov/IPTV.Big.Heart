namespace IPTV.Big.Heart.DTOs.BindingModels.User.Create
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
