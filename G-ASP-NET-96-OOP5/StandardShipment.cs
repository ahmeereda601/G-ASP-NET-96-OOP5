using System;

namespace G_ASP_NET_96_OOP3
{
    public class StandardShipment : Shipment, ITrackable, IInsurable
    {
        // =========================================
        // Constructor
        // =========================================

        public StandardShipment(
            string trackingCode,
            string description,
            DeliveryAddress deliveryAddress,
            double weight,
            decimal deliveryFee)
            : base(
                trackingCode,
                description,
                weight,
                deliveryFee,
                deliveryAddress)
        {
        }


        // =========================================
        // Constructor Overload
        // =========================================

        public StandardShipment(
            string trackingCode,
            string description,
            string street,
            string city,
            int buildingNumber,
            double weight,
            decimal deliveryFee)
            : base(
                trackingCode,
                description,
                weight,
                deliveryFee,
                street,
                city,
                buildingNumber)
        {
        }


        // =========================================
        // Estimated Cost
        // =========================================

        // Standard:
        // DeliveryFee + (Weight × 5)

        public override decimal EstimatedCost
        {
            get
            {
                return DeliveryFee +
                       ((decimal)Weight * 5);
            }
        }


        // =========================================
        // Print Shipment
        // =========================================

        public override void PrintShipment()
        {
            Console.WriteLine(
                $"Tracking Code: {TrackingCode}");

            Console.WriteLine(
                $"Description: {Description}");

            Console.WriteLine(
                $"Weight: {Weight}");

            Console.WriteLine(
                $"Delivery Fee: {DeliveryFee}");

            Console.WriteLine(
                $"Destination: {Destination.GetFullAddress()}");

            Console.WriteLine(
                $"Estimated Cost: {EstimatedCost}");

            Console.WriteLine(
                $"Tracking Status: {GetTrackingStatus()}");
        }


        // =========================================
        // IInsurable
        // =========================================

        // Standard Shipment insurance = 5%
        // of EstimatedCost

        public decimal CalculateInsurance()
        {
            return EstimatedCost * 0.05m;
        }
    }
}