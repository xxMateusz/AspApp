using AppPost.Models;
using DataPostu.Entities;

namespace AppPost.Mappers
{
    public class PostMapper
    {
        public static Post ToModel(PostEntity entity)
        {
            return new Post
            {
                Id = entity.Id,
                Content = entity.Content,
                Author = entity.Author,
                PublicationDate = (DateTime)entity.PublicationDate,
                Tags = entity.Tags,
                Comment = entity.Comment
            };
        }

        public static PostEntity ToEntity(Post model)
        {
            return new PostEntity
            {
                Id = model.Id,
                Content = model.Content,
                Author = model.Author,
                PublicationDate = model.PublicationDate,
                Tags = model.Tags,
                Comment = model.Comment
            };
        }
    }
}
