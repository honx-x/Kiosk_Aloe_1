using System.Data;
using System.IO;
using System.IO.Compression;
using System.Runtime.Serialization.Formatters.Binary;

namespace TLF.Framework.Utility
{
    /// <summary>
    /// Application에서 DataSet 압축에 사용할 Util Method를 정의합니다.
    /// </summary>
    /// <remarks>
    /// 2009-01-06 최초생성 : 황준혁
    /// 변경내역
    /// 
    /// </remarks>
    public class CompressionUtil
    {
        #region :: CompressDataSet :: DataSet - > Byte[] Compress

        /// <summary>
        /// DataSet - > Byte[] Compress
        /// </summary>
        /// <param name="dsData"></param>
        /// <returns></returns>
        public static byte[] CompressDataSet(DataSet dsData)
        {
            //DataSet Serialize
            dsData.RemotingFormat = SerializationFormat.Binary;
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, dsData);
                byte[] bytData = ms.ToArray();
                //Data Compress
                using (MemoryStream objMs = new MemoryStream())
                {
                    using (DeflateStream objDs = new DeflateStream(objMs, CompressionMode.Compress))
                    {
                        objDs.Write(bytData, 0, bytData.Length);
                        objDs.Flush();
                        objDs.Close();
                    }
                    return objMs.ToArray();
                }
            }
        }

        #endregion

        #region :: DeCompressDataSet :: WebService Binary -> UI DataSet Convert

        /// <summary>
        /// WebService Binary -> UI DataSet Convert
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static DataSet DeCompressDataSet(byte[] data)
        {
            DataSet dsOut = new DataSet();
            
            //input Data -> Stream Create
            using (MemoryStream ms = new MemoryStream(data))
            {
                ms.Seek(0, 0);
                //Compress object Create - UnCompress
                using (DeflateStream objStream = new DeflateStream(ms, CompressionMode.Decompress, true))
                {
                    byte[] bytData = null;

                    bytData = ReadFullStream(objStream);
                    objStream.Flush();
                    objStream.Close();
                    ms.Seek(0, 0);
                    //Compress object Create - UnCompress
                    //input Data -> Stream Create
                    //Stream  Convert
                    using (MemoryStream objMs = new MemoryStream(bytData))
                    {
                        objMs.Seek(0, 0);
                        dsOut.RemotingFormat = SerializationFormat.Binary;
                        //DataSet Deserialize
                        BinaryFormatter bf = new BinaryFormatter();
                        dsOut = (DataSet)bf.Deserialize(objMs, null);
                        
                        bytData = ReadFullStream(objStream);
                        objStream.Flush();
                        objStream.Close();
                        ms.Seek(0, 0);
                        //Compress object Create - UnCompress
                        //input Data -> Stream Create
                        //Stream  Convert
                        return dsOut;
                    }
                }
            }
        }

        /// <summary>
        /// Stream ->  Array Convert
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        private static byte[] ReadFullStream(Stream stream)
        {
            byte[] buffer = new byte[32768];

            using (MemoryStream ms = new MemoryStream())
            {
                int nRead = 0;

                while (true)
                {
                    nRead = stream.Read(buffer, 0, buffer.Length);

                    if (nRead <= 0)
                        return ms.ToArray();

                    ms.Write(buffer, 0, nRead);

                }
            }
        }

        #endregion 
    }
}
