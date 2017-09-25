using System;
using System.Collections.Generic;
using System.Text;

namespace XFormMD_Deploy.Utils
{
    public class StringManipulator_PTUD
    {
        private static readonly string[] VietNamChar = new string[] { "aAeEoOuUiIdDyY", "áàạảãâấầậẩẫăắằặẳẵ", "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ", "éèẹẻẽêếềệểễ", "ÉÈẸẺẼÊẾỀỆỂỄ", "óòọỏõôốồộổỗơớờợởỡ", "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ", "úùụủũưứừựửữ", "ÚÙỤỦŨƯỨỪỰỬỮ", "íìịỉĩ", "ÍÌỊỈĨ", "đ", "Đ", "ýỳỵỷỹ", "ÝỲỴỶỸ" };
        private string[] ChuSo = new string[10] { " không", " một", " hai", " ba", " bốn", " năm", " sáu", " bảy", " tám", " chín" };
        private string[] Tien = new string[6] { "", " nghìn", " triệu", " tỷ", " nghìn tỷ", " triệu tỷ" };
        public string defaultCurrencyName = " Đồng";
        public string defaultCurrencyCode = " VNĐ";

        //from anh Tuong - 20161026
        private static string[] ones = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen", };
        private static string[] tens = { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
        private static string[] thous = { "hundred", "thousand", "million", "billion", "trillion", "quadrillion" };
        public string ToWords(decimal number)
        {
            if (number < 0)
                return "negative " + ToWords(Math.Abs(number));

            int intPortion = (int)number;
            int decPortion = (int)((number - intPortion) * (decimal)100);

            return string.Format("{0} dollars and {1} cents", ToWords(intPortion), ToWords(decPortion));
        }
        public string ToWords(int number, string appendScale = "")
        {
            string numString = "";
            if (number < 100)
            {
                if (number < 20)
                    numString = ones[number];
                else
                {
                    numString = tens[number / 10];
                    if ((number % 10) > 0)
                        numString += "-" + ones[number % 10];
                }
            }
            else
            {
                int pow = 0;
                string powStr = "";

                if (number < 1000) // number is between 100 and 1000
                {
                    pow = 100;
                    powStr = thous[0];
                }
                else // find the scale of the number
                {
                    int log = (int)Math.Log(number, 1000);
                    pow = (int)Math.Pow(1000, log);
                    powStr = thous[log];
                }

                numString = string.Format("{0} {1}", ToWords(number / pow, powStr), ToWords(number % pow)).Trim();
            }

            return string.Format("{0} {1}", numString, appendScale).Trim();
        }
        public string ToWordsVND(decimal number)
        {
            if (number < 0)
                return "negative " + ToWords(Math.Abs(number));

            int intPortion = (int)number;
            int decPortion = (int)((number - intPortion) * (decimal)100);

            return string.Format("{0} vnd", ToWordsVND(intPortion), ToWordsVND(decPortion));
        }
        public string ToWordsVND(int number, string appendScale = "")
        {
            string numString = "";
            if (number < 100)
            {
                if (number < 20)
                    numString = ones[number];
                else
                {
                    numString = tens[number / 10];
                    if ((number % 10) > 0)
                        numString += "-" + ones[number % 10];
                }
            }
            else
            {
                int pow = 0;
                string powStr = "";

                if (number < 1000) // number is between 100 and 1000
                {
                    pow = 100;
                    powStr = thous[0];
                }
                else // find the scale of the number
                {
                    int log = (int)Math.Log(number, 1000);
                    pow = (int)Math.Pow(1000, log);
                    powStr = thous[log];
                }

                numString = string.Format("{0} {1}", ToWords(number / pow, powStr), ToWords(number % pow)).Trim();
            }

            return string.Format("{0} {1}", numString, appendScale).Trim();
        }
        //end of anh Tuong functions

        public string DocTienBangChu(decimal SoTien, string strTail)
        {
            int lan, i;
            decimal so;
            string KetQua = "", tmp = "";
            int[] ViTri = new int[6];
            if (SoTien < 0) return "Số tiền âm !";
            if (SoTien == 0) return "Không đồng !";
            if (SoTien > 0)
            {
                so = SoTien;
            }
            else
            {
                so = -SoTien;
            }
            //Kiểm tra số quá lớn
            if (SoTien > 8999999999999999)
            {
                SoTien = 0;
                return "";
            }
            ViTri[5] = (int)(so / 1000000000000000);
            so = so - long.Parse(ViTri[5].ToString()) * 1000000000000000;
            ViTri[4] = (int)(so / 1000000000000);
            so = so - long.Parse(ViTri[4].ToString()) * +1000000000000;
            ViTri[3] = (int)(so / 1000000000);
            so = so - long.Parse(ViTri[3].ToString()) * 1000000000;
            ViTri[2] = (int)(so / 1000000);
            ViTri[1] = (int)((so % 1000000) / 1000);
            ViTri[0] = (int)(so % 1000);
            if (ViTri[5] > 0)
            {
                lan = 5;
            }
            else if (ViTri[4] > 0)
            {
                lan = 4;
            }
            else if (ViTri[3] > 0)
            {
                lan = 3;
            }
            else if (ViTri[2] > 0)
            {
                lan = 2;
            }
            else if (ViTri[1] > 0)
            {
                lan = 1;
            }
            else
            {
                lan = 0;
            }
            for (i = lan; i >= 0; i--)
            {
                tmp = DocSo3ChuSo(ViTri[i]);
                KetQua += tmp;
                if (ViTri[i] != 0) KetQua += Tien[i];
                if ((i > 0) && (!string.IsNullOrEmpty(tmp))) KetQua += ",";//&& (!string.IsNullOrEmpty(tmp))
            }
            if (KetQua.Substring(KetQua.Length - 1, 1) == ",") KetQua = KetQua.Substring(0, KetQua.Length - 1);
            KetQua = KetQua.Trim() + strTail;
            return KetQua.Substring(0, 1).ToUpper() + KetQua.Substring(1);
        }
        public string DocTienBangChuSep(decimal SoTien, string strTail, string seperator)
        {
            int lan, i;
            decimal so;
            string KetQua = "", tmp = "";
            int[] ViTri = new int[6];
            if (SoTien < 0) return "Số tiền âm !";
            if (SoTien == 0) return "Không đồng !";
            if (SoTien > 0)
            {
                so = SoTien;
            }
            else
            {
                so = -SoTien;
            }
            //Kiểm tra số quá lớn
            if (SoTien > 8999999999999999)
            {
                SoTien = 0;
                return "";
            }
            ViTri[5] = (int)(so / 1000000000000000);
            so = so - long.Parse(ViTri[5].ToString()) * 1000000000000000;
            ViTri[4] = (int)(so / 1000000000000);
            so = so - long.Parse(ViTri[4].ToString()) * +1000000000000;
            ViTri[3] = (int)(so / 1000000000);
            so = so - long.Parse(ViTri[3].ToString()) * 1000000000;
            ViTri[2] = (int)(so / 1000000);
            ViTri[1] = (int)((so % 1000000) / 1000);
            ViTri[0] = (int)(so % 1000);
            if (ViTri[5] > 0)
            {
                lan = 5;
            }
            else if (ViTri[4] > 0)
            {
                lan = 4;
            }
            else if (ViTri[3] > 0)
            {
                lan = 3;
            }
            else if (ViTri[2] > 0)
            {
                lan = 2;
            }
            else if (ViTri[1] > 0)
            {
                lan = 1;
            }
            else
            {
                lan = 0;
            }
            for (i = lan; i >= 0; i--)
            {
                tmp = DocSo3ChuSo(ViTri[i]);
                KetQua += tmp;
                if (ViTri[i] != 0) KetQua += Tien[i];
                if ((i > 0) && (!string.IsNullOrEmpty(tmp))) KetQua += seperator;//&& (!string.IsNullOrEmpty(tmp))
            }
            if (KetQua.Substring(KetQua.Length - 1, 1) == seperator) KetQua = KetQua.Substring(0, KetQua.Length - 1);
            KetQua = KetQua.Trim() + strTail;
            return KetQua.Substring(0, 1).ToUpper() + KetQua.Substring(1);
        }
        // Hàm đọc số có 3 chữ số
        private string DocSo3ChuSo(int baso)
        {
            int tram, chuc, donvi;
            string KetQua = "";
            tram = (int)(baso / 100);
            chuc = (int)((baso % 100) / 10);
            donvi = baso % 10;
            if ((tram == 0) && (chuc == 0) && (donvi == 0)) return "";
            if (tram != 0)
            {
                KetQua += ChuSo[tram] + " trăm";
                if ((chuc == 0) && (donvi != 0)) KetQua += " linh";
            }
            if ((chuc != 0) && (chuc != 1))
            {
                KetQua += ChuSo[chuc] + " mươi";
                if ((chuc == 0) && (donvi != 0)) KetQua = KetQua + " linh";
            }
            if (chuc == 1) KetQua += " mười";
            switch (donvi)
            {
                case 1:
                    if ((chuc != 0) && (chuc != 1))
                    {
                        KetQua += " mốt";
                    }
                    else
                    {
                        KetQua += ChuSo[donvi];
                    }
                    break;
                case 5:
                    if (chuc == 0)
                    {
                        KetQua += ChuSo[donvi];
                    }
                    else
                    {
                        KetQua += " lăm";
                    }
                    break;
                default:
                    if (donvi != 0)
                    {
                        KetQua += ChuSo[donvi];
                    }
                    break;
            }
            return KetQua;
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

        public string cleanUpHtmlContent(string i)
        {
            string o = i.Replace(System.Environment.NewLine, "");
            o = o.Replace("</p><p>", "<br/>");
            o = o.Replace("<p>", "");
            o = o.Replace("</p>", "");
            //this.WriteLog("SCB_DOCSUBMISSIOM/cleanUpHtmlContent/o: " + o);
            return o;
        }

        public string splitDateFromDateTime(string i)
        {
            string r = i;
            string[] a = i.Split(' ');
            if (a.Length >= 2)
            {
                r = a[0];
            }

            return r;
        }
        public int convertToInt32(string str)
        {
            int result = 0;
            if (str != "")
                Int32.TryParse(str, out result);

            return result;
        }
        public decimal convertToDecimal(string str)
        {
            decimal result = 0;
            if (str != "")
                Decimal.TryParse(str, out result);

            return result;
        }
        public string escapeNull(DateTime? a)
        {
            return a == null ? "" : Convert.ToDateTime(a).ToString("dd/MM/yyyy");
        }
        public string escapeNull(decimal? a)
        {
            return escapeNull(a, "");
        }
        public string escapeNull(decimal? a, string displayStr)
        {
            return a == null ? displayStr : Convert.ToDecimal(a).ToString("#,##0.00");
        }
        public string escapeNull4(decimal? a, string displayStr)
        {
            return a == null ? displayStr : Convert.ToDecimal(a).ToString("#,#.0000");
        }
        public string escapeNull1(decimal? a)
        {
            return escapeNull1(a, "");
        }
        public string escapeNull1(decimal? a, string displayStr)
        {
            return a == null ? displayStr : Convert.ToDecimal(a).ToString("#,##");
        }
        public string escapeNull(string a)
        {
            return escapeNull(a, "");
        }
        public string escapeNull(string a, string displayStr)
        {
            return a == null ? displayStr : a;
        }

        public string manRep(string a, string oldS, string newS)
        {
            return a.Replace(oldS, newS);
        }

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
        /*public bool inList(string str, List<string> ls)
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
        public bool inList(string str, dynamic dyn_arr)
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

        public string noiChuoi(List<string> ls)
        {
            string firstSeperator = ", ";
            string finalSeperator = " và ";

            return this.noiChuoi(ls.ToArray(), firstSeperator, finalSeperator);
        }
        public string noiChuoi(List<string> ls, string firstSeperator, string finalSeperator)
        {
            return this.noiChuoi(ls.ToArray(), firstSeperator, finalSeperator);
        }
        public string noiChuoi(string[] ls)
        {
            string firstSeperator = ", ";
            string finalSeperator = " và ";

            return this.noiChuoi(ls, firstSeperator, finalSeperator);
        }
        public string noiChuoi(string[] ls, string firstSeperator, string finalSeperator)
        {
            string returnString = "";

            if (ls.Length == 1)
                returnString = ls[0];
            else if (ls.Length == 2)
                returnString = ls[0] + finalSeperator + ls[1];
            else if (ls.Length > 2)
            {
                List<string> newls = new List<string>();
                for (int i = 0; i < ls.Length - 1; i++)
                {
                    newls.Add(ls[i]);
                }
                returnString = String.Join(firstSeperator, newls) + finalSeperator + ls[ls.Length - 1];
            }

            return returnString;
        }
        public string removeDuplicatedSpace(string in_s)
        {
            string out_s = in_s;
            do
            {
                out_s = out_s.Replace("  ", " ");
            } while (out_s.IndexOf("  ") != -1);

            return out_s;
        }

        public string createMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
        public string getMasterPassHashed()
        {
            return "89851AB0B573E728078BFDB43668AC5A";
        }
        public string displayVNDWithoutDecimalPoint(decimal number)
        {
            return number.ToString("#,##0.");
        }
        public string displayVNDWithoutDecimalPoint(decimal? number)
        {
            return Convert.ToDecimal(number).ToString("#,##0.");
        }

        public string getDateFromFCDB(string input)
        {
            string retStr = input;
            string[] parts = input.Split(' ');
            if (parts.Length > 0)
            {
                string[] parts2 = parts[0].Split('/');
                if (parts2.Length == 3)
                {
                    int day = this.convertToInt32(parts2[1]);
                    int month = this.convertToInt32(parts2[0]);
                    int year = this.convertToInt32(parts2[2]);

                    if (month > 12)
                    {
                        day = this.convertToInt32(parts2[0]);
                        month = this.convertToInt32(parts2[1]);
                    }

                    if (day > 9)
                        retStr = day.ToString() + "/";
                    else
                        retStr = "0" + day.ToString() + "/";

                    if (month > 9)
                        retStr += month.ToString() + "/";
                    else
                        retStr += "0" + month.ToString() + "/";

                    retStr += year;
                }

            }

            return retStr;
        }
        public string getDateFromESP(string input)
        {
            //1995-08-02
            //2012-09-21 00:00:00.0
            // -- DỊCH VỤ NGÂN HÀNG ĐIỆN TỬ/NGÀY GIAO DỊCH CUỐI CÙNG
            // -- THÔNG TIN KHÁCH HÀNG/Ngày tạo MKH
            //2014-04-01 00:00:00
            // -- TÀI KHOẢN THANH TOÁN/NGÀY MỞ
            // -- TÀI KHOẢN TIẾT KIỆM/NGÀY MỞ
            // -- TÀI KHOẢN VAY/NGÀY MỞ

            //return format dd/mm/yyyy
            string retStr = input;
            string[] parts = input.Split(' ');
            if (parts.Length > 0)
            {
                string[] parts2 = parts[0].Split('-');
                if (parts2.Length == 3)
                {
                    int day = this.convertToInt32(parts2[2]);
                    int month = this.convertToInt32(parts2[1]);
                    int year = this.convertToInt32(parts2[0]);

                    if (day > 9)
                        retStr = day.ToString() + "/";
                    else
                        retStr = "0" + day.ToString() + "/";

                    if (month > 9)
                        retStr += month.ToString() + "/";
                    else
                        retStr += "0" + month.ToString() + "/";

                    retStr += year;
                }

            }

            return retStr;
        }
        public string getAmtFromESP(string input)
        {
            return this.convertToDecimal(input).ToString("#,##0.00");
        }
        public string buildOutESPTag(string inTag)
        {
            string retStr = inTag;
            string[] parts = inTag.Split('_');
            if (parts.Length >= 2 && parts[parts.Length - 1] == "in")
            {
                List<string> retList = new List<string>();
                for (int i = 0; i < parts.Length - 2; i++) {
                    retList.Add(parts[i]);
                }
                retStr = String.Join("_", retList);
            }

            return retStr + "_out";
        }
        public string cleanFcdbErrorMessage(string input)
        {
            return input.Replace("\'", "").Replace("\n", "");
        }
    }
}
