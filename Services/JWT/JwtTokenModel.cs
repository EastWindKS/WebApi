namespace WebAPI.Services.JWT
{
    public class JwtTokenModel
    {
        public string Token { get; set; }
    
        public DateTime Valid { get; set; }
    
        public string UserName { get; set; }
    }
}