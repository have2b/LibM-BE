namespace Core.Contracts
{
    public interface IRepositoryManager
    {
        IUserRepository User { get; }
        ICategoryRepository Category { get; }
        IBookRepository Book { get; }
        IRequestRepository Request { get; }
        IRequestDetailRepository RequestDetail { get; }
        Task SaveAsync();
    }
}