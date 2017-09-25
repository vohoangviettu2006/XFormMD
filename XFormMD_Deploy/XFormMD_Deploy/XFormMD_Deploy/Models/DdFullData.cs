using System;
using System.Collections.Generic;
using System.Text;

namespace XFormMD_Deploy.Models
{
    class DdFullData
    {
        public CIFInfo CIFInfo { get; set; }
        public CustomerInfo customerInfo { get; set; }
        public string accountNum { get; set; }
        public string accountName { get; set; }
        public string accountType { get; set; }
        public string accountTypeName { get; set; }
        public string accountCurrency { get; set; }

        public string accountBalance { get; set; }
        public string accountBalanceAvailable { get; set; }
        public string accountOpenDate { get; set; }
        public string accountOpenBrandCode { get; set; }
        public string accountLatestTransDate { get; set; }
        public string accountOverdraftDate { get; set; }
        public string accountOverdraftExpiredDate { get; set; }
        public string accountOverdraftLimit { get; set; }

        public string accountClassName { get; set; }
        public string accountClassCode { get; set; }
        public string accountInterestRate { get; set; }

        public string accountDelegatedPerson { get; set; }
        public string accountCoownerName { get; set; }
        public string accountStatus { get; set; }
        public string accountLockStatus { get; set; }
        public string accountAuthorizedStatus { get; set; }
    }
}
