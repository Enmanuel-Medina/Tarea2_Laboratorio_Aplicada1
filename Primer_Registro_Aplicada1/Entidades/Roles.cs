using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Primer_Registro_Aplicada1.Entidades
{
    public class Roles
    {
        [Key]
        public int RolId { get; set; }
        public DateTime FechaDeCreacion { get; set; }
        public string Descripcion { get; set; }


        public Roles()
        {
            RolId = 0;
            FechaDeCreacion = DateTime.Now;
            Descripcion = string.Empty;
        }
    }
}
