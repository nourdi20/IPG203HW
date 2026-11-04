using System;
using System.Collections.Generic;
using ApplianceMaintenanceSystem.Models;
namespace ApplianceMaintenanceSystem.Models
{
    public class WashingMachine : Appliance
    {
        // Additional properties specific to a washing machine
        public int CapacityKg { get; set; }
        public bool IsFullyAutomatic { get; set; }

        // Constructor - لاحظ كيف قمنا بإضافة brand و model هنا لكي يراها الـ base
        public WashingMachine(string serialNumber, string brand, string model, int capacityKg, bool isFullyAutomatic)
            : base(serialNumber, brand, model)
        {
            CapacityKg = capacityKg;
            IsFullyAutomatic = isFullyAutomatic;
        }

        // Override the abstract method to calculate repair cost specifically for a washing machine
        public override decimal CalculateRepairCost()
        {
            decimal baseCost = 50.0m;
            decimal capacityFee = CapacityKg * 5.0m;
            decimal typeFee = IsFullyAutomatic ? 30.0m : 15.0m;

            return baseCost + capacityFee + typeFee;
        }

        public override string GetDeviceInfo()
        {
            return base.GetDeviceInfo() +
                   $", Capacity: {CapacityKg}kg, " +
                   $"Automatic: {IsFullyAutomatic}";
        }
    }
}

