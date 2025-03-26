using System;

namespace API.Accounts.Extensions;

public static class DateTimeExtensions
{
    public static int CalculateAge(this DateOnly dob)
    {
        var today = DateOnly.FromDateTime(DateTime.Now);

        var age = today.Year - dob.Year;

        if (dob.CompareTo(today.AddYears(-age)) > 0) age--;

        return age;
    }

}
