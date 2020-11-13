using System;
using System.Data;
using System.Data.SqlClient;
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

            ListView1();




            SqlConnection sqlcon = new SqlConnection("Server=192.168.0.70; Database=ARTECH; uid=SA; pwd=hidata2312357!");
            sqlcon.Open();



        }


        private void ListView1()
        {
            listView1.View = View.Details;
            //listView1.size

            listView1.BeginUpdate();
            listView1.Columns.Add("지시번호");
            listView1.Columns.Add("타각넘버");
            listView1.Columns.Add("PART NAME");
            listView1.Columns.Add("공정명");
            listView1.Columns.Add("지시일자");
            listView1.Columns.Add("긴급");
            listView1.Columns.Add("진행상태");

            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent); // 컬럼 내용별 오토사이즈
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize); // 컬럼 헤더제목 오토사이즈


            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
