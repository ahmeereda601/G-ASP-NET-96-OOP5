using System;

namespace G_ASP_NET_96_OOP3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Part 01 - Theory

            // Q1 - Abstraction
            // Abstract is a class that cannot be instantiated directly.
            // It is used as a base class for other classes.

            // Q2 - Abstract Class vs Interface
            // An abstract class can contain fields, constructors,
            // concrete methods and abstract methods.
            // An interface defines a contract that classes can implement.
            // A class can inherit from only one class,
            // but it can implement multiple interfaces.

            #endregion


            #region Part 02 - Practical

            // ==========================================
            // 1. System Title
            // ==========================================

            DeliveryUtilities.PrintSystemTitle();


            // ==========================================
            // 2. Create Driver
            // ==========================================

            Console.Write("Enter Driver ID: ");
            int driverId = int.Parse(Console.ReadLine());

            Console.Write("Enter Driver Name: ");
            string driverName = Console.ReadLine();

            Console.Write("Enter Driver Phone: ");
            string driverPhone = Console.ReadLine();

            Driver driver =
                new Driver(driverId, driverName, driverPhone);


            // ==========================================
            // 3. Create Delivery Center
            // ==========================================

            Console.Write("Enter Center Name: ");
            string centerName = Console.ReadLine();

            DeliveryCenter center =
                new DeliveryCenter(centerName);

            // Aggregation
            center.Driver = driver;


            // ==========================================
            // 4. Standard Shipment
            // ==========================================

            DeliveryUtilities.PrintSeparator();

            Console.WriteLine("Enter Standard Shipment");

            DeliveryUtilities.PrintSeparator();

            Console.Write("Tracking Code: ");
            string trackingCode1 = Console.ReadLine();

            Console.Write("Description: ");
            string description1 = Console.ReadLine();

            Console.Write("Weight: ");
            double weight1 = double.Parse(Console.ReadLine());

            Console.Write("Delivery Fee: ");
            decimal fee1 = decimal.Parse(Console.ReadLine());

            Console.Write("City: ");
            string city1 = Console.ReadLine();

            Console.Write("Street: ");
            string street1 = Console.ReadLine();

            Console.Write("Building Number: ");
            int building1 = int.Parse(Console.ReadLine());

            StandardShipment standard =
                new StandardShipment(
                    trackingCode1,
                    description1,
                    street1,
                    city1,
                    building1,
                    weight1,
                    fee1);


            // ==========================================
            // 5. Express Shipment
            // ==========================================

            DeliveryUtilities.PrintSeparator();

            Console.WriteLine("Enter Express Shipment");

            DeliveryUtilities.PrintSeparator();

            Console.Write("Tracking Code: ");
            string trackingCode2 = Console.ReadLine();

            Console.Write("Description: ");
            string description2 = Console.ReadLine();

            Console.Write("Weight: ");
            double weight2 = double.Parse(Console.ReadLine());

            Console.Write("Delivery Fee: ");
            decimal fee2 = decimal.Parse(Console.ReadLine());

            Console.Write("Extra Fee: ");
            decimal extraFee = decimal.Parse(Console.ReadLine());

            Console.Write("City: ");
            string city2 = Console.ReadLine();

            Console.Write("Street: ");
            string street2 = Console.ReadLine();

            Console.Write("Building Number: ");
            int building2 = int.Parse(Console.ReadLine());

            ExpressShipment express =
                new ExpressShipment(
                    trackingCode2,
                    description2,
                    street2,
                    city2,
                    building2,
                    weight2,
                    fee2,
                    extraFee);


            // ==========================================
            // 6. International Shipment
            // ==========================================

            DeliveryUtilities.PrintSeparator();

            Console.WriteLine("Enter International Shipment");

            DeliveryUtilities.PrintSeparator();

            Console.Write("Tracking Code: ");
            string trackingCode3 = Console.ReadLine();

            Console.Write("Description: ");
            string description3 = Console.ReadLine();

            Console.Write("Weight: ");
            double weight3 = double.Parse(Console.ReadLine());

            Console.Write("Delivery Fee: ");
            decimal fee3 = decimal.Parse(Console.ReadLine());

            Console.Write("Destination Country: ");
            string country = Console.ReadLine();

            Console.Write("Customs Fee: ");
            decimal customsFee = decimal.Parse(Console.ReadLine());

            Console.Write("City: ");
            string city3 = Console.ReadLine();

            Console.Write("Street: ");
            string street3 = Console.ReadLine();

            Console.Write("Building Number: ");
            int building3 = int.Parse(Console.ReadLine());

            InternationalShipment international =
                new InternationalShipment(
                    trackingCode3,
                    description3,
                    street3,
                    city3,
                    building3,
                    weight3,
                    fee3,
                    country,
                    customsFee);


            // ==========================================
            // 7. Add Shipments
            // ==========================================

            center.AddShipment(standard);
            center.AddShipment(express);
            center.AddShipment(international);


            // ==========================================
            // 8. Print All Shipments
            // ==========================================

            Console.WriteLine();

            Console.WriteLine("Driver : " + center.Driver.FullName);

            center.PrintAllShipments();

            center.PrintTrackingStatuses();


            // ==========================================
            // 9. Insurance
            // ==========================================

            Console.WriteLine("\n--- Insurance Costs ---");

            if (standard is IInsurable s1)
                center.PrintInsurance(s1);

            if (express is IInsurable s2)
                center.PrintInsurance(s2);

            if (international is IInsurable s3)
                center.PrintInsurance(s3);


            // ==========================================
            // 10. DeliveryHelper
            // ==========================================

            Console.WriteLine("\nPrinting Using DeliveryHelper...");

            DeliveryHelper.PrintShipmentDetails(standard);
            DeliveryHelper.PrintShipmentDetails(express);
            DeliveryHelper.PrintShipmentDetails(international);


            // ==========================================
            // 11. Method Overloading
            // ==========================================

            Console.WriteLine("\nUpdating Weight...");

            Console.WriteLine(
                $"Original Weight : {standard.Weight} KG");

            standard.UpdateWeight(5);

            Console.WriteLine(
                $"Updated Weight : {standard.Weight} KG");

            standard.UpdateWeight(5, 0.5);

            Console.WriteLine(
                $"Updated Weight After Packing : {standard.Weight} KG");


            // ==========================================
            // 12. Shipment[] - Dynamic Binding
            // ==========================================

            Console.WriteLine();

            DeliveryUtilities.PrintSeparator();

            Console.WriteLine("Printing Using Shipment[]...");

            DeliveryUtilities.PrintSeparator();

            Shipment[] shipments =
            {
                standard,
                express,
                international
            };

            foreach (Shipment shipment in shipments)
            {
                shipment.PrintShipment();

                Console.WriteLine("---");
            }


            // ==========================================
            // 13. ITrackable[]
            // ==========================================

            ITrackable[] trackables =
            {
                standard,
                express,
                international
            };

            Console.WriteLine("\n--- ITrackable Array Statuses ---");

            foreach (ITrackable trackable in trackables)
            {
                Console.WriteLine(
                    trackable.GetTrackingStatus());
            }


            // ==========================================
            // 14. IInsurable[]
            // ==========================================

            IInsurable[] insurables =
            {
                standard,
                express,
                international
            };

            Console.WriteLine(
                "\n--- IInsurable Array Insurance Values ---");

            foreach (IInsurable insurable in insurables)
            {
                Console.WriteLine(
                    $"Insurance: {insurable.CalculateInsurance():C}");
            }


            // ==========================================
            // 15. Sealed Method
            // ==========================================

            PriorityInternationalShipment priority =
                new PriorityInternationalShipment(
                    "SH004",
                    "Documents",
                    street3,
                    city3,
                    building3,
                    2,
                    100,
                    "France",
                    50);

            priority.GenerateCustomsReport();


            // ==========================================
            // 16. Sealed Class
            // ==========================================

            // CompletedShipment is sealed.
            // So this is NOT allowed:

            // class TestShipment : CompletedShipment
            // {
            // }


            // =====================================================
            // Assignment 05
            // Object Copying
            // =====================================================

            DeliveryUtilities.PrintSeparator();

            Console.WriteLine("Assignment 05 - Object Copying");

            DeliveryUtilities.PrintSeparator();


            // =========================================
            // 17. Reference Assignment
            // ==========================================

            Console.WriteLine("\n--- Reference Assignment ---");

            Shipment shipment1 = standard;

            Shipment shipment2 = shipment1;

            Console.WriteLine(
                $"shipment1 == shipment2 : {shipment1 == shipment2}");

            Console.WriteLine(
                "Reference assignment does NOT create a new object.");

            Console.WriteLine(
                $"Tracking Code : {shipment2.TrackingCode}");


            // ==========================================
            // 18. Actual Copy
            // ==========================================

            Console.WriteLine("\n--- Actual Object Copy ---");

            Shipment copiedShipment =
                shipment1.CopyShipment();

            Console.WriteLine(
                $"shipment1 == copiedShipment : " +
                $"{shipment1 == copiedShipment}");

            Console.WriteLine(
                "The copied shipment is a different object.");


            // ==========================================
            // 19. Shallow Copy
            // ==========================================

            Console.WriteLine("\n--- Shallow Copy ---");

            Shipment shallowCopy =
                shipment1.ShallowCopy();

            Console.WriteLine(
                $"Same Shipment Object? " +
                $"{shipment1 == shallowCopy}");

            Console.WriteLine(
                $"Same DeliveryAddress Object? {ReferenceEquals(shipment1.Destination, shallowCopy.Destination)}");


            Console.WriteLine(
                $"\nOriginal Address Before Change: " +
                $"{shipment1.Destination.City}");

            Console.WriteLine(
                $"Copied Address Before Change: " +
                $"{shallowCopy.Destination.City}");


            // Change address through shallow copy
            shallowCopy.Destination.City = "Giza";


            Console.WriteLine(
                "\nAfter changing copied address:");

            Console.WriteLine(
                $"Original Address: " +
                $"{shipment1.Destination.City}");

            Console.WriteLine(
                $"Copied Address: " +
                $"{shallowCopy.Destination.City}");


            // ==========================================
            // 20. Deep Copy
            // ==========================================

            Console.WriteLine("\n--- Deep Copy ---");

            // Restore original address first
            shipment1.Destination.City = "Cairo";

            Shipment deepCopy =
                shipment1.DeepCopy();

            Console.WriteLine(
                $"Same Shipment Object? " +
                $"{shipment1 == deepCopy}");

            Console.WriteLine(
                $"Same DeliveryAddress Object? {ReferenceEquals(shipment1.Destination, deepCopy.Destination)}");


            Console.WriteLine(
                $"\nOriginal Address Before Change: " +
                $"{shipment1.Destination.City}");

            Console.WriteLine(
                $"Copied Address Before Change: " +
                $"{deepCopy.Destination.City}");


            // Change address through deep copy
            deepCopy.Destination.City = "Giza";


            Console.WriteLine(
                "\nAfter changing copied address:");

            Console.WriteLine(
                $"Original Address: " +
                $"{shipment1.Destination.City}");

            Console.WriteLine(
                $"Copied Address: " +
                $"{deepCopy.Destination.City}");


            // ==========================================
            // 21. Static Members
            // ==========================================

            Console.WriteLine("\n--- Static Members ---");

            Console.WriteLine(
                $"Total Shipments Created : " +
                $"{Shipment.GetTotalShipmentsCreated()}");


            // ==========================================
            // 22. Extension Methods
            // ==========================================

            Console.WriteLine("\n--- Extension Methods ---");

            // Change status to demonstrate Partial Method
            shipment1.UpdateTrackingStatus("Out For Delivery");

            Console.WriteLine(
                $"Summary: {shipment1.GetSummary()}");

            Console.WriteLine(
                $"Is Delivered? {shipment1.IsDelivered()}");


            // Demonstrate Delivered status
            shipment1.UpdateTrackingStatus("Delivered");

            Console.WriteLine(
                $"Summary: {shipment1.GetSummary()}");

            Console.WriteLine(
                $"Is Delivered? {shipment1.IsDelivered()}");


            // ==========================================
            // 23. Partial Method
            // ==========================================

            Console.WriteLine(
                "\nPartial Method demonstration completed.");

            Console.WriteLine(
                "The tracking status changed message " +
                "is generated from the partial method.");


            // ==========================================
            // 24. Final Static Counter
            // ==========================================

            DeliveryUtilities.PrintSeparator();

            Console.WriteLine(
                $"Final Total Shipments Created : " +
                $"{Shipment.GetTotalShipmentsCreated()}");

            DeliveryUtilities.PrintSeparator();


            Console.WriteLine("\nProgram is Finished");

            #endregion
        }
    }
}