﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.Post;

namespace WebApplication1.Models.Forum
{
    public class ForumTopicModel
    {
        public ForumListingModel Forum { get; set; }
        public IEnumerable<PostListingModel> Posts { get; set; }
        public string SearchQuery { get; set; }

    }
}
