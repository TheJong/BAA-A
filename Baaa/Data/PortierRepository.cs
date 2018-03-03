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
    public class PortierRepository
    {
        //All Portier orderby PortierAchternaam
        public List<PortierViewModel> GetAllPortier()
        {
            //Create sqlConnection
            using (IDbConnection db = new SqlConnection(ConnectionStrings.Baaa))
            {
                //Sql Query
                return db.Query<PortierViewModel>("SELECT p.Id, p.PortierNaam, p.PortierAchternaam, p.Adres, p.Postcode, p.PlaatsNaam, pr.ProvincieName FROM Portier p INNER JOIN Provincie pr ON p.ProvincieId = pr.Id ORDER BY PortierAchternaam ").ToList();
            }
        }
        //All Portier orderby PortierAchternaamDesc
        public List<PortierViewModel> GetAllPortierDesc()
        {
            using (IDbConnection db = new SqlConnection(ConnectionStrings.Baaa))
            {
                return db.Query<PortierViewModel>("SELECT p.Id, p.PortierNaam, p.PortierAchternaam, p.Adres, p.Postcode, p.PlaatsNaam, pr.ProvincieName FROM Portier p INNER JOIN Provincie pr ON p.ProvincieId = pr.Id ORDER BY PortierAchternaam DESC ").ToList();
            }
        }
        //All Portier orderby Adres
        public List<PortierViewModel> GetAllPortierAdres()
        {
            using (IDbConnection db = new SqlConnection(ConnectionStrings.Baaa))
            {
                return db.Query<PortierViewModel>("SELECT p.Id, p.PortierNaam, p.PortierAchternaam, p.Adres, p.Postcode, p.PlaatsNaam, pr.ProvincieName FROM Portier p INNER JOIN Provincie pr ON p.ProvincieId = pr.Id ORDER BY Adres ").ToList();
            }
        }
        //All klanten orderby AdresDesc
        public List<PortierViewModel> GetAllPortierAdresDesc()
        {
            using (IDbConnection db = new SqlConnection(ConnectionStrings.Baaa))
            {
                return db.Query<PortierViewModel>("SELECT p.Id, p.PortierNaam, p.PortierAchternaam, p.Adres, p.Postcode, p.PlaatsNaam, pr.ProvincieName FROM Portier p INNER JOIN Provincie pr ON p.ProvincieId = pr.Id ORDER BY Adres DESC").ToList();
            }
        }
        //All klanten orderby Postcode
        public List<PortierViewModel> GetAllPortierPostcode()
        {
            using (IDbConnection db = new SqlConnection(ConnectionStrings.Baaa))
            {
                return db.Query<PortierViewModel>("SELECT p.Id, p.PortierNaam, p.PortierAchternaam, p.Adres, p.Postcode, p.PlaatsNaam, pr.ProvincieName FROM Portier p INNER JOIN Provincie pr ON p.ProvincieId = pr.Id ORDER BY Postcode").ToList();
            }
        }
        //All klanten orderby PostcodeDesc
        public List<PortierViewModel> GetAllPortierPostcodeDesc()
        {
            using (IDbConnection db = new SqlConnection(ConnectionStrings.Baaa))
            {
                return db.Query<PortierViewModel>("SELECT p.Id, p.PortierNaam, p.PortierAchternaam, p.Adres, p.Postcode, p.PlaatsNaam, pr.ProvincieName FROM Portier p INNER JOIN Provincie pr ON p.ProvincieId = pr.Id ORDER BY Postcode DESC").ToList();
            }
        }
        //All klanten orderby Provincie
        public List<PortierViewModel> GetAllPortierProvincie()
        {
            using (IDbConnection db = new SqlConnection(ConnectionStrings.Baaa))
            {
                return db.Query<PortierViewModel>("SELECT p.Id, p.PortierNaam, p.PortierAchternaam, p.Adres, p.Postcode, p.PlaatsNaam, pr.ProvincieName FROM Portier p INNER JOIN Provincie pr ON p.ProvincieId = pr.Id ORDER BY p.ProvincieName").ToList();
            }
        }
        //All klanten orderby ProvincieDesc
        public List<PortierViewModel> GetAllPortierProvincieDesc()
        {
            using (IDbConnection db = new SqlConnection(ConnectionStrings.Baaa))
            {
                return db.Query<PortierViewModel>("SELECT p.Id, p.PortierNaam, p.PortierAchternaam, p.Adres, p.Postcode, p.PlaatsNaam, pr.ProvincieName FROM Portier p INNER JOIN Provincie pr ON p.ProvincieId = pr.Id ORDER BY p.ProvincieName DESC").ToList();
            }
        }
        //All klanten orderby PlaatsNaam
        public List<PortierViewModel> GetAllPortierPlaatsNaam()
        {
            using (IDbConnection db = new SqlConnection(ConnectionStrings.Baaa))
            {
                return db.Query<PortierViewModel>("SELECT p.Id, p.PortierNaam, p.PortierAchternaam, p.Adres, p.Postcode, p.PlaatsNaam, pr.ProvincieName FROM Portier p INNER JOIN Provincie pr ON p.ProvincieId = pr.Id ORDER BY PlaatsNaam").ToList();
            }
        }
        //All klanten orderby PlaatsNaamDesc
        public List<PortierViewModel> GetAllPortierPlaatsNaamDesc()
        {
            using (IDbConnection db = new SqlConnection(ConnectionStrings.Baaa))
            {
                return db.Query<PortierViewModel>("SELECT p.Id, p.PortierNaam, p.PortierAchternaam, p.Adres, p.Postcode, p.PlaatsNaam, pr.ProvincieName FROM Portier p INNER JOIN Provincie pr ON p.ProvincieId = pr.Id ORDER BY PlaatsNaam DESC").ToList();
            }
        }
        //CREATE Klant
        public bool CreatePortier(Portier portier)
        {
            using (IDbConnection db = new SqlConnection(ConnectionStrings.Baaa))
            {
                string sqlQuery = "INSERT INTO Portier([PortierNaam],[PortierAchternaam],[Adres],[Postcode],[PlaatsNaam],[Telefoon],[ProvincieId],[Opmerking]) VALUES (@PortierNaam,@PortierAchternaam,@Adres,@Postcode,@PlaatsNaam,@Telefoon,@ProvincieId,@Opmerking)";
                db.Execute(sqlQuery,
                    new
                    {
                        portier.PortierNaam,
                        portier.PortierAchternaam,
                        portier.Adres,
                        portier.Postcode,
                        portier.PlaatsNaam,
                        portier.Telefoon,
                        portier.ProvincieId,
                        portier.Opmerking
                    });
                return true;
            }
        }

        //GET Portier By ID
        public Portier GetPortierByIdEdit(int id)
        {
            using (IDbConnection db = new SqlConnection(ConnectionStrings.Baaa))
            {
                string strQuery = string.Format("Select * from Portier WHERE Id={0}", id);
                var pd = db.Query<Portier>(strQuery).SingleOrDefault();

                return pd;
            }
        }

        //GET Portier By ID (detail)
        public PortierDetail GetPortierById(int id)
        {
            using (IDbConnection db = new SqlConnection(ConnectionStrings.Baaa))
            {
                string strQuery = string.Format("Select p.PortierNaam, p.PortierAchternaam, p.Adres, p.Postcode, p.PlaatsNaam, p.Telefoon, pr.ProvincieName, p.Opmerking from Portier p INNER JOIN Provincie pr ON p.ProvincieId = pr.Id WHERE p.Id={0}", id);
                var pd = db.Query<PortierDetail>(strQuery).SingleOrDefault();

                return pd;
            }
        }

        //UPDATE Portier
        public bool UpdatePortier(Portier portier)
        {
            using (IDbConnection db = new SqlConnection(ConnectionStrings.Baaa))
            {
                string sqlQuery = "UPDATE [dbo].[Portier] SET [PortierNaam] =@PortierNaam, [PortierAchternaam] =@PortierAchternaam, [Adres] = @Adres, [Postcode] = @Postcode, [PlaatsNaam] = @PlaatsNaam, [Telefoon] = @Telefoon, [ProvincieId] = @ProvincieId, [Opmerking] = @Opmerking WHERE Id=@Id";
                db.Execute(sqlQuery,
                    new
                    {
                        portier.Id,
                        portier.PortierNaam,
                        portier.PortierAchternaam,
                        portier.Adres,
                        portier.Postcode,
                        portier.PlaatsNaam,
                        portier.Telefoon,
                        portier.ProvincieId,
                        portier.Opmerking
                    });
                return true;
            }
        }

        //DELETE product by id
        public bool DeletePortierById(int id)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConnectionStrings.Baaa))
                {
                    string sqlQuery = "DELETE FROM [dbo].[Portier] WHERE Id=@Id";
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
    }
}