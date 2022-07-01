

using System.Xml;
using tsogosun.com.GamingSystemIGT.Model.IGTCountryInfoDto.Response;

namespace tsogosun.com.GamingSystemIGT.XmlTransform.Interface
{
    public interface ICountryInfoIGTXMLTransform
    {
        ResponseIGTCountryInfo GetIGTResponseCountryInfo(XmlDocument countryInfoResponseXml);
        ResponseIGTZipCode GetIGTResponseZipCode(XmlDocument zipcodeResponseXml);
    }
}
