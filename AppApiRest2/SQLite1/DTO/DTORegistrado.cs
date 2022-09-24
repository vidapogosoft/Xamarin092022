
using System;

namespace SQLite1.DTO
{
    public class DTORegistrado
    {
        public int IdRegistrado { get; set; }
        public string Identificacion { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string NombresCompletos { get; set; }
        public DateTime? FechaRegistro { get; set; }
    }
}
