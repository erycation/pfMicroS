
using System.Linq;
using System.Xml;
using tsogosun.com.GamingSystemIGT.Model.IGTCountryInfoDto;
using tsogosun.com.GamingSystemIGT.Model.IGTCountryInfoDto.Response;
using tsogosun.com.GamingSystemIGT.Response;
using tsogosun.com.GamingSystemIGT.XmlTransform.Interface;

namespace tsogosun.com.GamingSystemIGT.XmlTransform
{
    public class CountryInfoIGTXMLTransform : ICountryInfoIGTXMLTransform
    {
        public CountryInfoIGTXMLTransform()
        {

        }

        public ResponseIGTCountryInfo GetIGTResponseCountryInfo(XmlDocument countryInfoResponseXml)
        {

            var countryInfoDto = new CountryInfoDto();
            var responseIGTCountryInfo = new ResponseIGTCountryInfo();
            var items = countryInfoResponseXml.DocumentElement.SelectNodes("Header/Operation").Cast<XmlElement>().ToList();

            var Operand = items[0].GetAttribute("Operand"); // Returns null if attribute doesn't exist, doesn't throw exception
            //var Data = items[0].GetAttribute("Data");

            if (Operand.ToString().ToLower() == "error")
            {
                var errorItems = countryInfoResponseXml.DocumentElement.SelectNodes("Body/Error").Cast<XmlElement>().ToList();

                responseIGTCountryInfo.Error = new Error
                {
                    ErrorCode = errorItems[0].SelectNodes("ErrorCode")[0].InnerText,
                    ErrorDescription = errorItems[0].SelectNodes("ErrorDescription")[0].InnerText
                };
            }
            else
            {
                var countryInfoElements = countryInfoResponseXml.DocumentElement.SelectNodes("Body/CountryInfo").Cast<XmlElement>().ToList();
                if (countryInfoElements != null)
                {
                    countryInfoDto.CountryID = countryInfoElements[0].SelectNodes("CountryID")[0] != null ? countryInfoElements[0].SelectNodes("CountryID")[0].InnerText : "";
                    countryInfoDto.CountryInfoDescription = countryInfoElements[0].SelectNodes("CountryInfoDescription")[0] != null ? countryInfoElements[0].SelectNodes("CountryInfoDescription")[0].InnerText : "";
                    countryInfoDto.Abrv2 = countryInfoElements[0].SelectNodes("Abrv2")[0] != null ? countryInfoElements[0].SelectNodes("Abrv2")[0].InnerText : "";
                    countryInfoDto.Abrv3 = countryInfoElements[0].SelectNodes("Abrv3")[0] != null ? countryInfoElements[0].SelectNodes("Abrv3")[0].InnerText : "";
                    countryInfoDto.Validate = countryInfoElements[0].SelectNodes("Validate")[0] != null ? countryInfoElements[0].SelectNodes("Validate")[0].InnerText : "";
                }
            }

            responseIGTCountryInfo.CountryInfoDto = countryInfoDto;
            return responseIGTCountryInfo;
        }

        public ResponseIGTZipCode GetIGTResponseZipCode(XmlDocument zipcodeResponseXml)
        {
            var zipCodeDto = new ZipCodeDto();
            var responseIGTZipCode = new ResponseIGTZipCode();
            var items = zipcodeResponseXml.DocumentElement.SelectNodes("Header/Operation").Cast<XmlElement>().ToList();

            var Operand = items[0].GetAttribute("Operand"); // Returns null if attribute doesn't exist, doesn't throw exception
            //var Data = items[0].GetAttribute("Data");

            if (Operand.ToString().ToLower() == "error")
            {
                var errorItems = zipcodeResponseXml.DocumentElement.SelectNodes("Body/Error").Cast<XmlElement>().ToList();

                responseIGTZipCode.Error = new Error
                {
                    ErrorCode = errorItems[0].SelectNodes("ErrorCode")[0].InnerText,
                    ErrorDescription = errorItems[0].SelectNodes("ErrorDescription")[0].InnerText
                };
            }
            else
            {
                var zipcodesElements = zipcodeResponseXml.DocumentElement.SelectNodes("Body/ZipCode").Cast<XmlElement>().ToList();
                if (zipcodesElements != null)
                {
                    zipCodeDto.ZipCodeID = zipcodesElements[0].SelectNodes("ZipCodeID")[0] != null ? zipcodesElements[0].SelectNodes("ZipCodeID")[0].InnerText : "";
                    zipCodeDto.ZipCode = zipcodesElements[0].SelectNodes("ZipCode")[0] != null ? zipcodesElements[0].SelectNodes("ZipCode")[0].InnerText : "";
                    zipCodeDto.City = zipcodesElements[0].SelectNodes("City")[0] != null ? zipcodesElements[0].SelectNodes("City")[0].InnerText : "";
                    zipCodeDto.State = zipcodesElements[0].SelectNodes("State")[0] != null ? zipcodesElements[0].SelectNodes("State")[0].InnerText : "";
                    zipCodeDto.CountryID = zipcodesElements[0].SelectNodes("CountryID")[0] != null ? zipcodesElements[0].SelectNodes("CountryID")[0].InnerText : "";
                    zipCodeDto.Verified = zipcodesElements[0].SelectNodes("Verified")[0] != null ? zipcodesElements[0].SelectNodes("Verified")[0].InnerText : "";
                    zipCodeDto.Status = zipcodesElements[0].SelectNodes("Status")[0] != null ? zipcodesElements[0].SelectNodes("Status")[0].InnerText : "";
                }
            }

            responseIGTZipCode.ZipCodeDto = zipCodeDto;
            return responseIGTZipCode;
        }
    }
}
