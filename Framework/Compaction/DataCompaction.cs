﻿using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO.Compression;

namespace TLF.Framework.Compaction
{
    /// <summary>
    /// 데이터 압축/압축해제를 담당하는 Class 입니다.
    /// </summary>
    /// <remarks>
    /// 2009-12-29 최초생성 : 황준혁
    /// 변경내역
    /// 
    /// </remarks>
    public class DataCompaction
    {
        #region :: ZipData :: DataSet을 압축하여 byte[]로 리턴합니다.

        /// <summary>
        /// DataSet을 압축하여 byte[]로 리턴합니다.
        /// </summary>
        /// <param name="ds">압축할 DataSet</param>
        /// <returns></returns>
        public byte[] ZipData(DataSet ds)
        {
            ds.RemotingFormat = SerializationFormat.Binary;

            BinaryFormatter bFormatter = new BinaryFormatter();
            using (MemoryStream mStream = new MemoryStream())
            {
                bFormatter.Serialize(mStream, ds);
                byte[] serializeData = mStream.ToArray();
                using (MemoryStream stream = new MemoryStream())
                {
                    using (DeflateStream dStream = new DeflateStream(stream, CompressionMode.Compress))
                    {
                        dStream.Write(serializeData, 0, serializeData.Length);
                        dStream.Flush();
                        dStream.Close();
                    }
                    return stream.ToArray();
                }
            }
        }

        #endregion

        #region :: UnzipData :: byte[]를 UnZip 하여 DataSet을 리턴합니다.

        /// <summary>
        /// byte[]를 UnZip 하여 DataSet을 리턴합니다.
        /// </summary>
        /// <param name="bData"></param>
        /// <returns></returns>
        public DataSet UnzipData(byte[] bData)
        {
            DataSet ds = new DataSet();
            byte[] bytData = null;

            using (MemoryStream ms = new MemoryStream(bData))
            {
                ms.Seek(0, 0);
                using (DeflateStream dStream = new DeflateStream(ms, CompressionMode.Decompress, true))
                {
                    bytData = ReadStream(dStream);
                    dStream.Flush();
                    dStream.Close();
                    using (MemoryStream mStream = new MemoryStream(bytData))
                    {
                        mStream.Seek(0, 0);
                        ds.RemotingFormat = SerializationFormat.Binary;
                        
                        BinaryFormatter bf = new BinaryFormatter();
                        ds = (DataSet)bf.Deserialize(mStream, null);
                        return ds;
                    }
                }
            }
        }

        private byte[] ReadStream(Stream stream)
        {
            byte[] buffer = new byte[32768];

            using (MemoryStream mStream = new MemoryStream())
            {
                int nRead = 0;

                while (true)
                {
                    nRead = stream.Read(buffer, 0, buffer.Length);

                    if (nRead <= 0)
                        return mStream.ToArray();

                    mStream.Write(buffer, 0, nRead);
                }
            }
        }

        #endregion
    }
}
