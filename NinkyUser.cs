using System.Collections.Generic;
using System.Net;

namespace NinkyNonk.Shared
{
    public class NinkyUser
    {
        public string Username { get; }
        
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
        
        
    }
}