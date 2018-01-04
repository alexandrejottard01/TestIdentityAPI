using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestIdentityAPI
{
    public partial class VoteInterestPoint
    {
        [Required]
        public bool IsPositiveAssessment { get; set; }

        [Required]
        public string IdUser { get; set; }

        [Required]
        public long IdInterestPoint { get; set; }

        public InterestPoint IdInterestPointNavigation { get; set; }
        public ApplicationUser IdUserNavigation { get; set; }
    }
}
