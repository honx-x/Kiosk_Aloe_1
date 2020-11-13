
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraPdfViewer;
using DevExpress.XtraPdfViewer.Commands;
using DevExpress.XtraPrinting.Export.Pdf;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TLF.Business.WSBiz;
using TLF.Framework.Authentication;
using TLF.Framework.Config;
using DevExpress.Pdf;
using DevExpress.XtraBars.Docking2010.Views.NoDocuments;
using PdfSharp;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace TLF.UI.Developer.Design
{

    public partial class helper_test : TLF.Framework.BaseFrame.UIFrame
    {
        string image_file = string.Empty;
        public string menuid = "";
        public UserInformation cut;
        string update_image_file = string.Empty;

        public helper_test()
        {
            InitializeComponent();
        }


        //폼실행시 발생
        private void helper_test_Load(object sender, EventArgs e)
        {
            btn_c_delete.Click += Btn_c_delete_Click;
            btn_update.Click += Btn_update_Click;
            btn_comment.Click += Btn_comment_Click;
            btn_img_c.Click += Btn_img_c_Click;
            SelectionData();
         



            using (WsBiz wb = new WsBiz(AppConfig.DEFAULTDB))
            {
                DataSet ds;

                string query = "dbo.MenuMaster_File_Select";

                var paramList = new string[] {    "@iMenuId"
                                             };
                var valueList = new object[] {   menuid
                                             };

                ds = wb.NTx_ExecuteDataSet(AppConfig.DEFAULTDB, query, AppConfig.COMMANDSP, paramList, valueList);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    System.Data.DataRow row = ds.Tables[0].Rows[0];
                    //byte[] byteArray = (byte[])row.ItemArray[0];
                    if (row[0] != DBNull.Value)
                    {
                        byte[] byteArray = (byte[])row[0];
                        //File.WriteAllBytes(@"C:\Users\PC\Downloads\test.pdf", byteArray);
                        MemoryStream stream = new MemoryStream(byteArray);
                        pdfViewer1.LoadDocument(stream);
                    }
                }

                //using (PdfSharp.Pdf.PdfDocument one = PdfReader.Open(@"C:\\Users\\PC\\Desktop\\hidata_mes\\helpmenual\\pdf.pdf", PdfDocumentOpenMode.Import))
                //using (PdfSharp.Pdf.PdfDocument two = PdfReader.Open(@"C:\\Users\\PC\\Desktop\\hidata_mes\\helpmenual\\sample2.pdf", PdfDocumentOpenMode.Import))
                //using (PdfSharp.Pdf.PdfDocument outPdf = new PdfSharp.Pdf.PdfDocument())
                //{
                //    CopyPages(one, outPdf);
                //    CopyPages(two, outPdf);

                //    outPdf.Save(@"C:\\Users\\PC\\Desktop\\hidata_mes\\helpmenual\\result.pdf");
                //}

                //void CopyPages(PdfSharp.Pdf.PdfDocument from, PdfSharp.Pdf.PdfDocument to)
                //{
                //    for (int i = 0; i < from.PageCount; i++)
                //    {
                //        to.AddPage(from.Pages[i]);
                //    }
                //}

            }

      
            //setCurrentPage(2);
            /******************************************************************************/
            //SizeF currentPageSize = pdfViewer1.GetPageSize(pdfViewer1.CurrentPageNumber);
            //float dpi = 110f;
            //float pageHeightPixel = currentPageSize.Height * dpi;
            //float topBottomOffset = 40f;
            //pdfViewer1.ZoomFactor = ((float)pdfViewer1.ClientSize.Height - topBottomOffset) / pageHeightPixel * 100f;
            /******************************************************************************/
            //if (menuid == "Dev_OutPuts2016")
            //{
            //    pdfViewer1.CurrentPageNumber = 3;
            //}
            //else if (menuid == "Dev_OutPuts2019")
            //{
            //    pdfViewer1.CurrentPageNumber = 5;
            //}
        }


        //삭제처리
        private void Btn_c_delete_Click(object sender, EventArgs e)
        {
            string focuseduser = comment_list.FocusedNode["InsertUserID"].ToString();

            if (comment_list.GetFocusedRowCellValue(Comment).ToString() == "삭제된 댓글입니다.")
            {
                MessageBox.Show("이미 삭제 된 글입니다.", "알림");
                return;
            }

            if (cut.UserID.ToString() == focuseduser)
            {
                if (MessageBox.Show("글을 삭제하시겠습니까?", "글 삭제", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    int seq = int.Parse(comment_list.FocusedNode["Seq"].ToString());
                    int rowHandle = comment_list.FocusedNode.Id;
                    using (var wb = new WsBiz(AppConfig.DEFAULTDB))
                    {

                        var query = "dbo.usp_HelpCommentHs_CRUD";
                        var paramList = new string[] {   "@iOp1"
                                                ,"@iOp2"
                                                ,"@Seq"
                                             };

                        var valueList = new object[] {   "D"
                                                ,"1"
                                                ,seq
                                             };

                        wb.Tx_ExecuteNonQuery(AppConfig.DEFAULTDB, query, AppConfig.COMMANDSP, paramList, valueList);
                    }

                    SelectionData();
                    comment_list.FocusedNode = comment_list.FindNodeByID(rowHandle);
                }
                else
                {

                }
            }
            if (cut.UserID.ToString() == "SYSTEM")
            {
                if (MessageBox.Show("글을 삭제하시겠습니까?", "글 삭제", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int seq = int.Parse(comment_list.FocusedNode["Seq"].ToString());
                    int rowHandle = comment_list.FocusedNode.Id;
                    using (var wb = new WsBiz(AppConfig.DEFAULTDB))
                    {

                        var query = "dbo.usp_HelpCommentHs_CRUD";
                        var paramList = new string[] {   "@iOp1"
                                                ,"@iOp2"
                                                ,"@Seq"
                                             };

                        var valueList = new object[] {   "D"
                                                ,"1"
                                                ,seq
                                             };

                        wb.Tx_ExecuteNonQuery(AppConfig.DEFAULTDB, query, AppConfig.COMMANDSP, paramList, valueList);
                    }

                    SelectionData();
                    comment_list.FocusedNode = comment_list.FindNodeByID(rowHandle);
                }
                else
                {
                    return;
                }
            }

        }

        protected void CreateUserMenu(DataSet ds)
        {
            comment_list.DataSource = ds;
            comment_list.DataMember = ds.Tables[0].TableName;
            comment_list.ExpandAll();
        }

        //조회처리
        public void SelectionData()
        {

            DataSet ds;


            //메인 댓글 불러오기
            #region msSql 기준 소스
            using (var wb = new WsBiz(AppConfig.DEFAULTDB))
            {

                var query = "dbo.usp_HelpCommentHs_CRUD";
                var paramList = new string[] {    "@iOp1"
                                                 ,"@iOp2"
                                                 ,"@MenuID"
                                             };


                var valueList = new object[] {   "R"
                                                ,"1"
                                                ,menuid
                                             };

                ds = wb.NTx_ExecuteDataSet(AppConfig.DEFAULTDB, query, AppConfig.COMMANDSP, paramList, valueList);

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (ds.Tables[0].Rows[i]["IsDelete"].Equals(true))
                    {
                        ds.Tables[0].Rows[i]["Comment"] = "삭제된 댓글입니다.";
                    }
                }

            }
            CreateUserMenu(ds);

            #endregion

        }

        //댓글 등록
        private void comment_save_Click(object sender, EventArgs e)
        {
            string commenttxt;
            string nowtime;
            //현재시간 받아오기
            System.DateTime.Now.ToString("yyyy");
            nowtime = DateTime.Now.ToString("yyyy-MM-dd-HH-mm");

            string userid = cut.UserID;

            commenttxt = comment_txt.Text.ToString();

            if (comment_txt.Text.ToString() == null)
            {
                MessageBox.Show("내용을 입력해주세요");
            }

            DataSet ds;

            using (var wb = new WsBiz(AppConfig.DEFAULTDB))
            {
                byte[] fileValue = null;
                if (img_box.Image != null) { fileValue = File.ReadAllBytes(image_file); }


                var query = "dbo.usp_HelpCommentHs_CRUD";
                var paramList = new string[] {   "@iOp1"
                                                ,"@iOp2"
                                                ,"@MenuID"
                                                ,"@Comment"
                                                ,"@ImageData"
                                                ,"@InsertUserID"

                                             };

                var valueList = new object[] {   "C"
                                                ,"1"
                                                ,menuid
                                                ,commenttxt
                                                ,fileValue //이미지 데이터 변환 코딩
                                                ,userid
                                             };

                wb.Tx_ExecuteNonQuery(AppConfig.DEFAULTDB, query, AppConfig.COMMANDSP, paramList, valueList);
            }

            comment_txt.Clear();
            img_box.Image = null;

            SelectionData();
            comment_list.MoveLast();


        }

        //첨부파일 등록
        private void img_save_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = @"C:\";

            var dialog_result = dialog.ShowDialog();
            if (dialog_result == DialogResult.OK)
            {
                image_file = dialog.FileName;
                img_box.Image = Bitmap.FromFile(image_file);

            }
            else if (dialog_result == DialogResult.Cancel)
            {
                img_box.Image = null;
            }
        }

        //수정버튼
        private void Btn_update_Click(object sender, EventArgs e)
        {
            string userid = cut.UserID;
            string focuseduser = comment_list.FocusedNode["InsertUserID"].ToString();
            int rowHandle = comment_list.FocusedNode.Id;

            if (Comment.OptionsColumn.AllowEdit)
            {
                Comment.OptionsColumn.AllowEdit = false; //전체 수정 끝
                btn_img_c.Buttons[0].Visible = false;
                img_c_img.OptionsColumn.AllowEdit = false;

                int seq = int.Parse(comment_list.FocusedNode["Seq"].ToString());
                string comment = comment_list.FocusedNode["Comment"].ToString();

                using (var wb = new WsBiz(AppConfig.DEFAULTDB))
                {

                    var query = "dbo.usp_HelpCommentHs_CRUD";
                    var paramList = new string[] {
                                                 "@iOp1"
                                                ,"@iOp2"
                                                ,"@Seq"
                                                ,"@Comment"
                                                ,"@ImageData"
                                                ,"@UpdateUserId"

                                             };

                    var valueList = new object[] {   "U"
                                                ,"1"
                                                ,seq
                                                ,comment
                                                ,comment_list.FocusedNode["ImageData"]==DBNull.Value?null:comment_list.FocusedNode["ImageData"] //이미지 데이터 변환 코딩
                                                ,userid
                                             };

                    wb.Tx_ExecuteNonQuery(AppConfig.DEFAULTDB, query, AppConfig.COMMANDSP, paramList, valueList);
                }

                SelectionData();
                comment_list.FocusedNode = comment_list.FindNodeByID(rowHandle);

            }

            else
            {
                if (userid == focuseduser)
                {

                    Comment.OptionsColumn.AllowEdit = true; //전체 수정 가능
                    btn_img_c.Buttons[0].Visible = true;
                    img_c_img.OptionsColumn.AllowEdit = true;
                    update_image_file = string.Empty;

                }
                if (userid.ToString() == "SYSTEM")
                {
                    Comment.OptionsColumn.AllowEdit = true; //전체 수정 가능
                    btn_img_c.Buttons[0].Visible = true;
                    img_c_img.OptionsColumn.AllowEdit = true;
                    update_image_file = string.Empty;

                }
            }

        }
        private void comment_list_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (Comment.OptionsColumn.AllowEdit)
            {
                int rowHandle = comment_list.FocusedNode.Id;

                Comment.OptionsColumn.AllowEdit = false; ;//셀위치 변경 시 수정 불가능
                btn_img_c.Buttons[0].Visible = false;
                img_c_img.OptionsColumn.AllowEdit = false;//첨부파일 수정불가능
                SelectionData();

                comment_list.FocusedNode = comment_list.FindNodeByID(rowHandle);
            }
        }

        //대댓글 등록
        private void Btn_comment_Click(object sender, EventArgs e)
        {
            //string nowtime;
            ////현재시간 받아오기
            //System.DateTime.Now.ToString("yyyy");
            //nowtime = DateTime.Now.ToString("yyyy-MM-dd-HH-mm");
            //string reply_comment = comment_list.FocusedNode["Comment"].ToString();
            //if(seq != null){
            //    ParentNode.Nodes.Add("아이디", nowtime,"수정버튼을 누른후 댓글입력", "댓글", "수정", "삭제", "첨부파일");
            //    comment_list.ExpandAll();
            //    comment_list.Invalidate();
            //}
            int seq = int.Parse(comment_list.FocusedNode["Seq"].ToString());
            int rowHandle = comment_list.FocusedNode.Id;
            DataSet ds;

            string userid = cut.UserID;
            using (var wb = new WsBiz(AppConfig.DEFAULTDB))
            {
                byte[] fileValue = null;
                if (img_box.Image != null) { fileValue = File.ReadAllBytes(image_file); }


                var query = "dbo.usp_HelpCommentHs_CRUD";
                var paramList = new string[] {   "@iOp1"
                                                ,"@iOp2"
                                                ,"@MenuID"
                                                ,"@ParentSeq"
                                                ,"@Comment"
                                                ,"@ImageData"
                                                ,"@InsertUserID"

                                             };

                var valueList = new object[] {   "C"
                                                ,"2"
                                                ,menuid
                                                ,seq
                                                ,""
                                                ,null //이미지 데이터 변환 코딩
                                                ,userid
                                             };

                wb.Tx_ExecuteNonQuery(AppConfig.DEFAULTDB, query, AppConfig.COMMANDSP, paramList, valueList);
            }

            //comment_txt.Clear();
            //img_box.Image = null;          
            SelectionData();
            TreeListNode newnode = comment_list.FindNodeByID(rowHandle);
            comment_list.FocusedNode = newnode.Nodes[newnode.Nodes.Count - 1];
        }

        //첨부파일 변경(수정부분)
        private void Btn_img_c_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = @"C:\";
            update_image_file = string.Empty;
            var dialog_result = dialog.ShowDialog();
            byte[] fileValus = null;

            if (dialog_result == DialogResult.OK)
            {
                update_image_file = dialog.FileName;
                fileValus = File.ReadAllBytes(update_image_file);
                comment_list.FocusedNode["ImageData"] = fileValus;

            }
            else if (dialog_result == DialogResult.Cancel)
            {
                comment_list.FocusedNode["ImageData"] = fileValus;
            }
        }
    }
}
