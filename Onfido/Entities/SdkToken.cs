using Newtonsoft.Json;

namespace Onfido.Entities
{
    public class SdkToken
    {
        [JsonProperty("token")]
        public string Token;
    }
}