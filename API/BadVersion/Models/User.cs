using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.BadVersion.Models
{
    internal class User
    {
        [JsonProperty("first_name")]

        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? Id { get; set; }
        public string Email { get; set; }
        public string Avatar { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is User user &&
                   FirstName == user.FirstName &&
                   LastName == user.LastName &&
                   Email == user.Email &&
                   Avatar == user.Avatar;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FirstName, LastName, Email, Avatar);
        }

        public override string? ToString()
        {
            return $"{FirstName}, {LastName}, {Email}, {Avatar}";
        }
    }
}
