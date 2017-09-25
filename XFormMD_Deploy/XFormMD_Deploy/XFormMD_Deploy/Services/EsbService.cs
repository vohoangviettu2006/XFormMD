using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using XFormMD_Deploy.Models;
using XFormMD_Deploy.Utils;

namespace XFormMD_Deploy.Services
{
    public class EsbService
    {
        private StringManipulator_PTUD strManipulate = new StringManipulator_PTUD();
        private XmlReader_PTUD xmlReader = new XmlReader_PTUD();
        private Debugging_PTUD debugger = new Debugging_PTUD();

        public string strRootURI = AppConfig.IIB_connectionMethod + "://" + AppConfig.IIB_address + ":" + AppConfig.IIB_port + "/";
        public string strUser = AppConfig.IIB_user;
        public string strSOAP_Begin = "<?xml version=\"1.0\" encoding=\"utf-8\"?>"
            + "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:bian=\"bian.scb.com.vn\">"
            + "<soapenv:Header/>"
            + "<soapenv:Body>";
        public string strSOAP_End = "</soapenv:Body></soapenv:Envelope>";
        public string tranInfo = "<transactionInfo><clientCode>" + AppConfig.IIB_clientCode + "</clientCode></transactionInfo>";
        public string getTranInfo(string clientCode)
        {
            string returnStr = "";
            if (clientCode != "")
                returnStr += "<clientCode>" + clientCode + "</clientCode>";
            return "<transactionInfo>" + returnStr + "</transactionInfo>";
        }

