using Application.Contracts;
using Core.Contracts;
using Microsoft.Extensions.Configuration;

namespace Application.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<ICategoryService> _categoryService;
        private readonly Lazy<IBookService> _bookService;
        private readonly Lazy<IRequestService> _requestService;
        private readonly Lazy<IRequestDetailService> _requestDetailService;
        private readonly Lazy<IUserService> _userService;
        private readonly Lazy<IBookCategoryService> _bookCategoryService;
        private readonly Lazy<IJwtAuthService> _jwtAuthService;
        private readonly Lazy<IAuthService> _authService;


        public ServiceManager(IRepositoryManager repository, IConfiguration configuration)
        {
            _categoryService = new Lazy<ICategoryService>(() => new CategoryService(repository));
            _bookService = new Lazy<IBookService>(() => new BookService(repository));
            _requestService = new Lazy<IRequestService>(() => new RequestService(repository));
            _requestDetailService = new Lazy<IRequestDetailService>(() => new RequestDetailService(repository));
            _userService = new Lazy<IUserService>(() => new UserService(repository));
            _bookCategoryService = new Lazy<IBookCategoryService>(() => new BookCategoryService(repository));
            _jwtAuthService = new Lazy<IJwtAuthService>(() => new JwtAuthService(configuration));
            _authService = new Lazy<IAuthService>(() => new AuthService(repository, _jwtAuthService.Value));
        }

        public ICategoryService CategoryService => _categoryService.Value;

        public IBookService BookService => _bookService.Value;

        public IUserService UserService => _userService.Value;

        public IRequestService RequestService => _requestService.Value;

        public IRequestDetailService RequestDetailService => _requestDetailService.Value;

        public IBookCategoryService BookCategoryService => _bookCategoryService.Value;

        public IJwtAuthService JwtAuthService => _jwtAuthService.Value;

        public IAuthService AuthService => _authService.Value;
    }
}