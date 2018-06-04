namespace ChurchSchool.Repository.Repositories
{
    public class BaseRepository
    {
        private RepositoryContext _context;

        public BaseRepository(RepositoryContext context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}