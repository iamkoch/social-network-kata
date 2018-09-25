using System;

namespace SocialNetwork.Domain
{
    public class Post
    {
        private readonly User _user;
        private readonly string _text;
        private readonly DateTimeOffset _when;

        public Post(User user, string text, DateTimeOffset when)
        {
            _user = user;
            _text = text;
            _when = when;
        }

        public string PrettyPrint 
            => $"{_user.DisplayName} - {_text} ({TimeFormatter.PrettyPrint(_when)})";
    }
}