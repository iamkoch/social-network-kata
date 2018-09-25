using System.Collections.Generic;

namespace SocialNetwork.ApplicationServices
{
    public class CommandHandler
    {
        public static List<string> Handle(Command command)
        {
            return command.Execute();
        }
    }
}