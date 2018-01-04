using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Required]
        [MinLength(15)]
        [MaxLength(500)]
        public string Explication { get; set; }

        [Required]
        public string IdUser { get; set; }

        [Required]
        public long IdInterestPoint { get; set; }

        public InterestPoint IdInterestPointNavigation { get; set; }
        public ApplicationUser IdUserNavigation { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public ICollection<VoteDescription> VoteDescription { get; set; }
    }
}