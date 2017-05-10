using Discord.Commands;
using Discord;
using capslockbot.Modules.Utilities;
using System;
using System.Xml;

namespace capslockbot.CommandDir
{
    class Hello
    {
        private CommandService commands;
        private static Randomization randomization = new Randomization();

        public Hello(CommandService command)
        {
            this.commands = command;
        }

        public void HelloControler()
        {
            int randResponse = 0;
            String sResponse = null;

            XmlDocument xml = new XmlDocument();
            xml.Load("DataDir/GreetingResponse.xml");

            int count = xml.SelectNodes("//response").Count;


            commands.CreateCommand("hello")
                .Alias(new string[] { "hi", "yo", "greetings", "hey" })
                .Description("Capslock greets those that say hello to it")
                .Do(async (e) =>
                {

                    var userName = e.User.Name;

                    //WORK IN PROGRESS
                    //var randUser = randomization.userRandom();
                    //if (randUser == null)
                        //Console.WriteLine("Random User is NULL");

                    Console.WriteLine(userName + " called Hello command.");

                    randResponse = randomization.intRandom(count);
                    
                    XmlNodeList nodes = xml.SelectNodes("//response");

                    sResponse = String.Format(nodes[randResponse].InnerText, userName /*,randUser*/);
                    await e.Channel.SendMessage(sResponse);
                });

        }
    }
}
