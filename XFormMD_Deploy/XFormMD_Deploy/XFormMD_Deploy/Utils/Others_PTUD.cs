using System;
using System.Collections.Generic;
using System.Text;

namespace XFormMD_Deploy.Utils
{
    public class Others_PTUD
    {
        private readonly string[] VietNamChar = new string[] { "aAeEoOuUiIdDyY", "áàạảãâấầậẩẫăắằặẳẵ", "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ", "éèẹẻẽêếềệểễ", "ÉÈẸẺẼÊẾỀỆỂỄ", "óòọỏõôốồộổỗơớờợởỡ", "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ", "úùụủũưứừựửữ", "ÚÙỤỦŨƯỨỪỰỬỮ", "íìịỉĩ", "ÍÌỊỈĨ", "đ", "Đ", "ýỳỵỷỹ", "ÝỲỴỶỸ" };
        private readonly string[] ServicesController = new string[] {
            "DvDkUserEbankings", "DvResetIBanks",
            "DvDkUserSmsbankings", "DvUpdateUserESMSbankings",
            "DvDkUserMbankings", "DvDkUserMbankingResetPasses", "DvDkUserMbankingLocks",
            "DvSmsTgDks", "DvSmsTgUpdates",
            "DvTthdHdOpenNews", "DvTthdHdCloses", "DvTthdHdUpdateSDTs", "DvTthdHdUpdateSTKs", "DvTthdDvs", "DvTthdDvDongMoes" };
        private readonly string[] TransactionsController = new string[] {
            "VayBoSungCcstk", "VayCCSTK", "VayTraNos",
            "TdAcount", "TatToanTd",
            "MoTkDD", "TatToanDD",
            "TabCustomer" };
        /*public bool isNullOrEmpty(dynamic a)
        {
            bool re = true;
            if (a != null)
            {
                if (a.Trim() != "")
                    re = false;
            }

            return re;
        }*/

        public bool inArray(int str, int[] ls)
        {
            bool rs = false;
            foreach (int ea in ls)
            {
                if (str == ea)
                {
                    rs = true;
                    break;
                }
            }

            return rs;
        }
        public bool inArray(string str, string[] ls)
        {
            bool rs = false;
            foreach (string ea in ls)
            {
                if (str == ea)
                {
                    rs = true;
                    break;
                }
            }

            return rs;
        }
        public bool inList(string str, List<string> ls)
        {
            bool rs = false;
            foreach (string ea in ls.ToArray())
            {
                if (str == ea)
                {
                    rs = true;
                    break;
                }
            }

            return rs;
        }
        /*public bool inList(string str, dynamic dyn_arr)
        {
            bool rs = false;
            foreach (string ea in dyn_arr)
            {
                if (str == ea)
                {
                    rs = true;
                    break;
                }
            }

            return rs;
        }*/
        
        public string convertToPeriodDescription(string input)
        {
            string returnStr = input;
            if (input.Length > 1)
            {
                string temp = input.Substring(input.Length - 1, 1);
                string replacedStr = "";
                if (temp.ToUpper() == "D")
                    replacedStr = " ngày";
                else if (temp.ToUpper() == "M")
                    replacedStr = " tháng";
                else if (temp.ToUpper() == "Y")
                    replacedStr = " năm";

                if (replacedStr != "")
                    returnStr = input.Substring(0, input.Length - 1).Trim() + replacedStr;
            }

            return returnStr;
        }

        public string vietnameseReplace(string str)
        {
            for (int i = 1; i < VietNamChar.Length; i++)
            {
                for (int j = 0; j < VietNamChar[i].Length; j++)
                    str = str.Replace(VietNamChar[i][j], VietNamChar[0][i - 1]);
            }
            return str;
        }

        public bool convertableToDateTime(string inputStr)
        {
            bool returnValue = false;
            string[] parts = inputStr.Split(' ');
            if (parts.Length >= 2)
            {
                string[] dparts = parts[0].Split('/');
                if (dparts.Length == 3)
                {
                    try
                    {
                        new DateTime(convertToInt32(dparts[2]), convertToInt32(dparts[0]), convertToInt32(dparts[1]));
                    }
                    catch
                    {

                    }
                }
            }

            return returnValue;
        }
        public DateTime convertToDateTime(string inputStr)
        {
            DateTime returnDate = new DateTime();
            string[] parts = inputStr.Split(' ');
            if (parts.Length >= 2)
            {
                string[] dparts = parts[0].Split('/');
                if (dparts.Length == 3)
                {
                    //returnDate = new 
                }
            }

            return returnDate;
        }

