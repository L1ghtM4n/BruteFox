/*
     Project > Mozilla Bruteforcer
     Author > github.com/L1ghtM4n
*/

using System.IO;
using System.Security.Cryptography;

namespace Bruteforce
{
    // Adapted from firepwd.net (https://github.com/gourk/FirePwd.Net)
    public class TripleDESHelper
    {

        public static byte[] DESCBCDecryptorByte(byte[] key, byte[] iv, byte[] input)
        {
            byte[] decrypted = new byte[512];

            using (TripleDESCryptoServiceProvider tdsAlg = new TripleDESCryptoServiceProvider())
            {
                tdsAlg.Key = key;
                tdsAlg.IV = iv;
                tdsAlg.Mode = CipherMode.CBC;
                tdsAlg.Padding = PaddingMode.None;

                ICryptoTransform decryptor = tdsAlg.CreateDecryptor(tdsAlg.Key, tdsAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(input))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        csDecrypt.Read(decrypted, 0, decrypted.Length);
                    }
                }

            }

            return decrypted;
        }
    }
}
