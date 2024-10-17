using Microsoft.AspNetCore.Mvc;
using IbarnAPI.Service;
using System.Collections.Generic;
using System.Linq;
using IbarnAPI.Service.BankAccountService;
using IbarnAPI.Models.Dtos;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace IbarnAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BankingController : ControllerBase
    {
        private readonly IBankingService _bankingService;
        private readonly ILogger _logger;

        public BankingController(ILogger<BankingController> logger, IBankingService bankingService)
        {
            _bankingService = bankingService;
            _logger = logger;
        }

        [HttpPost("/create")]
        public async Task<IActionResult> CreateBankAccount(AccountDto input)
        {
            try
            {
                var response = await _bankingService.CreateAccount(input);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        //[HttpPut("/deposit")]
        //public async Task<IActionResult> Deposit(DepositDto input)
        //{
        //    try
        //    {
        //        await _bankingService.De

        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500);
        //    }

        //}


    }
}