﻿using System;
using TsukiDiscordBot.DiscordClient;

namespace TsukiDiscordBot
{
    class Program
    {
        static void Main(string[] args)
        {
            DiscordBot bot = new DiscordBot();
            bot.run();
        }
    }
}
