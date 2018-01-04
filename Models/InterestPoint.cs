using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Required]
        public string IdUser { get; set; }

        [Required]
        public decimal Latitude { get; set; }

        [Required]
        public decimal Longitude { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
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
