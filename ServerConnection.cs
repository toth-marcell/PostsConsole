using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PostsConsole
{
    internal class ServerConnection(string url)
    {
        private readonly HttpClient HTTP = new() { BaseAddress = new Uri(url) };
        private string? Token;
        public bool IsLoggedIn => Token != null;
        public async Task<string> Register(string name, string password, string about)
        {
            try
            {
                HttpContent content = new StringContent(JsonSerializer.Serialize(new User(name, password, about)), Encoding.UTF8, "application/json");
                HttpResponseMessage result = await HTTP.PostAsync("register", content);
                string body = await result.Content.ReadAsStringAsync();
                Message response = JsonSerializer.Deserialize<Message>(body);
                return response.Content;
            }
            catch (Exception e) { return e.Message; }
        }
        public async Task<string> Login(string name, string password)
        {
            try
            {
                HttpContent content = new StringContent(JsonSerializer.Serialize(new User(name, password)), Encoding.UTF8, "application/json");
                HttpResponseMessage result = await HTTP.PostAsync("login", content);
                string body = await result.Content.ReadAsStringAsync();
                Message response = JsonSerializer.Deserialize<Message>(body);
                if (response.Token != null) Token = response.Token;
                return response.Content;
            }
            catch (Exception e) { return e.Message; }
        }
        public async Task<List<Post>> GetPosts()
        {
            HttpResponseMessage result = await HTTP.GetAsync("post");
            string body = await result.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Post>>(body);
        }
    }
}
