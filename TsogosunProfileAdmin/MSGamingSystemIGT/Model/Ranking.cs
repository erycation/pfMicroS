﻿

using Newtonsoft.Json;

namespace tsogosun.com.MSGamingSystemIGT.Model
{
    public class Ranking
    {
        [JsonProperty("@Description")]
        public string Description { get; set; }

        [JsonProperty("#text")]
        public string Text { get; set; }
    }
}