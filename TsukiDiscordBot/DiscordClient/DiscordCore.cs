using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using TsukiDiscordBot.DiscordClient.DiscordResponseModels;

namespace TsukiDiscordBot.DiscordClient
{
    public class DiscordCore
    {
        private String client_id;
        private WebClient client = new WebClient();
        ClientWebSocket socket = new ClientWebSocket();
        public DiscordCore(String client_id)
        {
            this.client_id = client_id;
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

            CancellationTokenSource source = new CancellationTokenSource();
            CancellationToken token = source.Token;

            String websocketUrl = response.url + "?v=" + DiscordConstLib.DISCORD_SOCKET_VERSION + "&encoding=" + DiscordConstLib.DISCORD_SOCKET_DATA_ENCODING;

            await socket.ConnectAsync(new Uri(websocketUrl), token);
        }
    }
}
