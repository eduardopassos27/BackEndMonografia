namespace BackEndMonografia.Configuration.Interfaces
{
    public interface IAppSettings
    {
        public string ConnectionString { get; set; }
    }
    public class AppSettings : IAppSettings
    {
        public string ConnectionString { get; set; }
    }

}
