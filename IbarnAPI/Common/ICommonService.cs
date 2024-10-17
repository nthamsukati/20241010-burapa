namespace IbarnAPI.Common
{
    public interface ICommonService
    {
        Task<string> GetIBan(string countryCode);

        //Task<decimal> FeeCalculate(decimal depositMoney);

        Task<string> ValidateIBan(string countryCode);
    }
}
