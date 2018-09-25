using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialNetwork.Domain
{
    public class SystemTime
    {
        public static Func<DateTimeOffset> Now = () => DateTimeOffset.UtcNow;
        public static Func<DateTimeOffset> Reset = Now = () => DateTimeOffset.UtcNow;
    }

    public class User
    {
        private readonly List<Post> _posts = new List<Post>();

        public User(string displayName)
        {
            DisplayName = displayName;
        }

        public string DisplayName { get; set; }

        public void PostToTimeline(string post, DateTimeOffset when)
        {
            _posts.Add(new Post(post, when));
        }

        public List<string> FormattedPosts()
        {
            return _posts.Select(x => $"{DisplayName} - {x.Text} ({(SystemTime.Now() - x.When).TotalMinutes} minutes ago)").ToList();
        }
    }

    public class Post
    {
        public string Text { get; }
        public DateTimeOffset When { get; }

        public Post(string text, DateTimeOffset when)
        {
            Text = text;
            When = when;
        }
    }
}