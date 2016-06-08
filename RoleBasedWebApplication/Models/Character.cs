using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RoleBasedWebApplication.Models
{
    public class Character
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Вы не вели имя персонажа")]
        [DisplayName("Имя")]
        public string Name { get; set; }
        
        public int GoldDime { get; set; }

        [Required(ErrorMessage = "Вы не выбрали тип персонажа")]
        [DisplayName("Выберите тип персонажа")]
        public int? CharacterTypeId { get; set; }
        public virtual CharacterType CharacterType { get; set; }

        [Required(ErrorMessage = "Вы не выбрали рассу персонажа")]
        [DisplayName("Выберите рассу персонажа")]
        public int? CharacterRaseId { get; set; }
        public virtual CharacterRase CharacterRase { get; set; }

        [Required(ErrorMessage = "Вы не выбрали аватар для персонажа")]
        [DisplayName("Выберите аватар для персонажа")]
        public int? CharacterAvatarId { get; set; }
        public virtual CharacterAvatar CharacterAvatar { get; set; }

        public string UserId { get; set; }
        public virtual ICollection<Buying> Buyings { get; set; }
        public virtual ICollection<Selling> Sellings { get; set; } 

        public Character()
        {
            Buyings = new List<Buying>();
            Sellings = new List<Selling>();
        }
    }
}