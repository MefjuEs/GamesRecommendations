namespace MAG.AppServices
{
    public class LogInResultDTO
    {
        public bool Success { get; set; }
        public bool InvalidUsernameOrPassword { get; set; }
        public string Token { get; set; }
    }
}
