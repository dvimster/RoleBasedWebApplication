using System.Collections.Generic;

namespace RoleBasedWebApplication.Models
{
    public class CharacterType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Character> Characters { get; set; }

        public CharacterType()
        {
            Characters = new List<Character>();
        }
    }
}