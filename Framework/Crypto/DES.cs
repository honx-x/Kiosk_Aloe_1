using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace TLF.Framework.Crypto
{
    /// <summary>
    /// DES 암/복호화를 담당하는 Class 입니다.
    /// </summary>
    /// <remarks>
    /// 2009-08-10 최초생성 : 황준혁
    /// 변경내역
    /// 
    /// </remarks>
    public class DES
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 전역변수 :: 

        private static string key = "SEMDJABC";         //반드시 8자리여야 한다.
        private static string iv = "ABCSEMDJ";          //반드시 8자리여야 한다.

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

            using (DESCryptoServiceProvider desKey = new DESCryptoServiceProvider { Key = Encoding.Default.GetBytes(key), IV = Encoding.Default.GetBytes(iv) })
            {
                using (MemoryStream mStream = new MemoryStream())
                {
                    using (CryptoStream cStream = new CryptoStream(mStream, desKey.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        using (StreamWriter sWriter = new StreamWriter(cStream))
                        {
                            sWriter.Write(encryptString);
                            sWriter.Close();
                        }
                        cStream.Close();
                        encrypt = Convert.ToBase64String(mStream.ToArray());
                    }
                    mStream.Close();
                }
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

            using (DESCryptoServiceProvider desKey = new DESCryptoServiceProvider { Key = Encoding.Default.GetBytes(key), IV = Encoding.Default.GetBytes(iv) })
            {
                byte[] buffer = Convert.FromBase64String(decryptString);

                using (MemoryStream mStream = new MemoryStream(buffer))
                {
                    ICryptoTransform cTrans = desKey.CreateDecryptor();
                    using (CryptoStream cStream = new CryptoStream(mStream, cTrans, CryptoStreamMode.Read))
                    {
                        using (StreamReader sReader = new StreamReader(cStream))
                        {
                            decrypt = sReader.ReadToEnd();
                            sReader.Close();
                        }
                        cStream.Close();
                    }
                    mStream.Close();
                }
            }

            return decrypt;
        }

        #endregion
    }
}
