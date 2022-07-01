

using System;
using System.Xml;
using tsogosun.com.GamingSystemIGT.Model.IGTPlayerFindInfoDto.Request;
using tsogosun.com.GamingSystemIGT.Model.IGTPlayerFindInfoDto.Response;
using tsogosun.com.GamingSystemIGT.Service.Interface;
using tsogosun.com.GamingSystemIGT.Shared;
using tsogosun.com.GamingSystemIGT.XmlTransform.Interface;

namespace tsogosun.com.GamingSystemIGT.Service
{
    public class PlayerInfoIGTService : IPlayerInfoIGTService
    {

        private IADISoapServiceIGT _aDISoapServiceIGT;
        private IPlayerInfoIGTXMLTransform _playerFindInfoIGTXMLTransform;

        public PlayerInfoIGTService(IADISoapServiceIGT aDISoapServiceIGT,
                                        IPlayerInfoIGTXMLTransform playerFindInfoIGTXMLTransform)
        {

            _aDISoapServiceIGT = aDISoapServiceIGT;
            _playerFindInfoIGTXMLTransform = playerFindInfoIGTXMLTransform;

        }

        public ResponseIGTPlayerInfo GetIGTPlayerInfoByName(RequestIGTPlayerInfoByName requestIGTPlayerInfoByName)
        {
            string requestBody = @$"<?xml version=""1.0"" encoding=""UTF-8""?>
                                    <CRMAcresMessage xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xsi:noNamespaceSchemaLocation=""C:\XSD\CRM.xsd"">
                                        <Header>
                                            <MessageID>123456791</MessageID>
                                            <TimeStamp>{DateTime.Now}</TimeStamp>
                                            <Operation Data=""PlayerFind"" Operand=""Request"" />
                                        </Header>
                                        <Body>
                                            <PlayerFind>
                                                <Filter>
                                                    <SearchName>
                                                            <FirstName>{requestIGTPlayerInfoByName.FirstName}</FirstName>
                                                            <LastName>{requestIGTPlayerInfoByName.LastName}</LastName>
                                                    </SearchName>
                                                </Filter>
                                            </PlayerFind>
                                         </Body>
                                      </CRMAcresMessage>";

            XmlDocument playerFindInfoResponse = new XmlDocument();

            playerFindInfoResponse.LoadXml(_aDISoapServiceIGT.GetResponse(requestIGTPlayerInfoByName.IpAddress, requestBody));

            return _playerFindInfoIGTXMLTransform.GetIGTResponsePlayerInfo(playerFindInfoResponse);

        }

        public ResponseIGTPlayerInfo GetIGTPlayerInfoByPlayerID(RequestIGTPlayerInfoByPlayerID requestIGTPlayerInfoByPlayerID)
        {
            string requestBody = @$"<?xml version=""1.0"" encoding=""UTF-8""?>
                                    <CRMAcresMessage xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xsi:noNamespaceSchemaLocation=""C:\XSD\CRM.xsd"">
                                        <Header>
                                            <MessageID>123456791</MessageID>
                                            <TimeStamp>{DateTime.Now}</TimeStamp>
                                            <Operation Data=""PlayerFind"" Operand=""Request"" />
                                        </Header>
                                        <Body>
                                            <PlayerFind>
                                                <Filter>
                                                    <SearchPlayerID>
                                                            <PlayerID>{requestIGTPlayerInfoByPlayerID.PlayerID}</PlayerID>
                                                    </SearchPlayerID>
                                                </Filter>
                                            </PlayerFind>
                                         </Body>
                                      </CRMAcresMessage>";

            XmlDocument playerFindInfoResponse = new XmlDocument();

            playerFindInfoResponse.LoadXml(_aDISoapServiceIGT.GetResponse(requestIGTPlayerInfoByPlayerID.IpAddress, requestBody));

            return _playerFindInfoIGTXMLTransform.GetIGTResponsePlayerInfo(playerFindInfoResponse);
        }

        public ResponseIGTPlayerInfo GetIGTPlayerInfoBySSN(RequestIGTPlayerInfoBySSN requestIGTPlayerInfoBySSN)
        {
            string requestBody = @$"<?xml version=""1.0"" encoding=""UTF-8""?>
                                    <CRMAcresMessage xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xsi:noNamespaceSchemaLocation=""C:\XSD\CRM.xsd"">
                                        <Header>
                                            <MessageID>123456791</MessageID>
                                            <TimeStamp>{DateTime.Now}</TimeStamp>
                                            <Operation Data=""PlayerFind"" Operand=""Request"" />
                                        </Header>
                                        <Body>
                                            <PlayerFind>
                                                <Filter>
                                                    <SearchSSN>
                                                            <SSN>{requestIGTPlayerInfoBySSN.SSN}</SSN>
                                                    </SearchSSN>
                                                </Filter>
                                            </PlayerFind>
                                         </Body>
                                      </CRMAcresMessage>";

            XmlDocument playerFindInfoResponse = new XmlDocument();

            playerFindInfoResponse.LoadXml(_aDISoapServiceIGT.GetResponse(requestIGTPlayerInfoBySSN.IpAddress, requestBody));

            return _playerFindInfoIGTXMLTransform.GetIGTResponsePlayerInfo(playerFindInfoResponse);

        }
    }
}
