using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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
