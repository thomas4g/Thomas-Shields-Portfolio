using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DateStuff
/// </summary>
public class DateStuff
{
	public static string plural(double num, string type)
	{
		return num + " " + (num > 1 ? type + "s" : type);
	}
	public static string getTimeSpan(DateTime postDate)
	{
		string stringy = "";
		TimeSpan diff = DateTime.Now.Subtract(postDate);
		double years = Math.Floor(diff.TotalDays / 365);
		double weeks = Math.Floor(diff.TotalDays / 7);
		double days = Math.Floor(diff.TotalDays);
		double hours = Math.Floor(diff.TotalHours);
		double minutes = Math.Floor(diff.TotalMinutes);
		if (minutes <= 1) {
			return "A few seconds ago";
		} 
		else if (years >= 1) {
			return plural(years, "year") + " ago";
		} 
		else if (weeks >= 1) {
			if ((days % 7 ) > 0) {
				stringy = ", " + plural(days % 7, "day");
			}
			return plural(weeks, "week") + stringy + " ago";
		} 
		else if (days >= 1) {
			if ((hours%24) > 0) {
				stringy = ", " + plural(hours % 24, "hour");
			}
			return plural(days, "day") + stringy + " ago";
		} 
		else if (hours >= 1) {
			if ((minutes%60) > 0) {
				stringy = ", " + plural(minutes%60, "minute");
			}
			return plural(hours, "hour") + stringy + " ago";
		} 
		else {
			return minutes.ToString() + " minutes ago";
		}
	}
}
	
