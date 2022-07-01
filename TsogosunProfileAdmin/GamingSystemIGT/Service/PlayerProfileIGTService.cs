using System;
using System.Text;
using System.Xml;
using tsogosun.com.GamingSystemIGT.Model.IGTPlayerFindInfoDto.Request;
using tsogosun.com.GamingSystemIGT.Model.PlayerProfileDto;
using tsogosun.com.GamingSystemIGT.Model.Request;
using tsogosun.com.GamingSystemIGT.Response;
using tsogosun.com.GamingSystemIGT.Service.Interface;
using tsogosun.com.GamingSystemIGT.Shared;
using tsogosun.com.GamingSystemIGT.Shared.Utils;
using tsogosun.com.GamingSystemIGT.XmlTransform.Interface;

namespace tsogosun.com.GamingSystemIGT.Service
{
    public class PlayerProfileIGTService : IPlayerProfileIGTService
    {

        private IADISoapServiceIGT _aDISoapServiceIGT;
        private IPlayerProfileIGTXMLTransform _playerProfileIGTXMLTransform;
        private IPlayerInfoIGTService _playerInfoIGTService;

        public PlayerProfileIGTService(IADISoapServiceIGT aDISoapServiceIGT,
                                       IPlayerProfileIGTXMLTransform playerProfileIGTXMLTransform,
                                       IPlayerInfoIGTService playerInfoIGTService)
        {

            _aDISoapServiceIGT = aDISoapServiceIGT;
            _playerProfileIGTXMLTransform = playerProfileIGTXMLTransform;
            _playerInfoIGTService = playerInfoIGTService;

        }

        public ResponsePlayerProfile GetPlayerProfileByPatronNo(RequestPlayerProfileIGT requestPlayerProfile)
        {

            string requestBody = @$"<?xml version=""1.0"" encoding=""UTF-8""?>
                                    <CRMAcresMessage xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xsi:noNamespaceSchemaLocation=""C:\XSD\CRM.xsd"">
                                        <Header>
                                            <MessageID>123456791</MessageID>
                                            <TimeStamp>{DateTime.Now}</TimeStamp>
                                            <Operation Data=""PlayerProfile"" Operand=""Request"" />
                                        </Header>
                                        <PlayerID>{requestPlayerProfile.PatronNo}</PlayerID>
                                      </CRMAcresMessage>";

            XmlDocument playerResponseXml = new XmlDocument();

            playerResponseXml.LoadXml(_aDISoapServiceIGT.GetResponse(requestPlayerProfile.IpAddress, requestBody));

            return _playerProfileIGTXMLTransform.GetResponsePlayer(playerResponseXml);
        }

        public ResponsePlayerProfile AddUpdatePlayerProfile(RequestAddUpdatePlayerProfileIGT requestAddUpdatePlayerProfile)
        {

            var requestIGTPlayerInfoBySSN = new RequestIGTPlayerInfoBySSN
            {
                SiteID = requestAddUpdatePlayerProfile.SiteID,
                IpAddress = requestAddUpdatePlayerProfile.IpAddress,
                SSN = requestAddUpdatePlayerProfile.PlayerProfile.Identifications[0].IDNumber
            };

            var playerInfo = _playerInfoIGTService.GetIGTPlayerInfoBySSN(requestIGTPlayerInfoBySSN);

            if (playerInfo.playersInfoDto.IsCollectionValid())
            {
                StringBuilder strBPatrons = new StringBuilder();

                foreach(var player in playerInfo.playersInfoDto)
                {
                    strBPatrons.Append($"{player.PlayerID}  ");
                }

                var responseError = new Error
                {
                    ErrorCode = "0000",
                    ErrorDescription = $"Identity Number {requestIGTPlayerInfoBySSN.SSN} is linked to patrons {strBPatrons}"
                };

                PlayerProfileBody playerProfileBody = new PlayerProfileBody();
                playerProfileBody.Error = responseError;

                return new ResponsePlayerProfile { PlayerProfileBody = playerProfileBody };
                
            }

            string tranformPlayerProfileXMLBody = _playerProfileIGTXMLTransform.ConvertXMLAddUpdatePlayerProfileIGT(requestAddUpdatePlayerProfile);

            string requestBody = @$"<?xml version=""1.0"" encoding=""UTF-8""?>
                                <CRMAcresMessage xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xsi:noNamespaceSchemaLocation=""C:\XSD\CRM.xsd"">
                                    <Header>
                                       <MessageID>123456791</MessageID>
                                       <TimeStamp>{DateTime.Now}</TimeStamp>
                                       <Operation Data=""PlayerProfile"" Operand=""Add""/>
                                    </Header>
                                <Body>                 
                                    {tranformPlayerProfileXMLBody}
                               </Body>
                        </CRMAcresMessage>";


            XmlDocument playerResponseXml = new XmlDocument();

            playerResponseXml.LoadXml(_aDISoapServiceIGT.GetResponse(requestAddUpdatePlayerProfile.IpAddress, requestBody));

            return _playerProfileIGTXMLTransform.GetResponsePlayer(playerResponseXml);
        }

        public ResponsePlayerProfile UpdatePlayerProfile(RequestAddUpdatePlayerProfileIGT requestAddUpdatePlayerProfile, string playerId)
        {

            string tranformPlayerProfileXMLBody = _playerProfileIGTXMLTransform.ConvertXMLAddUpdatePlayerProfileIGT(requestAddUpdatePlayerProfile);

            string requestBody = @$"<?xml version=""1.0"" encoding=""UTF-8""?>
                                <CRMAcresMessage xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xsi:noNamespaceSchemaLocation=""C:\XSD\CRM.xsd"">
                                    <Header>
                                       <MessageID>123456791</MessageID>
                                       <TimeStamp>{DateTime.Now}</TimeStamp>
                                       <Operation Data=""PlayerProfile"" Operand=""Update""/>
                                    </Header>
                                    <PlayerID>{playerId}</PlayerID>
                                <Body>                 
                                    {tranformPlayerProfileXMLBody}
                               </Body>
                        </CRMAcresMessage>";


            XmlDocument playerResponseXml = new XmlDocument();

            playerResponseXml.LoadXml(_aDISoapServiceIGT.GetResponse(requestAddUpdatePlayerProfile.IpAddress, requestBody));

            return _playerProfileIGTXMLTransform.GetResponsePlayer(playerResponseXml);

        }
    }
}
