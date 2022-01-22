using System;
using System.IO;

namespace NinkyNonk.Shared.Data
{
    public static class DataExtensions
    {
        public static int GetEpoch(this DateTime span)
        {
            double t = (span - new DateTime(1970, 1, 1)).TotalSeconds;
            return (int) t;
        }
        
        public static byte[] ToByteArray(this Stream sourceStream)
        {
            using (var memoryStream = new MemoryStream())
            {
                sourceStream.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }
    }
}