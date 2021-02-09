namespace IPTV.Big.Heart.DTOs.BindingModels.Location.Create
{
    public class CreateCountryBindingModel
    {
        public CreateCountryBindingModel()
        {

        }

        public CreateCountryBindingModel(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
    }
}
