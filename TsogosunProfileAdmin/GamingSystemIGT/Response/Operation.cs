using Newtonsoft.Json;

namespace tsogosun.com.GamingSystemIGT.Response
{
    public class Operation
    {

        [JsonProperty("@Data")]
        public string Data { get; set; }

        [JsonProperty("@Operand")]
        public string Operand { get; set; }

    }
}