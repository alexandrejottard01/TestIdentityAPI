using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace TestIdentityAPI
{
    public partial class InterestPoint
    {
        public InterestPoint()
        {
            Description = new HashSet<Description>();
            VoteInterestPoint = new HashSet<VoteInterestPoint>();
        }

        public long IdInterestPoint { get; set; }
        public string IdUser { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string Name { get; set; }
        public DateTime DateCreation { get; set; }

        public ApplicationUser IdUserNavigation { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public ICollection<Description> Description { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]        
        public ICollection<VoteInterestPoint> VoteInterestPoint { get; set; }
    }
}
