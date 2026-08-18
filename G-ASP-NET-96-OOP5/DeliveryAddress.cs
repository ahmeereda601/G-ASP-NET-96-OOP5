using System;

namespace G_ASP_NET_96_OOP3
{
    // DeliveryAddress is owned by a Shipment (Composition).
    // It is a reference type (class), which is important for
    // demonstrating Shallow Copy and Deep Copy.
    public class DeliveryAddress
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }

        public DeliveryAddress(
            string street,
            string city,
            string zipCode,
            string country)
        {
            Street = street ?? string.Empty;
            City = city ?? string.Empty;
            ZipCode = zipCode ?? string.Empty;
            Country = country ?? string.Empty;
        }

        // Convenience constructor
        public DeliveryAddress(
            string street,
            string city,
            int number)
        {
            Street = street ?? string.Empty;
            City = city ?? string.Empty;
            ZipCode = number.ToString();
            Country = "Unknown";
        }

        public override string ToString()
        {
            return $"{Street}, {City}, {ZipCode}, {Country}";
        }

        public string GetFullAddress()
        {
            return ToString();
        }
    }
}