using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace capslockbot.CommandDir
{
    class Mute
    {
        CommandService commands;

        public Mute(CommandService command)
        {
            this.commands = command;
        }

        public void MuteController()
        {
            commands.CreateCommand("Mute")
                .Alias("Shut up", "mute", "muet", "shut up")
                .Description("Capslock will mute the user specificed by the command caller")
                .Parameter("User", ParameterType.Required)
                .Do(async (e) =>
                {
                    try
                    {
                        if(e.User.ServerPermissions.MuteMembers)
                        {
                            User user = null;

                            user = e.Server.FindUsers(e.GetArg("User")).First();

                            if (user != null)
                            {
                                if (user.Equals(e.User.Name))
                                {
                                    await e.Channel.SendMessage("How dare you!");
                                }
                                else
                                {
                                    await user.Edit(isMuted: true);
                                    await e.Channel.SendMessage(user + " was muted!");
                                }
                            }
                            else
                            {
                                await e.Channel.SendMessage("Couldn't find " + user);
                            }
                        }
                        else
                        {

                        }
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex);
                        return;
                    }
                });
        }
    }
}
