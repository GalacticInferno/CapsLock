using Discord;
using Discord.Commands;
using System;
using System.Linq;

namespace capslockbot
{
    class Kick
    {
        CommandService commands;

        public Kick(CommandService command)
        {
            this.commands = command;
        }

        public void KickController()
        {
            commands.CreateCommand("kick")
                .Description("Capslock kicks those that are mentioned")
                .Parameter("User", ParameterType.Required)
                .Do(async (e) =>
                {
                    try
                    {
                        if (e.User.ServerPermissions.KickMembers)
                        {
                            User user = null;

                            user = e.Server.FindUsers(e.GetArg("User")).First();

                            if (user != null)
                            {
                                if (user.Equals(e.User.Name))
                                {
                                    await e.Channel.SendMessage("OUCH! That hurts!");
                                }
                                else
                                {
                                    await user.Kick();
                                    await e.Channel.SendMessage(user + " was kicked from the Discord Server!");
                                }
                            }
                            else
                            {
                                await e.Channel.SendMessage("Couldn't find " + user);
                            }

                        }
                        else
                        {
                            var temp = e.User.Name;
                            await e.Channel.SendMessage(temp + " you don't have permission to kick.");
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
