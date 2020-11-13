

namespace TLF.Framework.ControlLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public class AdvPBandedGridInfoRegistrator : DevExpress.XtraGrid.Registrator.AdvBandedGridInfoRegistrator
    {
        /// <summary>
        /// 
        /// </summary>
        public AdvPBandedGridInfoRegistrator()
        {
            
        }


        #region :: ViewName :: 기본 GridView의 이름을 설정합니다.

        /// <summary>
        /// 기본 GridView의 이름을 설정합니다.
        /// </summary>
        public override string ViewName
        {
            get { return "AdvPBandedGridView"; }
        }

        #endregion

        #region :: CreateView :: 기본 GridView를 생성합니다.


        /// <summary>
        /// 기본 BandedGridView를 생성합니다.
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public override DevExpress.XtraGrid.Views.Base.BaseView CreateView(DevExpress.XtraGrid.GridControl grid)
        {
            return new AdvPBandedGridView(grid);
        }

        #endregion

        #region :: CreateViewInfo :: GridView를 생성합니다.

        /// <summary>
        /// BandedGridView를 생성합니다.
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        public override DevExpress.XtraGrid.Views.Base.ViewInfo.BaseViewInfo CreateViewInfo(DevExpress.XtraGrid.Views.Base.BaseView view)
        {
            return new AdvPBandedGridViewInfo(view as AdvPBandedGridView);
        }

        #endregion

        #region :: CreateHandler :: GridHandler를 생성합니다.

        /// <summary>
        /// GridHandler를 생성합니다.
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        public override DevExpress.XtraGrid.Views.Base.Handler.BaseViewHandler CreateHandler(DevExpress.XtraGrid.Views.Base.BaseView view)
        {
            return new AdvPBandedGridHandler(view as AdvPBandedGridView);
        }

        #endregion
    }
}
