

using Newtonsoft.Json;

namespace tsogosun.com.GamingSystemIGT.Model
{
    public class Status
    {
        [JsonProperty("@Description")]
        public string Description { get; set; }

        [JsonProperty("#text")]
        public string Text { get; set; }
    }
}
