using System.Collections.Generic;

namespace RoleBasedWebApplication.Models
{
    public class ArtifactClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Artifact> Artifacts { get; set; }

        public ArtifactClass()
        {
            Artifacts = new List<Artifact>();
        }
    }
}