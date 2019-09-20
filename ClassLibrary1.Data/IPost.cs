using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1.Data.Models;

namespace ClassLibrary1.Data
{
    public interface IPost
    {
        Post GetById(int id);
        IEnumerable<Post> GetAll();

        Task Add(Post post);
        Task Delete(int id);
        Task EditPostContent(int id, string newContent);
        Task AddReply(PostReply reply);

        IEnumerable<Post> GetPostByForum(int id);
        IEnumerable<Post> GetLatestPosts(int n);
        IEnumerable<Post> GetFilteredPosts(Forum forum, string searchQuery);
        IEnumerable<Post> GetFilteredPosts(string searchQuery);
    }
}
