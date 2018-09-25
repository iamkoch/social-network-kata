using System.Collections.Generic;
using System.Linq;
using SocialNetwork.Domain;

namespace SocialNetwork.ApplicationServices
{
    public abstract class Command
    {
        private readonly List<User> _users;

        protected Command(List<User> users)
        {
            _users = users;
        }

        protected User GetCreateUser(string name)
        {
            var matchingUser = _users.FirstOrDefault(x => x.Is(name));

            if (matchingUser != null)
                return matchingUser;

            var newUser = new User(name);

            _users.Add(newUser);

            return newUser;
        }

        public abstract List<string> Execute();
    }
}