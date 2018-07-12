using System.Collections.Generic;

namespace ETicModels.Entities
{
    public enum Role
    {
        Admin=0,
        User=1
    }
   public class AppUser:CoreEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string ImagePath { get; set; }
        public List<Comment> Comments { get; set; }
        public string Address { get; set; }
        public Role Role { get; set; }
    }
}
