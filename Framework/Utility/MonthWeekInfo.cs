using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TLF.Framework.Utility
{
	public class MonthWeekInfo
	{
		public DateTime curDateTime;
		public DateTime WeekStartDate;
		public DateTime WeekEndDate;
		public int WeekNumber;


		/// <summary>
		/// 년도 4자리와 월 2자리와 원하는 주차 입력
		/// </summary>
		/// <param name="pYear"></param>
		/// <param name="pMonth"></param>
		/// <param name="pWeekNo"></param>
		public MonthWeekInfo(string pYear, string pMonth, string pWeekNo)
		{
			WeekNumber = Convert.ToInt16(pWeekNo);

			int mYear = Convert.ToInt16(pYear);
			int mMonth = Convert.ToInt16(pMonth);

			curDateTime = new DateTime(mYear, mMonth, 1);
			initDate();
		}

		private void initDate()
		{
			int intDayStartNumber = 0;
			DateTime MonthEndDate;

			switch (curDateTime.DayOfWeek)
			{
				case DayOfWeek.Sunday:
					intDayStartNumber = 1;
					break;
				case DayOfWeek.Monday:
					intDayStartNumber = 2;
					break;
				case DayOfWeek.Tuesday:
					intDayStartNumber = 3;
					break;
				case DayOfWeek.Wednesday:
					intDayStartNumber = 4;
					break;
				case DayOfWeek.Thursday:
					intDayStartNumber = 5;
					break;
				case DayOfWeek.Friday:
					intDayStartNumber = 6;
					break;
				case DayOfWeek.Saturday:
					intDayStartNumber = 7;
					break;
			}

			if (WeekNumber == 1)
			{
				this.WeekStartDate = this.curDateTime;
				if (this.WeekStartDate.DayOfWeek == DayOfWeek.Sunday) this.WeekStartDate = this.WeekStartDate.AddDays(1);
			}
			else
			{
				this.WeekStartDate = this.curDateTime.AddDays((WeekNumber * 7) - (intDayStartNumber + 4));
			}

			this.WeekEndDate = this.WeekStartDate.AddDays(5);
			if (this.WeekStartDate.Month != this.WeekEndDate.Month)
			{
				this.WeekEndDate = new DateTime(this.WeekEndDate.Year, this.WeekEndDate.Month, 1);
				this.WeekEndDate = this.WeekEndDate.AddDays(-1);
				if (this.WeekEndDate.DayOfWeek == DayOfWeek.Sunday) this.WeekEndDate = this.WeekEndDate.AddDays(-1);
			}

			MonthEndDate = new DateTime(this.curDateTime.Year, this.curDateTime.Month + 1, 1);
			MonthEndDate = MonthEndDate.AddDays(-1);
			if (MonthEndDate.DayOfWeek == DayOfWeek.Sunday) MonthEndDate = MonthEndDate.AddDays(-1);
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
