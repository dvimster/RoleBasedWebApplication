using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RoleBasedWebApplication.Models
{
    public class Artifact
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Вы не ввели имя артифакта")]
        [DisplayName("Задайте имя артифакта")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Вы не ввели описание артифакта")]
        [DisplayName("Введите описание артифакта")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Вы не указали стоимость артифакта")]
        [DisplayName("Стоимость артифакта")]
        public int OrderWorth { get; set; }
        [Required(ErrorMessage = "Вы не указали продажною стоимость артифакта")]
        [DisplayName("Продажная стоимость артифакта")]
        public int SaleWorth { get; set; }
        [Required(ErrorMessage = "Вы не выбрали изображение для артифакта")]
        [DisplayName("Выберете изображение для артифакта")]
        public int? ArtifactImageId { get; set; }
        public virtual ArtifactImage ArtifactImage { get; set; }
        [Required(ErrorMessage = "Вы не выбрали иконку для артефакта")]
        [DisplayName("Выберете иконку для артифакта")]
        public int? ArtifactIconId { get; set; }
        public virtual ArtifactIcon ArtifactIcon { get; set; }
        public int? ArtifactClassId { get; set; }
        public virtual ArtifactClass ArtifactClass { get; set; }
        public int? ArtifactTypeId { get; set; }
        public virtual ArtifactType ArtifactType { get; set; }
        [Required(ErrorMessage = "Вы не задали свойства для артефакта")]
        [DisplayName("Задайте свойства для артифакта")]
        public string Properties  { get; set; }
        public virtual ICollection<Buying> Buyings { get; set; }
        public virtual ICollection<Selling> Sellings { get; set; } 

        public Artifact()
        {
            Buyings = new List<Buying>();
            Sellings = new List<Selling>();
        }
    }
}