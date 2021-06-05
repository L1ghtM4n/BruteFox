/*
     Project > Mozilla Bruteforcer
     Author > github.com/L1ghtM4n
*/

using System;
using System.Security.Cryptography;

namespace Bruteforce
{
    public class MozillaPBE
    {
        private byte[] cipherText { get; set; }
        private byte[] GlobalSalt { get; set; }
        private byte[] MasterPassword { get; set; }
        private byte[] EntrySalt { get; set; }
        public byte[] partIV { get; private set; }

        public MozillaPBE(byte[] cipherText, byte[] GlobalSalt, byte[] MasterPassword, byte[] EntrySalt, byte[] partIV)
        {
            this.cipherText = cipherText;
            this.GlobalSalt = GlobalSalt;
            this.MasterPassword = MasterPassword;
            this.EntrySalt = EntrySalt;
            this.partIV = partIV;
        }

        public byte[] Compute(int iterations = 1)
        {
            byte[] GLMP; // GlobalSalt + MasterPassword
            byte[] HP; // SHA1(GLMP)
            byte[] IV; // ivPrefix + partIV
            byte[] key; // ivPrefix + partIV
            int keyLength = 32;
            // GLMP
            GLMP = new byte[GlobalSalt.Length + MasterPassword.Length];
            Buffer.BlockCopy(GlobalSalt, 0, GLMP, 0, GlobalSalt.Length);
            Buffer.BlockCopy(MasterPassword, 0, GLMP, GlobalSalt.Length, MasterPassword.Length);
            // HP
            HP = new SHA1Managed().ComputeHash(GLMP);
            // IV
            byte[] ivPrefix = new byte[2] { 0x04, 0x0e };
            IV = new byte[ivPrefix.Length + partIV.Length];
            Buffer.BlockCopy(ivPrefix, 0, IV, 0, ivPrefix.Length);
            Buffer.BlockCopy(partIV, 0, IV, ivPrefix.Length, partIV.Length);
            // PBKDF2
            Rfc2898DeriveBytes df = new Rfc2898DeriveBytes(HP, EntrySalt, iterations, HashAlgorithmName.SHA256);
            key = df.GetBytes(keyLength);
            // AES-CBC-256 settings
            Rijndael aes = new RijndaelManaged
            {
                Mode = CipherMode.CBC,
                BlockSize = 128,
                KeySize = 256,
                Padding = PaddingMode.Zeros,
            };
            // Decrypt AES cipher text
            ICryptoTransform AESDecrypt = aes.CreateDecryptor(key, IV);
            byte[] clearText = AESDecrypt.TransformFinalBlock(cipherText, 0, cipherText.Length);
            return clearText;
        }
    }
}
