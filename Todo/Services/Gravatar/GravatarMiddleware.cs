using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;

namespace Todo.Services.Gravatar
{
    public static class GravatarMiddlewareExtensions
    {
        public static IApplicationBuilder UseGravatar(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<GravatarMiddleware>();
        }
    }
    
    public class GravatarMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IMemoryCache _cache;
        private readonly IGravatarClient _gravatarClient;

        public GravatarMiddleware(RequestDelegate next, IMemoryCache cache, IGravatarClient gravatarClient)
        {
            _next = next;
            _cache = cache;
            _gravatarClient = gravatarClient;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.User.Identity == null)
                throw new InvalidOperationException("Cannot use gravatar before user authorization.");

            var name = await _gravatarClient.GetName(context.User.Identity.Name);
            _cache.Set(context.User.Identity.Name, name, TimeSpan.FromDays(1));
            
            await _next(context);
        }
    }
}