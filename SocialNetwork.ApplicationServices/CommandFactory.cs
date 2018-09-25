using System;

namespace SocialNetwork.ApplicationServices
{
    public class CommandFactory
    {
        public static Command CreateFromInvocation(string input)
        {
            return new Command();
        }
    }

    public class Command
    {

    }
}
