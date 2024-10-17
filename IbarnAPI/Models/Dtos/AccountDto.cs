using System.ComponentModel.DataAnnotations;

namespace IbarnAPI.Models.Dtos
{
    public class AccountDto
    {
        [Required]
        public string firstName { get; set; }
        [Required]
        public string lastName { get; set; }
        [Required]
        public string countryCode { get; set; }
        public string email { get; set; }
        public string password { get; set; }

    }
}
