using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TsukiDiscordBot.DiscordClient;

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

            discord = new DiscordCore(client_id);
        }

        public void run()
        {
            discord.initializeConnection();
            Console.ReadLine();
        }
    }
}
