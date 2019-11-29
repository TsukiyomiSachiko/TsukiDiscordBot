using DiscordClient;
using System;

namespace TsukiDiscordBot
{
    static class EventResolver
    {
        public static void onReadyEvent()
        {
            Console.WriteLine("Ready");
        }
    }
}
