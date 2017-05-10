using Discord;
using Discord.Commands;
using System;
using System.Linq;

namespace capslockbot
{
    class UnBan
    {
        CommandService commands;

        public UnBan(CommandService command)
        {
            this.commands = command;
        }

        public void UnBanController()
        {
            commands.CreateCommand("unban")
                .Alias(new string[] { "unBan, UnBan" })
                .Description("Capslock unbans the user given")
                .Parameter("User")
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
                                await e.Channel.SendMessage(user + " was unbanned from the Discord Server!");
                            }
                            else
                            {
                                await e.Channel.SendMessage("Couldn't find " + user);
                            }

                        }
                        else
                        {
                            var temp = e.User.Name;
                            await e.Channel.SendMessage(temp + " you don't have permission to unban.");
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
