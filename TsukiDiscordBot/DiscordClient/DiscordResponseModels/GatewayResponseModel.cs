using System;

namespace TsukiDiscordBot.DiscordClient.DiscordResponseModels
{
    class GatewayResponseModel
    {
        public String url { get; set; }
        public int shards { get; set; }
        public SessionStartLimitModel session_start_limit { get; set; }
    }
}
