using System;

namespace G_ASP_NET_96_OOP3
{
    public class PriorityInternationalShipment : InternationalShipment
    {
        public PriorityInternationalShipment(
            string trackingCode,
            string description,
            DeliveryAddress deliveryAddress,
            double weight,
            decimal deliveryFee,
            string destinationCountry,
            decimal customsFee)
            : base(
                trackingCode,
                description,
                deliveryAddress,
                weight,
                deliveryFee,
                destinationCountry,
                customsFee)
        {
        }

        public PriorityInternationalShipment() : base()
        {
        }

        // Overload: accept address components
        public PriorityInternationalShipment(
            string trackingCode,
            string description,
            string street,
            string city,
            int buildingNumber,
            double weight,
            decimal deliveryFee,
            string destinationCountry,
            decimal customsFee)
            : base(
                trackingCode,
                description,
                street,
                city,
                buildingNumber,
                weight,
                deliveryFee,
                destinationCountry,
                customsFee)
        {
        }

        public sealed override void GenerateCustomsReport()
        {
            Console.WriteLine("Priority International Customs Report");
        }
    }
}