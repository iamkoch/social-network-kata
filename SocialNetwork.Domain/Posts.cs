using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialNetwork.Domain
{
    public class Posts
    {
        private readonly List<Post> _posts = new List<Post>();

        public void Add(User user, string text, DateTimeOffset when) 
            => _posts.Add(new Post(user, text, when));

        public List<string> ToList() 
            => _posts.Select(x => x.PrettyPrint).ToList();
    }
}