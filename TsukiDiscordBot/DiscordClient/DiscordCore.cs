using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using TsukiDiscordBot.DiscordClient.DiscordInterfaces;
using TsukiDiscordBot.DiscordClient.DiscordRequestModels.DiscordOPModels.DiscordOPPayloads;
using TsukiDiscordBot.DiscordClient.DiscordResponseModels;
using TsukiDiscordBot.DiscordClient.DiscordResponseModels.DiscordOPModels.DiscordOPPayloads;

namespace TsukiDiscordBot.DiscordClient
{
    class DiscordCore
    {
        private String client_id;
        private WebClient client = new WebClient();
        ClientWebSocket socket = new ClientWebSocket();
        System.Timers.Timer heartbeatTimer = new System.Timers.Timer();
        DiscordSocketSender socketSender;
        IDiscordEvents? events;

        public static int? lastSequence = null;
        public DiscordCore(String client_id, IDiscordEvents? events)
        {
            this.client_id = client_id;
            heartbeatTimer.Elapsed += HeartbeatTimerElapsed;
            heartbeatTimer.AutoReset = true;
            socketSender = new DiscordSocketSender(socket, client_id);
            this.events = events;
        }

        public async void initializeConnection()
        {
            const String API_FUNCTION = "/gateway/bot";
            const String url = DiscordConstLib.BASE_DISCORD_API_URL + DiscordConstLib.DISCORD_API_VERSION + API_FUNCTION;
            client.Headers.Add("Authorization", "Bot " + client_id);
            client.Headers.Add("User-Agent", "DiscordBot (" + url + ", " + DiscordConstLib.DISCORD_API_VERSION + ")");

            String data = await client.DownloadStringTaskAsync(new Uri(url));

            GatewayResponseModel response = JsonConvert.DeserializeObject<GatewayResponseModel>(data);

            Console.WriteLine("url: " + response.url);

            String websocketUrl = response.url + "?v=" + DiscordConstLib.DISCORD_SOCKET_VERSION + "&encoding=" + DiscordConstLib.DISCORD_SOCKET_DATA_ENCODING;

            await socket.ConnectAsync(new Uri(websocketUrl), CancellationToken.None);

            ArraySegment<byte> receivedBytes = new ArraySegment<byte>(new byte[1024]);
            WebSocketReceiveResult result = await socket.ReceiveAsync(receivedBytes, CancellationToken.None);
            String resultString = Encoding.UTF8.GetString(receivedBytes.Array, 0, result.Count);
            
            Console.WriteLine(resultString);

            DiscordOP10ResponsePayloadModel payload = JsonConvert.DeserializeObject<DiscordOP10ResponsePayloadModel>(resultString);
            
            if (payload.op == 10)
            {
                Console.WriteLine(payload.d.heartbeat_interval);
                heartbeatTimer.Interval = payload.d.heartbeat_interval;
                heartbeatTimer.Start();

                await socketSender.SendIdentify();
            }
            else
            {
                Console.WriteLine("Unexpected OPCode, expected value: 10; actual value: " + payload.op);
                await socket.CloseAsync(WebSocketCloseStatus.InvalidPayloadData, "Expected OPCode: 10", CancellationToken.None);
            }
        }

        private async void HeartbeatTimerElapsed(Object source, ElapsedEventArgs e)
        {
            await SendHeartbeat();
        }

        public async Task SendHeartbeat()
        {
            await socketSender.SendHeartbeat();
        }
    }
}
