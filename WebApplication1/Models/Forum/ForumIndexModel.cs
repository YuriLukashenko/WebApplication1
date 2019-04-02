using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.Forum
{
    public class ForumIndexModel
    {
        public IEnumerable <ForumListingModel> ForumList { get; set; }
    }
}
