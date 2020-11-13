using System;
using System.Collections;

namespace TLF.Framework.Collections
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 2008-12-22 최초생성 :: 황준혁
    /// 변경내역
    /// 
    /// </remarks>
    public class LinkEventParams : DictionaryBase
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Properties
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: Index :: LinkEventParams의 Index를 설정합니다.

        /// <summary>
        /// LinkEventParams의 Index를 설정합니다.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public object this[object key]
        {
            get { return ((object)Dictionary[key]); }
            set { Dictionary[key] = value; }
        }

        #endregion

        #region :: Keys ::  LinkEventParams의 Key를 가져옵니다.

        /// <summary>
        /// LinkEventParams의 Key를 가져옵니다.
        /// </summary>
        public ICollection Keys
        {
            get { return (Dictionary.Keys); }
        }

        #endregion

        #region :: Values :: LinkEventParams의 값을 가져옵니다.

        /// <summary>
        /// LinkEventParams의 값을 가져옵니다.
        /// </summary>
        public ICollection Values
        {
            get { return (Dictionary.Values); }
        }

        #endregion

        #region :: Add :: LinkEventParams의 값을 추가 합니다.

        /// <summary>
        /// LinkEventParams의 값을 추가 합니다.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add(string key, object value)
        {
            if (Contains(key))
                Dictionary[key] = value;
            else
                Dictionary.Add(key, value);
        }

        /// <summary>
        /// LinkEventParams의 값을 추가 합니다.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add(int key, object value)
        {
            if (Contains(key))
                Dictionary[key] = value;
            else
                Dictionary.Add(key, value);
        }

        #endregion

        #region :: Remove :: LinkEventParams의 값을 제거 합니다.

        /// <summary>
        /// LinkEventParams의 값을 제거 합니다.
        /// </summary>
        /// <param name="key"></param>
        public void Remove(string key)
        {
            Dictionary.Remove(key);
        }

        /// <summary>
        /// LinkEventParams의 값을 제거 합니다.
        /// </summary>
        /// <param name="key"></param>
        public void Remove(int key)
        {
            Dictionary.Remove(key);
        }

        #endregion

        #region :: Contains :: LinkEventParams의 값이 있는지 Check 합니다.

        /// <summary>
        /// LinkEventParams의 값이 있는지 Check 합니다.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Contains(string key)
        {
            return (Dictionary.Contains(key));
        }

        /// <summary>
        /// LinkEventParams의 값이 있는지 Check 합니다.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Contains(int key)
        {
            return (Dictionary.Contains(key));
        }

        #endregion
    }
}
