using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CrudEF.Models
{
    public class Cuenta
    {
        public int CuentaId { get; set; }

        [Required]
        [MaxLength(8)]
        public string NumeroCuenta { get; set; }

        [DataType(DataType.Currency)]
        public decimal Saldo { get; set; }

        [Required]
        public string TipoCuenta { get; set; }


        [DataType(DataType.DateTime)]
        public DateTime FechaCreacion { get; set; }

        //Foranea a Sucursal
        public int SucursalId { get; set; }
        [ForeignKey("SucursalId")]
        public virtual Sucursal Sucursal { get; set; }

        public int? EmpleadoId { get; set; }
        [ForeignKey("EmpleadoId")]
        public virtual Empleado Empleado { get; set; }
    }
}