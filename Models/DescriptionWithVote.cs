using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using TestIdentityAPI;

namespace MoveAndSeeAPI
{
    public partial class DescriptionWithVote
    {
        [Required]
        public Description Description { get; set; }

        [Required]
        public int Average { get; set; }

       
    }
}
