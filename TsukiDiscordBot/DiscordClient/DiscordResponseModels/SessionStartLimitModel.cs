using System;
using System.Collections.Generic;
using System.Text;

namespace TsukiDiscordBot.DiscordClient.DiscordResponseModels
{
    class SessionStartLimitModel
    {
        public int total { get; set; }
        public int remaining { get; set; }
        public int reset_after { get; set; }
    }
}
