using System;
using System.Collections.Generic;

namespace TestIdentityAPI
{
    public partial class User
    {
        public User()
        {
            Description = new HashSet<Description>();
            InterestPoint = new HashSet<InterestPoint>();
            UnknownPoint = new HashSet<UnknownPoint>();
            VoteDescription = new HashSet<VoteDescription>();
            VoteInterestPoint = new HashSet<VoteInterestPoint>();
        }

        public long IdUser { get; set; }
        public string Pseudo { get; set; }
        public string Password { get; set; }
        public bool IsCertified { get; set; }
        public string NameCertified { get; set; }
        public string Email { get; set; }
        public string Language { get; set; }
        public bool? IsMale { get; set; }
        public DateTime? BirthDate { get; set; }
        public bool IsAdmin { get; set; }
        public byte[] RowVersion { get; set; }

        public ICollection<Description> Description { get; set; }
        public ICollection<InterestPoint> InterestPoint { get; set; }
        public ICollection<UnknownPoint> UnknownPoint { get; set; }
        public ICollection<VoteDescription> VoteDescription { get; set; }
        public ICollection<VoteInterestPoint> VoteInterestPoint { get; set; }
    }
}
