using IbarnAPI.Common;
using IbarnAPI.Models.Dtos;
using IbarnAPI.Models.Response;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System;

namespace IbarnAPI.Service.BankAccountService
{
    public class BankingService : IBankingService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;
        private readonly ICommonService _commonService;
        public BankingService(IConfiguration configuration, ICommonService commonService)
        {
           _configuration = configuration;
            _commonService = commonService;
        }

        public async Task<AccountCreateResponse> CreateAccount(AccountDto input)
        {
            var IBanCode = await _commonService.GetIBan(input.countryCode);

            // Imagine we insert using entity frameowrk to db
            //var user = new User
            //{
            //    FirstName = userDto.FirstName,
            //    LastName = userDto.LastName,
            //    IBanCode = IBanCode,
            //    Email = userDto.Email,
            //    Password = userDto.Password // Ensure to hash passwords in production
            //};

            //_context.Users.Add(user);
            //await _context.SaveChangesAsync();

            AccountCreateResponse response = new AccountCreateResponse();
            response.firstName = input.firstName;
            response.lastName = input.lastName;
            response.IBanCode = IBanCode;
            response.createDate = DateTime.UtcNow;

            return response;

        }

        public async Task<DepositResponse> DepositMoney(DepositDto input)
        {
            DepositResponse response = new DepositResponse();
            // IBan validate
            // var isValid = await _commonService.GetIBan(input.IBanCode)
            if (input.DepositMoney < 0)
            {
                response.Status = false;
                response.StatusDescription = "Money can't be negetive";
                return response;
            }
            decimal depositAfterFee = await _commonService.FeeCalculate(input.DepositMoney);
            response.DepositMoney = depositAfterFee;
            response.Status = true;
            response.StatusDescription = "Transaction Complete";
            response.OperateBy = input.IBanCode;
            response.OperateForm = "IPhone 4s";
            response.TransectionTime = DateTime.UtcNow;
            return response;
        }

        public async Task<TransferResponse> TransferMoney(TransferDto input)
        {
            TransferResponse response = new TransferResponse();

            // 
        }

    }
}
