﻿using Actual_Project_V3.Models;

namespace Actual_Project_V3.Repositories
{
    public class SearchResults
    {
        public List<User> Users { get; set; }
        public List<Post> Posts { get; set; }
        public List<Subreddit> Subreddits { get; set; }
    }
}
