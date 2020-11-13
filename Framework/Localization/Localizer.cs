using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using TLF.Framework.Config;

namespace TLF.Framework.Localization
{
    /// <summary>
    /// System에서 사용할 다국어지원 Class 입니다.
    /// </summary>
    /// <remarks>
    /// 2010-03-15 최초생성 :황준혁
    /// </remarks>
    public class Localizer
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// 다국어지원 Class Instance를 생성합니다.
        /// </summary>
        /// <param name="culture">사용 문화권</param>
        public Localizer(string culture)
        {
            _culture = culture;
        }         

        #endregion

        #region :: 전역변수 ::

        private string _culture = string.Empty;

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Method(Public)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: GetLocalizedString :: StringId로 해당 문화권의 언어를 가져옵니다.

        /// <summary>
        /// StringId로 해당 문화권의 언어를 가져옵니다.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetLocalizedString(StrId id)
        {
            //XmlDocument document = new XmlDocument();
            //document.Load(AppConfig.LOCALEXMLPATH);

            //XmlNodeList nodeList = document.SelectNodes("//Table");

            //foreach (XmlNode node in nodeList)
            //{
            //    if (Convert.ToInt32(id).ToString() != node["StringID"].InnerText)
            //        continue;

            //    return node[_culture].InnerText;
            //}

            return "";
        }

        #endregion

        #region :: GetLocalizedMessage :: MessageId로 해당 문화권의 메시지를 가져옵니다.

        /// <summary>
        /// MessageId로 해당 문화권의 메시지를 가져옵니다.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetLocalizedMessage(MsgId id)
        {
            XmlDocument document = new XmlDocument();
            document.Load(AppConfig.MESSAGEXMLPATH);

            XmlNodeList nodeList = document.SelectNodes("//Table");

            foreach (XmlNode node in nodeList)
            {
                if (Convert.ToInt32(id).ToString() != node["MessageID"].InnerText)
                    continue;

                return node[_culture].InnerText;
            }

            return "";
        }

        #endregion
    }
}
