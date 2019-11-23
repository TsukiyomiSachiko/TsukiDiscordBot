using System;
using System.Collections.Generic;
using System.Text;
using TsukiDiscordBot.DiscordClient.DiscordInterfaces;

namespace TsukiDiscordBot.DiscordClient
{
    class DiscordEventResolver
    {
        private IDiscordEvents events;

        public DiscordEventResolver(IDiscordEvents events)
        {
            this.events = events;
        }
        public async void resolveEvent()
        {
            events.onReadyEvent();
        }
    }
}
