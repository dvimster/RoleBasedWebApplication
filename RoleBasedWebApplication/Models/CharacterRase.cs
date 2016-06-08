using System.Collections.Generic;

namespace RoleBasedWebApplication.Models
{
    public class CharacterRase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Character> Characters { get; set; }

        public CharacterRase()
        {
            Characters = new List<Character>();
        }
    }
}