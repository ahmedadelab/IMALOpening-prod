using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Data;
using System.Net;
using System.Xml;
using System.Xml.Linq;

namespace IMALOpening
{
    public class DLL_Code
    {

        DAL_Code DalCode = new DAL_Code();

        public static HttpWebRequest CreateWebRequestOpenAcc()
        {
            var MyConfig = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var OpenAcc = MyConfig.GetValue<string>("AppSettings:OpenAccUrl");
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(OpenAcc);
            webRequest.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
            webRequest.Headers.Add(@"SOAP:Action");
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            return webRequest;
        }
        public static HttpWebRequest CreateWebRequestCIF()
        {
            var MyConfig = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var CreateCIF = MyConfig.GetValue<string>("AppSettings:CreateCIF");
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(CreateCIF);
            webRequest.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
            webRequest.Headers.Add(@"SOAP:Action");
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            return webRequest;
        }

        public static HttpWebRequest CreateWebRequestValidateCIF()
        {
            var MyConfig = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var CreateValidateCIF = MyConfig.GetValue<string>("AppSettings:ValidateCIFUrl");
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(CreateValidateCIF);
            webRequest.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
            webRequest.Headers.Add(@"SOAP:Action");
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            return webRequest;
        }
        public string CheckChannel(String ChannelName, string username, string ServiceName)
        {
            string ChannelIP = "";
            string statusChannel = "";
            string EnableChannel = "";
            DataTable dt_Channel = DalCode.IMALChannelstatus(ChannelName, username, ChannelIP, ServiceName);
            DLL_Code[] BR_Channel = new DLL_Code[dt_Channel.Rows.Count];


            if (BR_Channel.Length != 0)
            {
                int ii;
                for (ii = 0; ii < dt_Channel.Rows.Count; ii++)
                {

                    EnableChannel = dt_Channel.Rows[ii]["EnableChannel"].ToString().Trim();
                }
            }
            if (EnableChannel == "1")
            {
                statusChannel = "Enabled";
            }
            else
            {
                statusChannel = "Disabled";
            }
            return statusChannel;
        }

        public class ReqCreateCIF
        {
            public string? cifType { get; set; }
            public string? idType { get; set; }
            public string? idNumber { get; set; }
            public string? dateOFbirth { get; set; }
            public string? idExpiryDate { get; set; }
            public string? maritalStatus { get; set; }
            public string? gender { get; set; }
            public string? language { get; set; }
            public string? shortName { get; set; }
            public string? longName { get; set; }
            public string? shortNameArabic { get; set; }
            public string? longNameArabic { get; set; }
            public string? nationality { get; set; }
            public string? country { get; set; }
            public string? firstName { get; set; }
            public string? secondName { get; set; }
            public string? thirdName { get; set; }
            public string? lastName { get; set; }
            public string? firstNameArabic { get; set; }
            public string? secondNameArabic { get; set; }
            public string? thirdNameArabic { get; set; }
            public string? lastNameArabic { get; set; }
            public string? block { get; set; }

            public string? blockenglish { get; set; }
            public string? mobile { get; set; }
            public string? area { get; set; }
            public string? addressCountry { get; set; }
            public string? modeOfStatementDelivery { get; set; }
            public string? statement { get; set; }
            public string? economicSector { get; set; }
            public string? legalStatus { get; set; }
            public string? ranking { get; set; }
            public string? occupation { get; set; }
            public string? division { get; set; }
            public string? department { get; set; }
            public string? username { get; set; }
            public string? password { get; set; }

            public string? channelName { get; set; }

            public string? CorpCIF { get; set; }

            public string? CIFBranch { get; set; }

        }

        public class RespCreateCIF
        {
            public string? StatusCode { get; set; }

            public string? StatusDesc { get; set; }

            public string? CIF { get; set; }
        }

        public class ReqValidiateCIF
        {

            public string? CIFno { get; set; }
            public string? autoApproveFlag { get; set; }

