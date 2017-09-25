/*using Android.Util;*/
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
            //string logType = "DebugLog";
            //this.WriteLog(sErrMsg, logType);
            Log.Info("XFormMD_Deploy", sErrMsg);
        }
        public void WriteLog(string sErrMsg, string logType)
        {
            bool continueWritingLog = false;

            //system allow writing log - write all log types
            if (AppConfig.WriteLog == "true")
                continueWritingLog = true;
            else {
                //system doesnt allow writing log - dont writing debug log
                if (logType.Trim() != "Info")
                    continueWritingLog = true;
            }

            if (continueWritingLog)
            {
                switch (logType.Trim()) {
                    case "Info":
                        Log.Info("XFormMD_Deploy", sErrMsg);
                        break;
                    case "Warn":
                        Log.Warn("XFormMD_Deploy", sErrMsg);
                        break;
                    case "Error":
                        Log.Error("XFormMD_Deploy", sErrMsg);
                        break;
                    default:
                        break;
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
