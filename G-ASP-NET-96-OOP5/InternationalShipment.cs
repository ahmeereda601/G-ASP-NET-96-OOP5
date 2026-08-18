using System;

namespace G_ASP_NET_96_OOP3
{
    public class InternationalShipment : Shipment, ITrackable, IInsurable
    {
        private string _destinationCountry;
        private decimal _customsFee;

        // =========================================
        // Destination Country
        // =========================================

        public string DestinationCountry
        {
            get
            {
                return _destinationCountry;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(
                        "DestinationCountry cannot be null, empty, or whitespace");
                }

                _destinationCountry = value;
            }
        }

        // =========================================
        // Customs Fee
        // =========================================

        public decimal CustomsFee
        {
            get
            {
                return _customsFee;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(
                        "CustomsFee must be greater than or equal to 0");
                }

                _customsFee = value;
            }
        }

        // =========================================
        // Estimated Cost
        // =========================================

        // International:
        // DeliveryFee + (Weight × 5) + CustomsFee

        public override decimal EstimatedCost
        {
            get
            {
                return DeliveryFee
                       + ((decimal)Weight * 5)
                       + CustomsFee;
            }
        }

        // =========================================
        // Constructor
        // =========================================

        public InternationalShipment(
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
                weight,
                deliveryFee,
                deliveryAddress)
        {
            DestinationCountry = destinationCountry;
            CustomsFee = customsFee;
        }

        // =========================================
        // Constructor Overload
        // =========================================

        public InternationalShipment(
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
                weight,
                deliveryFee,
                street,
                city,
                buildingNumber)
        {
            DestinationCountry = destinationCountry;
            CustomsFee = customsFee;
        }

        // =========================================
        // Default Constructor
        // =========================================

        public InternationalShipment() : base()
        {
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
            Console.WriteLine($"Destination: {Destination.GetFullAddress()}");
            Console.WriteLine($"Destination Country: {DestinationCountry}");
            Console.WriteLine($"Customs Fee: {CustomsFee}");
            Console.WriteLine($"Estimated Cost: {EstimatedCost}");
            Console.WriteLine($"Tracking Status: {GetTrackingStatus()}");
        }

        // =========================================
        // IInsurable
        // =========================================

        // 12% of EstimatedCost
        public decimal CalculateInsurance()
        {
            return EstimatedCost * 0.12m;
        }

        // =========================================
        // Generate Customs Report
        // =========================================

        public virtual void GenerateCustomsReport()
        {
            Console.WriteLine("International Customs Report");
        }

        // =========================================
        // ToString
        // =========================================

        public override string ToString()
        {
            return base.ToString()
                   + $"\nDestination Country: {DestinationCountry}\n"
                   + $"Customs Fee: {CustomsFee:C}"
                   + $"\nTracking Status: {GetTrackingStatus()}";
        }
    }
}