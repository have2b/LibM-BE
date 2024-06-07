using System.Reflection;
using Application.DTOs;
using Core.Entities;
using Mapster;

namespace API.Extensions
{
    public static class MapsterConfig
    {
        public static void RegisterMapsterConfiguration(this IServiceCollection services)
        {
            TypeAdapterConfig<Request, RequestDto>
            .NewConfig()
            .Map(dest => dest.BookIds, src => src.RequestDetails.Select(rq => rq.BookId));

            TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());

        }
    }
}