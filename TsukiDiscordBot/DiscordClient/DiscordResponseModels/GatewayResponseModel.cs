using System;
using System.Collections.Generic;
using System.Text;

namespace TsukiDiscordBot.DiscordClient.DiscordResponseModels
{
    class GatewayResponseModel
    {
        public String url;
        public int shards;
        public SessionStartLimitModel session_start_limit;
    }
}
