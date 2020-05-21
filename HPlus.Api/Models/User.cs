using System.Collections.Generic;

namespace HPlus.Api.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public IList<Order> Orders { get; set; }
    }
}
