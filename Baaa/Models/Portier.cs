using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Baaa.Models
{
    public class Portier
    {
        public int Id { get; set; }
        [DisplayName("Voornaam")]
        public string PortierNaam { get; set; }
        [DisplayName("Achternaam")]
        public string PortierAchternaam { get; set; }
        public string Adres { get; set; }
        public string Postcode { get; set; }
        [DisplayName("Plaats")]
        public string PlaatsNaam { get; set; }
        public string Telefoon { get; set; }
        [DisplayName("Provincie")]
        public int ProvincieId { get; set; }
        //Expand the size to Multiline
        [DataType(DataType.MultilineText)]
        public string Opmerking { get; set; }
    }

    public class PortierViewModel
    {
        public int Id { get; set; }
        [DisplayName("Naam")]
        public string PortierNaam { get; set; }
        [DisplayName("Achternaam")]
        public string PortierAchternaam { get; set; }
        [DisplayName("Adres")]
        public string Adres { get; set; }
        [DisplayName("Postcode")]
        public string Postcode { get; set; }
        [DisplayName("Plaats")]
        public string PlaatsNaam { get; set; }
        [DisplayName("Provincie")]
        public string ProvincieName { get; set; }
    }

    public class PortierDetail
    {
        public int Id { get; set; }

        [DisplayName("Voornaam")]
        public string PortierNaam { get; set; }
        [DisplayName("Achternaam")]
        public string PortierAchternaam { get; set; }
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
        public string Opmerking { get; set; }
    }
}