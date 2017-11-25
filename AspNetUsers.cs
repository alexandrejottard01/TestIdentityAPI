using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace TestIdentityAPI
{
    public partial class AspNetUsers
    {
        public AspNetUsers()
        {
            AspNetUserClaims = new HashSet<AspNetUserClaims>();
            AspNetUserLogins = new HashSet<AspNetUserLogins>();
            AspNetUserRoles = new HashSet<AspNetUserRoles>();
            AspNetUserTokens = new HashSet<AspNetUserTokens>();
            Description = new HashSet<Description>();
            InterestPoint = new HashSet<InterestPoint>();
            UnknownPoint = new HashSet<UnknownPoint>();
            VoteDescription = new HashSet<VoteDescription>();
            VoteInterestPoint = new HashSet<VoteInterestPoint>();
        }

        public string Id { get; set; }
        public int AccessFailedCount { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool LockoutEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public string NormalizedEmail { get; set; }
        public string NormalizedUserName { get; set; }
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public string SecurityStamp { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public string UserName { get; set; }
        public bool IsCertified { get; set; }
        public string NameCertified { get; set; }
        public string Language { get; set; }
        public bool? IsMale { get; set; }
        public DateTime? BirthDate { get; set; }
        public byte[] RowVersion { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public ICollection<AspNetUserClaims> AspNetUserClaims { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public ICollection<AspNetUserLogins> AspNetUserLogins { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public ICollection<AspNetUserRoles> AspNetUserRoles { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public ICollection<AspNetUserTokens> AspNetUserTokens { get; set; }
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
