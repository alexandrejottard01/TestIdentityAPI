﻿using System;
using System.Collections.Generic;

namespace TestIdentityAPI
{
    public partial class VoteInterestPoint
    {
        public bool IsPositiveAssessment { get; set; }
        public long IdUser { get; set; }
        public long IdInterestPoint { get; set; }

        public InterestPoint IdInterestPointNavigation { get; set; }
        public User IdUserNavigation { get; set; }
    }
}