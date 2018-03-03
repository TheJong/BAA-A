using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Baaa.Models
{
    public class Klanten
    {
        public int Id { get; set; }
        //Data input required
        [Required]
        //Max input length
        [StringLength(20)]
        //Changes the display name
        [DisplayName("Voornaam")]
        public string VoorNaam { get; set; }
        [Required]
        [StringLength(20)]
        [DisplayName("Achternaam")]
        public string AchterNaam { get; set; }
        [Required]
        [StringLength(50)]
        [DisplayName("Adres")]
        public string Adres { get; set; }
        [Required]
        [StringLength(15)]
        [DisplayName("Postcode")]
        public string Postcode { get; set; }
        [Required]
        [StringLength(100)]
        [DisplayName("Plaats")]
        public string PlaatsNaam { get; set; }
        [Required]
        [StringLength(25)]
        [DisplayName("Telefoon")]
        public string Telefoon { get; set; }
        [Required]
        [DisplayName("Provincie")]
        public int ProvincieId { get; set; }
        [StringLength(50)]
        [DisplayName("Opslag")]
        public string Opslag { get; set; }
        [StringLength(50)]
        [DisplayName("Huisdier")]
        public string DierName { get; set; }
        [StringLength(50)]
        [DisplayName("Opvang")]
        public string OpvangName { get; set; }
        [DisplayName("Observeren")]
        public int ObserverenId { get; set; }
        [DisplayName("Weghalen")]
        public int WeghaalId { get; set; }
        [StringLength(300)]
        //Expand the size to Multiline
        [DataType(DataType.MultilineText)]
        public string Opmerking { get; set; }
    }

    public class KlantViewModel
    {
        public int Id { get; set; }
        [DisplayName("Naam")]
        public string VoorNaam { get; set; }
        [DisplayName("Achternaam")]
        public string AchterNaam { get; set; }
        [DisplayName("Adres")]
        public string Adres { get; set; }
        [DisplayName("Postcode")]
        public string Postcode { get; set; }
        [DisplayName("Plaats")]
        public string PlaatsNaam { get; set; }
        [DisplayName("Provincie")]
        public string ProvincieName { get; set; }
        [DisplayName("Opslag")]
        public string Opslag { get; set; }
    }

    public class KlantenDetail
    {
        public int Id { get; set; }

        [DisplayName("Voornaam")]
        public string VoorNaam { get; set; }
        [DisplayName("Achternaam")]
        public string AchterNaam { get; set; }
        [DisplayName("Adres")]
        public string Adres { get; set; }
        [DisplayName("Postcode")]
        public string Postcode { get; set; }
        [DisplayName("Plaats")]
        public string PlaatsNaam { get; set; }
        [DisplayName("Telefoon")]
        public string Telefoon { get; set; }
        [DisplayName("Provincie")]
        public string ProvincieName { get; set; }
        [DisplayName("Opslag")]
        public string Opslag { get; set; }
        [DisplayName("Huisdier")]
        public string DierName { get; set; }
        [DisplayName("Opvang")]
        public string OpvangName { get; set; }
        [DisplayName("Observeren")]
        public string ObserverenName { get; set; }
        [DisplayName("Weghalen")]
        public string WeghaalName { get; set; }
        public string Opmerking { get; set; }
    }
}