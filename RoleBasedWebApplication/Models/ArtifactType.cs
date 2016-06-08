using System.Collections.Generic;

namespace RoleBasedWebApplication.Models
{
    public class ArtifactType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Artifact> Artifacts { get; set; }

        public ArtifactType()
        {
            Artifacts = new List<Artifact>();
        }
    }
}