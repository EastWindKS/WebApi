namespace WebAPI.Services.Novell
{
    public class NovellUser
    {
        public string CN { get; set; }

        public string DN { get; set; }
        
        public string Password { get; set; }

        public bool IsAlien => DN.Contains("o=Alien");

        public Dictionary<string, string[]> Attributes { get; set; }
    }
}