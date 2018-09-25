using System;
using System.Collections.Generic;
using System.Linq;
using SocialNetwork.Domain;

namespace SocialNetwork.ApplicationServices
{
    public class CommandFactory
    {
        private static List<User> _users = new List<User>();

        public static Command CreateFromInvocation(string input)
        {
            if (input.Contains("->"))
                return new PostToTimelineCommand(_users, input);

            if (_users.Any(x => x.DisplayName == input))
                return new DisplayTimelineCommand(_users, input);

            throw new NotImplementedException();
        }
    }

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

    public abstract class Command
    {
        private readonly List<User> _users;

        protected Command(List<User> users)
        {
            _users = users;
        }

        protected User GetCreateUser(string name)
        {
            var matchingUser = _users.FirstOrDefault(x => x.DisplayName == name);

            if (matchingUser != null)
                return matchingUser;

            var newUser = new User(name);

            _users.Add(newUser);

            return newUser;
        }

        public abstract List<string> Execute();
    }
}
