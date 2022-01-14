using System.Collections.Generic;

namespace NinkyNonk.Shared
{
    public class NinkyUser
    {
        public string Username { get; set; }
        
        public Dictionary<string, string> Credentials { get; }
        
        public NinkyUser()
        {
            Username = "";
            Credentials = new Dictionary<string, string>();
        }
        
        public NinkyUser(string username)
        {
            Username = username;
            Credentials = new Dictionary<string, string>();
        }

        public override string ToString()
        {
            return Username;
        }

        public override bool Equals(object obj)
        {
            return obj?.ToString() == ToString();
        }
    }
}