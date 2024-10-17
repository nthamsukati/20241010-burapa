using System.ComponentModel.DataAnnotations;

namespace IbarnAPI.Models.Response
{
    public class DepositResponse
    {
        [Required]
        public string IBanCode { get; set; }
        [Required]
        public decimal DepositMoney { get; set; }
        public DateTime TransectionTime { get; set; }
        public string OperateBy { get; set; }
        public string OperateForm { get; set; }
        public bool Status { get; set; }
        public string StatusDescription { get; set; }
    }
}
