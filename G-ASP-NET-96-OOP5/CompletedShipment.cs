using System;

namespace G_ASP_NET_96_OOP3
{
    public sealed class CompletedShipment : Shipment
    {
        public CompletedShipment(
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

        public CompletedShipment(
            string trackingCode,
            string description,
            double weight,
            decimal deliveryFee,
            DeliveryAddress deliveryAddress)
            : this(
                trackingCode,
                description,
                deliveryAddress,
                weight,
                deliveryFee)
        {
        }

        public CompletedShipment() : base()
        {
        }

        public override decimal EstimatedCost
        {
            get
            {
                return DeliveryFee + ((decimal)Weight * 5);
            }
        }

        public override void PrintShipment()
        {
            Console.WriteLine($"Tracking Code: {TrackingCode}");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"Weight: {Weight}");
            Console.WriteLine($"Delivery Fee: {DeliveryFee}");
            Console.WriteLine($"Destination: {Destination.GetFullAddress()}");
            Console.WriteLine($"Estimated Cost: {EstimatedCost}");
        }
    }
}