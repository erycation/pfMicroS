
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using tsogosun.com.GamingSystemIGT.Model.IGTPlayerFindInfoDto;
using tsogosun.com.GamingSystemIGT.Model.IGTPlayerFindInfoDto.Response;
using tsogosun.com.GamingSystemIGT.Response;
using tsogosun.com.GamingSystemIGT.XmlTransform.Interface;

namespace tsogosun.com.GamingSystemIGT.XmlTransform
{
    public class PlayerInfoIGTXMLTransform : IPlayerInfoIGTXMLTransform
    {
        public PlayerInfoIGTXMLTransform()
        {

        }

        public ResponseIGTPlayerInfo GetIGTResponsePlayerInfo(XmlDocument playerInfoResponseXml)
        {

            var playersInfoDto = new List<PlayerFindInfoDto>();
            var responseIGTPlayerInfo = new ResponseIGTPlayerInfo();
            var items = playerInfoResponseXml.DocumentElement.SelectNodes("Header/Operation").Cast<XmlElement>().ToList();

            var Operand = items[0].GetAttribute("Operand"); // Returns null if attribute doesn't exist, doesn't throw exception
            //var Data = items[0].GetAttribute("Data");

            if (Operand.ToString().ToLower() == "error")
            {
                var errorItems = playerInfoResponseXml.DocumentElement.SelectNodes("Body/Error").Cast<XmlElement>().ToList();

                responseIGTPlayerInfo.Error = new Error
                {
                    ErrorCode = errorItems[0].SelectNodes("ErrorCode")[0].InnerText,
                    ErrorDescription = errorItems[0].SelectNodes("ErrorDescription")[0].InnerText
                };
            }
            else
            {
                var profileInfoElements = playerInfoResponseXml.DocumentElement.SelectNodes("Body/PlayerFind").Cast<XmlElement>().ToList();

                for (var i = 0; i <= 50; i++)
                {
                    if (profileInfoElements[0].SelectNodes("PlayersFound/PlayerFound")[i] != null)
                    {
                        playersInfoDto.Add(new PlayerFindInfoDto
                        {
                            PlayerID = profileInfoElements[0].SelectNodes("PlayersFound/PlayerFound/PlayerID")[i] != null ? profileInfoElements[0].SelectNodes("PlayersFound/PlayerFound/PlayerID")[i].InnerText : "",
                            FirstName = profileInfoElements[0].SelectNodes("PlayersFound/PlayerFound/FirstName")[i] != null ? profileInfoElements[0].SelectNodes("PlayersFound/PlayerFound/FirstName")[i].InnerText : "",
                            MiddleName = profileInfoElements[0].SelectNodes("PlayersFound/PlayerFound/MiddleName")[i] != null ? profileInfoElements[0].SelectNodes("PlayersFound/PlayerFound/MiddleName")[i].InnerText : "",
                            LastName = profileInfoElements[0].SelectNodes("PlayersFound/PlayerFound/LastName")[i] != null ? profileInfoElements[0].SelectNodes("PlayersFound/PlayerFound/LastName")[i].InnerText : "",
                            PreferredName = profileInfoElements[0].SelectNodes("PlayersFound/PlayerFound/PreferredName")[i] != null ? profileInfoElements[0].SelectNodes("PlayersFound/PlayerFound/PreferredName")[i].InnerText : "",
                            Ranking = profileInfoElements[0].SelectNodes("PlayersFound/PlayerFound/Ranking")[i] != null ? profileInfoElements[0].SelectNodes("PlayersFound/PlayerFound/Ranking")[i].InnerText : "",
                            SSN = profileInfoElements[0].SelectNodes("PlayersFound/PlayerFound/SSN")[i] != null ? profileInfoElements[0].SelectNodes("PlayersFound/PlayerFound/SSN")[i].InnerText : "",
                            DateOfBirth = profileInfoElements[0].SelectNodes("PlayersFound/PlayerFound/DateOfBirth")[i] != null ? profileInfoElements[0].SelectNodes("PlayersFound/PlayerFound/DateOfBirth")[i].InnerText : "",
                            CreditAccount = profileInfoElements[0].SelectNodes("PlayersFound/PlayerFound/CreditAccount")[i] != null ? profileInfoElements[0].SelectNodes("PlayersFound/PlayerFound/CreditAccount")[i].InnerText : "",
                        });
                    }
                }

                responseIGTPlayerInfo.playersInfoDto = playersInfoDto;
            }

            return responseIGTPlayerInfo;
        }
    }
}
