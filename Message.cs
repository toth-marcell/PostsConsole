using System.Text.Json.Serialization;

namespace PostsConsole
{
    internal struct Message(string content)
    {
        [JsonPropertyName("msg")]
        public string Content { get; set; } = content;
        [JsonPropertyName("token")]
        public string? Token { get; set; }
    }
}
