using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Todo.Services.Gravatar
{
    public interface IGravatarClient
    {
        Task<string> GetName(string email);
    }
    
    public class GravatarClient : IGravatarClient
    {
        private readonly HttpClient _client;

        public GravatarClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<string> GetName(string email)
        {
            try
            {
                var profile = await _client.GetFromJsonAsync<GravatarProfile>($"{Gravatar.GetHash(email)}.json");
                return profile?.Entry[0].DisplayName;
            }
            catch (Exception)
            {
                // TODO: log exception
                return null;
            }
        }
    }
}