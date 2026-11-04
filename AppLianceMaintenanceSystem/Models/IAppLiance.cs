using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLianceMaintenanceSystem
{
    namespace ApplianceMaintenanceSystem.Models
    {
        public interface IAppliance
        {
            string SerialNumber { get; }

            string GetDeviceInfo();

            decimal CalculateRepairCost();

            void UpdateMaintenanceStatus(string newStatus);
        }
    }
}