        //class functions
        /*
        public async Task<CustomerDetails> GetCustomerDetails(string inputStr)
        {
            CustomerDetails returnObj = new CustomerDetails();
            XmlDocument document = new XmlDocument();

            var result = await this.retrieveCustomerRefDataMgmt_in(inputStr);
            if (result != null)
            {
                try
                {
                    //debugger.WriteLog("parseToXml/result: " + result);
                    document.LoadXml(result);
                }
                catch (Exception ex)
                {
                    debugger.WriteLog("parseToXml/exception loading xml: " + inputStr + " (" + ex.Message.ToString() + ")", "ErrorLog");
                    throw ex;
                }

            }
            if (document != null)
            {
                XmlNodeList rstNodes = document.GetElementsByTagName("retrieveCustomerRefDataMgmt_out");
                foreach (XmlNode eachNode in rstNodes)
                {
                    returnObj = new CustomerDetails
                    {
                        CIFInfo = new CIFInfo
                        {
                            CIFNum = xmlReader.getData(eachNode.SelectSingleNode("CIFInfo/CIFNum")),
                            CIFIssuedDate = xmlReader.getData(eachNode.SelectSingleNode("CIFInfo/CIFIssuedDate")),
                            BranchCode = xmlReader.getData(eachNode.SelectSingleNode("CIFInfo/branchCode")),
                            CustomerType = xmlReader.getData(eachNode.SelectSingleNode("CIFInfo/customerType"))
                        },
                        CustomerInfo = new CustomerInfo
                        {
                            Fullname = xmlReader.getData(eachNode.SelectSingleNode("customerInfo/fullname")),
                            BirthDay = xmlReader.getData(eachNode.SelectSingleNode("customerInfo/birthDay")),
                            Gender = xmlReader.getData(eachNode.SelectSingleNode("customerInfo/gender")),
                            CustomerVIPType = xmlReader.getData(eachNode.SelectSingleNode("customerInfo/customerVIPType")),
                            ManageStaffID = xmlReader.getData(eachNode.SelectSingleNode("customerInfo/manageStaffID")),
                            JobInfo = new JobInfo
                            {
                                ProfessionalName = xmlReader.getData(eachNode.SelectSingleNode("customerInfo/ProfessionalName"))
                            },
                            IDInfo = new IDInfo
                            {
                                IDNum = xmlReader.getData(eachNode.SelectSingleNode("customerInfo/IDInfo/IDNum")),
                                IDIssuedDate = xmlReader.getData(eachNode.SelectSingleNode("customerInfo/IDInfo/IDIssuedDate")),
                                IDIssuedLocation = xmlReader.getData(eachNode.SelectSingleNode("customerInfo/IDInfo/IDIssuedLocation"))
                            },
                            Address = new Address
                            {
                                Address1 = xmlReader.getData(eachNode.SelectSingleNode("customerInfo/address/address1")),
                                Email = xmlReader.getData(eachNode.SelectSingleNode("customerInfo/address/email")),
                                MobileNum = xmlReader.getData(eachNode.SelectSingleNode("customerInfo/address/mobileNum"))
                            }
                        }
                    };

                    break;
                }
            }

            return returnObj;
        }
        */
        /*
        public async Task<DdFullData> RetrieveDdAccount(string inputStr)
        {
            //"<accountInfo><accountNum>1260900421720055</accountNum></accountInfo>
            DdFullData returnObj = new DdFullData();
            XmlDocument document = new XmlDocument();

            var result = await this.retrieveCurrentAccountCASA_in(inputStr);
            if (result != null)
            {
                try
                {
                    //debugger.WriteLog("parseToXml/result: " + result);
                    document.LoadXml(result);
                }
                catch (Exception ex)
                {
                    debugger.WriteLog("parseToXml/exception loading xml: " + inputStr + " (" + ex.Message.ToString() + ")", "ErrorLog");
                    throw ex;
                }

            }
            if (document != null)
            {
                #region retrieveCurrentAccountCASA_out
                XmlNodeList rstNodes = document.GetElementsByTagName("retrieveCurrentAccountCASA_out");
                foreach (XmlNode eachNode in rstNodes)
                {
                    returnObj = new DdFullData
                    {
                        CIFInfo = new CIFInfo
                        {
                            CIFNum = getData(eachNode.SelectSingleNode("accountInfo/CIFInfo/CIFNum")),
                        },
                        customerInfo = new customerInfo
                        {
                            fullname = getData(eachNode.SelectSingleNode("accountInfo/customerInfo/fullname")),
                        },

                        accountNum = getData(eachNode.SelectSingleNode("accountInfo/accountNum")),
                        accountName = getData(eachNode.SelectSingleNode("accountInfo/accountName")),
                        accountType = getData(eachNode.SelectSingleNode("accountInfo/accountType")),
                        accountTypeName = getData(eachNode.SelectSingleNode("accountInfo/accountTypeName")),
                        accountCurrency = getData(eachNode.SelectSingleNode("accountInfo/accountCurrency")),
                        accountClassName = getData(eachNode.SelectSingleNode("accountInfo/accountClassName")),


                        accountBalance = getData(eachNode.SelectSingleNode("accountInfo/accountBalance")),
                        accountBalanceAvailable = getData(eachNode.SelectSingleNode("accountInfo/accountBalanceAvailable")),
                        accountOpenDate = getData(eachNode.SelectSingleNode("accountInfo/accountOpenDate")),
                        accountOpenBrandCode = getData(eachNode.SelectSingleNode("accountInfo/accountOpenBrandCode")),
                        accountLatestTransDate = getData(eachNode.SelectSingleNode("accountInfo/accountLatestTransDate")),
                        accountOverdraftDate = getData(eachNode.SelectSingleNode("accountInfo/accountOverdraftDate")),
                        accountOverdraftExpiredDate = getData(eachNode.SelectSingleNode("accountInfo/accountOverdraftExpiredDate")),
                        accountOverdraftLimit = getData(eachNode.SelectSingleNode("accountInfo/accountOverdraftLimit")),
                        accountDelegatedPerson = getData(eachNode.SelectSingleNode("accountInfo/accountDelegatedPerson")),
                        accountCoownerName = getData(eachNode.SelectSingleNode("accountInfo/accountCoownerName")),
                        accountAuthorizedStatus = getData(eachNode.SelectSingleNode("accountInfo/accountAuthorizedStatus")),
                        accountStatus = getData(eachNode.SelectSingleNode("accountInfo/accountStatus")),


                    };

                    break;
                }
                #endregion

            }

            return returnObj;
        }
        */

        //processing functions
        public async Task<string> retrieveCustomerRefDataMgmt_in(string strKeyword)
        {
            return await this.sendSoapRequest(strKeyword, "retrieveCustomerRefDataMgmt_in", "customerrefdatamgmt", "v1.0", AppConfig.IIB_clientCode);
        }