            public string? username { get; set; }

            public string? password { get; set; }


        }

        public class RespValidateCIF
        {
            public string? statusCode { get; set; }

            public string? statusDesc { get; set; }
        }
    
        public class ReqCreateGL
        {
            public string? CIF { get; set; }
            public string? currency { get; set; }
            public string? accGl { get; set; }
            public string? Branch { get; set; }
            public string? username { get; set; }

            public string? Password { get; set; }
            public string? ChannelName { get; set; }
        }

        public class RespCreateGL
        {
            public string? additionalRef { get; set; }

            public string? ibanAccNo { get; set; }

            public string? statusCode { get; set; }

            public string? statusDesc { get; set; }
        }
       public string CreateCIF(string cifType, string idType, string idNumber,string Country_of_issuance, string dateOFbirth, string idExpiryDate, string maritalStatus, string gender, string language,
       string shortName, string longName, string shortNameArabic, string longNameArabic, string nationality, string country, string firstName, string secondName,
       string thirdName, string lastName, string firstNameArabic, string secondNameArabic, string thirdNameArabic, string lastNameArabic, string block,string blockenglish, string mobile, string area,
       string addressCountry, string modeOfStatementDelivery, string statement, string economicSector, string legalStatus, string ranking, string occupation, string division,
       string department, string username, string password,string channelName,string CorpCIF,string CIFBranch)
        {
            string SstatusCode = "";
            string SstatusDesc = "";
            string soapResult = "";
            string RequestID = "MW-CIFC-" + idNumber + "-" + DateTime.Now.ToString("ddMMyyyyHHmmssff");
            string requesterTimeStamp = System.DateTime.Now.ToString("yyyy-MM-dd" + "T" + "HH:mm:ss");
            List<ReqCreateCIF> logrequest = new List<ReqCreateCIF>();
            List<RespCreateCIF> LogResp = new List<RespCreateCIF>();
            try
            {
                string status = CheckChannel(channelName, username, "CreateCIF");

                logrequest.Add(new ReqCreateCIF
                {

                    cifType = cifType,
                    idType = idType,
                    idNumber = idNumber,
                    dateOFbirth = dateOFbirth,
                    idExpiryDate = idExpiryDate,
                    maritalStatus = maritalStatus,
                    gender = gender,
                    language = language,
                    shortName = shortName,
                    longName = longName,
                    shortNameArabic = shortNameArabic,
                    longNameArabic= longNameArabic,
                    nationality = nationality,
                    country = country,
                    firstName = firstName,
                    secondName = secondName,
                    thirdName = thirdName,
                    lastName = lastName,
                    firstNameArabic = firstNameArabic,
                    secondNameArabic = secondNameArabic,
                    thirdNameArabic = thirdNameArabic,
                    lastNameArabic = lastNameArabic,
                    block = block,
                    blockenglish = blockenglish,
                    mobile = mobile,
                    area = area,
                    addressCountry = addressCountry,
                    modeOfStatementDelivery = modeOfStatementDelivery,
                    statement = statement,
                    economicSector = economicSector,
                    legalStatus = legalStatus,
                    ranking = ranking,
                    occupation = occupation,
                    division = division,
                    CorpCIF = CorpCIF,
                    CIFBranch= CIFBranch,
                    channelName = channelName,
                    username= username,
                    password = "*******"
                });
                string ClientRequest = JsonConvert.SerializeObject(logrequest);
                DalCode.InsertLog("CreateCIF", Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")), ClientRequest, "Pending", channelName, RequestID);
       
                if (status == "Enabled")
                {
                    HttpWebRequest request = CreateWebRequestCIF();
                    XmlDocument soapEnvelopeXml = new XmlDocument();

                    soapEnvelopeXml.LoadXml(@"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:cif=""cifManagementWs"" >
   <soapenv:Header/>
   <soapenv:Body>
   <cif:createRetailCif>
         <!--You may enter the following 20 items in any order-->
         <!--Optional:-->
         <serviceContext>
            <!--You may enter the following 6 items in any order-->
            <!--Optional:-->
            <businessArea>Retail</businessArea>
            <!--Optional:-->
            <businessDomain>Products</businessDomain>
            <!--Optional:-->
            <operationName>createRetailCif</operationName>
            <!--Optional:-->
            <serviceDomain>CifManagement</serviceDomain>
            <!--Optional:-->
            <serviceID>1901</serviceID>
            <!--Optional:-->
            <version>1.0</version>
         </serviceContext>
         
         <companyCode>1</companyCode>
         <branchCode>"+ CIFBranch + @"</branchCode>
         <cifBranch>"+ CIFBranch + @"</cifBranch>
         
         <cifDetails> <!-- P -->
         
            <cifType>" + cifType + @"</cifType>
            <idType>" + idType + @"</idType>
            <idNumber>" + idNumber + @"</idNumber>
            <dateOfBirth>" + dateOFbirth + @"</dateOfBirth>
            <countryOfIssuance>" + Country_of_issuance + @"</countryOfIssuance>
            <idExpiryDate>" + idExpiryDate + @"</idExpiryDate>
            <maritalStatus>" + maritalStatus + @"</maritalStatus>
            <gender>" + gender + @"</gender>
            <language>" + language + @"</language>
            <shortName>" + shortName + @"</shortName>
            <longName>" + longName + @"</longName>
            <shortNameArabic>" + shortNameArabic + @"</shortNameArabic>
            <longNameArabic>" + longNameArabic + @"</longNameArabic>
            <nationality>" + nationality + @"</nationality>
            <country>" + country + @"</country>
            <firstName>" + firstName + @"</firstName>
            <secondName>" + secondName + @"</secondName>
            <thirdName>" + thirdName + @"</thirdName>
            <lastName>" + lastName + @"</lastName>
            <firstNameArabic>" + firstNameArabic + @"</firstNameArabic>
            <secondNameArabic>" + secondNameArabic + @"</secondNameArabic>
            <thirdNameArabic>" + thirdNameArabic + @"</thirdNameArabic>
            <lastNameArabic>" + lastNameArabic + @"</lastNameArabic>

            <addressList>
               <addressDetailsCreateDC>
      <addressDescriptionEnglish>" + blockenglish + @"</addressDescriptionEnglish>
                  <block>" + blockenglish + @"</block>
                  <blockArabic>" + block + @"</blockArabic>
                  <mobile>" + mobile + @"</mobile>
                  <area>" + area + @"</area>
                  <country>" + addressCountry + @"</country>
               </addressDetailsCreateDC>
            </addressList>
            
            <modeOfStatementDelivery>" + modeOfStatementDelivery + @"</modeOfStatementDelivery>
            <statement>" + statement + @"</statement>
            
         </cifDetails>

         <additionalDetails> <!-- P -->
            <economicSector>" + economicSector + @"</economicSector>
            <legalStatus>" + legalStatus + @"</legalStatus>
            <ranking>" + ranking + @"</ranking>
            <occupation>" + occupation + @"</occupation>
            <division>" + division + @"</division>
            <department>" + department + @"</department>
            <agent>"+CorpCIF+ @"</agent>
            <kyc>Y</kyc>
         
         </additionalDetails>
         

         
         <requestContext>
            <requestID>" + RequestID + @"</requestID>
            <!--<coreRequestTimeStamp>" + requesterTimeStamp + @"</coreRequestTimeStamp>-->
            <!--<requestKernelDetails>?</requestKernelDetails>-->
         </requestContext>
         <requesterContext>
            <channelID>1</channelID>
            <hashKey>1</hashKey>
              <langId>EN</langId>
            <password>" + password + @"</password>
            <requesterTimeStamp>" + requesterTimeStamp + @"</requesterTimeStamp>
            <userID>" + username + @"</userID>
         </requesterContext>
         <!--Optional:-->
         <vendorContext>
            <!--You may enter the following 3 items in any order-->
            <!--Optional:-->
            <license>Copyright 2018 Path Solutions. All Rights Reserved</license>
            <!--Optional:-->
            <providerCompanyName>Path Solutions</providerCompanyName>
            <!--Optional:-->
            <providerID>IMAL</providerID>
         </vendorContext>
      </cif:createRetailCif>
   </soapenv:Body>
</soapenv:Envelope>
");

                    using (Stream stream = request.GetRequestStream())
                    {
                        soapEnvelopeXml.Save(stream);
                    }

                    string ResponseCIF = "";
                    using (WebResponse response = request.GetResponse())
                    {
                        using (StreamReader rd = new StreamReader(response.GetResponseStream()))
                        {
                            soapResult = rd.ReadToEnd();
                            Console.WriteLine(soapResult);
                            var str = XElement.Parse(soapResult);
                            XmlDocument xmlDoc = new XmlDocument();
                            xmlDoc.LoadXml(soapResult);
                            XmlNodeList elemlistCode = xmlDoc.GetElementsByTagName("statusCode");
                            SstatusCode = elemlistCode[0].InnerXml;
                            XmlNodeList elstatusDesc = xmlDoc.GetElementsByTagName("statusDesc");
                            SstatusDesc = elstatusDesc[0].InnerXml;
                            if (SstatusCode == "0")
                            { 
                                XmlNodeList ELCIF = xmlDoc.GetElementsByTagName("cifNo");
                            ResponseCIF = ELCIF[0].InnerXml;
                        }

                        }
                    }
                    LogResp.Add(new RespCreateCIF
                    {
                        StatusCode = SstatusCode,
                        StatusDesc = SstatusDesc,
                        CIF = ResponseCIF

                    });
                }
                else
                {
                    LogResp.Add(new RespCreateCIF
                    {
                    StatusCode = "-985",
                    StatusDesc = "you are not authorize"


                    });
                }
                string statuslog = "";
                if (SstatusCode == "0")
                {
                    statuslog = "Success";
                }
                else
                {
                    statuslog = "Failed";
                }
                DalCode.UpdateLog(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), JsonConvert.SerializeObject((LogResp)), statuslog, channelName, RequestID);

            }
            catch(Exception ex)
            {
                Console.WriteLine(DateTime.Now +"\n"+"ID Number: "+idNumber+ "\n"+ ex.StackTrace);
            }
            return JsonConvert.SerializeObject((LogResp)); 
        }

        public string CIFVALIDATE(string CIF,string username,string ChannelName,string password)
        {
            string SstatusCode = "";
            string SstatusDesc = "";
            string soapResult = "";
            string RequestID = "MW-CIFV-" + CIF + "-" + DateTime.Now.ToString("ddMMyyyyHHmmssff");
            string requesterTimeStamp = System.DateTime.Now.ToString("yyyy-MM-dd" + "T" + "HH:mm:ss");
            List<ReqValidiateCIF> logrequest = new List<ReqValidiateCIF>();
            List<RespValidateCIF> LogResp = new List<RespValidateCIF>();
            try
            {
                string status = CheckChannel(ChannelName, username, "ValidateCIF");

                logrequest.Add(new ReqValidiateCIF
                {
                    CIFno = CIF,
                    autoApproveFlag ="1",
                    username= username,
                    password ="*******"


                });
                string ClientRequest = JsonConvert.SerializeObject(logrequest);
                DalCode.InsertLog("ValidateCIF", Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")), ClientRequest, "Pending", ChannelName, RequestID);
                if (status == "Enabled")
                {
                    HttpWebRequest request = CreateWebRequestCIF();
                    XmlDocument soapEnvelopeXml = new XmlDocument();

                    soapEnvelopeXml.LoadXml(@"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:cif=""cifManagementWs"">
   <soapenv:Header/>
   <soapenv:Body>
      <cif:validateRetailCif>
         <!--You may enter the following 27 items in any order-->
         <!--Optional:-->
         <serviceContext>
            <!--You may enter the following 6 items in any order-->
            <!--Optional:-->
            <businessArea>Retail</businessArea>
            <!--Optional:-->
            <businessDomain>Products</businessDomain>
            <!--Optional:-->
            <operationName>validateRetailCif</operationName>
            <!--Optional:-->
            <serviceDomain>CifManagement</serviceDomain>
            <!--Optional:-->
            <serviceID>1903</serviceID>
            <!--Optional:-->
            <version>1.0</version>
         </serviceContext>

         
         <companyCode>1</companyCode>
         <branchCode>5599</branchCode>
         <cifNo>" + CIF + @"</cifNo> <!-- P -->
         <autoApproveFlag>1</autoApproveFlag>      
         <additionalFieldsList> <!-- P -->        
            <additionalField>
               <fieldCode>6</fieldCode>
<!--               <valueDate>?</valueDate>
-->
<!--               <valueVarchar>?</valueVarchar>           
-->
               <valueNumber>59</valueNumber> <!-- P -->
            </additionalField>
            <additionalField>
               <fieldCode>7</fieldCode>
<!--               <valueDate>?</valueDate>-->
<!--               <valueVarchar>?</valueVarchar>-->
               <valueNumber>66</valueNumber>
            </additionalField>
            <additionalField>
               <fieldCode>9</fieldCode>
<!--               <valueDate>?</valueDate>-->
<!--               <valueVarchar>?</valueVarchar>-->
               <valueNumber>1</valueNumber>
            </additionalField>
            <additionalField>
               <fieldCode>17</fieldCode>
<!--               <valueDate>?</valueDate>-->
<!--               <valueVarchar>?</valueVarchar>-->
               <valueNumber>7</valueNumber>
            </additionalField>
            <additionalField>
               <fieldCode>109</fieldCode>
<!--               <valueDate>?</valueDate>-->
<!--               <valueVarchar>?</valueVarchar>-->
               <valueNumber>1</valueNumber>
            </additionalField>
            <additionalField>
               <fieldCode>110</fieldCode>
<!--               <valueDate>?</valueDate>-->
               <valueVarchar>0</valueVarchar>
<!--               <valueNumber>0</valueNumber>-->
            </additionalField>
            <additionalField>
               <fieldCode>111</fieldCode>
<!--               <valueDate>?</valueDate>-->
<!--               <valueVarchar>0</valueVarchar>-->
               <valueNumber>1</valueNumber>
            </additionalField>
         </additionalFieldsList>         
         <requestContext>
            <requestID>" + RequestID + @"</requestID>
            <coreRequestTimeStamp>" + requesterTimeStamp + @"</coreRequestTimeStamp>
            <!--<requestKernelDetails>?</requestKernelDetails>-->
         </requestContext>
         <requesterContext>
            <channelID>1</channelID>
            <hashKey>1</hashKey>
              <langId>EN</langId>
            <password>" + password + @"</password> <!-- P -->
            <requesterTimeStamp>" + requesterTimeStamp + @"</requesterTimeStamp>
            <userID>" + username + @"</userID> <!-- P -->
         </requesterContext> 


         
         <!--Optional:-->
         <vendorContext>
            <!--You may enter the following 3 items in any order-->
            <!--Optional:-->
            <license>Copyright 2018 Path Solutions. All Rights Reserved</license>
            <!--Optional:-->
            <providerCompanyName>Path Solutions</providerCompanyName>
            <!--Optional:-->
            <providerID>IMAL</providerID>
         </vendorContext>
      </cif:validateRetailCif>
   </soapenv:Body>
</soapenv:Envelope>
");

                    using (Stream stream = request.GetRequestStream())
                    {
                        soapEnvelopeXml.Save(stream);
                    }

                    string ResponseCIF = "";
                    using (WebResponse response = request.GetResponse())
                    {
                        using (StreamReader rd = new StreamReader(response.GetResponseStream()))
                        {
                            soapResult = rd.ReadToEnd();
                            Console.WriteLine(soapResult);
                            var str = XElement.Parse(soapResult);
                            XmlDocument xmlDoc = new XmlDocument();
                            xmlDoc.LoadXml(soapResult);
                            XmlNodeList elemlistCode = xmlDoc.GetElementsByTagName("statusCode");
                            SstatusCode = elemlistCode[0].InnerXml;
                            XmlNodeList elstatusDesc = xmlDoc.GetElementsByTagName("statusDesc");
                            SstatusDesc = elstatusDesc[0].InnerXml;

                        }
                    }
                    LogResp.Add(new RespValidateCIF
                    {
                        statusCode = SstatusCode,
                        statusDesc = SstatusDesc
                   

                    });
                }
                else
                {
                        LogResp.Add(new RespValidateCIF
                        {
                            statusCode = "-985",
                            statusDesc = "you are not authorize"


                        });
                    }
                    string statuslog = "";
                    if (SstatusCode == "0")
                    {
                        statuslog = "Success";
                    }
                    else
                    {
                        statuslog = "Failed";
                    }
                    DalCode.UpdateLog(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), JsonConvert.SerializeObject((LogResp)), statuslog, ChannelName, RequestID);
                }
            catch(Exception ex)
            {
                Console.WriteLine(DateTime.Now +"\n"+"Error on CIF Validation:"+CIF+"\n"+ ex.StackTrace);
            }
            return JsonConvert.SerializeObject((LogResp));

        }


        public string GLCreation(string CIF,string currency,string accGl,string Branch,string username,string password,string channelName)
        {
            string SstatusCode = "";
            string SstatusDesc = "";
            string soapResult = "";
            string RequestID = "MW-GLC-" + CIF + "-" + DateTime.Now.ToString("ddMMyyyyHHmmssff");
            string requesterTimeStamp = System.DateTime.Now.ToString("yyyy-MM-dd" + "T" + "HH:mm:ss");
            List<ReqCreateGL> logrequest = new List<ReqCreateGL>();
            List<RespCreateGL> LogResp = new List<RespCreateGL>();
            try
            {
                string status = CheckChannel(channelName, username, "CreateGL");
                logrequest.Add(new ReqCreateGL
                {
                    CIF = CIF,
                    currency = currency,
                    accGl = accGl,
                    Branch = Branch,
                    username = username,
                    Password = "*******",
                    ChannelName = channelName
                });

                string ClientRequest = JsonConvert.SerializeObject(logrequest);
                DalCode.InsertLog("CreateGL", Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")), ClientRequest, "Pending", channelName, RequestID);
                if (status == "Enabled")
                {
                    HttpWebRequest request = CreateWebRequestOpenAcc();
                    XmlDocument soapEnvelopeXml = new XmlDocument();
                    soapEnvelopeXml.LoadXml(@"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:gen=""generalAccountsWs"">
   <soapenv:Header/>
   <soapenv:Body>
      <gen:createGeneralAccount>
         <!--You may enter the following 24 items in any order-->
         <!--Optional:-->
         <serviceContext>
            <!--You may enter the following 6 items in any order-->
            <!--Optional:-->
            <businessArea>Retail</businessArea>
            <!--Optional:-->
            <businessDomain>Products</businessDomain>
            <!--Optional:-->
            <operationName>createGeneralAccount</operationName>
            <!--Optional:-->
            <serviceDomain>GeneralAccounts</serviceDomain>
            <!--Optional:-->
            <serviceID>806</serviceID>
            <!--Optional:-->
            <version>1.0</version>
         </serviceContext>

         
         <companyCode>1</companyCode>
         <branchCode>" + Branch + @"</branchCode>
         <branch>" + Branch + @"</branch>
         <currency>" + currency + @"</currency>
         <accGl>" + accGl + @"</accGl>
         <cifNo>" + CIF + @"</cifNo>
         
         <accountDetails>
<!--            <economicSector>1</economicSector>-->
<!--            <subEconomicSector>1</subEconomicSector>-->
         </accountDetails>


         
         <autoApproveFlag>1</autoApproveFlag>

         <!--Optional:-->
        <requestContext>
            <requestID>" + RequestID + @"</requestID>
            <coreRequestTimeStamp>" + requesterTimeStamp + @"</coreRequestTimeStamp>
            <!--<requestKernelDetails>?</requestKernelDetails>-->
         </requestContext>
         <requesterContext>
            <channelID>1</channelID>
            <hashKey>1</hashKey>
              <langId>EN</langId>
            <password>" + password + @"</password>
            <requesterTimeStamp>" + requesterTimeStamp + @"</requesterTimeStamp>
            <userID>" + username + @"</userID>
         </requesterContext>
         <!--Optional:-->
         <vendorContext>
            <!--You may enter the following 3 items in any order-->
            <!--Optional:-->
            <license>Copyright 2018 Path Solutions. All Rights Reserved</license>
            <!--Optional:-->
            <providerCompanyName>Path Solutions</providerCompanyName>
            <!--Optional:-->
            <providerID>IMAL</providerID>
         </vendorContext>
      </gen:createGeneralAccount>
   </soapenv:Body>
</soapenv:Envelope>
");


                    using (Stream stream = request.GetRequestStream())
                    {
                        soapEnvelopeXml.Save(stream);
                    }

                  
                
                    string IbanAccNo = "";
                 
                    string additionalRef = "";
                    using (WebResponse response = request.GetResponse())
                    {
                        using (StreamReader rd = new StreamReader(response.GetResponseStream()))
                        {
                            soapResult = rd.ReadToEnd();
                            Console.WriteLine(soapResult);
                            var str = XElement.Parse(soapResult);
                            XmlDocument xmlDoc = new XmlDocument();
                            xmlDoc.LoadXml(soapResult);
                            XmlNodeList elemStatusCode = xmlDoc.GetElementsByTagName("statusCode");
                        
                            SstatusCode = elemStatusCode[0].InnerXml;
                            XmlNodeList elstatusDesc = xmlDoc.GetElementsByTagName("statusDesc");
                            SstatusDesc = elstatusDesc[0].InnerXml;

                            if (SstatusCode == "0")
                            {
                        
                         
                  
                                XmlNodeList elemIbanAccNo = xmlDoc.GetElementsByTagName("ibanAccNo");
                                IbanAccNo = elemIbanAccNo[0].InnerXml;
                   
                          
                                XmlNodeList elemAddRef = xmlDoc.GetElementsByTagName("additionalRef");
                                additionalRef = elemAddRef[0].InnerXml;
                            }

                            LogResp.Add(new RespCreateGL
                            {
                              
                                ibanAccNo = IbanAccNo,
                                additionalRef= additionalRef,
                                statusCode = SstatusCode,
                                statusDesc = SstatusDesc
                            });
                        }
                    }

                }
                else
                {
                    LogResp.Add(new RespCreateGL
                    {
                        statusCode = "-985",
                        statusDesc = "you are not authorize"


                    });
                }
                string statuslog = "";
                if (SstatusCode == "0")
                {
                    statuslog = "Success";
                }
                else
                {
                    statuslog = "Failed";
                }
                DalCode.UpdateLog(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), JsonConvert.SerializeObject((LogResp)), statuslog, channelName, RequestID);

            }
            catch (Exception ex)
            {
                Console.WriteLine(DateTime.Now +"\n" +" Create GL Error for CIF No:"+CIF+ "\n"+ ex.StackTrace);
            }
            return JsonConvert.SerializeObject((LogResp));
        }

    }
}
