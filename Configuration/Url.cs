using System;

namespace NinkyNonk.Shared.Configuration
{
    public readonly struct Url : IEquatable<string>
    {
        private readonly string _noTrailingUrl;

        public Url(string url)
        {
            _noTrailingUrl = RemoveTrailingSlashes(url);
        }
        
        private static string RemoveTrailingSlashes(string url)
        {
            if (url.Contains("http://") || url.Contains("https://"))
                url = url.Replace("https://", "").Replace("http://", "");
            int index = url.IndexOf('/');
            url.Remove(index);
            return url;
        }
        
        public override string ToString()
        {
            return _noTrailingUrl;
        }
        
        public string Format(bool secure)
        {
            string s = "http";
            if (secure)
                s += "s";
            return s + "://" + _noTrailingUrl + "/";
        }

        public bool Equals(string other)
        {
            return ToString() == other || Format(false) == other || Format(true) == other;
        }

        public override bool Equals(object other)
        {
            return _noTrailingUrl == (other is Url url ? url : default)._noTrailingUrl;
        }

        public override int GetHashCode()
        {
            return (_noTrailingUrl != null ? _noTrailingUrl.GetHashCode() : 0);
        }

        
    }
}