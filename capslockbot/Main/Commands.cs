using Discord.Commands;
using capslockbot.CommandDir;

namespace capslockbot
{
    class Commands
    {
        CommandService commands;

        //Commands Constructor
        public Commands(CommandService command)
        {
            this.commands = command;
        }

        //Class Main Function
        public void CommandControler()
        {
            RegisterHelloCommand();

            RegisterKickCommand();
            RegisterBanCommand();
            RegisterUnBanCommand();

            RegisterCreateChannelCommand();
            RegisterDeleteChannelCommand();

            RegisterMuteCommand();
            RegisterUnMuteCommand();

            //RegisterDeafenCommand();
            //RegisterUnDeafenCommand();

            //RegisterRoleCommand();
        }

        private void RegisterHelloCommand()
        {
            var hello = new Hello(commands);
            hello.HelloControler();
        }

        private void RegisterKickCommand()
        {
            var kick = new Kick(commands);
            kick.KickController();
        }

        private void RegisterBanCommand()
        {
            var ban = new Ban(commands);
            ban.BanController();
        }

        private void RegisterUnBanCommand()
        {
            var unban = new UnBan(commands);
            unban.UnBanController();
        }

        private void RegisterMuteCommand()
        {
            var mute = new Mute(commands);

            mute.MuteController();
        }

        private void RegisterUnMuteCommand()
        {

        }

        private void RegisterCreateChannelCommand()
        {

        }

        private void RegisterDeleteChannelCommand()
        { 
        }


    }
}
