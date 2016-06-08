using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoleBasedWebApplication.Models
{
    public class CharacterAvatar
    {
        public int Id { get; set; }
        public string Avatar { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Character> Characters { get; set; }

        public CharacterAvatar()
        {
            Characters = new List<Character>();
        }
    }
}