using System;
using System.Collections.Generic;
using System.Text;
using TsukiDiscordBot.DiscordClient.DiscordInterfaces;

namespace TsukiDiscordBot
{
    class EventResolver : IDiscordEvents
    {
        public void onReadyEvent()
        {
            Console.WriteLine("Ready");
        }
    }
}