        public int convertToInt32(string str)
        {
            int result = 0;
            if (str != "")
                Int32.TryParse(str, out result);

            return result;
        }

        

        public string getDuLieuTvKh(string tv, string nomark, bool upper)
        {
            string returnStr = "";
            if (!String.IsNullOrEmpty(nomark))
                returnStr = nomark;
            if (!String.IsNullOrEmpty(tv))
                returnStr = tv;

            return upper == true ? returnStr.ToUpper() : returnStr;
        }

        public Decimal makeItPositive(Decimal? input)
        {
            Decimal outut = Convert.ToDecimal(input);
            if (outut < 0)
                outut = outut * (-1);

            return outut;
        }
        public Decimal makeItPositive(Decimal input)
        {
            Decimal outut = input;
            if (outut < 0)
                outut = outut * (-1);

            return outut;
        }

        public bool isEmptyNullOrZero(string input)
        {
            bool retVal = false;
            if (input == null)
                retVal = true;

            if (input == "")
                retVal = true;

            if (input == "0")
                retVal = true;

            return retVal;
        }

        public bool isRequiredOnESPConnection(string loginBranch)
        {
            bool returnResult = false;
            if (AppConfig.IIBConnectionRestriction.Length == 1 && AppConfig.IIBConnectionRestriction[0].ToUpper() == "ALL")
            {
                returnResult = true;
            }
            else
            {
                foreach (string eachBranchCode in AppConfig.IIBConnectionRestriction)
                {
                    if (eachBranchCode == loginBranch)
                    {
                        returnResult = true;
                        break;
                    }
                }
            }

            if (returnResult == true)
            {
                if (AppConfig.IIBConnectionException.Length >= 1 || AppConfig.IIBConnectionException[0].ToUpper() != "NONE")
                {
                    foreach (string eachBranchCode in AppConfig.IIBConnectionException)
                    {
                        if (eachBranchCode == loginBranch)
                        {
                            returnResult = false;
                            break;
                        }
                    }
                }
            }

            return returnResult;
        }
        public bool matchedMessage(string branchCode, string controllerName, string messageGhiChu)
        {
            //160,001|TatToanTd,TdAcount
            //ALL|ALL
            //NONE|NONE
            bool matched = false;
            string[] parts = messageGhiChu.Split('|');
            if (parts.Length >= 2)
            {
                if (parts[0] == "ALL")
                {
                    if (parts[1] == "ALL")
                    {
                        matched = true;
                    }
                    else if (parts[1] == "SERVICES")
                    {
                        if (this.inArray(controllerName, this.ServicesController))
                        {
                            matched = true;
                        }
                    }
                    else if (parts[1] == "TRANSACTIONS")
                    {
                        if (this.inArray(controllerName, this.TransactionsController))
                        {
                            matched = true;
                        }
                    }
                    else
                    {
                        string[] parts2 = parts[1].Split(',');
                        if (this.inArray(controllerName, parts2))
                        {
                            matched = true;
                        }
                    }
                }
                else
                {
                    string[] parts1 = parts[0].Split(',');
                    if (this.inArray(branchCode, parts1))
                    {
                        if (parts[1] == "ALL")
                        {
                            matched = true;
                        }
                        else if (parts[1] == "SERVICES")
                        {
                            if (this.inArray(controllerName, this.ServicesController))
                            {
                                matched = true;
                            }
                        }
                        else if (parts[1] == "TRANSACTIONS")
                        {
                            if (this.inArray(controllerName, this.TransactionsController))
                            {
                                matched = true;
                            }
                        }
                        else
                        {
                            string[] parts2 = parts[1].Split(',');
                            if (this.inArray(controllerName, parts2))
                            {
                                matched = true;
                            }
                        }
                    }
                }
            }

            return matched;
        }
    }
}
