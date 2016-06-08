using System.Collections.Generic;

namespace RoleBasedWebApplication.Models
{
    public class ArtifactIcon
    {
        public int Id { get; set; }
        public string Src { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Artifact> Artifacts { get; set; }

        public ArtifactIcon()
        {
            Artifacts = new List<Artifact>();
        }
    }
}