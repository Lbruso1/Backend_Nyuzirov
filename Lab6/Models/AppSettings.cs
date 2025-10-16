namespace Lab6.Models
{
    public class AppSettings
    {
        public string ApplicationName { get; set; } = string.Empty;
        public string Version { get; set; } = string.Empty;
        public string ApiEndpoint { get; set; } = string.Empty;
        public int ConnectionTimeout { get; set; }
        public bool EnableFeatureX { get; set; }
        public bool DebugMode { get; set; }
    }
} 