using Discord;
using System;
using System.Linq;
using System.Text;

namespace capslockbot.Modules.Utilities
{
    class Randomization
    {
        private Server server;
        private User user;
        private Random random = new Random();
        
        //Get a random Integer
        public int intRandom(int count)
        {

            int rand = 0;

            rand = random.Next(0, count);

            //Console.WriteLine("New random number: " + rand);
            return rand;
        }

        //Get a random User
        //WORK IN PROGRESS
        public User userRandom()
        {
            Console.WriteLine("Entered Random User");

            int count = EnumController.Count(server.Users);
            Console.WriteLine("Count: " + count);
            int rand = intRandom(count);
            Console.WriteLine("Rand: " + rand);

            return server.Users.ElementAt(rand);
        }
    }
}
