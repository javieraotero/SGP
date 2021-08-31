using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class ConcursosDeIngresoViewT
	{
        #region Propiedades

        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }

        [Display(Name = "FechaInicio")]
        public DateTime FechaInicio { get; set; }

        [Display(Name = "FechaFin")]
        public DateTime FechaFin { get; set; }

        [Display(Name = "FechaAlta")]
        public DateTime FechaAlta { get; set; }

        [Display(Name = "UsuarioAlta")]
        public int UsuarioAlta { get; set; }

        [Display(Name = "Organismo")]
        public int Organismo { get; set; }

        [Display(Name = "Cargo")]
        public int Cargo { get; set; }

        [Display(Name = "Activo")]
        public bool Activo { get; set; }
        #endregion


    }
}
