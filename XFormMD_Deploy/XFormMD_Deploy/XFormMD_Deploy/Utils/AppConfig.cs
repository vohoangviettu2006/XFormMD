using System;
using System.Collections.Generic;
using System.Text;

namespace XFormMD_Deploy.Utils
{
    public class AppConfig
    {
        public static string[] IIBConnectionRestriction = new string[] { };
        public static string[] IIBConnectionException = new string[] { "NONE" };
        public static string IIB_user = "tester:123456";
        public static string IIB_connectionMethod = "http";
        public static string IIB_address = "192.168.73.49";
        public static string IIB_port = "7890";
        public static string IIB_clientCode = "INAPPTABLET";

        public static string WriteLog = "true";
        public static string WriteWsLog = "true";
        public static string WebServiceConnection = "test";
    }
}
