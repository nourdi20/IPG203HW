using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Text.RegularExpressions;

namespace ApplianceMaintenanceSystem.Models
{
    public static class ValidationHelper
    {
        // Static property to keep track of total appliances registered in the system
        public static int TotalApplianceCount { get; set; } = 0;

        // Static method to validate serial number (e.g., must be alphanumeric and at least 5 characters)
        public static bool IsValidSerialNumber(string serialNumber)
        {
            if (string.IsNullOrWhiteSpace(serialNumber))
                return false;

            // Simple pattern: letters and numbers, length between 5 and 15
            return Regex.IsMatch(serialNumber.Trim(), @"^[a-zA-Z0-9]{5,15}$");
        }

        // Static method to validate date (ensures date is not in the future or unreasonably old)
        public static bool IsValidDate(DateTime date)
        {
            DateTime today = DateTime.Now;
            return date <= today && date >= today.AddYears(-10);
        }
    }
}