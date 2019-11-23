using System;
using System.Collections.Generic;
using System.Text;

namespace TsukiDiscordBot.DiscordClient.DiscordResponseModels.DiscordOPModels
{
    class DiscordGenericOPResponse
    {
        public int op { get; set; }
        public object d { get; set; }
        public int s { get; set; }
        public string t { get; set; }
    }
}
