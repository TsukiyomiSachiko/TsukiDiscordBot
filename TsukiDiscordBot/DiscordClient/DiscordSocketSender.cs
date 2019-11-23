using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using TsukiDiscordBot.DiscordClient.DiscordRequestModels.DiscordOPModels.DiscordOPData;
using TsukiDiscordBot.DiscordClient.DiscordRequestModels.DiscordOPModels.DiscordOPPayloads;
using TsukiDiscordBot.DiscordClient.DiscordRequestModels.DiscordOPModels.DiscordOPData.SubModels;
using System.Threading.Tasks;

namespace TsukiDiscordBot.DiscordClient
{
    class DiscordSocketSender
    {
        private ClientWebSocket socket;
        private String client_id;
        public DiscordSocketSender(ClientWebSocket socket, String client_id)
        {
            this.socket = socket;
            this.client_id = client_id;
        }

        public async Task SendHeartbeat()
        {
            DiscordOP1RequestPayloadModel payload = new DiscordOP1RequestPayloadModel();
            payload.d = DiscordCore.lastSequence;

            String payloadString = JsonConvert.SerializeObject(payload);
            await socket.SendAsync(Encoding.UTF8.GetBytes(payloadString), WebSocketMessageType.Text, true, CancellationToken.None);
        }

        public async Task SendIdentify()
        {
            DiscordOP2RequestPayloadModel payload = new DiscordOP2RequestPayloadModel();
            payload.d = new DiscordOP2RequestDataModel();

            payload.d.token = client_id;
            payload.d.properties = new DiscordOP2RequestDataPropertiesModel();

            payload.d.properties.os = "Windows";
            payload.d.properties.device = "TsukiDiscordBot";
            payload.d.properties.browser = "TsukiDiscordBot";

            //Initialize presence to set status to Online, and afk to false
            payload.d.presence = new DiscordOP2RequestDataStatusModel();

            String payloadString = JsonConvert.SerializeObject(
                payload,
                Formatting.None,
                new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }
            );

            await socket.SendAsync(Encoding.UTF8.GetBytes(payloadString), WebSocketMessageType.Text, true, CancellationToken.None);
        }
    }
}
