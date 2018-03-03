using Baaa.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Baaa.Data
{
    public class KlantenRepository
    {
        //All klanten orderby Achternaam
        public List<KlantViewModel> GetAllKlanten()
        {
            //Create sqlConnection
            using (IDbConnection db = new SqlConnection(ConnectionStrings.Baaa))
            {
                //Sql Query
                return db.Query<KlantViewModel>("SELECT k.Id, k.Voornaam, k.Achternaam, k.Adres, k.Postcode, k.PlaatsNaam, p.ProvincieName, k.Opslag FROM Klanten k INNER JOIN Provincie p ON k.ProvincieId = p.Id ORDER BY Achternaam ").ToList();
            }
        }
        //All klanten orderby AchternaamDesc
        public List<KlantViewModel> GetAllKlantenDesc()
        {
            using (IDbConnection db = new SqlConnection(ConnectionStrings.Baaa))
            {
                return db.Query<KlantViewModel>("SELECT k.Id, k.Voornaam, k.Achternaam, k.Adres, k.Postcode, k.PlaatsNaam, p.ProvincieName, k.Opslag FROM Klanten k INNER JOIN Provincie p ON k.ProvincieId = p.Id ORDER BY Achternaam DESC").ToList();
            }
        }
        //All klanten orderby Adres
        public List<KlantViewModel> GetAllKlantenAdres()
        {
            using (IDbConnection db = new SqlConnection(ConnectionStrings.Baaa))
            {
                return db.Query<KlantViewModel>("SELECT k.Id, k.Voornaam, k.Achternaam, k.Adres, k.Postcode, k.PlaatsNaam, p.ProvincieName, k.Opslag FROM Klanten k INNER JOIN Provincie p ON k.ProvincieId = p.Id ORDER BY Adres ").ToList();
            }
        }
        //All klanten orderby AdresDesc
        public List<KlantViewModel> GetAllKlantenAdresDesc()
        {
            using (IDbConnection db = new SqlConnection(ConnectionStrings.Baaa))
            {
                return db.Query<KlantViewModel>("SELECT k.Id, k.Voornaam, k.Achternaam, k.Adres, k.Postcode, k.PlaatsNaam, p.ProvincieName, k.Opslag FROM Klanten k INNER JOIN Provincie p ON k.ProvincieId = p.Id ORDER BY Adres DESC").ToList();
            }
        }
        //All klanten orderby Postcode
        public List<KlantViewModel> GetAllKlantenPostcode()
        {
            using (IDbConnection db = new SqlConnection(ConnectionStrings.Baaa))
            {
                return db.Query<KlantViewModel>("SELECT k.Id, k.Voornaam, k.Achternaam, k.Adres, k.Postcode, k.PlaatsNaam, p.ProvincieName, k.Opslag FROM Klanten k INNER JOIN Provincie p ON k.ProvincieId = p.Id ORDER BY Postcode").ToList();
            }
        }
        //All klanten orderby PostcodeDesc
        public List<KlantViewModel> GetAllKlantenPostcodeDesc()
        {
            using (IDbConnection db = new SqlConnection(ConnectionStrings.Baaa))
            {
                return db.Query<KlantViewModel>("SELECT k.Id, k.Voornaam, k.Achternaam, k.Adres, k.Postcode, k.PlaatsNaam, p.ProvincieName, k.Opslag FROM Klanten k INNER JOIN Provincie p ON k.ProvincieId = p.Id ORDER BY Postcode DESC").ToList();
            }
        }
        //All klanten orderby PlaatsNaam
        public List<KlantViewModel> GetAllKlantenPlaatsNaam()
        {
            using (IDbConnection db = new SqlConnection(ConnectionStrings.Baaa))
            {
                return db.Query<KlantViewModel>("SELECT k.Id, k.Voornaam, k.Achternaam, k.Adres, k.Postcode, k.PlaatsNaam, p.ProvincieName, k.Opslag FROM Klanten k INNER JOIN Provincie p ON k.ProvincieId = p.Id ORDER BY PlaatsNaam").ToList();
            }
        }

        //All klanten orderby PlaatsNaamDesc
        public List<KlantViewModel> GetAllKlantenPlaatsNaamDesc()
        {
            using (IDbConnection db = new SqlConnection(ConnectionStrings.Baaa))
            {
                return db.Query<KlantViewModel>("SELECT k.Id, k.Voornaam, k.Achternaam, k.Adres, k.Postcode, k.PlaatsNaam, p.ProvincieName, k.Opslag FROM Klanten k INNER JOIN Provincie p ON k.ProvincieId = p.Id ORDER BY PlaatsNaam DESC").ToList();
            }
        }
        //All klanten orderby Provincie
        public List<KlantViewModel> GetAllKlantenProvincie()
        {
            using (IDbConnection db = new SqlConnection(ConnectionStrings.Baaa))
            {
                return db.Query<KlantViewModel>("SELECT k.Id, k.Voornaam, k.Achternaam, k.Adres, k.Postcode, k.PlaatsNaam, p.ProvincieName, k.Opslag FROM Klanten k INNER JOIN Provincie p ON k.ProvincieId = p.Id ORDER BY p.ProvincieName").ToList();
            }
        }
        //All klanten orderby ProvincieDesc
        public List<KlantViewModel> GetAllKlantenProvincieDesc()
        {
            using (IDbConnection db = new SqlConnection(ConnectionStrings.Baaa))
            {
                return db.Query<KlantViewModel>("SELECT k.Id, k.Voornaam, k.Achternaam, k.Adres, k.Postcode, k.PlaatsNaam, p.ProvincieName, k.Opslag FROM Klanten k INNER JOIN Provincie p ON k.ProvincieId = p.Id ORDER BY p.ProvincieName DESC").ToList();
            }
        }
        //All klanten orderby Opslag
        public List<KlantViewModel> GetAllKlantenOpslag()
        {
            using (IDbConnection db = new SqlConnection(ConnectionStrings.Baaa))
            {
                return db.Query<KlantViewModel>("SELECT k.Id, k.Voornaam, k.Achternaam, k.Adres, k.Postcode, k.PlaatsNaam, p.ProvincieName, k.Opslag FROM Klanten k INNER JOIN Provincie p ON k.ProvincieId = p.Id ORDER BY Opslag").ToList();
            }
        }
        //All klanten orderby OpslagDesc
        public List<KlantViewModel> GetAllKlantenOpslagDesc()
        {
            using (IDbConnection db = new SqlConnection(ConnectionStrings.Baaa))
            {
                return db.Query<KlantViewModel>("SELECT k.Id, k.Voornaam, k.Achternaam, k.Adres, k.Postcode, k.PlaatsNaam, p.ProvincieName, k.Opslag FROM Klanten k INNER JOIN Provincie p ON k.ProvincieId = p.Id ORDER BY Opslag DESC").ToList();
            }
        }

        //CREATE Klant
        public bool CreateKlant(Klanten klant)
        {
            using (IDbConnection db = new SqlConnection(ConnectionStrings.Baaa))
            {
                string sqlQuery = "INSERT INTO Klanten([Voornaam],[AchterNaam],[Adres],[Postcode],[PlaatsNaam],[Telefoon],[ProvincieId],[Opslag],[DierName],[OpvangName],[ObserverenId],[WeghaalId],[Opmerking]) VALUES (@Voornaam,@AchterNaam,@Adres,@Postcode,@PlaatsNaam,@Telefoon,@ProvincieId,@Opslag,@DierName,@OpvangName,@ObserverenId,@WeghaalId,@Opmerking)";
                db.Execute(sqlQuery,
                    new
                    {
                        klant.VoorNaam,
                        klant.AchterNaam,
                        klant.Adres,
                        klant.Postcode,
                        klant.PlaatsNaam,
                        klant.Telefoon,
                        klant.ProvincieId,
                        klant.Opslag,
                        klant.DierName,
                        klant.OpvangName,
                        klant.ObserverenId,
                        klant.WeghaalId,
                        klant.Opmerking
                    });
                return true;
            }
        }

        //GET Klant By ID
        public Klanten GetKlantByIdEdit(int id)
        {
            using (IDbConnection db = new SqlConnection(ConnectionStrings.Baaa))
            {
                string strQuery = string.Format("Select * from Klanten WHERE Id={0}", id);
                var pd = db.Query<Klanten>(strQuery).SingleOrDefault();

                return pd;
            }
        }

        //GET Klant By ID (detail)
        public KlantenDetail GetKlantById(int id)
        {
            using (IDbConnection db = new SqlConnection(ConnectionStrings.Baaa))
            {
                string strQuery = string.Format("Select k.Voornaam, k.Achternaam, k.Adres, k.Postcode, k.Telefoon, k.PlaatsNaam, pr.ProvincieName, k.Opslag, k.Diername, k.Opvangname, o.ObserverenName, w.WeghaalName, k.Opmerking from Klanten k INNER JOIN Provincie pr ON k.ProvincieId = pr.Id INNER JOIN Observeren o ON k.observerenId = o.Id INNER JOIN Weghalen w ON WeghaalId = w.Id WHERE k.Id={0}", id);
                var pd = db.Query<KlantenDetail>(strQuery).SingleOrDefault();

                return pd;
            }
        }

        //UPDATE Klant
        public bool UpdateKlanten(Klanten klant)
        {
            using (IDbConnection db = new SqlConnection(ConnectionStrings.Baaa))
            {
                string sqlQuery = "UPDATE [dbo].[Klanten] SET [VoorNaam] =@VoorNaam, [AchterNaam] =@AchterNaam, [Adres] = @Adres, [Postcode] = @Postcode, [PlaatsNaam] = @PlaatsNaam, [Telefoon] = @Telefoon, [ProvincieId] = @ProvincieId, [Opslag] = @Opslag, [DierName] = @DierName, [OpvangName] = @OpvangName, [ObserverenId] = @ObserverenId, [WeghaalId] = @WeghaalId, [Opmerking] = @Opmerking WHERE Id=@Id";
                db.Execute(sqlQuery,
                    new
                    {
                        klant.Id,
                        klant.VoorNaam,
                        klant.AchterNaam,
                        klant.Adres,
                        klant.Postcode,
                        klant.PlaatsNaam,
                        klant.Telefoon,
                        klant.ProvincieId,
                        klant.Opslag,
                        klant.DierName,
                        klant.OpvangName,
                        klant.ObserverenId,
                        klant.WeghaalId,
                        klant.Opmerking
                    });
                return true;
            }
        }

        //DELETE product by id
        public bool DeleteKlantById(int id)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConnectionStrings.Baaa))
                {
                    string sqlQuery = "DELETE FROM [dbo].[Klanten] WHERE Id=@Id";
                    db.Execute(sqlQuery, new { id });
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //Dropdown Provincie
        public IEnumerable<Provincie> GetProvincieList()
        {
            using (IDbConnection db = new SqlConnection(ConnectionStrings.Baaa))
            {
                string strQuery = "SELECT Id, ProvincieName FROM Provincie";
                var result = db.Query<Provincie>(strQuery);
                return result;
            }
        }
        //Dropdown Observeren
        public IEnumerable<Observeren> GetObserveerList()
        {
            using (IDbConnection db = new SqlConnection(ConnectionStrings.Baaa))
            {
                string strQuery = "SELECT Id, ObserverenName FROM Observeren";
                var result = db.Query<Observeren>(strQuery);
                return result;
            }
        }
        //Dropdown Weghaal
        public IEnumerable<Weghalen> GetWeghaalList()
        {
            using (IDbConnection db = new SqlConnection(ConnectionStrings.Baaa))
            {
                string strQuery = "SELECT Id, WeghaalName FROM Weghalen";
                var result = db.Query<Weghalen>(strQuery);
                return result;
            }
        }
    }
}