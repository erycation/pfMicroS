
using System.Xml;
using tsogosun.com.GamingSystemIGT.Model.IGTPlayerFindInfoDto.Response;

namespace tsogosun.com.GamingSystemIGT.XmlTransform.Interface
{
    public interface IPlayerInfoIGTXMLTransform
    {
        ResponseIGTPlayerInfo GetIGTResponsePlayerInfo(XmlDocument playerInfoResponseXml);

    }
}
