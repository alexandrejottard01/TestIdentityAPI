using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestIdentityAPI
{
    public partial class UnknownPoint
    {
        public long IdUnknownPoint { get; set; }

        [Required]
        public string IdUser { get; set; }

        [Required]
        public decimal Latitude { get; set; }

        [Required]
        public decimal Longitude { get; set; }

        [Required]
        public DateTime DateCreation { get; set; }

        public ApplicationUser IdUserNavigation { get; set; }
    }
}
