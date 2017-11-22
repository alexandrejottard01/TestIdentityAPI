﻿using System;
using System.Collections.Generic;

namespace TestIdentityAPI
{
    public partial class Description
    {
        public Description()
        {
            VoteDescription = new HashSet<VoteDescription>();
        }

        public long IdDescription { get; set; }
        public string Explication { get; set; }
        public long IdUser { get; set; }
        public long IdInterestPoint { get; set; }

        public InterestPoint IdInterestPointNavigation { get; set; }
        public User IdUserNavigation { get; set; }
        public ICollection<VoteDescription> VoteDescription { get; set; }
    }
}