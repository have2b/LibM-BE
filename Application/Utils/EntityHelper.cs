using Core.Exceptions;

namespace Application.Utils
{
    public static class EntityHelper
    {
        public static async Task<T> GetEntityAndCheckIfItExists<T>(Guid id, Func<Guid, Task<T>> getEntityAsync) where T : class
        {
            var entity = await getEntityAsync(id)
                         ?? throw new NotFoundException(typeof(T), id);

            return entity;
        }
    }
}