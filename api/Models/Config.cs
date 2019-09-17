namespace api.Models
{
    public class LogLevel
    {
        public string Default { get; set; }
    }

    public class Logging
    {
        public LogLevel LogLevel { get; set; }
    }

    public class ConnectionStrings
    {
        public string sqlserverconn { get; set; }
    }

    public class AppSetting
    {
        public Logging Logging { get; set; }
        public string AllowedHosts { get; set; }
        public ConnectionStrings ConnectionStrings { get; set; }
    }
}