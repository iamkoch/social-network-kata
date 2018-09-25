using System;
using System.Collections.Generic;
using System.Linq;
using SocialNetwork.Domain;

namespace SocialNetwork.ApplicationServices
{
    public class CommandFactory
    {
        private static readonly List<User> Users = new List<User>();

        public static Command CreateFromInvocation(string input)
        {
            if (input.Contains("->"))
                return new PostToTimelineCommand(Users, input);

            if (Users.Any(x => x.Is(input)))
                return new DisplayTimelineCommand(Users, input);

            throw new NotImplementedException();
        }
    }
}
