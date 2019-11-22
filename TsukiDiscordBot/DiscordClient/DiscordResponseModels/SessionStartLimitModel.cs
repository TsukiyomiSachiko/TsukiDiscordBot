using System;
using System.Collections.Generic;
using System.Text;

namespace TsukiDiscordBot.DiscordClient.DiscordResponseModels
{
    class SessionStartLimitModel
    {
        public int total;
        public int remaining;
        public int reset_after;
    }
}
