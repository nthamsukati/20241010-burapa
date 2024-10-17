using System.ComponentModel.DataAnnotations;

namespace IbarnAPI.Models.Dtos
{
    public class TransferDto
    {
        [Required]
        public string IBanCode { get; set; }
        [Required]
        public string IBanReciever { get; set; }
        [Required]
        public decimal transferAmount { get; set; }
    }
}
