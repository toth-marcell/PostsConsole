using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PostsConsole
{
    internal class User
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("about")]
        public string About { get; set; }

        [JsonPropertyName("isAdmin")]
        public bool IsAdmin { get; set; }

        public User(string name, string password, string about = "", bool isAdmin = false)
        {
            Name = name;
            Password = password;
            About = about;
            IsAdmin = isAdmin;
        }
    }
}
