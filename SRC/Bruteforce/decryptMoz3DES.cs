﻿/*
     Project > Mozilla Bruteforcer
     Author > github.com/L1ghtM4n
*/

using System;
using System.Security.Cryptography;

namespace Bruteforce
{
    // Adapted from firepwd.net (https://github.com/gourk/FirePwd.Net)
    public class decryptMoz3DES
    {
        private byte[] cipherText { get; set; }
        private byte[] GlobalSalt { get; set; }
        private byte[] MasterPassword { get; set; }
        private byte[] EntrySalt { get; set; }
        public byte[] Key { get; private set; }
        public byte[] IV { get; private set; }

        public decryptMoz3DES(byte[] cipherText, byte[] GlobalSalt, byte[] MasterPassword, byte[] EntrySalt)
        {
            this.cipherText = cipherText;
            this.GlobalSalt = GlobalSalt;
            this.MasterPassword = MasterPassword;
            this.EntrySalt = EntrySalt;
        }

        public byte[] Compute()
        {
            byte[] GLMP; // GlobalSalt + MasterPassword
            byte[] HP; // SHA1(GLMP)
            byte[] HPES; // HP + EntrySalt
            byte[] CHP; // SHA1(HPES)
            byte[] PES; // EntrySalt completed to 20 bytes by zero
            byte[] PESES; // PES + EntrySalt
            byte[] k1;
            byte[] tk;
            byte[] k2;
            byte[] k; // final value conytaining key and iv

            // GLMP
            GLMP = new byte[GlobalSalt.Length + MasterPassword.Length];
            Buffer.BlockCopy(GlobalSalt, 0, GLMP, 0, GlobalSalt.Length);
            Buffer.BlockCopy(MasterPassword, 0, GLMP, GlobalSalt.Length, MasterPassword.Length);

            // HP
            HP = new SHA1Managed().ComputeHash(GLMP);

            // HPES
            HPES = new byte[HP.Length + EntrySalt.Length];
            Buffer.BlockCopy(HP, 0, HPES, 0, HP.Length);
            Buffer.BlockCopy(EntrySalt, 0, HPES, EntrySalt.Length, HP.Length);

            // CHP
            CHP = new SHA1Managed().ComputeHash(HPES);

            //PES
            PES = new byte[20];
            Array.Copy(EntrySalt, 0, PES, 0, EntrySalt.Length);
            for (int i = EntrySalt.Length; i < 20; i++)
            {
                PES[i] = 0;
            }
            // PESES
            PESES = new byte[PES.Length + EntrySalt.Length];
            Array.Copy(PES, 0, PESES, 0, PES.Length);
            Array.Copy(EntrySalt, 0, PESES, PES.Length, EntrySalt.Length);

            using (HMACSHA1 hmac = new HMACSHA1(CHP))
            {
                // k1
                k1 = hmac.ComputeHash(PESES);
                // tk
                tk = hmac.ComputeHash(PES);
                // tkES
                byte[] tkES = new byte[tk.Length + EntrySalt.Length];
                Buffer.BlockCopy(tk, 0, tkES, 0, tk.Length);
                Buffer.BlockCopy(EntrySalt, 0, tkES, tk.Length, EntrySalt.Length);
                // k2
                k2 = hmac.ComputeHash(tkES);
            }

            // k
            k = new byte[k1.Length + k2.Length];
            Array.Copy(k1, 0, k, 0, k1.Length);
            Array.Copy(k2, 0, k, k1.Length, k2.Length);

            Key = new byte[24];

            for (int i = 0; i < Key.Length; i++)
            {
                Key[i] = k[i];
            }

            IV = new byte[8];
            int j = IV.Length - 1;

            for (int i = k.Length - 1; i >= k.Length - IV.Length; i--)
            {
                IV[j] = k[i];
                j--;
            }

            byte[] decryptedCiphertext = TripleDESHelper.DESCBCDecryptorByte(Key, IV, cipherText);

            // Trim decrypted password-check - we only need the first 24 bytes
            byte[] clearText = new byte[24];
            Array.Copy(decryptedCiphertext, clearText, clearText.Length);

            return clearText;
        }
    }
}