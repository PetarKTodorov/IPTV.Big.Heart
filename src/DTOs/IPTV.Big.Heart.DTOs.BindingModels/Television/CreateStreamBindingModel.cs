namespace IPTV.Big.Heart.DTOs.BindingModels.Television
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
