using Newtonsoft.Json;

namespace Coding_Test.Model
{
    public class Info
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string? Name { get; set; }
        [JsonProperty(PropertyName = "tags")]
        public List<string>? Tags { get; set; }
    }


}
