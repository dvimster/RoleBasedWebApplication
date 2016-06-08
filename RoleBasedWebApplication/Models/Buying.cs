using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoleBasedWebApplication.Models
{
    public class Buying
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int? ArtifactId { get; set; }
        public virtual Artifact Artifact { get; set; }
        public int? CharacterId { get; set; }
        public virtual Character Character { get; set; }
        public DateTime DateTime { get; set; }
    }
}