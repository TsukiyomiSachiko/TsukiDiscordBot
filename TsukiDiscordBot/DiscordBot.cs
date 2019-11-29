using DiscordClient;
using System;
using System.IO;

namespace TsukiDiscordBot
{
    class DiscordBot
    {
        private String client_id;
        private DiscordCore discord;
        public DiscordBot()
        {
            using (StreamReader r = new StreamReader("./client_secret.txt"))
            {
                client_id = r.ReadToEnd();
                client_id = client_id.Trim();
            }
            DiscordEventResolver discordEventResolver = new DiscordEventResolver();

            discordEventResolver.setReadyEventHandler(EventResolver.onReadyEvent);

            discord = new DiscordCore(client_id, discordEventResolver);
        }

        public void run()
        {
            discord.initializeConnection();
            Console.ReadLine();
        }
    }
}
