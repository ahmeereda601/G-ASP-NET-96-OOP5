using System;

namespace G_ASP_NET_96_OOP3
{
    internal class DeliveryCenter
    {
        private Shipment[] shipments;
        private int count;
        private string name;

        /*
        Index
        0 --> Shipment1
        1 --> Shipment2
        2 --> Shipment3
        3 --> Empty
        ...
        9 --> Empty
        */

        // Constructors
        public DeliveryCenter()
        {
            shipments = new Shipment[10];
            count = 0;
            name = "Unnamed Center";
        }

        public DeliveryCenter(string name) : this()
        {
            this.name = name ?? "Unnamed Center";
        }

        // Integer Indexer
        public Shipment this[int index]
        {
            get
            {
                if (index >= 0 && index < count)
                    return shipments[index];

                return default;
            }

            set
            {
                if (index >= 0 && index < count)
                    shipments[index] = value;
            }
        }

        // String Indexer
        public Shipment this[string trackingCode]
        {
            get
            {
                for (int i = 0; i < count; i++)
                {
                    if (shipments[i].TrackingCode == trackingCode)
                        return shipments[i];
                }

                return default;
            }
        }

        // Add Shipment
        public bool AddShipment(Shipment shipment)
        {
            if (shipment == null)
                return false;

            if (count == shipments.Length)
                return false;

            shipments[count] = shipment;
            count++;

            return true;
        }

        // Print all shipments
        public void PrintAllShipments()
        {
            Console.WriteLine(
                $"--- Shipments in {name} (count: {count}) ---");

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"\nShipment #{i + 1}:");
                shipments[i].PrintShipment();
            }
        }

        // Print tracking status for a single ITrackable shipment
        public void PrintShipment(ITrackable shipment)
        {
            if (shipment == null)
                return;

            Console.WriteLine(shipment.GetTrackingStatus());
        }

        // Print insurance cost for a single IInsurable shipment
        public void PrintInsurance(IInsurable shipment)
        {
            if (shipment == null)
                return;

            Console.WriteLine(
                $"Insurance: {shipment.CalculateInsurance():C}");
        }

        // Print tracking statuses for all shipments
        // that implement ITrackable
        public void PrintTrackingStatuses()
        {
            Console.WriteLine("--- Tracking Statuses ---");

            for (int i = 0; i < count; i++)
            {
                if (shipments[i] is ITrackable trackable)
                {
                    Console.WriteLine(
                        trackable.GetTrackingStatus());
                }
            }
        }

        // Remove shipment by tracking code
        public bool RemoveShipment(string trackingCode)
        {
            for (int i = 0; i < count; i++)
            {
                if (shipments[i].TrackingCode == trackingCode)
                {
                    // Shift left
                    for (int j = i; j < count - 1; j++)
                    {
                        shipments[j] = shipments[j + 1];
                    }

                    shipments[count - 1] = null;
                    count--;

                    return true;
                }
            }

            return false;
        }

        // Aggregation: DeliveryCenter has a Driver
        private Driver _driver;

        public Driver Driver
        {
            get => _driver;
            set => _driver =
                value ?? throw new ArgumentNullException(nameof(value));
        }

        public override string ToString()
        {
            return $"DeliveryCenter: {name} (Shipments: {count})";
        }
    }
}