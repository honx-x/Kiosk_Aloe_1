using System.Drawing;
using System;
using System.IO;

namespace TLF.Framework.Config
{
    /// <summary>
    /// Application에서 사용할 Configuration 정보를 정의합니다.
    /// </summary>
    /// <remarks>
    /// 2008-12-16 최초생성 : 황준혁
    /// 변경내역
    /// 
    /// </remarks>
    public class AppConfig
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // 경로 및 기본 설정값 정의
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: CHECKCOLUMNNAME :: GridView에서 사용할 기본 Check Column 명입니다.

        /// <summary>
        /// GridView에서 사용할 기본 Check Column 명입니다.
        /// Value : "isCheck"
        /// </summary>
        public const string CHECKCOLUMNNAME = "isCheck";

        #endregion

        #region :: CLEARTAG :: Clear Tag입니다.

        /// <summary>
        /// Clear Tag입니다.
        /// Value : "|"
        /// </summary>
        public const string CLEARTAG = "|";

        #endregion

        #region :: CONTROLCATEGORY :: Control의 Property Group명입니다.

        /// <summary>
        /// Control의 Property Group명입니다.
        /// Value : "S.E.M Control"
        /// </summary>
        public const string CONTROLCATEGORY = "T.L Control";

        #endregion

        #region :: EVENTCATEGORY :: Control의 Event Property Group명입니다.

        /// <summary>
        /// Event의 Group명입니다.
        /// Value : "S.E.M Event"
        /// </summary>
        public const string EVENTCATEGORY = "S.E.M Event";

        #endregion

        #region :: SETTINGFILEPATH :: 사용자 정보(ini) File을 저장할 경로입니다.

        /// <summary>
        /// 사용자 정보(ini) File을 저장할 경로입니다.
        /// Value : Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), SYSTEMNAME + @"\Setting.ini")
        /// </summary>
        public static string SETTINGFILEPATH = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + String.Format(@"\{0}\BaseSettings.ini", AppConfig.SYSTEMNAME);

        #endregion

        #region :: SYSTEMNAME :: System 이름입니다.

        /// <summary>
        /// System 이름입니다.
        /// Value : "SWMES"
        /// </summary>
        public const string SYSTEMNAME = "DYS";

        #endregion

        #region :: WEBSERVICEURL :: 사용할 Web Service의 주소입니다. 
        
        /// <summary>
        /// 기본 Web Service 주소입니다.
        /// Value : "http://161.83.27.100/WebService/"
        /// </summary>
        public static string WEBSERVICEURL = "http://161.83.27.100/WebService/";
        /// <summary>
        /// MES CORE Web Service 주소입니다.
        /// </summary>
        public static string CORECommon_WEBSERVICEURL = "http://116.3.63.35/CORECommonWebService/";

        //public static string WEBSERVICEURL = "http://localhost:5628/SemWebService/"; 

        #endregion

        #region :: Assembly Path 관련 ::

        /// <summary>
        /// Assembly가 저장될 Folder
        /// VALUE : Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), SYSTEMNAME)
        /// </summary>
//        public static string ASSEMBLYFOLDER = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), SYSTEMNAME);
        public static string ASSEMBLYFOLDER = "./";

