using System;
using System.Collections.Generic;
using System.Text;

namespace TsukiDiscordBot.DiscordClient.DiscordResponseModels.DiscordOPModels.DiscordOPData
{
    //Response data for Discord's OPCode 10 response
    class DiscordOP10ResponseDataModel
    {
        public int heartbeat_interval { get; set; }
        //_fields are for Discord's internal use, do not rely on these
        //Format: Json
        public string[] _trace { get; set; }
    }
}
