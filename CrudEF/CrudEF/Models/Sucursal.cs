using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CrudEF.Models
{
    public class Sucursal
    {        
        public int SucursalId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }

        [Required,MaxLength(100)]
        public string Direccion { get; set; }

        [Required,Phone]
        public string Telefono { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaApertura { get; set; }

        // Relaciones indirectas
        public virtual ICollection<Empleado> Empleados { get; set; }
        public virtual ICollection<Cuenta> Cuentas { get; set; }

    }
}