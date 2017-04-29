using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MercuryHealth.Web.Utilities
{
    public static class TelemetryClientHelper
    {
        public static void TrackEvent(string description)
        {
            // Uncomment these lines to track custom events.

            // var telemetry = new Microsoft.ApplicationInsights.TelemetryClient();
            // telemetry.TrackEvent(description);
        }
    }
}