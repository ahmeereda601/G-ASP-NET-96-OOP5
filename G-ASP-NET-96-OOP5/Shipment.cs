using System;

namespace G_ASP_NET_96_OOP3
{
    /*
     * Shipment is an abstract class.
     * It cannot be instantiated directly.
     * It is used as a base class for different shipment types.
     */
    public abstract partial class Shipment : ITrackable
    {
        // =========================================
        // Fields
        // =========================================

        private string trackingCode;
        private string description;
        private double weight;
        private decimal deliveryFee;

        // Static field shared by all Shipment objects
        private static int TotalShipmentsCreated;

        // Tracking is implemented in a separate partial file (Shipment.Tracking.cs)


        // =========================================
        // Composition
        // =========================================

        // Shipment owns its DeliveryAddress.
        public DeliveryAddress Destination { get; private set; }


        // =========================================
        // Static Constructor
        // =========================================

        static Shipment()
        {
            TotalShipmentsCreated = 0;

            Console.WriteLine("Shipment System Initialized");
        }


        // =========================================
        // Default Constructor
        // =========================================

        public Shipment()
        {
            TotalShipmentsCreated++;

            trackingCode = "";
            description = "";
            weight = 0;
            deliveryFee = 0;

            Destination =
                new DeliveryAddress("Unknown", "Unknown", 0);

            TrackingCode = "";
            Description = "Unknown";
            Weight = 1;
            DeliveryFee = 50;
        }


        // =========================================
        // Constructor - Tracking Code
        // =========================================

        public Shipment(string trackingCode)
        {
            TotalShipmentsCreated++;

            this.trackingCode = "";
            description = "";
            weight = 0;
            deliveryFee = 0;

            Destination =
                new DeliveryAddress("Unknown", "Unknown", 0);

            TrackingCode = trackingCode;
            Description = "Unknown";
            Weight = 1;
            DeliveryFee = 50;
        }


        // =========================================
        // Full Constructor
        // =========================================

        public Shipment(
            string trackingCode,
            string description,
            double weight,
            decimal deliveryFee,
            DeliveryAddress destination)
        {
            TotalShipmentsCreated++;

            this.trackingCode = "";
            this.description = "";
            this.weight = 0;
            this.deliveryFee = 0;

            // Create a new DeliveryAddress
            // because Shipment owns its address.
            Destination =
                new DeliveryAddress(
                    destination.Street,
                    destination.City,
                    destination.ZipCode,
                    destination.Country);

            TrackingCode = trackingCode;
            Description = description;
            Weight = weight;
            DeliveryFee = deliveryFee;
        }


        // =========================================
        // Constructor Overload
        // =========================================

        public Shipment(
            string trackingCode,
            string description,
            double weight,
            decimal deliveryFee,
            string street,
            string city,
            int buildingNumber)
            : this(
                trackingCode,
                description,
                weight,
                deliveryFee,
                new DeliveryAddress(
                    street,
                    city,
                    buildingNumber))
        {
        }


        // =========================================
        // Properties
        // =========================================

        public string TrackingCode
        {
            get
            {
                return trackingCode;
            }

            private set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    trackingCode = value;
                }
            }
        }


        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    description = value;
                }
            }
        }


        public double Weight
        {
            get
            {
                return weight;
            }

            set
            {
                if (value > 0)
                {
                    weight = value;
                }
            }
        }


        public decimal DeliveryFee
        {
            get
            {
                return deliveryFee;
            }

            private set
            {
                if (value > 0)
                {
                    deliveryFee = value;
                }
            }
        }


        // =========================================
        // Update Weight
        // =========================================

        public void UpdateWeight(double newWeight)
        {
            if (newWeight > 0)
            {
                Weight = newWeight;
            }
        }


        // Method Overloading
        public void UpdateWeight(
            double newWeight,
            double extraPackingWeight)
        {
            if (newWeight > 0 &&
                extraPackingWeight >= 0)
            {
                Weight =
                    newWeight + extraPackingWeight;
            }
        }


        // =========================================
        // Abstract Estimated Cost
        // =========================================

        // Each shipment type provides its own cost.
        public abstract decimal EstimatedCost { get; }


        // =========================================
        // Update Delivery Fee
        // =========================================

        public void UpdateDeliveryFee(decimal newFee)
        {
            if (newFee > 0)
            {
                DeliveryFee = newFee;
            }
        }


        // =========================================
        // Print Shipment
        // =========================================

        public virtual void PrintShipment()
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

        // Partial method implementation for tracking status change notification.
        // The declaration of this partial method is in Shipment.Tracking.cs
        partial void OnTrackingStatusChanged(string newStatus)
        {
            Console.WriteLine($"Tracking status changed to: {newStatus}");
        }


        // =========================================
        // Object Copying
        // =========================================

        /*
         * CopyShipment creates a new Shipment object.
         *
         * It preserves the runtime type of the object.
         *
         * Example:
         * ExpressShipment -> ExpressShipment copy
         * InternationalShipment -> InternationalShipment copy
         */
        public Shipment CopyShipment()
        {
            Shipment copy =
                (Shipment)this.MemberwiseClone();

            // Copy the DeliveryAddress as a new object.
            copy.Destination =
                new DeliveryAddress(
                    Destination.Street,
                    Destination.City,
                    Destination.ZipCode,
                    Destination.Country);

            // A new object was created.
            TotalShipmentsCreated++;

            return copy;
        }


        // =========================================
        // Shallow Copy
        // =========================================

        /*
         * MemberwiseClone creates a shallow copy.
         *
         * The Shipment object is new,
         * but reference-type members are shared.
         *
         * Therefore:
         *
         * shipment1 != shallowCopy
         *
         * but:
         *
         * shipment1.Destination ==
         * shallowCopy.Destination
         */
        public Shipment ShallowCopy()
        {
            Shipment copy =
                (Shipment)this.MemberwiseClone();

            // Count the newly created object.
            TotalShipmentsCreated++;

            return copy;
        }


        // =========================================
        // Deep Copy
        // =========================================

        /*
         * Deep Copy creates:
         *
         * 1. A new Shipment object.
         * 2. A new DeliveryAddress object.
         *
         * Therefore changing the copied address
         * does not affect the original address.
         */
        public Shipment DeepCopy()
        {
            Shipment copy =
                (Shipment)this.MemberwiseClone();

            copy.Destination =
                new DeliveryAddress(
                    Destination.Street,
                    Destination.City,
                    Destination.ZipCode,
                    Destination.Country);

            // Count the newly created object.
            TotalShipmentsCreated++;

            return copy;
        }


        // =========================================
        // Static Method
        // =========================================

        public static int GetTotalShipmentsCreated()
        {
            return TotalShipmentsCreated;
        }


        // =========================================
        // ToString
        // =========================================

        public override string ToString()
        {
            return
                $"Tracking: {TrackingCode}\n" +
                $"Description: {Description}\n" +
                $"Weight: {Weight}\n" +
                $"Delivery Fee: {DeliveryFee:C}\n" +
                $"Destination: {Destination.GetFullAddress()}\n" +
                $"Estimated Cost: {EstimatedCost:C}";
        }
    }
}