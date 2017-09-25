using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace XFormMD_Deploy.Utils
{
    public class Debugging_PTUD
    {
        private string[] localDNS = new string[] { "TUVOLEGION", "000044DES014", "000044DES009" };
        private string[] liveDNS = new string[] { "app-tablet-ptud2" };
        private Others_PTUD oCommon = new Others_PTUD();

        /*public void WriteLog(string sErrMsg)
        {
            string logType = "DebugLog";
            this.WriteLog(sErrMsg, logType);
        }
        public void WriteLog(string sErrMsg, string logType)
        {
            bool continueWritingLog = false;

            //system allow writing log - write all log types
            if (AppConfig.WriteWsLog == "true")
                continueWritingLog = true;
            else {
                //system doesnt allow writing log - dont writing debug log
                if (logType != "DebugLog")
                    continueWritingLog = true;
            }

            if (continueWritingLog)
            {
                try
                {
                    string sLogFormat = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss") + " ==> ";
                    string sErrorDate = DateTime.Now.ToString("yyyyMMdd");
                    string sPathName = logType + "_" + sErrorDate + ".log";

                    StreamWriter sw = new StreamWriter(sPathName);
                    sw.WriteLine(sLogFormat + sErrMsg);
                    sw.Flush();
                    sw.Close();
                }
                catch (Exception ex)
                {
                    string er = ex.Message.ToString();
                }
            }
        }        */

        public bool isLive()
        {
            bool ret = false;
            if (AppConfig.WebServiceConnection == "live")
                ret = true;

            return ret;
        }
    }
}
