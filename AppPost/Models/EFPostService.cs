using AppPost.Mappers;
using DataPostu;
using DataPostu.Entities;


namespace AppPost.Models
{
    public class EFPostService : IPostService
    {
        private readonly AppDbContext _context;
        
        public EFPostService(AppDbContext context)
        {
            _context = context;
        }

        public int Add(Post post)
        {
            var entity = PostMapper.ToEntity(post);
            var addedEntity = _context.Pots.Add(entity);
            _context.SaveChanges();
            return addedEntity.Entity.Id;
        }

        public void Delete(int id)
        {
            var entity = _context.Pots.Find(id);
            if (entity != null)
            {
                _context.Pots.Remove(entity);
                _context.SaveChanges();
            }
        }

        public List<Post> FindAll()
        {
            var entities = _context.Pots.ToList();
            return entities.Select(PostMapper.ToModel).ToList();
        }

        public Post? FindById(int id)
        {
            var entity = _context.Pots.Find(id);
            return entity != null ? PostMapper.ToModel(entity) : null;
        }

        public void Update(Post post)
        {
            var entity = PostMapper.ToEntity(post);
            _context.Pots.Update(entity);
            _context.SaveChanges();
        }

        public PagingList<Post> FindPage(int page, int size)
        {
            int totalItems = _context.Pots.Count();
            var entities = _context.Pots
                .OrderBy(p => p.Id)
                .Skip((page - 1) * size)
                .Take(size)
                .ToList();

            var posts = entities.Select(PostMapper.ToModel).ToList();

            return PagingList<Post>.Create(posts, totalItems, page, size);
        }
    }
}
