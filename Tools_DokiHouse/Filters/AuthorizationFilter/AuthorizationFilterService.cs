using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.DependencyInjection;


namespace Tools_DokiHouse.Filters.AuthorizationFilter
{
    public static class AuthorizationFilterService
    {
        public static void AddFilterControllersAuthorize(this IServiceCollection service)
        {
            service.AddControllers(options =>
            {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();

                options.Filters.Add(new AuthorizeFilter(policy));
            });
        }
    }
}
