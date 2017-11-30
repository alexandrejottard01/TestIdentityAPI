using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestIdentityAPI
{
    public partial class VoteDescription
    {
        [Required]
        public bool IsPositiveAssessment { get; set; }

        [Required]
        public string IdUser { get; set; }

        [Required]
        public long IdDescription { get; set; }

        public Description IdDescriptionNavigation { get; set; }
        public ApplicationUser IdUserNavigation { get; set; }
    }
}
