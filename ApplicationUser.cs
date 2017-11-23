using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace TestIdentityAPI
{
    public class ApplicationUser:IdentityUser
    {
        public bool IsCertified { get; set; }
        public string NameCertified { get; set; }
        public string Language { get; set; }
        public bool? IsMale { get; set; }
        public DateTime? BirthDate { get; set; }
        public byte[] RowVersion { get; set; }

        public ICollection<Description> Description { get; set; }
        public ICollection<InterestPoint> InterestPoint { get; set; }
        public ICollection<UnknownPoint> UnknownPoint { get; set; }
        public ICollection<VoteDescription> VoteDescription { get; set; }
        public ICollection<VoteInterestPoint> VoteInterestPoint { get; set; }
    }
}