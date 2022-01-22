namespace NinkyNonk.Shared
{
    public class NinkyProduct
    {
        public string Id { get; set; }
        public string Uri { get; set; }
        public string LatestVersion { get; set; }

        public NinkyProduct()
        {
            
        }

        public NinkyProduct(string id, string uri, string latestVersion)
        {
            Id = id;
            Uri = uri;
            LatestVersion = latestVersion;
        }
        
        public override string ToString()
        {
            return Id;
        }

        public override bool Equals(object obj)
        {
            return obj.ToString() == ToString();
        }
        
    }
}