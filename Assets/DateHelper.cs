using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Date
{
    public Date(int day, int month, int year)
    {
        Day = day;
        Month = month;
        Year = year;

        DT = new DateTime(year, month, day);
    }

    public int Day
    { get; private set; }
    public int Month
    { get; private set; }
    public int Year
    { get; private set; }
    public DateTime DT
    {
        get; private set;
    }

    public string PrintDateShort()
    {
        return Month + "/" + Day + "/" + Year;
    }

    public string PrintDateEuro()
    {
        return Day + "/" + Month + "/" + Year;
    }

    public string PrintDateLong()
    {
        return MonthString() + " " + Day + ", " + Year; 
    }

    string MonthString()
    {
        switch(Month)
        {
            case 1:     return "January";
            case 2:     return "February";
            case 3:     return "March";
            case 4:     return "April";
            case 5:     return "May";
            case 6:     return "June";
            case 7:     return "July";
            case 8:     return "August";
            case 9:     return "September";
            case 10:    return "October";
            case 11:    return "November";
            case 12:    return "December";
            default:    return "que?";
        }
    }
}

public static class DateHelper
{
    public static Date GetTodaysDate()
    {
        return new Date(DateTime.Today.Day, DateTime.Today.Month, DateTime.Today.Year);
    }

    public static bool SinceLastCleaning(Date current, Date lastReport)
    {
        return ((current.DT - lastReport.DT).TotalDays < 14);
    }

}
