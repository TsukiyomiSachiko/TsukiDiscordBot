using System;
using System.Collections.Generic;
using System.Text;

namespace TsukiDiscordBot.DiscordClient.DiscordRequestModels.DiscordOPModels.DiscordOPData.SubModels
{
    class DiscordOP2RequestDataStatusModel
    {
#nullable enable
        public int? since { get; set; }
        public DiscordOP2RequestDataActivityModel? game { get; set; }
        public string status { get; set; } = "online";
        public bool afk { get; set; } = false;

    }
}
