using System.Collections.Generic;

namespace RoleBasedWebApplication.Models
{
    public class ArtifactImage
    {
        public int Id { get; set; }
        public string Src { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Artifact> Artifacts { get; set; }
        public ArtifactImage()
        {
            Artifacts = new List<Artifact>();
        }
    }
}