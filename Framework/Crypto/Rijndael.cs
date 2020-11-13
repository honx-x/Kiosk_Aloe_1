using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace TLF.Framework.Crypto
{
    /// <summary>
    /// Rijndael 암/복호화를 담당하는 Class 입니다.
    /// </summary>
    /// <remarks>
    /// 2009-08-10 최초생성 : 황준혁
    /// 변경내역
    /// 
    /// </remarks>
    public class Rijndael
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 전역변수 ::

        private static string key = "SEMDJABCSEMDJABC";     //반드시 16자리여야 한다.
        private static string iv = "ABCSEMDJABCSEMDJ";      //반드시 16자리여야 한다.

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Static Member & Function
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: Encrypt :: 문자열을 암호화합니다.

        /// <summary>
        /// 문자열을 암호화합니다.
        /// </summary>
        /// <param name="encryptString">암호화할 문자열</param>
        /// <returns></returns>
        public static string Encrypt(string encryptString)
        {
            string encrypt = string.Empty;

            using (MemoryStream mStream = new MemoryStream())
            {
                using (RijndaelManaged aesAlg = new RijndaelManaged { Key = Encoding.Default.GetBytes(key), IV = Encoding.Default.GetBytes(iv) })
                {
                    ICryptoTransform cTrans = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                    using (CryptoStream cStream = new CryptoStream(mStream, cTrans, CryptoStreamMode.Write))
                    {
                        using (StreamWriter sWriter = new StreamWriter(cStream))
                        {
                            sWriter.Write(encryptString);
                            sWriter.Close();
                        }
                        cStream.Close();
                    }
                    aesAlg.Clear();
                }
                encrypt = Convert.ToBase64String(mStream.ToArray());
                mStream.Close();
            }
            return encrypt;
        }

        #endregion

        #region :: Decrypt :: 문자열을 복호화합니다.

        /// <summary>
        /// 문자열을 복호화합니다.
        /// </summary>
        /// <param name="decryptString">복호화할 문자열</param>
        /// <returns></returns>
        public static string Decrypt(string decryptString)
        {
            string decrypt = string.Empty;

            using (RijndaelManaged aesAlg = new RijndaelManaged { Key = Encoding.Default.GetBytes(key), IV = Encoding.Default.GetBytes(iv) })
            {
                ICryptoTransform cTrans = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                byte[] buffer = Convert.FromBase64String(decryptString);
                using (MemoryStream msDecrypt = new MemoryStream(buffer))
                {
                    using (CryptoStream cStream = new CryptoStream(msDecrypt, cTrans, CryptoStreamMode.Read))
                    {
                        using (StreamReader sReader = new StreamReader(cStream))
                        {
                            decrypt = sReader.ReadToEnd();
                            sReader.Close();
                        }
                        cStream.Close();
                    }
                    msDecrypt.Close();
                }
                aesAlg.Clear();
            }
            return decrypt;
        }

        #endregion
    }
}
