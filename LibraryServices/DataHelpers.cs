﻿using System;
using System.Collections.Generic;
using System.Text;
using LibraryData.Models;

namespace LibraryServices
{
    class DataHelpers
    {
        public static IEnumerable<string> HumanizeBusinessHours(IEnumerable<BranchHours> branchHours)
        {
            var hours = new List<string>();

            foreach (var time in branchHours)
            {
                var day = HumanizeDay(time.DayOfWeek);
                var openTime = HumanizeTime(time.OpenTime);
                var closeTime = HumanizeTime(time.CloseTime);

                var timeEntry = $"{day} {openTime} {closeTime}";
                hours.Add(timeEntry);
            }
            return hours;
        }

        public static string HumanizeDay(int number)
        {
            // data maps 1 to Sunday
            return Enum.GetName(typeof(DayOfWeek), number-1);
        }

        public static string HumanizeTime(int time)
        {
            return TimeSpan.FromHours(time).ToString("hh':'mm");
        }
    }
}
