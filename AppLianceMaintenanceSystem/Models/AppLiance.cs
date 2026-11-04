using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLianceMaintenanceSystem.ApplianceMaintenanceSystem.Models;

namespace ApplianceMaintenanceSystem.Models
{
    // 1. تعريف الـ Delegate 
    public delegate void ApplianceStatusChangedHandler(string serialNumber, string newStatus);

    public abstract class Appliance : IAppliance
    {
        private readonly string _serialNumber;
        private string _brand;
        private string _model;
        private string _maintenanceStatus;

        // 2. تعريف الـ Event باستخدام الـ Delegate
        public event ApplianceStatusChangedHandler StatusChanged;

        public string SerialNumber => _serialNumber;

        public string Brand
        {
            get => _brand;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Brand cannot be empty.");
                _brand = value;
            }
        }

        public string Model
        {
            get => _model;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Model cannot be empty.");
                _model = value;
            }
        }

        public string MaintenanceStatus
        {
            get => _maintenanceStatus;
            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Status cannot be empty.");
                _maintenanceStatus = value;
            }
        }

        protected Appliance (string serialNumber, string brand, string model)
        {
            if (string.IsNullOrWhiteSpace(serialNumber))
                throw new ArgumentException("Serial number cannot be empty.");
            if (string.IsNullOrWhiteSpace(brand))
                throw new ArgumentException("Brand cannot be empty.");
            if (string.IsNullOrWhiteSpace(model))
                throw new ArgumentException("Model cannot be empty.");

            _serialNumber = serialNumber.Trim();
            _brand = brand.Trim();
            _model = model.Trim();
            _maintenanceStatus = "Received";
        }

        public abstract decimal CalculateRepairCost();

        public virtual string GetDeviceInfo()
        {
            return $"Type: {GetType().Name}, Serial Number: {SerialNumber}, Brand: {Brand}, Model: {Model}, Status: {MaintenanceStatus}, Repair Cost: {CalculateRepairCost():0.00}";
        }

        // 3. تحديث الحالة وإطلاق الحدث عند اكتمال الصيانة
        public void UpdateMaintenanceStatus(string newStatus)
        {
            if (string.IsNullOrWhiteSpace(newStatus))
                throw new ArgumentException("Status cannot be empty.");

            _maintenanceStatus = newStatus.Trim();

            // إطلاق الحدث (Event) لإعلام النظام بتغير الحالة
            StatusChanged?.Invoke(_serialNumber, _maintenanceStatus);
        }
    }
}