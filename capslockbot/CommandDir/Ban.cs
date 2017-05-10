using Discord;
using Discord.Commands;
using System;
using System.Linq;

namespace capslockbot
{
    class Ban
    {
        CommandService commands;

        public Ban(CommandService command)
        {
            this.commands = command;
        }

        public void BanController()
        {
            commands.CreateCommand("ban")
                .Alias(new string[] { "Bye, disapper, leave" })
                .Description("Capslock bans the user given")
                .Parameter("User", ParameterType.Required)
                .Do(async (e) =>
                {
                    try
                    {

                        if (e.User.ServerPermissions.BanMembers)
                        {
                            User user = null;

                            user = e.Server.FindUsers(e.GetArg("User")).First();

                            if (user != null)
                            {
                                await user.Kick();
                                await e.Channel.SendMessage(user + " was banned from the Discord Server!");
                            }
                            else
                            {
                                await e.Channel.SendMessage("Couldn't find " + user);
                            }

                        }
                        else
                        {
                            var temp = e.User.Name;
                            await e.Channel.SendMessage(temp + " you don't have permission to ban.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        return;
                    }
                });
        }
    }
}
