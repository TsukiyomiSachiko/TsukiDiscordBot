using System;
using TsukiDiscordBot.DiscordClient.DiscordResponseModels.DiscordOPModels.DiscordOPData;

namespace TsukiDiscordBot.DiscordClient.DiscordResponseModels.DiscordOPModels.DiscordOPPayloads
{
    class DiscordOP10ResponsePayloadModel
    {
        public int op; //Opcode for the payload
        public DiscordOP10ResponseDataModel d; //Event data
#nullable enable
        public int? s; //Sequence number, used for resuming sessions and heartbeats
        public String? t; //Event name for this payload
    }
}
