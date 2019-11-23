using System;
using System.Collections.Generic;
using System.Text;
using TsukiDiscordBot.DiscordClient.DiscordRequestModels.DiscordOPModels.DiscordOPData.SubModels;

namespace TsukiDiscordBot.DiscordClient.DiscordRequestModels.DiscordOPModels.DiscordOPData
{
    class DiscordOP2RequestDataModel
    {
#nullable enable
        public string token { get; set; }
        public DiscordOP2RequestDataPropertiesModel properties { get; set; }
        public bool? compress { get; set; }
        public int? large_threshold { get; set; }
        public int[]? shards { get; set; }
        public DiscordOP2RequestDataStatusModel? presence { get; set; }
        public bool? guild_subscriptions { get; set; }
    }
}
