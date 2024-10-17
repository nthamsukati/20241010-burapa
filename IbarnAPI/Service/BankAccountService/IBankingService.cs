using IbarnAPI.Models.Dtos;
using IbarnAPI.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace IbarnAPI.Service.BankAccountService
{
    public interface IBankingService
    {
        Task<AccountCreateResponse> CreateAccount(AccountDto input);

        //public Task<IActionResult> DepositMoney(DepositDto input);


    }
}
