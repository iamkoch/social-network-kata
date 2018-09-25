using System;
using System.Collections.Generic;
using System.Linq;
using SocialNetwork.Domain;

namespace SocialNetwork.ApplicationServices
{
    public class PostToTimelineCommand : Command
    {
        private readonly string _input;

        public PostToTimelineCommand(List<User> users, string input) : base(users)
        {
            _input = input;
        }

        public override List<string> Execute()
        {
            var tokens = _input.Split(new string[] { " -> " }, StringSplitOptions.None);
            var user = tokens.First();
            var post = tokens.Skip(1).First();

            var matchingUser = GetCreateUser(user);

            matchingUser.PostToTimeline(post, SystemTime.Now());

            return Enumerable.Empty<string>().ToList();
        }
    }
}