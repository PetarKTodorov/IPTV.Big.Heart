namespace IPTV.Big.Heart.DTOs.BindingModels.Television.Create
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
