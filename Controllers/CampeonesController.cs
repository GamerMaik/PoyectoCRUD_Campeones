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
        public ActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegistrarCampeon(Campeones campeon)
        {
            using (SqlConnection oconexion = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("PA_CREARCAMPEON", oconexion);
                cmd.Parameters.AddWithValue("Nombre", campeon.Nombres);
                cmd.Parameters.AddWithValue("Rol", campeon.Rol);
                cmd.Parameters.AddWithValue("Ataque", campeon.Ataque);
                cmd.Parameters.AddWithValue("Daño", campeon.Daño);
                cmd.CommandType = CommandType.StoredProcedure;
                oconexion.Open();
                cmd.ExecuteNonQuery();
            }

            return RedirectToAction("Inicio","Campeones");
        }

        public ActionResult Editar(int? IdCampeon)
        {
            if (IdCampeon==null)     
                return RedirectToAction("Inicio", "Campeones");
            Campeones campeon = olista.Where(c => c.IdCampeon == IdCampeon).FirstOrDefault();
            return View(campeon);
        }
        public ActionResult Eliminar(int? IdCampeon)
        {
            if (IdCampeon == null)
                return RedirectToAction("Inicio", "Campeones");


            Campeones campeon = olista.Where(c => c.IdCampeon == IdCampeon).FirstOrDefault();

            return View(campeon);
        }

        [HttpPost]
        public ActionResult EditarCampeon(Campeones campeon)
        {
            using (SqlConnection oconexion = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("PA_EDITARCAMPEON", oconexion);
                cmd.Parameters.AddWithValue("IdCampeon", campeon.IdCampeon);
                cmd.Parameters.AddWithValue("Nombre", campeon.Nombres);
                cmd.Parameters.AddWithValue("Rol", campeon.Rol);
                cmd.Parameters.AddWithValue("Ataque", campeon.Ataque);
                cmd.Parameters.AddWithValue("Daño", campeon.Daño);
                cmd.CommandType = CommandType.StoredProcedure;
                oconexion.Open();
                cmd.ExecuteNonQuery();
            }

            return RedirectToAction("Inicio", "Campeones");
        }

        [HttpPost]
        public ActionResult EliminarCampeon(string IdCampeon)
        {
            using (SqlConnection oconexion = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("PA_ELIMINARCAMPEON", oconexion);
                cmd.Parameters.AddWithValue("IdCampeon", IdCampeon);              
                cmd.CommandType = CommandType.StoredProcedure;
                oconexion.Open();
                cmd.ExecuteNonQuery();
            }

            return RedirectToAction("Inicio", "Campeones");
        }
    }
}