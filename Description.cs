using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

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
        public string IdUser { get; set; }
        public long IdInterestPoint { get; set; }

        public InterestPoint IdInterestPointNavigation { get; set; }
        public ApplicationUser IdUserNavigation { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public ICollection<VoteDescription> VoteDescription { get; set; }
    }
}