        //utilities function
        public async Task<string> sendSoapRequest(string strKeyword, string functionName, string collectionName, string version, string clientCode)
        {
            string directionalParams = "";
            return await sendSoapRequest(strKeyword, functionName, collectionName, version, clientCode, "", "", directionalParams);
        }
        public async Task<string> sendSoapRequest(string strKeyword, string functionName, string collectionName, string version, string clientCode, string extraParam2, string extraParam1, string directionalParams)
        {
            string soap = this.strSOAP_Begin + "<bian:" + functionName + ">" + this.getTranInfo(clientCode)
                + extraParam1 + strKeyword + extraParam2 + "</bian:" + functionName + ">" + this.strSOAP_End;
            HttpClient client = new HttpClient();
            // authorization
            var credentials = Encoding.UTF8.GetBytes(this.strUser);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(credentials));

            var uri = this.strRootURI + collectionName + "/" + version + "/ws";
            var content = new StringContent(soap, Encoding.UTF8, "text/xml");
            //string sPathName = debugger.WriteLogInput("sendSoapRequest[" + AppConfig.IIB_address + "-" + AppConfig.IIB_connectionMethod + "-" + AppConfig.IIB_port + "-" + AppConfig.IIB_clientCode + "]/input: " + soap, "sendSoapRequest");
            //write pushCoreLog Here
           // PsCore psCoreLog = xmlReader.writeESPInputLog(functionName, soap, directionalParams);
            try
            {
                using (var response = await client.PostAsync(uri, content))
                {
                    var soapResponse = await response.Content.ReadAsStringAsync();
                    //debugger.WriteLogOutput("sendSoapRequest[" + AppConfig.IIB_address + "-" + AppConfig.IIB_connectionMethod + "-" + AppConfig.IIB_port + "-" + AppConfig.IIB_clientCode + "]/output: " + strManipulate.cleanFcdbErrorMessage(soapResponse), "sendSoapRequest", sPathName);
                    //if (psCoreLog != null && psCoreLog.ID != 0)
                        //xmlReader.updateESPLogStatus(psCoreLog.ID, strManipulate.cleanFcdbErrorMessage(soapResponse));

                    return strManipulate.cleanFcdbErrorMessage(soapResponse);
                }
            }
            catch (Exception)
            {
                //throw;
            }

            return null;
        }
        public async Task<string> sendSoapInitRequest(string functionParams, string functionName, string collectionName, string version, string directionalParams)
        {
            string soap = this.strSOAP_Begin + "<bian:" + functionName + ">" + functionParams + "</bian:" + functionName + ">" + this.strSOAP_End;

            HttpClient client = new HttpClient();
            // authorization
            var credentials = Encoding.UTF8.GetBytes(this.strUser);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(credentials));

            var uri = this.strRootURI + collectionName + "/" + version + "/ws";
            var content = new StringContent(soap, Encoding.UTF8, "text/xml");
            //string sPathName = debugger.WriteLogInput("sendSoapInitRequest[" + AppConfig.IIB_address + "-" + AppConfig.IIB_connectionMethod + "-" + AppConfig.IIB_port + "-" + AppConfig.IIB_clientCode + "]/input: " + soap, "sendSoapInitRequest");
            //write pushCoreLog Here
            //PsCore psCoreLog = xmlReader.writeESPInputLog(functionName, soap, directionalParams);
            try
            {
                using (var response = await client.PostAsync(uri, content))
                {
                    var soapResponse = await response.Content.ReadAsStringAsync();
                    //debugger.WriteLogOutput("sendSoapInitRequest[" + AppConfig.IIB_address + "-" + AppConfig.IIB_connectionMethod + "-" + AppConfig.IIB_port + "-" + AppConfig.IIB_clientCode + "]/output: " + strManipulate.cleanFcdbErrorMessage(soapResponse), "sendSoapInitRequest", sPathName);
                    //if (psCoreLog != null && psCoreLog.ID != 0)
                        //xmlReader.updateESPLogStatus(psCoreLog.ID, strManipulate.cleanFcdbErrorMessage(soapResponse));

                    return strManipulate.cleanFcdbErrorMessage(soapResponse);
                }
            }
            catch (Exception)
            {
                //throw;
            }

            return null;
        }

    }
}
