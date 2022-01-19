using NinkyNonk.Shared.Configuration;

namespace NinkyNonk.Shared
{
    public static class NinkyNonkService
    {
        public const string Domain = "nonk.uk";
        public static Url Url { get; } = new Url(Domain);
        public static Url ApiUrl { get; } = new Url("api." + Domain);
    }
}