using System.Security.Cryptography;

namespace BarberHouse.JWT_Token
{
    public class KeyGenerator
    {
        public static byte[] GenerateKey(int keySizeInBits)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] key = new byte[keySizeInBits / 8];
                rng.GetBytes(key);
                return key;
            }
        }
    }
}
