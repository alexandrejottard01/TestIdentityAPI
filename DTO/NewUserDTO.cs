using System;

namespace TestIdentityAPI.DTO
{
    public class NewUserDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }
        public string Email { get; set; }  

        public bool IsCertified { get; set; }
        public string Language { get; set; }    
        public string NameCertified { get; set; }
        public bool? IsMale { get; set; }
        public DateTime? BirthDate { get; set; }

    }
}