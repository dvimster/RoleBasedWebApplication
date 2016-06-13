using RoleBasedWebApplication.Models;

namespace RoleBasedWebApplication.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RoleBasedWebApplication.Models.EntriesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RoleBasedWebApplication.Models.EntriesContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.CharacterAvatars.AddOrUpdate(
                p => p.Avatar,
                new CharacterAvatar { Avatar = "1.jpg" },
                new CharacterAvatar { Avatar = "2.jpg" },
                new CharacterAvatar { Avatar = "3.jpg" },
                new CharacterAvatar { Avatar = "4.jpg" },
                new CharacterAvatar { Avatar = "5.jpg" },
                new CharacterAvatar { Avatar = "6.jpg" }
                );

            context.CharacterTypes.AddOrUpdate(
                p => p.Name,
                new CharacterType { Name = "Killer" },
                new CharacterType { Name = "Soldier" },
                new CharacterType { Name = "Warrior" },
                new CharacterType { Name = "Mag" },
                new CharacterType { Name = "Sniper" },
                new CharacterType { Name = "Saper" }
                );
            context.CharacterRases.AddOrUpdate(
                p => p.Name,
                new CharacterRase { Name = "Orks" },
                new CharacterRase { Name = "Elphs" },
                new CharacterRase { Name = "Mags" },
                new CharacterRase { Name = "Human" },
                new CharacterRase { Name = "Teacher" },
                new CharacterRase { Name = "Gnoms" }
                );
            context.ArtifactClasses.AddOrUpdate(
                p => p.Name,
                new ArtifactClass { Name = "Speed" },
                new ArtifactClass { Name = "Health" },
                new ArtifactClass { Name = "Damage" },
                new ArtifactClass { Name = "Opacity" },
                new ArtifactClass { Name = "Guard" }
                );
            context.ArtifactTypes.AddOrUpdate(
                p => p.Name,
                new ArtifactType { Name = "Soldier" },
                new ArtifactType { Name = "Mag" },
                new ArtifactType { Name = "Sniper" },
                new ArtifactType { Name = "Warrior" },
                new ArtifactType { Name = "Teacher" },
                new ArtifactType { Name = "General" }
                );
            context.ArtifactIcons.AddOrUpdate(
                p => p.Src,
                new ArtifactIcon { Src = "1.png" },
                new ArtifactIcon { Src = "2.png" },
                new ArtifactIcon { Src = "3.png" },
                new ArtifactIcon { Src = "4.png" },
                new ArtifactIcon { Src = "5.png" },
                new ArtifactIcon { Src = "6.png" },
                new ArtifactIcon { Src = "7.png" },
                new ArtifactIcon { Src = "8.png" },
                new ArtifactIcon { Src = "9.png" },
                new ArtifactIcon { Src = "10.png" },
                new ArtifactIcon { Src = "11.png" },
                new ArtifactIcon { Src = "12.png" },
                new ArtifactIcon { Src = "13.png" },
                new ArtifactIcon { Src = "14.png" },
                new ArtifactIcon { Src = "15.png" },
                new ArtifactIcon { Src = "16.png" },
                new ArtifactIcon { Src = "17.png" },
                new ArtifactIcon { Src = "18.png" },
                new ArtifactIcon { Src = "19.png" },
                new ArtifactIcon { Src = "20.png" },
                new ArtifactIcon { Src = "21.png" },
                new ArtifactIcon { Src = "22.png" },
                new ArtifactIcon { Src = "23.png" }
                );
            context.ArtifactImages.AddOrUpdate(
                p => p.Src,
                new ArtifactImage { Src = "1.png" },
                new ArtifactImage { Src = "2.png" },
                new ArtifactImage { Src = "3.png" },
                new ArtifactImage { Src = "4.png" },
                new ArtifactImage { Src = "5.png" },
                new ArtifactImage { Src = "6.png" },
                new ArtifactImage { Src = "7.png" },
                new ArtifactImage { Src = "8.png" },
                new ArtifactImage { Src = "9.png" },
                new ArtifactImage { Src = "10.png" },
                new ArtifactImage { Src = "11.png" },
                new ArtifactImage { Src = "12.png" },
                new ArtifactImage { Src = "13.png" },
                new ArtifactImage { Src = "14.png" },
                new ArtifactImage { Src = "15.png" },
                new ArtifactImage { Src = "16.png" },
                new ArtifactImage { Src = "17.png" },
                new ArtifactImage { Src = "18.png" },
                new ArtifactImage { Src = "19.png" },
                new ArtifactImage { Src = "20.png" },
                new ArtifactImage { Src = "21.png" },
                new ArtifactImage { Src = "22.png" },
                new ArtifactImage { Src = "23.png" }
                );
        }
    }
}
