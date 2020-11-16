using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Kiosk_ex1
{
    public partial class Kiosk_WorkOrder_Status : Form
    {
        public Kiosk_WorkOrder_Status()
        {

            string NowDate = string.Empty;
            string NowWeekday = string.Empty;

            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;



            NowDate = System.DateTime.Now.ToString("yyyy/MM/dd");
            DayOfWeek today = DateTime.Today.DayOfWeek;
            //this.label_date.Text = NowDate + "(" + today + ")";

            //InitGridControl();
            GridView_OL();
            GridView_CL();


        }

        private void GridView_CL()
        {

            SqlConnection sqlcon = new SqlConnection("Server=192.168.0.70; Database=ARTECH; uid=SA; pwd=hidata2312357!");
            SqlCommand cmd = new SqlCommand();
            sqlcon.Open();


            cmd.Connection = sqlcon;
            cmd.CommandText = "SELECT * FROM dbo.PdWorkOrder";


            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "Work_table");

            gridView_OL.DataSource = ds;
            gridView_OL.DataMember = "Work_table";


            /*
            gridView_OL.Columns["WorkOrderNo"].HeaderText = "작업지시번호";
            gridView_OL.Columns["OrderStatus"].HeaderText = "상태        ";
            gridView_OL.Columns["EngravingNo"].HeaderText = "타각넘버    ";
            gridView_OL.Columns["ItemSeq"].HeaderText = "제품일련번호";
            gridView_OL.Columns["ItemNo"].HeaderText = "PART NO     ";
            gridView_OL.Columns["ItemNm"].HeaderText = "PART NAME   ";
            gridView_OL.Columns["ProcSeq"].HeaderText = "공정일련번호";
            gridView_OL.Columns["ProcCd"].HeaderText = "공정코드    ";
            gridView_OL.Columns["ProcNm"].HeaderText = "공정명      ";
            gridView_OL.Columns["OrderDt"].HeaderText = "지시일자    ";
            gridView_OL.Columns["EmergencyYn"].HeaderText = "긴급여부    ";
            gridView_OL.Columns["Remark"].HeaderText = "비고        ";
            */

            
            gridView_OL.Columns[0].HeaderText = "작업지시번호";
            gridView_OL.Columns[1].HeaderText = "상태";
            gridView_OL.Columns[2].HeaderText = "타각넘버";
            gridView_OL.Columns[3].HeaderText = "제품일련번호";
            gridView_OL.Columns[4].HeaderText = "PART NO";
            gridView_OL.Columns[5].HeaderText = "지시일자";
            gridView_OL.Columns[6].HeaderText = "긴급여부";
            gridView_OL.Columns[7].HeaderText = "삭제가능여부";
            gridView_OL.Columns[8].HeaderText = "지시자";
            gridView_OL.Columns[9].HeaderText = "지시일자";
            gridView_OL.Columns[10].HeaderText = "수정자";
            gridView_OL.Columns[11].HeaderText = "수정일자";
            gridView_OL.Columns[12].HeaderText = "비고";
            

            this.gridView_OL.ColumnHeadersDefaultCellStyle.Font = new Font("돋움", 15, FontStyle.Bold);
            this.gridView_OL.DefaultCellStyle.Font = new Font("돋움", 12, FontStyle.Regular);
            this.gridView_OL.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.gridView_OL.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            


        }

        private void GridView_OL()
        {
            SqlConnection sqlcon = new SqlConnection("Server=192.168.0.70; Database=ARTECH; uid=SA; pwd=hidata2312357!");
            SqlCommand cmd = new SqlCommand();
            sqlcon.Open();


            cmd.Connection = sqlcon;
            cmd.CommandText = "SELECT * FROM dbo.PdWorkOrder";


            SqlDataAdapter da = new SqlDataAdapter(cmd); 
            DataSet ds = new DataSet();
            da.Fill(ds, "Work_table");

            gridView_CL.DataSource = ds;
            gridView_CL.DataMember = "Work_table";

            this.gridView_CL.ColumnHeadersDefaultCellStyle.Font = new Font("돋움", 15, FontStyle.Bold);
            this.gridView_CL.DefaultCellStyle.Font = new Font("돋움", 12, FontStyle.Regular);

        }


        private void InitGridControl()
        {

            gridView_OL.Columns["WorkOrderNo"].HeaderText = "작업지시번호";
            gridView_OL.Columns["OrderStatus"].HeaderText = "상태        ";
            gridView_OL.Columns["EngravingNo"].HeaderText = "타각넘버    ";
            gridView_OL.Columns["ItemSeq    "].HeaderText = "제품일련번호";
            gridView_OL.Columns["ItemNo     "].HeaderText = "PART NO     ";
            gridView_OL.Columns["ItemNm     "].HeaderText = "PART NAME   ";
            gridView_OL.Columns["ProcSeq    "].HeaderText = "공정일련번호";
            gridView_OL.Columns["ProcCd     "].HeaderText = "공정코드    ";
            gridView_OL.Columns["ProcNm     "].HeaderText = "공정명      ";
            gridView_OL.Columns["OrderDt    "].HeaderText = "지시일자    ";
            gridView_OL.Columns["EmergencyYn"].HeaderText = "긴급여부    ";
            gridView_OL.Columns["Remark     "].HeaderText = "비고        ";

        }
    }
}
