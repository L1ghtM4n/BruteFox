/*
     Project > Mozilla Bruteforcer
     Author > github.com/L1ghtM4n
*/

using System;
using System.Text;
using System.Diagnostics;

namespace Bruteforce
{
    internal sealed class mozillaPrivateKey
    {

        #region Fields

        private int
            iterationsCount = 1000;
        private byte[]
            globalSalt,
            partIV,
            entrySalt,
            cipherText;
        private Encoding
            ISO_8859_1 = Encoding.GetEncoding("ISO-8859-1");
        private bool
            Encryption_2A864886F70D01050D = false,
            Encryption_2A864886F70D010C050103 = false;

        #endregion

        #region Constructor

        public mozillaPrivateKey(byte[] globalSalt, byte[] item2Byte)
        {
            this.globalSalt = globalSalt;
            Asn1Der asn = new Asn1Der();
            Asn1DerObject item2 = asn.Parse(item2Byte);
            string asnString = item2.ToString();

            Debug.WriteLine($"ASN: " + asnString);
            // Get encryption algorithm
            Encryption_2A864886F70D01050D = asnString.Contains("2A864886F70D01050D");
            Encryption_2A864886F70D010C050103 = asnString.Contains("2A864886F70D010C050103");
            // Check for pbeWithSha1AndTripleDES-CBC algorithm OID in ASN (1.2.840.113549.1.12.5.1.3)
            // Use to decrypt password-check if found
            if (Encryption_2A864886F70D010C050103)
            {
                entrySalt = item2.objects[0].objects[0].objects[1].objects[0].Data;
                cipherText = item2.objects[0].objects[1].Data;
            }
            // Check for pkcs5 pbes2 algorithm OID in ASN (1.2.840.113549.1.5.13)
            // Use to decrypt password-check if found
            else if (Encryption_2A864886F70D01050D)
            {
                partIV = item2.objects[0].objects[0].objects[1].objects[2].objects[1].Data;
                entrySalt = item2.objects[0].objects[0].objects[1].objects[0].objects[1].objects[0].Data;
                cipherText = item2.objects[0].objects[0].objects[1].objects[3].Data;
                iterationsCount = item2.objects[0].objects[0].objects[1].objects[0].objects[1].objects[1].Int() != 1 ? 10000 : 1;
            }
            else if (!asnString.Contains("2A864886F70D010C050103") && !asnString.Contains("2A864886F70D01050D"))
            {
                throw new Exception("Unrecognized encryption algorithm");
            }
        }

        #endregion

        #region Public Methods
        
        public bool CheckPassword(string password)
        {
            byte[] passwordCheck = null;
            byte[] masterPassword = Encoding.ASCII.GetBytes(password);

            if (Encryption_2A864886F70D010C050103)
            {
                passwordCheck = new decryptMoz3DES(
                    cipherText,
                    globalSalt,
                    masterPassword,
                    entrySalt
                ).Compute();
            }
            else if (Encryption_2A864886F70D01050D)
            {
                passwordCheck = new MozillaPBE(
                    cipherText,
                    globalSalt,
                    masterPassword,
                    entrySalt,
                    partIV
                ).Compute(iterationsCount);
            }

            string decryptedPwdChk = Encoding.ASCII.GetString(passwordCheck);
            return decryptedPwdChk.StartsWith("password-check");
        }
        
        #endregion

    }
}
