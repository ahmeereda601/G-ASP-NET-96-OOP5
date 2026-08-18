using System;

namespace G_ASP_NET_96_OOP3
{
    public static class ShipmentExtensions
    {
        public static string GetSummary(this Shipment shipment)
        {
            if (shipment == null) return string.Empty;

            // Shipment Type: remove trailing 'Shipment' word for nicer display
            string typeName = shipment.GetType().Name;
            if (typeName.EndsWith("Shipment", StringComparison.OrdinalIgnoreCase))
            {
                typeName = typeName.Substring(0, typeName.Length - "Shipment".Length).Trim();
            }

            return $"{shipment.TrackingCode} | {typeName} | {shipment.Weight} KG | {shipment.GetTrackingStatus()}";
        }

        public static bool IsDelivered(this Shipment shipment)
        {
            if (shipment == null) return false;

            return string.Equals(shipment.GetTrackingStatus(), "Delivered", StringComparison.OrdinalIgnoreCase);
        }
    }
}
