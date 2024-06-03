using Core.Contracts;
using Core.Entities;
using Infrastructure.Context;

namespace Infrastructure.Repositories
{
    public class RequestDetailRepository(ApplicationDbContext context) : RepositoryBase<RequestDetail>(context), IRequestDetailRepository
    {

    }
}