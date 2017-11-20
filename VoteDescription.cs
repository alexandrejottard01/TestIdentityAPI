using System;
using System.Collections.Generic;

namespace TestIdentityAPI
{
    public partial class VoteDescription
    {
        public bool IsPositiveAssessment { get; set; }
        public long IdUser { get; set; }
        public long IdDescription { get; set; }

        public Description IdDescriptionNavigation { get; set; }
        public User IdUserNavigation { get; set; }
    }
}
