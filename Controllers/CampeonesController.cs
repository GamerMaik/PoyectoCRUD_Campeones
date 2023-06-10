using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using PoyectoCRUD_Campeones.Models;
using System.Data.SqlClient;
using System.Data;

namespace PoyectoCRUD_Campeones.Controllers
{
    public class CampeonesController : Controller
    {
        private static string conexion = ConfigurationManager.ConnectionStrings["cadena"].ToString();

        private static List<Campeones> olista = new List<Campeones>();
        // GET: Campeones
        public ActionResult Inicio()
        {
            olista = new List<Campeones>();

            using (SqlConnection oconexion = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM CAMPEON", oconexion);
                cmd.CommandType = CommandType.Text;
                oconexion.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Campeones nuevoCampeon = new Campeones();
                        nuevoCampeon.IdCampeon = Convert.ToInt32(dr["IdCampeon"]);
                        nuevoCampeon.Nombres = dr["Nombres"].ToString();
                        nuevoCampeon.Rol = dr["Rol"].ToString();
                        nuevoCampeon.Ataque = dr["Ataque"].ToString();
                        nuevoCampeon.Daño = dr["Daño"].ToString();

                        olista.Add(nuevoCampeon);
                    }
                }
            }
                return View(olista);
        }
    }
}