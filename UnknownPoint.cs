using System;
using System.Collections.Generic;

namespace TestIdentityAPI
{
    public partial class UnknownPoint
    {
        public long IdUnknownPoint { get; set; }
        public long IdUser { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public DateTime DateCreation { get; set; }

        public User IdUserNavigation { get; set; }
    }
}
