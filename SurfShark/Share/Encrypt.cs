using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace SurfShark.program
{
    class Encrypt
    {
        private static string IVString = "1234567890123456";
        private static string KeyString = "gamessharkkeyidx";

        static public byte[] Decodebs(string str)
        {
            var decbuff = Convert.FromBase64String(str);
            return decbuff;
        }

        static public string Decode(string cypherx)
        {
            var sRet = "";
            byte[] cypher = Decodebs(cypherx.Trim());
            var encoding = new UTF8Encoding();
            var Key = encoding.GetBytes(KeyString);
            var IV = encoding.GetBytes(IVString);

            using (var rj = new RijndaelManaged())
            {
                try
                {
                    rj.Padding = PaddingMode.PKCS7;
                    rj.Mode = CipherMode.CBC;
                    rj.KeySize = 128;
                    rj.BlockSize = 128;
                    rj.Key = Key;
                    rj.IV = IV;
                    var ms = new MemoryStream(cypher);

                    using (var cs = new CryptoStream(ms, rj.CreateDecryptor(Key, IV), CryptoStreamMode.Read))
                    {
                        using (var sr = new StreamReader(cs))
                        {
                            sRet = sr.ReadLine();
                        }
                    }
                }
                finally
                {
                    rj.Clear();
                }
            }

            return sRet;
        }

        static public string Encode(string prm_text_to_encrypt)
        {
            var sToEncrypt = prm_text_to_encrypt.Trim();

            var rj = new RijndaelManaged()
            {
                Padding = PaddingMode.PKCS7,
                Mode = CipherMode.CBC,
                KeySize = 128,
                BlockSize = 128,
            };
            var encoding = new UTF8Encoding();
            var key = encoding.GetBytes(KeyString);
            var IV = encoding.GetBytes(IVString);


            var encryptor = rj.CreateEncryptor(key, IV);

            var msEncrypt = new MemoryStream();
            var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);

            var toEncrypt = Encoding.ASCII.GetBytes(sToEncrypt);

            csEncrypt.Write(toEncrypt, 0, toEncrypt.Length);
            csEncrypt.FlushFinalBlock();

            var encrypted = msEncrypt.ToArray();

            return (Convert.ToBase64String(encrypted));
        }
    }
}
