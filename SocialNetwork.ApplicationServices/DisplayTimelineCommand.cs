using System.Collections.Generic;
using SocialNetwork.Domain;

namespace SocialNetwork.ApplicationServices
{
    public class DisplayTimelineCommand : Command
    {
        private readonly string _input;

        public DisplayTimelineCommand(List<User> users, string input) : base(users)
        {
            _input = input;
        }

        public override List<string> Execute()
        {
            var user = GetCreateUser(_input);
            return user.FormattedPosts();
        }
    }
}