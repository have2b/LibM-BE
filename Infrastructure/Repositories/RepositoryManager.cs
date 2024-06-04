using Core.Contracts;
using Infrastructure.Context;

namespace Infrastructure.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly ApplicationDbContext _context;
        private readonly Lazy<ICategoryRepository> _categoryRepository;
        private readonly Lazy<IBookRepository> _bookRepository;
        private readonly Lazy<IUserRepository> _userRepository;
        private readonly Lazy<IRequestRepository> _requestRepository;
        private readonly Lazy<IRequestDetailRepository> _requestDetailRepository;
        private readonly Lazy<IBookCategoryRepository> _bookCategoryRepository;
        public RepositoryManager(ApplicationDbContext context)
        {
            _context = context;
            _categoryRepository = new Lazy<ICategoryRepository>(() => new CategoryRepository(context));
            _bookRepository = new Lazy<IBookRepository>(() => new BookRepository(context));
            _userRepository = new Lazy<IUserRepository>(() => new UserRepository(context));
            _requestRepository = new Lazy<IRequestRepository>(() => new RequestRepository(context));
            _requestDetailRepository = new Lazy<IRequestDetailRepository>(() => new RequestDetailRepository(context));
            _bookCategoryRepository = new Lazy<IBookCategoryRepository>(() => new BookCategoryRepository(context));
        }

        public ICategoryRepository Category => _categoryRepository.Value;
        public IUserRepository User => _userRepository.Value;
        public IBookRepository Book => _bookRepository.Value;
        public IRequestRepository Request => _requestRepository.Value;
        public IRequestDetailRepository RequestDetail => _requestDetailRepository.Value;

        public IBookCategoryRepository BookCategory => _bookCategoryRepository.Value;

        public async Task SaveAsync() => await _context.SaveChangesAsync();
    }
}