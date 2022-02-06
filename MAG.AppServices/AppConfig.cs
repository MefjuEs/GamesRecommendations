namespace MAG.AppServices
{
    public class AppConfig
    {
        public ConnectionStringsConfig ConnectionStrings { get; set; }
        public HostConfig Host { get; set; }
        public JWTConfig JWTToken { get; set; }
    }

    public class ConnectionStringsConfig
    {
        public string GamesDatabase { get; set; }
        public string Identity { get; set; }
    }

    public class HostConfig
    {
        public string Url { get; set; }
        public string FrontURL { get; set; }
    }

    public class JWTConfig
    {
        public string SigningKey { get; set; }
        public int ExpirationTimeMinutes { get; set; }
    }
}
