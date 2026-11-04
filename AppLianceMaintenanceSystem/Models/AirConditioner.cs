using System;
using System.Collections.Generic;
using ApplianceMaintenanceSystem.Models;
namespace ApplianceMaintenanceSystem.Models
{
    public class AirConditioner : Appliance
    {
        // Additional properties specific to an air conditioner
        public int BTU { get; set; }
        public bool IsInverter { get; set; }

        // Constructor
        public AirConditioner(string serialNumber, string brand, string model, int btu, bool isInverter)
            : base(serialNumber, brand, model)
        {
            BTU = btu;
            IsInverter = isInverter;
        }

        // Override the abstract method to calculate repair cost specifically for an air conditioner
        public override decimal CalculateRepairCost()
        {
            decimal baseCost = 70.0m;
            decimal btuFee = BTU * 0.01m;
            decimal inverterFee = IsInverter ? 50.0m : 20.0m;

            return baseCost + btuFee + inverterFee;
        }

        public override string GetDeviceInfo()
        {
            return base.GetDeviceInfo() +
                   $", BTU: {BTU}, " +
                   $"Inverter: {IsInverter}";
        }
    }
}