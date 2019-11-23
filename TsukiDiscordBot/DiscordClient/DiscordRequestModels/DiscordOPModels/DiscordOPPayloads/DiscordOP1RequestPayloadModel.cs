using System;
using System.Collections.Generic;
using System.Text;

namespace TsukiDiscordBot.DiscordClient.DiscordRequestModels.DiscordOPModels.DiscordOPPayloads
{
    class DiscordOP1RequestPayloadModel
    {
        public int op { get; set; } = 1;
        public int? d { get; set; }
    }
}
