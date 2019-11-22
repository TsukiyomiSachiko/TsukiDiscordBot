using System;
using System.Collections.Generic;
using System.Text;

namespace TsukiDiscordBot.DiscordClient.DiscordResponseModels
{
    class SocketPayloadModel
    {
        public int op; //Opcode for the payload
        public String d; //Event data
        public int s; //Sequence number, used for resuming sessions and heartbeats
        public String t; //Event name for this payload
    }
}