        /// <summary>
        /// Grid Layout XML이 저장될 Folder
        /// VALUE : Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), String.Format(@"{0}\GridLayout", SYSTEMNAME))
        /// </summary>
        public static string GRIDLAYOUTFOLDER = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), String.Format(@"{0}\GridLayout", SYSTEMNAME));

        /// <summary>
        /// Assembly를 Download 할 URL(Web Server)
        /// VALUE : "http://61.83.27.100/WebService/Assembly"
        /// </summary>
        public const string ASSEMBLYDOWNLOADURL = "http://61.83.27.100/WebService/Assembly";

        /// <summary>
        /// Xml File의 저장 Path
        /// VALUE : Path.Combine(ASSEMBLYFOLDER, "AssemblyDownloadList.xml")
        /// </summary>
        public static string ASSEMBLYXMLFILEPATH = Path.Combine(ASSEMBLYFOLDER, "AssemblyDownloadList.xml");

        /// <summary>
        /// Locale Master의 저장 Path
        /// VALUE : Path.Combine(ASSEMBLYFOLDER, "LocaleMaster.xml")
        /// </summary>
        public static string LOCALEXMLPATH = Path.Combine(ASSEMBLYFOLDER, "LocaleMaster.xml");

        /// <summary>
        /// Locale Message Master의 저장 Path
        /// VALUE : Path.Combine(ASSEMBLYFOLDER, "MessageMaster.xml")
        /// </summary>
        public static string MESSAGEXMLPATH = Path.Combine(ASSEMBLYFOLDER, "MessageMaster.xml"); 

        #endregion

        #region :: DEFAULTDATEFORMAT :: 시스템에서 사용할 기본 Date Format입니다.

        /// <summary>
        /// 시스템에서 사용할 기본 Date Format입니다.
        /// VALUE : AppConfig.DEFAULTDATEFORMAT
        /// </summary>
        public static string DEFAULTDATEFORMAT = "yyyy-MM-dd HH:mm:ss";

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Webservice Parameter 관련
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: Command Type :: StoredProcedure, Text

        /// <summary>
        /// Sql Command에 StoredProcedure를 사용합니다.
        /// Value : "StoredProcedure"
        /// </summary>
        public const string COMMANDSP = "StoredProcedure";
        /// <summary>
        /// Sql Command에 Text를 사용합니다.
        /// Value : "Text"
        /// </summary>
        public const string COMMANDTEXT = "Text";

        #endregion

        #region :: Database Name :: Web.config 의 ConnectionString과 Mapping 할 정보입니다.
        
        /// <summary>
        /// 기준정보 Database를 사용합니다.
        /// Value : "MESDB"
        /// </summary>
        public const string MESDB = "MESDB";
        /// <summary>
        /// 치공구 3차개발 Database를 사용합니다.
        /// Value : "MESDB"
        /// </summary>
        public const string MESDB3 = "MESDB3";
        /// <summary>
        /// 치공구 Database를 사용합니다.
        /// Value : "JIGDB"
        /// </summary>
        public const string JIGDB = "TLF_DataDB";
        /// <summary>
        /// 치공구 3차개발 Database를 사용합니다.
        /// Value : "JIGDB3"
        /// </summary>
        public const string JIGDB3 = "JIGDB3";
        /// <summary>
        /// 부산 치공구 Database를 사용합니다.
        /// Value : "PUSANJIGDB"
        /// </summary>
        public const string LFMES = "LFMES";
        /// <summary>
        /// SCALE Database를 사용합니다.
        /// Value : "SCLDB"
        /// </summary>
        public const string SCLDB = "SCLDB";

        /// <summary>
        /// 이물분석 Database를 사용합니다.
        /// Value : "ASSAY"
        /// </summary>
        public const string ASSAY = "ASSAY";
        /// <summary>
        /// 제조WorkPlace Database를 사용합니다.
        /// Value : "MESDB_RPT"
        /// </summary>
        public const string MESDB_RPT = "MESDB_RPT";
        /// <summary>
        /// FILE 저장 Database를 사용합니다.
        /// Value : "FILEDB"
        /// </summary>
        public const string FILEDB = "FILEDB";
        /// <summary>
        /// AOI 불석데이터 Database를 사용합니다.
        /// Value : "AOIDB"
        /// </summary>
        public const string AOIDB = "AOIDB";
        /// <summary>
        /// 헬프데스크 Database를 사용합니다.
        /// Value : "HelpDeskDB"
        /// </summary>
        public const string HelpDeskDB = "HelpDeskDB";
        /// <summary>
        /// SMS / AI Database를 사용합니다.
        /// Value : "AIDB"
        /// </summary>
        public const string AIDB = "MESAI";
        /// <summary>
        /// SPC Database를 사용합니다.
        /// Value : "SPCDB"
        /// </summary>
        public const string SPCDB = "SPCDB";
        /// <summary>
        /// Scheduler Database를 사용합니다.
        /// Value : "SCHEDULERDB"
        /// </summary>
        public const string SCHEDULERDB = "SCHEDULERDB";
        /// <summary>
        /// Tavis DB를 사용합니다.
        /// Value : "TAVISDB"
        /// </summary>
        public const string TAVISDB = "TAVISDB";
        /// <summary>
        /// WMS Database를 사용합니다.
        /// Value : "WMSDB"
        /// </summary>
        public const string WMSDB = "WMSDB";
        /// <summary>
        /// 부산 WMS Database를 사용합니다.
        /// Value : "PUSANWMSDB"
        /// </summary>
        public const string PUSANWMSDB = "PUSANWMSDB";


        public const string DEVTEST = "Devtest";

        /// <summary>
        /// 기본적으로 사용할 Database입니다.
        /// Value : MESDB
        /// </summary>
        public static string DEFAULTDB = MESDB;
        /// <summary>
        /// 기준정보에서 사용할 Database 입니다.
        /// Value : MESDB
        /// </summary>
        public static string DEFAULTMESDB = MESDB;
        /// <summary>
        /// MES에서 사용할 Database 입니다.
        /// Value : MESDB
        /// </summary>

        public static string DEFAULTJIGDB = JIGDB;
        /// <summary>
        /// 이물분석 시스템에서 사용할 Database입니다.
        /// Value : ASSAY
        /// </summary>
        public static string DEFAULTASSAY = ASSAY;
        /// <summary>
        /// 제조 WorkPlace에서 사용할 Database입니다.
        /// Value : MESDB_RPT
        /// </summary>
        public static string DEFAULTWORKPLACE = MESDB_RPT;
        /// <summary>
        /// FILE을 저장할 DB에서 사용할 Database입니다.
        /// Value : FILEDB
        /// </summary>
        public static string DEFAULTFILEDB = FILEDB;
        /// <summary>
        /// Scale 관리 시스템에서 사용할 Database입니다.
        /// </summary>
        public static string DEFAULTSCLDB = SCLDB;
        /// <summary>
        /// AOI 분석 데이터 시스템에서 사용할 Database 입니다.
        /// </summary>
        public static string DEFAULTAOIDB = AOIDB;
        /// <summary>
        /// HelpDesk 조회단 시스템에서 사용할 Database 입니다.
        /// </summary>
        public static string DEFAULTHELPDESKDB = HelpDeskDB;
        /// <summary>
        /// SPC 시스템에서 사용할 Database 입니다.
        /// </summary>
        public static string DEFAULTSPCDB = SPCDB;
        /// <summary>
        /// SMS / AI Database를 사용합니다.
        /// Value : "MESAI"
        /// </summary>
        public static string DEFAULTAIDB = AIDB;
        /// <summary>
        /// Scheduler Database를 사용합니다.
        /// Value : "SCHEDULERDB"
        /// </summary>
        public static string DEFAULTSCHEDULEDB = SCHEDULERDB;
        /// <summary>
        /// Tavis DB를 사용합니다.
        /// Value : "TAVISDB"
        /// </summary>
        public static string DEFAULTTAVISDB = TAVISDB;
        /// <summary>
        /// WMS Database를 사용합니다.
        /// Value : "WMSDB"
        /// </summary>
        public static string DEFAULTWMSDB = WMSDB;
        #endregion

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Font 및 Color, Width, Height
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: Font And Color, Width, Height ::

        /// <summary>
        /// 
        /// </summary>
        public static readonly Color CONDITIONCOLOR = Color.FromArgb(50, 228, 150, 181);
                
        /// <summary>
        /// ComboBox 에서 사용할 ValueMember
        /// Value : "CodeValue"
        /// </summary>
        public const string VALUEMEMBER = "CodeValue";
        
        /// <summary>
        /// ComboBox 에서 사용할 DisplayMember
        /// Value : "DisplayValue"
        /// </summary>
        public const string DISPLAYMEMBER = "DisplayValue";
        /// <summary>
        /// 기간표시 컬러
        /// </summary>
        public static readonly Color PERIODCOLOR = Color.DarkSalmon;

        #endregion
    }
}

namespace TLF.Framework.Config
{
    public class AppConfig
    {
    }
}