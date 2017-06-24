using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Omnimerit_Portal.Models
{
    public class TransportDetails
    {
        public int Id { get; set; }
        public string RouteCode { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public string VehicleNo { get; set; }
        public string DriverName { get; set; }
        public string UserType { get; set; }
        public string UserName { get; set; }
    }
}