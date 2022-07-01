

using System;
using System.Xml;
using tsogosun.com.GamingSystemIGT.Model.IGTCountryInfoDto.Request;
using tsogosun.com.GamingSystemIGT.Model.IGTCountryInfoDto.Response;
using tsogosun.com.GamingSystemIGT.Service.Interface;
using tsogosun.com.GamingSystemIGT.Shared;
using tsogosun.com.GamingSystemIGT.XmlTransform.Interface;

namespace tsogosun.com.GamingSystemIGT.Service
{
    public class CountryInfoIGTService : ICountryInfoIGTService
    {

        private IADISoapServiceIGT _aDISoapServiceIGT;
        private ICountryInfoIGTXMLTransform _countryInfoIGTXMLTransform;

        public CountryInfoIGTService(IADISoapServiceIGT aDISoapServiceIGT,
                                        ICountryInfoIGTXMLTransform countryInfoIGTXMLTransform)
        {

            _aDISoapServiceIGT = aDISoapServiceIGT;
            _countryInfoIGTXMLTransform = countryInfoIGTXMLTransform;
        }

        public ResponseIGTCountryInfo GetIGTCountryInfoName(RequestIGTCountryInfo requestIGTCountryInfo) 
        {

              string requestBody = @$"<?xml version=""1.0"" encoding=""UTF-8""?>
                                    <CRMAcresMessage xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xsi:noNamespaceSchemaLocation=""C:\XSD\CRM.xsd"">
                                        <Header>
                                            <TimeStamp>{DateTime.Now}</TimeStamp>
                                            <Operation Data=""CountryInfo"" Operand=""Request""  WhereClause=""{requestIGTCountryInfo.ConditionClause} = {requestIGTCountryInfo.ConditionValue}"" MaxRecords =""5"" TotalRecords = ""1"" />
                                        </Header>
                                      </CRMAcresMessage>";

            XmlDocument countryInfoResponse = new XmlDocument();

            countryInfoResponse.LoadXml(_aDISoapServiceIGT.GetResponse(requestIGTCountryInfo.IpAddress, requestBody));

            return _countryInfoIGTXMLTransform.GetIGTResponseCountryInfo(countryInfoResponse);

        }
        public ResponseIGTZipCode GetIGTZipCode(RequestIGTZipCode requestIGTZipCode)
        {

            string requestBody = @$"<?xml version=""1.0"" encoding=""UTF-8""?>
                                    <CRMAcresMessage xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xsi:noNamespaceSchemaLocation=""C:\XSD\CRM.xsd"">
                                        <Header>
                                            <TimeStamp>{DateTime.Now}</TimeStamp>
                                            <Operation Data=""ZipCode"" Operand=""Request""  WhereClause=""{requestIGTZipCode.ConditionClause} = {requestIGTZipCode.ConditionValue}"" MaxRecords =""5"" TotalRecords = ""1"" />
                                        </Header>
                                       <PlayerID>1</PlayerID>
                                      </CRMAcresMessage>";

            XmlDocument zipcodeResponse = new XmlDocument();

            zipcodeResponse.LoadXml(_aDISoapServiceIGT.GetResponse(requestIGTZipCode.IpAddress, requestBody));

            return _countryInfoIGTXMLTransform.GetIGTResponseZipCode(zipcodeResponse);

        }
    }
}
