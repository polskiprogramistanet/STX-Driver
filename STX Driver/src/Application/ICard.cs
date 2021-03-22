using System;
using STX_Driver.src.Common.Enums;

namespace STX_Driver.src.Application
{
    public interface ICard
    {
        string CardCode { get; set; }
        string CardNumber { get; set; }
        CardTypeEnum CardType { get; set; }
        DateTime CreationDate { get; set; }
        DateTime ExpirationDate { get; set; }
        int Id { get; }
        DateTime LastUsingDate { get; set; }
        int PINActive { get; set; }
        string PINCode { get; set; }
        int SendEmail { get; set; }
        int SendSMS { get; set; }
        StatusCardEnum State { get; set; }
    }
}