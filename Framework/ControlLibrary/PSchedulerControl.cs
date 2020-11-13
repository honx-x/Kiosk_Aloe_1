using System;
using System.Data;

namespace TLF.Framework.ControlLibrary
{
    /// <summary>
    /// Scheduler Control 입니다.
    /// </summary>
    /// <remarks>
    /// 2011-04-12 최초생성 : 황준혁
    /// 변경내역
    /// 
    /// </remarks>
    public partial class PSchedulerControl : DevExpress.XtraScheduler.SchedulerControl
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// SchedulerControl을 생성합니다.
        /// </summary>
        public PSchedulerControl()
        {
            InitializeComponent();
        }

        #endregion        

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Method(Public)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: FillAppointment(+1 Overloading) :: 데이터를 채웁니다.

        /// <summary>
        /// 데이터를 채웁니다.
        /// </summary>
        /// <param name="ds">DataSource</param>
        /// <remarks>
        /// 2011-04-12 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public void FillAppointment(DataSet ds)
        {
            FillAppointment(ds, ds.Tables[0].TableName);
        }

        /// <summary>
        /// 데이터를 채웁니다.
        /// </summary>
        /// <param name="ds">DataSource</param>
        /// <param name="tableName">DataTable 이름</param>
        /// <remarks>
        /// 2011-04-12 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public void FillAppointment(DataSet ds, string tableName)
        {
            Storage.Appointments.DataSource = ds;
            Storage.Appointments.DataMember = ds.Tables[tableName].TableName;
        }

        #endregion

        #region :: FillResource(+1 Overloading) :: Resource 데이터를 채웁니다.

        /// <summary>
        /// 데이터를 채웁니다.
        /// </summary>
        /// <param name="ds">DataSource</param>
        /// <remarks>
        /// 2011-04-12 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public void FillResource(DataSet ds)
        {
            FillResource(ds, ds.Tables[0].TableName);
        }

        /// <summary>
        /// 데이터를 채웁니다.
        /// </summary>
        /// <param name="ds">DataSource</param>
        /// <param name="tableName">DataTable 이름</param>
        /// <remarks>
        /// 2011-04-12 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public void FillResource(DataSet ds, string tableName)
        {
            Storage.Resources.DataSource = ds;
            Storage.Resources.DataMember = ds.Tables[tableName].TableName;
        }

        #endregion

        /// <summary>
        /// 데이터와 데이터소스를 Mapping 합니다.
        /// </summary>
        /// <param name="subject"></param>
        /// <param name="location"></param>
        /// <param name="label"></param>
        /// <param name="resourceId"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="description"></param>
        /// <param name="allday"></param>
        /// <param name="status"></param>
        /// <param name="type"></param>
        public void InitAppointmentMapping(string subject, string location, string label, 
                                        string resourceId, string start, string end, 
                                        string description, string allday, string status, string type)
        {
            Storage.Appointments.Mappings.Subject = subject;
            Storage.Appointments.Mappings.Location = location;
            Storage.Appointments.Mappings.Label = label;
            Storage.Appointments.Mappings.ResourceId = resourceId;
            Storage.Appointments.Mappings.Start = start;
            Storage.Appointments.Mappings.End = end;
            Storage.Appointments.Mappings.Description = description;
            Storage.Appointments.Mappings.AllDay = allday;
            Storage.Appointments.Mappings.Status = status;
            Storage.Appointments.Mappings.Type = type;
        }

        #region :: InitResourceMapping :: 리소스와 데이터소스를 Mapping 합니다.

        /// <summary>
        /// 리소스와 데이터소스를 Mapping 합니다.
        /// </summary>
        /// <param name="id">ID 열 이름</param>
        /// <param name="caption">캡션 열 이름</param>
        /// <param name="color">색상 열 이름</param>    
        public void InitResourceMapping(string id, string caption, string color)
        {
            Storage.Resources.Mappings.Id = id;
            Storage.Resources.Mappings.Caption = caption;
            Storage.Resources.Mappings.Color = color;
        }

        #endregion
    }
}
