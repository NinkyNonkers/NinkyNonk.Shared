using System;

namespace NinkyNonk.Shared.Configuration
{
    public struct Url : IEquatable<string>, IEquatable<Uri>
    {
        private readonly string _noTrailingUrl;
        private string _path;

        public bool UseSecureByDefault { get; set; }

        public Url(string url)
        {
            _noTrailingUrl = RemoveTrailingSlashes(url);
            UseSecureByDefault = false;
            _path = "";
        }
        
        private static string RemoveTrailingSlashes(string url)
        {
            if (url.Contains("http://") || url.Contains("https://"))
                url = url.Replace("https://", "").Replace("http://", "");
            if (!url.Contains("/"))
                return url;
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
            return s + "://" + _noTrailingUrl + "/" + _path;
        }

        public bool Equals(string other)
        {
            return ToString() == other || Format(false) == other || Format(true) == other;
        }

        public bool Equals(Uri other)
        {
            return other?.AbsoluteUri == Format(false) || other?.AbsoluteUri == Format(true);
        }

        public override bool Equals(object other)
        {
            return _noTrailingUrl == (other is Url url ? url : default)._noTrailingUrl;
        }

        public override int GetHashCode()
        {
            return (_noTrailingUrl != null ? _noTrailingUrl.GetHashCode() : 0);
        }

        public static implicit operator Uri(Url value)
        {
            Uri x = new Uri(value.Format(value.UseSecureByDefault));
            return x;
        }

        public Url AddPath(string path)
        {
            Url url = this;
            url._path = path;
            if (path[0].ToString() == "/")
                url._path.Remove(0);
            return url;
        }
        
    }
}