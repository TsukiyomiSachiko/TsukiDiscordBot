using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TsukiDiscordBot.DiscordClient.DiscordRequestModels.DiscordOPModels.DiscordOPData.SubModels
{
    class DiscordOP2RequestDataPropertiesModel
    {
        [JsonProperty(PropertyName = "$os")]
        public string os { get; set; }

        [JsonProperty(PropertyName = "$browser")]
        public string browser { get; set; }

        [JsonProperty(PropertyName = "$device")]
        public string device { get; set; }
    }
}
