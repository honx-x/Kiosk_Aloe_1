using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TLF.Framework.Utility
{
	public class WeekInfo
	{
		public DateTime curDateTime;
		public DateTime WeekStartDate;
		public DateTime WeekEndDate;
		public int WeekNumber;

		/// <summary>
		/// 날짜를 당일로 세팅한다. 
		/// WeekInfo wi = new WeekInfo();
		/// wi.getWeekNumber();
		/// wi.getWeekStartDate();
		/// wi.getWeekEndDate();
		/// </summary>
		/// <param name="pCurDate">년월일 8 자리</param>
		public WeekInfo()
		{
			curDateTime = DateTime.Today;

			initDate();
		}

		/// <summary>
		/// 날짜를 DateTime형식으로 세팅한다. 
		/// WeekInfo wi = new WeekInfo();
		/// wi.getWeekNumber();
		/// wi.getWeekStartDate();
		/// wi.getWeekEndDate();
		/// </summary>
		/// <param name="pCurDate">년월일 8 자리</param>
		public WeekInfo(DateTime dtDay)
		{
			curDateTime = dtDay;

			initDate();
		}

		/// <summary>
		/// 날짜를 8자리 문자로 세팅한다. 
		/// WeekInfo wi = new WeekInfo("20040101");
		/// wi.getWeekNumber();
		/// wi.getWeekStartDate();
		/// wi.getWeekEndDate();
		/// </summary>
		/// <param name="pCurDate">년월일 8 자리</param>
		public WeekInfo(string pCurDate)
		{
			int mYear = Convert.ToInt16(pCurDate.Substring(0, 4));
			int mMonth = Convert.ToInt16(pCurDate.Substring(4, 2));
			int mDay = Convert.ToInt16(pCurDate.Substring(6, 2));

			curDateTime = new DateTime(mYear, mMonth, mDay);

			initDate();
		}

		/// <summary>
		/// 년도 4 자리와 년도의 원하는 주차를 입력
		/// WeekInfo wi = new WeekInfo("2004","2"); // 2004 년의 2 주차 
		/// wi.getWeekNumber();
		/// wi.getWeekStartDate();
		/// wi.getWeekEndDate();
		/// </summary>
		/// <param name="pDate">년도 문자 4자리</param>
		/// <param name="pWeekNumber">원하느 주차</param>
		public WeekInfo(string pYear, int pWeekNumber)
		{
			int mYear = Convert.ToInt16(pYear);
			int mMonth = 1;
			int mDay = 1;

			curDateTime = new DateTime(mYear, mMonth, mDay);
			initDate();
			if (pWeekNumber > 1)
			{
				// 재계산
				curDateTime = this.WeekEndDate.AddDays((pWeekNumber - 1) * 7 - 1);
				initDate();
			}
		}
		private void initDate()
		{
			int intDayNumber = curDateTime.DayOfYear;
			int intDayStartNumber = 0;

			switch (curDateTime.DayOfWeek)
			{
				case DayOfWeek.Sunday:
					intDayStartNumber = intDayNumber;
					WeekStartDate = curDateTime;
					WeekEndDate = curDateTime.AddDays(6);
					break;
				case DayOfWeek.Monday:
					intDayStartNumber = intDayNumber - 1;
					WeekStartDate = curDateTime.AddDays(-1);
					WeekEndDate = curDateTime.AddDays(5);
					break;
				case DayOfWeek.Tuesday:
					intDayStartNumber = intDayNumber - 2;
					WeekStartDate = curDateTime.AddDays(-2);
					WeekEndDate = curDateTime.AddDays(4);
					break;
				case DayOfWeek.Wednesday:
					intDayStartNumber = intDayNumber - 3;
					WeekStartDate = curDateTime.AddDays(-3);
					WeekEndDate = curDateTime.AddDays(3);
					break;
				case DayOfWeek.Thursday:
					intDayStartNumber = intDayNumber - 4;
					WeekStartDate = curDateTime.AddDays(-4);
					WeekEndDate = curDateTime.AddDays(2);
					break;
				case DayOfWeek.Friday:
					intDayStartNumber = intDayNumber - 5;
					WeekStartDate = curDateTime.AddDays(-5);
					WeekEndDate = curDateTime.AddDays(1);
					break;
				case DayOfWeek.Saturday:
					intDayStartNumber = intDayNumber - 6;
					WeekStartDate = curDateTime.AddDays(-6);
					WeekEndDate = curDateTime;
					break;
			}

			this.WeekNumber = intDayStartNumber / 7;

			if (WeekStartDate.Year > curDateTime.AddYears(-1).Year)
			{
				this.WeekNumber += 1;

				int intDivideWeekNumber = intDayStartNumber % 7;

				if (intDivideWeekNumber != 0)
					this.WeekNumber += 1;

				if (curDateTime.Year == WeekEndDate.AddYears(-1).Year)
				{
					WeekEndDate = WeekEndDate.AddDays((-1) * WeekEndDate.DayOfYear);
				}
			}
			else
			{
				this.WeekNumber = 1;
				intDayStartNumber = (-1) * intDayStartNumber + 1;
				WeekStartDate = WeekStartDate.AddDays(intDayStartNumber);
			}
		}
		/// <summary>
		/// 주차 정보
		/// </summary>
		/// <returns></returns>
		public int getWeekNumber()
		{
			return this.WeekNumber;
		}

		/// <summary>
		/// 주차의 시작날짜 8 자리(일요일)
		/// </summary>
		/// <returns>20040101</returns>
		public string getWeekStartDate()
		{
			string strDate;
			strDate = setZero(WeekStartDate.Year.ToString(), 4);
			strDate += setZero(WeekStartDate.Month.ToString(), 2);
			strDate += setZero(WeekStartDate.Day.ToString(), 2);
			return strDate;

		}
	
		/// <summary>
		/// 주차의 마지막 날짜 8 자리(토요일)
		/// </summary>
		/// <returns>20040103</returns>
		public string getWeekEndDate()
		{
			string strDate;
			strDate = setZero(WeekEndDate.Year.ToString(), 4);
			strDate += setZero(WeekEndDate.Month.ToString(), 2);
			strDate += setZero(WeekEndDate.Day.ToString(), 2);
			return strDate;
		}
		private string setZero(string pValue, int pCount)
		{
			if (pValue.Length == pCount)
			{
				return pValue;
			}
			else
			{
				return pValue.PadLeft(pCount, '0');
			}
		}
	}
}
