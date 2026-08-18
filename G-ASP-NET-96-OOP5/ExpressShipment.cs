using System;

namespace G_ASP_NET_96_OOP3
{
    public class ExpressShipment : Shipment, ITrackable, IInsurable
    {
        private decimal _extraFee;

        public decimal ExtraFee
        {
            get
            {
                return _extraFee;
            }

            set
            {
                if (value < 0)
                    throw new ArgumentException(
                        "ExtraFee must be greater than or equal to 0");

                _extraFee = value;
            }
        }

        // =========================================
        // Estimated Cost
        // =========================================

        // Express:
        // DeliveryFee + (Weight × 5) + ExtraFee

        public override decimal EstimatedCost
        {
            get
            {
                return DeliveryFee + ((decimal)Weight * 5) + ExtraFee;
            }
        }

        // =========================================
        // Constructor
        // =========================================

        public ExpressShipment(
            string trackingCode,
            string description,
            DeliveryAddress deliveryAddress,
            double weight,
            decimal deliveryFee,
            decimal extraFee)
            : base(
                trackingCode,
                description,
                weight,
                deliveryFee,
                deliveryAddress)
        {
            ExtraFee = extraFee;
        }

        // =========================================
        // Constructor Overload
        // =========================================

        public ExpressShipment(
            string trackingCode,
            string description,
            string street,
            string city,
            int buildingNumber,
            double weight,
            decimal deliveryFee,
            decimal extraFee)
            : base(
                trackingCode,
                description,
                weight,
                deliveryFee,
                street,
                city,
                buildingNumber)
        {
            ExtraFee = extraFee;
        }

        // =========================================
        // Print Shipment
        // =========================================

        public override void PrintShipment()
        {
            Console.WriteLine($"Tracking Code: {TrackingCode}");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"Weight: {Weight}");
            Console.WriteLine($"Delivery Fee: {DeliveryFee}");
            Console.WriteLine($"Extra Fee: {ExtraFee}");
            Console.WriteLine($"Destination: {Destination.GetFullAddress()}");
            Console.WriteLine($"Estimated Cost: {EstimatedCost}");
            Console.WriteLine($"Tracking Status: {GetTrackingStatus()}");
        }

        // =========================================
        // ITrackable
        // =========================================

        // Tracking is now handled by Shipment.Tracking.cs
        // so we do not need another GetTrackingStatus() here.

        // =========================================
        // IInsurable
        // =========================================

        // 8% of EstimatedCost
        public decimal CalculateInsurance()
        {
            return EstimatedCost * 0.08m;
        }

        // =========================================
        // Default Constructor
        // =========================================

        public ExpressShipment() : base()
        {
        }

        // =========================================
        // ToString
        // =========================================

        public override string ToString()
        {
            return base.ToString()
                   + $"\nExtra Fee: {ExtraFee:C}"
                   + $"\nTracking Status: {GetTrackingStatus()}";
        }
    }
}