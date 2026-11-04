using System;
using System.Collections.Generic;
using ApplianceMaintenanceSystem.Models;
namespace ApplianceMaintenanceSystem.Models
{
    public class Refrigerator : Appliance
    {
        // Additional properties specific to a refrigerator
        public int CapacityLititers { get; set; }
        public bool HasFreezer { get; set; }

        // Constructor
        public Refrigerator(string serialNumber, string brand, string model, int capacityLititers, bool hasFreezer)
            : base(serialNumber, brand, model)
        {
            CapacityLititers = capacityLititers;
            HasFreezer = hasFreezer;
        }

        // Override the abstract method to calculate repair cost specifically for a refrigerator
        public override decimal CalculateRepairCost()
        {
            decimal baseCost = 60.0m;
            decimal capacityFee = CapacityLititers * 0.1m;
            decimal freezerFee = HasFreezer ? 40.0m : 0.0m;

            return baseCost + capacityFee + freezerFee;
        }

        public override string GetDeviceInfo()
        {
            return base.GetDeviceInfo() +
                   $", Capacity: {CapacityLititers}L, " +
                   $"Has Freezer: {HasFreezer}";
        }
    }
}