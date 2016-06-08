using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RoleBasedWebApplication.Models
{
    public class EntriesContext : DbContext
    {
        public EntriesContext()
            : base("DefaultConnection")
        {
            
        }

        public DbSet<Character> Characters { get; set; }
        public DbSet<CharacterRase> CharacterRases { get; set; }
        public DbSet<CharacterType> CharacterTypes { get; set; }
        public DbSet<CharacterAvatar> CharacterAvatars { get; set; }
        public DbSet<Artifact> Artifacts { get; set; }
        public DbSet<ArtifactClass> ArtifactClasses { get; set; }
        public DbSet<ArtifactType> ArtifactTypes { get; set; }
        public DbSet<ArtifactIcon> ArtifactIcons { get; set; }
        public DbSet<ArtifactImage> ArtifactImages { get; set; }
        public DbSet<Buying> Buyings { get; set; }
        public DbSet<Selling> Sellings { get; set; }
    }
}