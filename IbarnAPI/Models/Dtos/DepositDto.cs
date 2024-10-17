using System.ComponentModel.DataAnnotations;

namespace IbarnAPI.Models.Dtos
{
    public class DepositDto
    {
        [Required]
        public string IBanCode { get; set; }

        [Required]
        public decimal DepositMoney { get; set; }


    }
}
