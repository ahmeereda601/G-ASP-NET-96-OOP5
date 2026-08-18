using System;

namespace G_ASP_NET_96_OOP3
{
    public abstract partial class Shipment
    {
        // Tracking status for the shipment (owned by the Shipment)
        private string trackingStatus = "Created";

        // ITrackable implementation
        public string GetTrackingStatus()
        {
            return trackingStatus ?? "In Transit";
        }

        // Update the tracking status and notify via partial method hook
        public void UpdateTrackingStatus(string status)
        {
            if (string.IsNullOrWhiteSpace(status)) return;

            trackingStatus = status;

            // Invoke partial method hook if implemented elsewhere
            OnTrackingStatusChanged(status);
        }

        // Partial method declaration; optionally implemented in another partial file
        partial void OnTrackingStatusChanged(string newStatus);
    }
}
