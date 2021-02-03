namespace IPTV.Big.Heart.DTOs.BindingModels.Television
{
    public class CreateTelevisionCategoryBindingModel
    {
        public CreateTelevisionCategoryBindingModel(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
    }
}
