namespace Application.Contracts
{
    public interface IServiceManager
    {
        ICategoryService CategoryService { get; }
        IBookService BookService { get; }
        IUserService UserService { get; }
        IRequestService RequestService { get; }
        IRequestDetailService RequestDetailService { get; }
        IBookCategoryService BookCategoryService { get; }
        IJwtAuthService JwtAuthService { get; }
    }
}