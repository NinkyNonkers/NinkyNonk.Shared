namespace NinkyNonk.Shared
{
    public class NinkyProduct
    {
        public string Id { get; set; }
        public string FileName { get; set; }
        public string LatestVersion { get; set; }

        public NinkyProduct()
        {
            
        }

        public NinkyProduct(string id, string fileName, string latestVersion)
        {
            Id = id;
            FileName = fileName;
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