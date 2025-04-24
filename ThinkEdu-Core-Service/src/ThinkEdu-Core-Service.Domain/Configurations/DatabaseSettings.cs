namespace ThinkEdu_Core_Service.Domain.Configurations
{
    public class DatabaseSettings
    {
        public string ConnectionString { get; set; }

        public DatabaseSettings()
        {
            ConnectionString = "";
        }
    }
}