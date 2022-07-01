
using System;
using System.Linq;
using System.Xml;
using tsogosun.com.GamingSystemIGT.Model.PlayerRankingDto;
using tsogosun.com.GamingSystemIGT.Service.Interface;
using tsogosun.com.GamingSystemIGT.Shared;

namespace tsogosun.com.GamingSystemIGT.Service
{
    public class PatronRankingIGTService : IPatronRankingIGTService
    {

        private IADISoapServiceIGT _aDISoapServiceIGT;

        public PatronRankingIGTService(IADISoapServiceIGT aDISoapServiceIGT)
        {

            _aDISoapServiceIGT = aDISoapServiceIGT;

        }

        public ResponsePlayerRanking UpdatePlayerRanking(RequestPlayerRankingIGT playerRanking)
        {

            XmlDocument playerRankingResponseXml = new XmlDocument();

            string requestBody = @$"<?xml version=""1.0"" encoding=""UTF-8""?>
                                <CRMAcresMessage xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xsi:noNamespaceSchemaLocation=""C:\XSD\CRM.xsd"">
                                    <Header>
                                       <MessageID>123456791</MessageID>
                                       <TimeStamp>{DateTime.Now}</TimeStamp>
                                       <Operation Data=""PlayerRanking"" Operand=""Update""/>
                                    </Header>
                                    <PlayerID>{playerRanking.PlayerID}</PlayerID>
                                    <Body>                 
                                        <PlayerRanking>
                                            <Site>
                                                <SiteID>{playerRanking.SiteID}</SiteID>
                                                <SiteDescription>{playerRanking.SiteDescription}</SiteDescription>
                                            </Site>
                                            <Ranking Description=""{playerRanking.RankingDescription}"">{playerRanking.RankingID}</Ranking>
                                        </PlayerRanking>
                                </Body>
                            </CRMAcresMessage>";

            playerRankingResponseXml.LoadXml(_aDISoapServiceIGT.GetResponse(playerRanking.IpAddress, requestBody));

            return GetPlayerRankingResponse(playerRankingResponseXml);
        }

        private ResponsePlayerRanking GetPlayerRankingResponse(XmlDocument playerRankingResponseXml)
        {

            var responsePlayerRanking = new ResponsePlayerRanking();

            var items = playerRankingResponseXml.DocumentElement.SelectNodes("Header/Operation").Cast<XmlElement>().ToList();

            //var Operand = items[0].GetAttribute("Operand"); // Returns null if attribute doesn't exist, doesn't throw exception
            //var Data = items[0].GetAttribute("Data");

            if (items[0].GetAttribute("Operand").ToString().ToLower() == "success")
            {
                responsePlayerRanking.Success = true;
                responsePlayerRanking.Message = "Successfully";
            }
            else
            {
                var errorItems = playerRankingResponseXml.DocumentElement.SelectNodes("Body/Error").Cast<XmlElement>().ToList();

                responsePlayerRanking.Success = false;
                responsePlayerRanking.Message =  errorItems[0].SelectNodes("ErrorDescription")[0].InnerText;
                responsePlayerRanking.ErrorCode = errorItems[0].SelectNodes("ErrorCode")[0].InnerText;
                responsePlayerRanking.ErrorDescription = errorItems[0].SelectNodes("ErrorDescription")[0].InnerText;
            }

            return responsePlayerRanking;
        }
    }
}
