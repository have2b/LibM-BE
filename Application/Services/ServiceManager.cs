using Application.Contracts;
using Core.Contracts;

namespace Application.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<ICategoryService> _categoryService;
        private readonly Lazy<IBookService> _bookService;
        private readonly Lazy<IRequestService> _requestService;
        private readonly Lazy<IUserService> _userService;
        private readonly Lazy<IBookCategoryService> _bookCategoryService;


        public ServiceManager(IRepositoryManager repository)
        {
            _categoryService = new Lazy<ICategoryService>(() => new CategoryService(repository));
            _bookService = new Lazy<IBookService>(() => new BookService(repository));
            _requestService = new Lazy<IRequestService>(() => new RequestService(repository));
            _userService = new Lazy<IUserService>(() => new UserService(repository));
            _bookCategoryService = new Lazy<IBookCategoryService>(() => new BookCategoryService(repository));
        }

        public ICategoryService CategoryService => _categoryService.Value;

        public IBookService BookService => _bookService.Value;

        public IUserService UserService => _userService.Value;

        public IRequestService RequestService => _requestService.Value;

        public IRequestDetailService RequestDetailService => throw new NotImplementedException();

        public IBookCategoryService BookCategoryService => _bookCategoryService.Value;
    }
}