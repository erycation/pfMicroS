

using System.Collections.Generic;
using System.Linq;
using System.Xml;
using tsogosun.com.GamingSystemIGT.Model;
using tsogosun.com.GamingSystemIGT.Model.PlayerProfileDto;
using tsogosun.com.GamingSystemIGT.Model.UserDto;
using tsogosun.com.GamingSystemIGT.Response;
using tsogosun.com.GamingSystemIGT.Shared.Utils;
using tsogosun.com.GamingSystemIGT.XmlTransform.Interface;

namespace tsogosun.com.GamingSystemIGT.XmlTransform
{
    public class PlayerProfileIGTXMLTransform : IPlayerProfileIGTXMLTransform
    {

        public PlayerProfileIGTXMLTransform()
        {

        }

        public string ConvertXMLAddUpdatePlayerProfileIGT(RequestAddUpdatePlayerProfileIGT requestAddUpdatePlayer)
        {

            string xmlAddressElements = "";
            string xmlPhoneNumbersElements = "";
            string xmlEmailsElements = "";
            string xmlLanguagesElements = "";
            string xmlIdentificationsElements = "";
            string xmlEnrolledByElements = "";
            string xmlSiteInfoElements = "";
            string xmlPlayerRestrictions = "";
            string xmlCardNumbers = "";
            string xmlInterests = "";

            if (requestAddUpdatePlayer.PlayerProfile.Addresses.IsCollectionValid())
            {
                foreach (var address in requestAddUpdatePlayer.PlayerProfile.Addresses)
                {
                    xmlAddressElements += @$"<Address>
                                                <Address1>{address?.Address1}</Address1>
                                                <City>{address?.City}</City>
                                                <StateProvince>{address?.StateProvince}</StateProvince>
                                                <PostalCode>{address?.PostalCode}</PostalCode>
                                                <Country>{address?.Country}</Country>
                                                <Location>{address?.Location}</Location>
                                                <Deliverable>{address?.Deliverable}</Deliverable>
                                                <Preferred>{address?.Preferred}</Preferred>
                                                <Suburb>{address?.Suburb}</Suburb>
                                                <CreditAddress>{address?.CreditAddress}</CreditAddress>
                                            </Address>";
                }
            }

            if (requestAddUpdatePlayer.PlayerProfile.PhoneNumbers.IsCollectionValid())
            {
                foreach (var phoneNumber in requestAddUpdatePlayer.PlayerProfile.PhoneNumbers)
                {
                    xmlPhoneNumbersElements += @$"<PhoneNumber>
                                                <Number>{phoneNumber?.Number}</Number>
                                                <Location>{phoneNumber?.Location}</Location>
                                            </PhoneNumber>";
                }
            }

            if (requestAddUpdatePlayer.PlayerProfile.Emails.IsCollectionValid())
            {
                foreach (var email in requestAddUpdatePlayer.PlayerProfile.Emails)
                {
                    xmlEmailsElements += @$"<Email>
                                                    <Address>{email?.Address}</Address>
                                                    <Location>{email?.Location}</Location>
                                                </Email>";
                }
            }

            if (requestAddUpdatePlayer.PlayerProfile.Languages.IsCollectionValid())
            {
                foreach (var language in requestAddUpdatePlayer.PlayerProfile.Languages)
                {
                    xmlLanguagesElements += @$"<Language>
                                                    <Language>{language?.Language}</Language>
                                             </Language>";
                }
            }

            if (requestAddUpdatePlayer.PlayerProfile.Identifications.IsCollectionValid())
            {
                foreach (var identification in requestAddUpdatePlayer.PlayerProfile.Identifications)
                {
                    xmlIdentificationsElements += @$"<Identification>
                                                        <Type>{identification?.Type}</Type>
                                                        <IDNumber>{identification?.IDNumber}</IDNumber>
                                                    </Identification>";
                }
            }

            if (requestAddUpdatePlayer.PlayerProfile.EnrolledBy != null)
            {
                xmlEnrolledByElements += @$"<User>
                                               <FirstName>{requestAddUpdatePlayer.PlayerProfile?.EnrolledBy?.FirstName}</FirstName>
                                               <LastName>{requestAddUpdatePlayer.PlayerProfile?.EnrolledBy?.LastName}</LastName>
                                               <LoginName>{requestAddUpdatePlayer.PlayerProfile?.EnrolledBy?.LoginName}</LoginName>
                                               <UserID>{requestAddUpdatePlayer.PlayerProfile?.EnrolledBy?.UserID}</UserID>
                                               <License>{requestAddUpdatePlayer.PlayerProfile?.EnrolledBy?.License}</License>
                                             </User>";

            }

            if (requestAddUpdatePlayer.PlayerProfile.Interests.IsCollectionValid())
            {
                foreach (var interest in requestAddUpdatePlayer.PlayerProfile.Interests)
                {
                    xmlInterests += @$"<Interest>
                                        <Description>{interest?.Description}</Description>                                                                                                
                                     </Interest>";
                }
            }

            if (requestAddUpdatePlayer.PlayerProfile.PlayerRestrictions.IsCollectionValid())
            {
                foreach (var restriction in requestAddUpdatePlayer.PlayerProfile.PlayerRestrictions)
                {
                    xmlPlayerRestrictions += @$"<Restriction>
                                                  <Description>{restriction?.Description}</Description>
                                                  <Expiration>{restriction?.Expiration}</Expiration>                                                                                                 
                                              </Restriction>";
                }
            }

            if (requestAddUpdatePlayer.PlayerProfile.CardNumbers.IsCollectionValid())
            {
                foreach (var cardNumber in requestAddUpdatePlayer.PlayerProfile.CardNumbers)
                {
                    xmlCardNumbers += @$"<CardNumber>
                                                  <CardID>{cardNumber?.CardID}</CardID>
                                                  <Status>{cardNumber?.Status}</Status>                                                                                                 
                                              </CardNumber>";
                }
            }

            if (requestAddUpdatePlayer.PlayerProfile.SiteParameters.IsCollectionValid())
            {
                foreach (var siteInfo in requestAddUpdatePlayer.PlayerProfile.SiteParameters)
                {
                    xmlSiteInfoElements += @$"<SiteInfo>
                                                    <SiteID>{siteInfo?.SiteID}</SiteID>
                                                    <PointBalance>{siteInfo?.PointBalance}</PointBalance>
                                                    <Ranking Description=""{siteInfo?.Ranking?.Description}"">{siteInfo?.Ranking?.Text}</Ranking>
                                                    <Host>
                                                        <UserID>{siteInfo?.Host?.UserID}</UserID>
                                                        <LoginName>{siteInfo?.Host?.LoginName}</LoginName>
                                                        <FirstName>{siteInfo?.Host?.FirstName}</FirstName>
                                                        <LastName>{siteInfo?.Host?.LastName}</LastName>
                                                        <License>{siteInfo?.Host?.License}</License>
                                                    </Host>                                               
                                                </SiteInfo>";
                }
            }

            return @$"<PlayerProfile>
                        <DateofBirth>{requestAddUpdatePlayer.PlayerProfile?.DateofBirth}</DateofBirth>
                        <CreditAccount>{requestAddUpdatePlayer.PlayerProfile?.CreditAccount}</CreditAccount>
                        <Gender>{requestAddUpdatePlayer.PlayerProfile?.Gender}</Gender>
                        <WebEnabled>{requestAddUpdatePlayer.PlayerProfile?.WebEnabled}</WebEnabled>
                        <Nationality>{requestAddUpdatePlayer.PlayerProfile?.Nationality}</Nationality>
                        <PipPep>{requestAddUpdatePlayer.PlayerProfile?.PipPep}</PipPep>
                        <Name>
                            <Title> {requestAddUpdatePlayer.PlayerProfile?.Name?.Title}</Title>
                            <FirstName> {requestAddUpdatePlayer.PlayerProfile?.Name?.FirstName}</FirstName>
                            <PreferredName>{requestAddUpdatePlayer.PlayerProfile?.Name?.PreferredName}</PreferredName>
                            <MiddleName>{requestAddUpdatePlayer.PlayerProfile?.Name?.MiddleName}</MiddleName>
                            <LastName>{requestAddUpdatePlayer.PlayerProfile?.Name?.LastName}</LastName>
                        </Name>
                        <Addresses>{xmlAddressElements}</Addresses>
                        <PhoneNumbers> {xmlPhoneNumbersElements}</PhoneNumbers>
                        <Emails> {xmlEmailsElements}</Emails>
                        <Languages>{xmlLanguagesElements}</Languages>
                        <Identifications>{xmlIdentificationsElements}</Identifications>                                          
                        <EnrolledBy>{xmlEnrolledByElements}</EnrolledBy>
                        <Status Description=""{requestAddUpdatePlayer.PlayerProfile?.Status?.Description}"">{requestAddUpdatePlayer.PlayerProfile?.Status?.Text}</Status>
                        <CardNumbers>{xmlCardNumbers}</CardNumbers>
                        <Employment>
                             <Company>{requestAddUpdatePlayer.PlayerProfile?.Employment?.Company}</Company>
                             <Position>{requestAddUpdatePlayer.PlayerProfile?.Employment?.Position}</Position>
                        </Employment>
                        <Interests>{xmlInterests}</Interests>
                        <PlayerRestrictions>{xmlPlayerRestrictions}</PlayerRestrictions>
                        <SiteParameters> {xmlSiteInfoElements}</SiteParameters>
                        </PlayerProfile>";

        }

