using System.Data;
using TLF.Business.WSBiz;
using TLF.Framework.Config;

namespace TLF.Framework.Utility
{
    public class LabelCodeUtil
    {
        public static DataTable Get_CheckData(string spName, string[] Setparams, object[] SetValues)
        {
            DataTable dt = null;

            using (WsBiz wb = new WsBiz(AppConfig.DEFAULTDB))
            {

                string query = spName;

                string[] param = Setparams;

                //new string[] { "@AUTHORITY", "@EMPLOYEECODE" };

                object[] values = SetValues;
                    //new object[] { values1, values2 };

                dt = wb.NTx_ExecuteDataSet(AppConfig.DEFAULTMESDB, query, AppConfig.COMMANDSP, param, values).Tables[0];
            }

            return dt;
       }

        public static DataSet Get_CheckData(string spName, string[] Setparams, object[] SetValues, string Type)
        {
            DataSet ds = null;

            using (WsBiz wb = new WsBiz(AppConfig.DEFAULTDB))
            {

                string query = spName;

                string[] param = Setparams;

                //new string[] { "@AUTHORITY", "@EMPLOYEECODE" };

                object[] values = SetValues;
                //new object[] { values1, values2 };

                ds = wb.NTx_ExecuteDataSet(AppConfig.DEFAULTMESDB, query, AppConfig.COMMANDSP, param, values);
            }

            return ds;
        }
    }
}
