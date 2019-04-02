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
        IEnumerable<Post> GetFilteredPost(string searchQuery);

        Task Add(Post post);
        Task Delete(int id);
        Task EditPostContent(int id, string newContent);

    }
}
