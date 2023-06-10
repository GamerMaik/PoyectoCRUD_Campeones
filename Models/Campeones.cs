using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PoyectoCRUD_Campeones.Models
{
    public class Campeones
    {
        public int IdCampeon { get; set; }
        public string Nombres { get; set; }
        public string Rol { get; set; }
        public string Ataque { get; set; }
        public string Daño { get; set; }

    }
}