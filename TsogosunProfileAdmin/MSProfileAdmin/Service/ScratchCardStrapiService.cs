
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using tsogosun.com.MSProfileAdmin.Model.Dtos.StrapiConfiguration;
using tsogosun.com.MSProfileAdmin.Model.Dtos.StrapiContent;
using tsogosun.com.MSProfileAdmin.Service.Interface;

namespace tsogosun.com.MSProfileAdmin.Service
{
    public class ScratchCardStrapiService : IScratchCardStrapiService
    {

        private readonly IConfiguration _configuration;

        public ScratchCardStrapiService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<ScratchCardStrapi>> GetScratchCardStrapiContentsByUnitId(int unitId)
        {

            var scratchCardStrapiContents = new List<ScratchCardStrapi>();

            var strapiConfigurations = _configuration.GetSection("StrapiConfig").Get<StrapiConfig>();

            var httpClientConfig = strapiConfigurations.CollectionType.Where(s => s.Unit == unitId).ToList();

            var httpClientIpAddress = strapiConfigurations.IpAddress + "" + httpClientConfig[0]?.ScratchCard;

            if (String.IsNullOrEmpty(httpClientIpAddress))
                return scratchCardStrapiContents;

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(httpClientIpAddress))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    scratchCardStrapiContents = JsonConvert.DeserializeObject<List<ScratchCardStrapi>>(apiResponse);
                }
            }

            return scratchCardStrapiContents;
        }
    }
}
