using Discord;
using Discord.Commands;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace capslockbot
{

    class Capslock
    {
        DiscordClient discord;
        CommandService command;

        public Capslock()
        {
            //setup Capslock error logging
            discord = new DiscordClient(x => 
                {
                    x.LogLevel = LogSeverity.Info;
                    x.LogHandler = Logbook;
                });

            //setup command handling
            discord.UsingCommands(x => 
                {
                    x.PrefixChar = '~';
                    x.AllowMentionPrefix = true;
                });

            command = discord.GetService<CommandService>();

            //setup the commands
            var request = new Commands(command);
            request.CommandControler();

            XmlDocument xml = new XmlDocument();
            xml.Load("DataDir/Private.xml");
            XmlNode node = xml.SelectSingleNode("//token");
            String sNode = node.InnerText;

            try
            {
                //connect the bot
                discord.ExecuteAndWait(async () =>
                {
                    await discord.Connect(sNode, TokenType.Bot);
                });
                
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Token: " + sNode);
            }

        }

        private void Logbook(object sender, LogMessageEventArgs e) 
        {
            Console.WriteLine(e.Message);
        }
    }
}
