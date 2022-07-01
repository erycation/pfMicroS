using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using tsogosun.com.MSProfileAdmin.Model.Dtos.StrapiContent;
using tsogosun.com.MSProfileAdmin.Model.Dtos.StrapiConfiguration;
using tsogosun.com.MSProfileAdmin.Service.Interface;

namespace tsogosun.com.MSProfileAdmin.Service
{
    public class LeaderBoardStrapiService : ILeaderBoardStrapiService
    {

        private readonly IConfiguration _configuration;

        public LeaderBoardStrapiService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<LeaderBoardStrapi>> GetLeaderBoardStrapiContentsByUnitId(int unitId)
        {

            var leaderBoardStrapiContents = new List<LeaderBoardStrapi>();

            var strapiConfigurations = _configuration.GetSection("StrapiConfig").Get<StrapiConfig>();

            var httpClientConfig = strapiConfigurations.CollectionType.Where(s => s.Unit == unitId).ToList();

            var httpClientIpAddress = strapiConfigurations.IpAddress + "" + httpClientConfig[0]?.LeaderBoard;

            if (String.IsNullOrEmpty(httpClientIpAddress))
                return leaderBoardStrapiContents;

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(httpClientIpAddress))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    leaderBoardStrapiContents = JsonConvert.DeserializeObject<List<LeaderBoardStrapi>>(apiResponse);
                }
            }

            return leaderBoardStrapiContents;
        }
    }
}