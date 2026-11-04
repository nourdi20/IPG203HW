// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;
using ApplianceMaintenanceSystem.Models;

namespace ApplianceMaintenanceSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== نظام إدارة مركز صيانة وإصلاح الأجهزة المنزلية ===\n");

            // إنشاء قائمة لتخزين الأجهزة (تعدد الأشكال - Polymorphism)
            List<Appliance> appliances = new List<Appliance>();

            try
            {
                // التحقق من صحة الرقم التسلسلي باستخدام الفئة الثابتة ValidationHelper
                string serial1 = "WASH123";
                if (ValidationHelper.IsValidSerialNumber(serial1))
                {
                    WashingMachine wm = new WashingMachine(serial1, "Samsung", "EcoBubble", 8, true);
                    appliances.Add(wm);
                    ValidationHelper.TotalApplianceCount++;
                }

                string serial2 = "REF456";
                if (ValidationHelper.IsValidSerialNumber(serial2))
                {
                    Refrigerator refApp = new Refrigerator(serial2, "LG", "InstaView", 500, true);
                    appliances.Add(refApp);
                    ValidationHelper.TotalApplianceCount++;
                }

                string serial3 = "AC789";
                if (ValidationHelper.IsValidSerialNumber(serial3))
                {
                    AirConditioner ac = new AirConditioner(serial3, "GREE", "Pular", 12000, true);
                    appliances.Add(ac);
                    ValidationHelper.TotalApplianceCount++;
                }

                // الاشتراك بالحدث (Event) لكل جهاز للإشعار عند تغير الحالة
                foreach (var appliance in appliances)
                {
                    appliance.StatusChanged += (sNum, status) =>
                    {
                        Console.WriteLine($"[تنبيه حدث] الجهاز ذو الرقم التسلسلي ({sNum}) تغيرت حالته إلى: {status}");
                    };
                }

                Console.WriteLine($"إجمالي الأجهزة المسجلة في النظام: {ValidationHelper.TotalApplianceCount}\n");

                // عرض معلومات جميع الأجهزة وحساب تكلفة الإصلاح باستخدام تعدد الأشكال
                decimal totalRepairCosts = 0;
                foreach (var appliance in appliances)
                {
                    Console.WriteLine(appliance.GetDeviceInfo());
                    totalRepairCosts += appliance.CalculateRepairCost();
                }

                Console.WriteLine($"\nإجمالي تكاليف الإصلاح لكل الأجهزة: {totalRepairCosts:0.00} ليرة\n");

                // تجربة تحديث حالة أحد الأجهزة واختبار إطلاق الحدث (Event)
                Console.WriteLine("--- تحديث حالات الصيانة ---");
                appliances[0].UpdateMaintenanceStatus("Under Repair");
                appliances[0].UpdateMaintenanceStatus("Completed"); // هنا سيتم إطلاق الحدث تلقائياً

            }
            catch (Exception ex)
            {
                Console.WriteLine($"خطأ: {ex.Message}");
            }

            Console.WriteLine("\nاضغط أي مفتاح للخروج...");
            Console.ReadKey();
        }
    }
}