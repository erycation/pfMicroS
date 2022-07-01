

using System.Xml;
using tsogosun.com.GamingSystemIGT.Model.PlayerProfileDto;

namespace tsogosun.com.GamingSystemIGT.XmlTransform.Interface
{
    public interface IPlayerProfileIGTXMLTransform
    {

        string ConvertXMLAddUpdatePlayerProfileIGT(RequestAddUpdatePlayerProfileIGT requestAddUpdatePlayerProfile);
        ResponsePlayerProfile GetResponsePlayer(XmlDocument playerResponseXml);

    }
}
