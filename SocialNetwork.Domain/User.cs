using System;
using System.Collections.Generic;

namespace SocialNetwork.Domain
{
    public class User
    {
        private readonly Posts _posts = new Posts();

        public User(string displayName)
        {
            DisplayName = displayName;
        }

        public string DisplayName { get; }

        public bool Is(string nameToMatch) => DisplayName == nameToMatch;

        public void PostToTimeline(string text, DateTimeOffset when)
        {
            _posts.Add(this, text, when);
        }

        public List<string> FormattedPosts()
        {
            return _posts.ToList();
        }
    }
}