using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PostsConsole
{
    internal class Post
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("link")]
        public string? Link { get; set; }

        [JsonPropertyName("linkType")]
        public string? LinkType { get; set; }

        [JsonPropertyName("text")]
        public string? Text { get; set; }

        [JsonPropertyName("category")]
        public string Category { get; set; }

        public int UserId { get; set; }

        public Post(string title, string? link, string? linkType, string? text, string category, int userId)
        {
            Title = title;
            Link = link;
            LinkType = linkType;
            Text = text;
            Category = category;
            UserId = userId;
        }
    }
}
