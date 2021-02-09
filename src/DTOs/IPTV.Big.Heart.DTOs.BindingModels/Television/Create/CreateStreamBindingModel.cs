namespace IPTV.Big.Heart.DTOs.BindingModels.Television.Create
{
    public class CreateStreamBindingModel
    {

        public CreateStreamBindingModel(string path)
        {
            this.Path = path;
        }

        public string Path { get; set; }
    }
}
