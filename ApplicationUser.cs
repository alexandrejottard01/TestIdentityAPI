using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

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

        [JsonIgnore]
        [IgnoreDataMember]
        public ICollection<Description> Description { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public ICollection<InterestPoint> InterestPoint { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public ICollection<UnknownPoint> UnknownPoint { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public ICollection<VoteDescription> VoteDescription { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public ICollection<VoteInterestPoint> VoteInterestPoint { get; set; }
    }
}