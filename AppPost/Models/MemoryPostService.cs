﻿namespace AppPost.Models
{
    public class MemoryPostService : IPostService
    {
        private  Dictionary<int, Post> _posts = new Dictionary<int, Post>();

        public int Add(Post post)
        {
            int id = _posts.Keys.Count != 0 ? _posts.Keys.Max() + 1 : 1;
            post.Id = id;
            _posts.Add(id, post);
            return id;
        }

        public void Delete(int id)
        {
            _posts.Remove(id);
        }

        public List<Post> FindAll()
        {
            return _posts.Values.ToList();
        }


        public Post? FindById(int id)
        {
            if (_posts.TryGetValue(id, out var post))
            {
                return post;
            }
            return null;
        }

        public void Update(Post post)
        {
            if (_posts.ContainsKey(post.Id))
            {
                _posts[post.Id] = post;
            }
         
        }
        public PagingList<Post> FindPage(int page, int size)
        {
            int totalItems = _posts.Count;
            var posts = _posts.Values
                .Skip((page - 1) * size)
                .Take(size)
                .ToList();

            return PagingList<Post>.Create(posts, totalItems, page, size);
        }
    }
}