        public ResponsePlayerProfile GetResponsePlayer(XmlDocument playerResponseXml)
        {

            var address = new List<Address>();
            var phoneNumber = new List<PhoneNumber>();
            var email = new List<Email>();
            var languages = new List<Languages>();
            var identification = new List<Identification>();
            var cardNumber = new List<CardNumber>();
            var restriction = new List<Restriction>();
            var interest = new List<Interest>();
            var siteInfo = new List<SiteInfo>();
            var playerProfile = new PlayerProfile();
            var playerProfileBody = new PlayerProfileBody();
            var responsePlayerProfile = new ResponsePlayerProfile();

            var items = playerResponseXml.DocumentElement.SelectNodes("Header/Operation").Cast<XmlElement>().ToList();

            var Operand = items[0].GetAttribute("Operand"); // Returns null if attribute doesn't exist, doesn't throw exception
            var Data = items[0].GetAttribute("Data");

            if (Operand.ToString().ToLower() == "error")
            {
                var errorItems = playerResponseXml.DocumentElement.SelectNodes("Body/Error").Cast<XmlElement>().ToList();

                var responseError = new Error
                {
                    ErrorCode = errorItems[0].SelectNodes("ErrorCode")[0].InnerText,
                    ErrorDescription = errorItems[0].SelectNodes("ErrorDescription")[0].InnerText
                };

                playerProfileBody.Error = responseError;
                responsePlayerProfile.PlayerProfileBody = playerProfileBody;

            }
            else
            {

                var playerIDElement = playerResponseXml.DocumentElement.GetElementsByTagName("PlayerID");

                responsePlayerProfile.PlayerID = playerIDElement[0].InnerXml != null ? playerIDElement[0].InnerXml : "";

                var profileElements = playerResponseXml.DocumentElement.SelectNodes("Body/PlayerProfile").Cast<XmlElement>().ToList();

                playerProfile.DateofBirth = profileElements[0].SelectNodes("DateofBirth")[0] != null ? profileElements[0].SelectNodes("DateofBirth")[0].InnerText : "";
                playerProfile.Anniversary = profileElements[0].SelectNodes("Anniversary")[0] != null ? profileElements[0].SelectNodes("Anniversary")[0].InnerText : "";
                playerProfile.CreditAccount = profileElements[0].SelectNodes("CreditAccount")[0] != null ? profileElements[0].SelectNodes("CreditAccount")[0].InnerText : "";
                playerProfile.Gender = profileElements[0].SelectNodes("Gender")[0] != null ? profileElements[0].SelectNodes("Gender")[0].InnerText : "";
                playerProfile.PINLocked = profileElements[0].SelectNodes("PINLocked")[0] != null ? profileElements[0].SelectNodes("PINLocked")[0].InnerText : "";
                playerProfile.WebEnabled = profileElements[0].SelectNodes("WebEnabled")[0] != null ? profileElements[0].SelectNodes("WebEnabled")[0].InnerText : "";
                playerProfile.Exempt = profileElements[0].SelectNodes("Exempt")[0] != null ? profileElements[0].SelectNodes("Exempt")[0].InnerText : "";
                playerProfile.Attraction = profileElements[0].SelectNodes("Attraction")[0] != null ? profileElements[0].SelectNodes("Attraction")[0].InnerText : "";
                playerProfile.Affiliation = profileElements[0].SelectNodes("Affiliation")[0] != null ? profileElements[0].SelectNodes("Affiliation")[0].InnerText : "";
                playerProfile.DateEnrolled = profileElements[0].SelectNodes("DateEnrolled")[0] != null ? profileElements[0].SelectNodes("DateEnrolled")[0].InnerText : "";
                playerProfile.Nationality = profileElements[0].SelectNodes("Nationality")[0] != null ? profileElements[0].SelectNodes("Nationality")[0].InnerText : "";
                playerProfile.PipPep = profileElements[0].SelectNodes("PipPep")[0] != null ? profileElements[0].SelectNodes("PipPep")[0].InnerText : "";

                playerProfile.Name = new Name
                {
                    Title = profileElements[0].SelectNodes("Name/Title")[0] != null ? profileElements[0].SelectNodes("Name/Title")[0].InnerText : "",
                    FirstName = profileElements[0].SelectNodes("Name/FirstName")[0] != null ? profileElements[0].SelectNodes("Name/FirstName")[0].InnerText : "",
                    PreferredName = profileElements[0].SelectNodes("Name/PreferredName")[0] != null ? profileElements[0].SelectNodes("Name/PreferredName")[0].InnerText : "",
                    LastName = profileElements[0].SelectNodes("Name/LastName")[0] != null ? profileElements[0].SelectNodes("Name/LastName")[0].InnerText : "",
                    MiddleName = profileElements[0].SelectNodes("Name/MiddleName")[0] != null ? profileElements[0].SelectNodes("Name/MiddleName")[0].InnerText : ""

                };

                playerProfile.Employment = new Employment
                {
                    Company = profileElements[0].SelectNodes("Employment/Company")[0] != null ? profileElements[0].SelectNodes("Employment/Company")[0].InnerText : "",
                    Position = profileElements[0].SelectNodes("Employment/Position")[0] != null ? profileElements[0].SelectNodes("Employment/Position")[0].InnerText : ""

                };

                var statusDescription = playerResponseXml.DocumentElement.SelectNodes("Body/PlayerProfile/Status").Cast<XmlElement>().ToList();

                playerProfile.Status = new Status
                {
                    Text = profileElements[0].SelectNodes("Status")[0] != null ? profileElements[0].SelectNodes("Status")[0].InnerText : "",
                    Description = statusDescription.Count > 0 ? statusDescription[0].GetAttribute("Description") : ""

                };

                playerProfile.EnrolledBy  = new User
                {
                    UserID = profileElements[0].SelectNodes("EnrolledBy/User/UserID")[0] != null ? profileElements[0].SelectNodes("EnrolledBy/User/UserID")[0].InnerText : "",
                    LoginName = profileElements[0].SelectNodes("EnrolledBy/User/LoginName")[0] != null ? profileElements[0].SelectNodes("EnrolledBy/User/LoginName")[0].InnerText : "",
                    FirstName = profileElements[0].SelectNodes("EnrolledBy/User/FirstName")[0] != null ? profileElements[0].SelectNodes("EnrolledBy/User/FirstName")[0].InnerText : "",
                    LastName = profileElements[0].SelectNodes("EnrolledBy/User/LastName")[0] != null ? profileElements[0].SelectNodes("EnrolledBy/User/LastName")[0].InnerText : "",
                    License = profileElements[0].SelectNodes("EnrolledBy/User/License")[0] != null ? profileElements[0].SelectNodes("EnrolledBy/User/License")[0].InnerText : ""
                };


                for (var i = 0; i <= 50; i++)
                {

                    if (profileElements[0].SelectNodes("Addresses/Address/Address1")[i] != null)
                    {
                        address.Add(new Address
                        {
                            Address1 = profileElements[0].SelectNodes("Addresses/Address/Address1")[i] != null ? profileElements[0].SelectNodes("Addresses/Address/Address1")[i].InnerText : "",
                            City = profileElements[0].SelectNodes("Addresses/Address/City")[i] != null ? profileElements[0].SelectNodes("Addresses/Address/City")[i].InnerText : "",
                            StateProvince = profileElements[0].SelectNodes("Addresses/Address/StateProvince")[i] != null ? profileElements[0].SelectNodes("Addresses/Address/StateProvince")[i].InnerText : "",
                            PostalCode = profileElements[0].SelectNodes("Addresses/Address/PostalCode")[i] != null ? profileElements[0].SelectNodes("Addresses/Address/PostalCode")[i].InnerText : "",
                            Country = profileElements[0].SelectNodes("Addresses/Address/Country")[i] != null ? profileElements[0].SelectNodes("Addresses/Address/Country")[i].InnerText : "",
                            Location = profileElements[0].SelectNodes("Addresses/Address/Location")[i] != null ? profileElements[0].SelectNodes("Addresses/Address/Location")[i].InnerText : "",
                            Deliverable = profileElements[0].SelectNodes("Addresses/Address/Deliverable")[i] != null ? profileElements[0].SelectNodes("Addresses/Address/Deliverable")[i].InnerText : "",
                            Preferred = profileElements[0].SelectNodes("Addresses/Address/Preferred")[i] != null ? profileElements[0].SelectNodes("Addresses/Address/Preferred")[i].InnerText : "",
                            Suburb = profileElements[0].SelectNodes("Addresses/Address/Suburb")[i] != null ? profileElements[0].SelectNodes("Addresses/Address/Suburb")[i].InnerText : "",
                            CreditAddress = profileElements[0].SelectNodes("Addresses/Address/CreditAddress")[i] != null ? profileElements[0].SelectNodes("Addresses/Address/CreditAddress")[i].InnerText : ""

                        });
                    }

                    if (profileElements[0].SelectNodes("PhoneNumbers/PhoneNumber/Number")[i] != null)
                    {
                        phoneNumber.Add(new PhoneNumber
                        {
                            Number = profileElements[0].SelectNodes("PhoneNumbers/PhoneNumber/Number")[i] != null ? profileElements[0].SelectNodes("PhoneNumbers/PhoneNumber/Number")[i].InnerText : "",
                            Location = profileElements[0].SelectNodes("PhoneNumbers/PhoneNumber/Location")[i] != null ? profileElements[0].SelectNodes("PhoneNumbers/PhoneNumber/Location")[i].InnerText : "",
                            Preferred = profileElements[0].SelectNodes("PhoneNumbers/PhoneNumber/Preferred")[i] != null ? profileElements[0].SelectNodes("PhoneNumbers/PhoneNumber/Preferred")[i].InnerText : ""
                        });
                    }

                    if (profileElements[0].SelectNodes("Emails/Email/Address")[i] != null)
                    {
                        email.Add(new Email
                        {
                            Address = profileElements[0].SelectNodes("Emails/Email/Address")[i] != null ? profileElements[0].SelectNodes("Emails/Email/Address")[i].InnerText : "",
                            Location = profileElements[0].SelectNodes("Emails/Email/Location")[i] != null ? profileElements[0].SelectNodes("Emails/Email/Location")[i].InnerText : ""
                        });
                    }

                    if (profileElements[0].SelectNodes("Languages/Language")[i] != null)
                    {
                        languages.Add(new Languages
                        {
                            Language = profileElements[0].SelectNodes("Languages/Language")[i] != null ? profileElements[0].SelectNodes("Languages/Language")[i].InnerText : ""
                        });
                    }

                    if (profileElements[0].SelectNodes("Identifications/Identification/IDNumber")[i] != null)
                    {
                        identification.Add(new Identification
                        {
                            Type = profileElements[0].SelectNodes("Identifications/Identification/Type")[i] != null ? profileElements[0].SelectNodes("Identifications/Identification/Type")[i].InnerText : "",
                            IDNumber = profileElements[0].SelectNodes("Identifications/Identification/IDNumber")[i] != null ? profileElements[0].SelectNodes("Identifications/Identification/IDNumber")[i].InnerText : "",
                            VerificationDate = profileElements[0].SelectNodes("Identifications/Identification/VerificationDate")[i] != null ? profileElements[0].SelectNodes("Identifications/Identification/VerificationDate")[i].InnerText : "",
                            Country = profileElements[0].SelectNodes("Identifications/Identification/Country")[i] != null ? profileElements[0].SelectNodes("Identifications/Identification/Country")[i].InnerText : "",
                            Primary = profileElements[0].SelectNodes("Identifications/Identification/Primary")[i] != null ? profileElements[0].SelectNodes("Identifications/Identification/Primary")[i].InnerText : ""
                        });
                    }

                    if (profileElements[0].SelectNodes("CardNumbers/CardNumber/CardID")[i] != null)
                    {
                        cardNumber.Add(new CardNumber
                        {
                            CardID = profileElements[0].SelectNodes("CardNumbers/CardNumber/CardID")[i] != null ? profileElements[0].SelectNodes("CardNumbers/CardNumber/CardID")[i].InnerText : "",
                            Status = profileElements[0].SelectNodes("CardNumbers/CardNumber/Status")[i] != null ? profileElements[0].SelectNodes("CardNumbers/CardNumber/Status")[i].InnerText : ""
                        });
                    }

                    if (profileElements[0].SelectNodes("PlayerRestrictions/Restriction/Description")[i] != null)
                    {
                        restriction.Add(new Restriction
                        {
                            Description = profileElements[0].SelectNodes("PlayerRestrictions/Restriction/Description")[i] != null ? profileElements[0].SelectNodes("PlayerRestrictions/Restriction/Description")[i].InnerText : "",
                            Expiration = profileElements[0].SelectNodes("PlayerRestrictions/Restriction/Expiration")[i] != null ? profileElements[0].SelectNodes("PlayerRestrictions/Restriction/Expiration")[i].InnerText : ""
                        });
                    }

                    if (profileElements[0].SelectNodes("Interests/Interest/Code")[i] != null)
                    {
                        interest.Add(new Interest
                        {
                            Code = profileElements[0].SelectNodes("Interests/Interest/Code")[i] != null ? profileElements[0].SelectNodes("Interests/Interest/Code")[i].InnerText : "",
                            Description = profileElements[0].SelectNodes("Interests/Interest/Description")[i] != null ? profileElements[0].SelectNodes("Interests/Interest/Description")[i].InnerText : ""
                        });
                    }

                    if (profileElements[0].SelectNodes("SiteParameters/SiteInfo/SiteID")[i] != null)
                    {

                        var rankingDescription = playerResponseXml.DocumentElement.SelectNodes("Body/PlayerProfile/SiteParameters/SiteInfo/Ranking").Cast<XmlElement>().ToList();

                        siteInfo.Add(new SiteInfo
                        {
                            SiteID = profileElements[0].SelectNodes("SiteParameters/SiteInfo/SiteID")[i] != null ? profileElements[0].SelectNodes("SiteParameters/SiteInfo/SiteID")[i].InnerText : "",
                            PointBalance = profileElements[0].SelectNodes("SiteParameters/SiteInfo/PointBalance")[i] != null ? profileElements[0].SelectNodes("SiteParameters/SiteInfo/PointBalance")[i].InnerText : "",
                            Ranking = new Ranking
                            {
                                Text = profileElements[0].SelectNodes("SiteParameters/SiteInfo/Ranking")[i] != null ? profileElements[0].SelectNodes("SiteParameters/SiteInfo/Ranking")[i].InnerText : "",
                                Description = rankingDescription.Count > 0 ? rankingDescription[0].GetAttribute("Description") : ""
                            },
                            Host = new User
                            {
                                UserID = profileElements[0].SelectNodes("SiteParameters/SiteInfo/Host/UserID")[0] != null ? profileElements[0].SelectNodes("SiteParameters/SiteInfo/Host/UserID")[0].InnerText : "",
                                LoginName = profileElements[0].SelectNodes("SiteParameters/SiteInfo/Host/LoginName")[0] != null ? profileElements[0].SelectNodes("SiteParameters/SiteInfo/Host/LoginName")[0].InnerText : "",
                                FirstName = profileElements[0].SelectNodes("SiteParameters/SiteInfo/Host/FirstName")[0] != null ? profileElements[0].SelectNodes("SiteParameters/SiteInfo/Host/FirstName")[0].InnerText : "",
                                LastName = profileElements[0].SelectNodes("SiteParameters/SiteInfo/Host/LastName")[0] != null ? profileElements[0].SelectNodes("SiteParameters/SiteInfo/Host/LastName")[0].InnerText : "",
                                License = profileElements[0].SelectNodes("SiteParameters/SiteInfo/Host/License")[0] != null ? profileElements[0].SelectNodes("SiteParameters/SiteInfo/Host/License")[0].InnerText : ""
                            }
                        });
                    }
                }

                playerProfile.Addresses = address;
                playerProfile.Emails = email;
                playerProfile.Languages = languages;
                playerProfile.PhoneNumbers = phoneNumber;
                playerProfile.Identifications = identification;
                playerProfile.CardNumbers = cardNumber;
                playerProfile.PlayerRestrictions = restriction;
                playerProfile.Interests = interest;
                playerProfile.SiteParameters = siteInfo;
                playerProfileBody.PlayerProfile = playerProfile;
                responsePlayerProfile.PlayerProfileBody = playerProfileBody;

            }

            return responsePlayerProfile;
        }
    }
}
