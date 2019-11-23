using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TsukiDiscordBot.DiscordClient.DiscordInterfaces;
using TsukiDiscordBot.DiscordClient.DiscordResponseModels.DiscordOPModels;

namespace TsukiDiscordBot.DiscordClient
{
    class DiscordSocketReceiver
    {
        private DiscordCore core;
        private ClientWebSocket socket;
        private DiscordEventResolver eventResolver;
        public DiscordSocketReceiver(ClientWebSocket socket, DiscordCore caller, IDiscordEvents events)
        {
            this.core = caller;
            this.socket = socket;
            this.eventResolver = new DiscordEventResolver(events);
        }
        public async void run()
        {
            while(true)
            {
                ArraySegment<byte> receivedBytes = new ArraySegment<byte>(new byte[1024]);
                WebSocketReceiveResult result = await socket.ReceiveAsync(receivedBytes, CancellationToken.None);
                String resultString = Encoding.UTF8.GetString(receivedBytes.Array, 0, result.Count);

                DiscordGenericOPResponse response = JsonConvert.DeserializeObject<DiscordGenericOPResponse>(resultString);

                switch (response.op)
                {
                    case 0:
                        Thread thread0 = new Thread(handleOP0);
                        thread0.Start(response);
                        break;
                    case 1:
                        Thread thread1 = new Thread(handleOP1);
                        thread1.Start();
                        break;
                    case 7:
                        handleOP7();
                        break;
                    case 9:
                        handleOP9();
                        break;
                    case 10:
                        handleOP10();
                        break;
                    case 11:
                        handleOP11();
                        break;
                    default:
                        Console.WriteLine("Unexpected OPCode received, shutting down");
                        await socket.CloseAsync(WebSocketCloseStatus.InvalidPayloadData, "OPCode not marked for receive in docs", CancellationToken.None);
                        break;
                }
            }
        }

        private async void handleOP0(object response)
        {
            DiscordGenericOPResponse message = (DiscordGenericOPResponse)response;
        }
        private async void handleOP1()
        {
            await core.SendHeartbeat();
        }

        private async void handleOP7()
        {

        }

        private async void handleOP9()
        {

        }

        private async void handleOP10()
        {

        }

        private async void handleOP11()
        {

        }
    }
}
