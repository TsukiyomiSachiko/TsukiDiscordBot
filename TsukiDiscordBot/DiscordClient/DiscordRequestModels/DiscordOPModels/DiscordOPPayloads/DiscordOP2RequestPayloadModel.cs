using System;
using System.Collections.Generic;
using System.Text;
using TsukiDiscordBot.DiscordClient.DiscordRequestModels.DiscordOPModels.DiscordOPData;

namespace TsukiDiscordBot.DiscordClient.DiscordRequestModels.DiscordOPModels.DiscordOPPayloads
{
    class DiscordOP2RequestPayloadModel
    {
        public int op { get; } = 2;
        public DiscordOP2RequestDataModel d { get; set; }
    }
}
