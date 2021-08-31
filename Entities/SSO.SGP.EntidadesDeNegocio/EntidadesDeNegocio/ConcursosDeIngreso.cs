
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SSO.SGP.MetaData;


namespace SSO.SGP.EntidadesDeNegocio
{
	/// <summary>
	/// Entidad Generada por el Generador de codigo.
	/// </summary>
	[MetadataTypeAttribute(typeof(ConcursosDeIngresoMetaData))]
	[Table("ConcursosDeIngreso")]
	public partial class ConcursosDeIngreso
	{
		#region Constructor
		public ConcursosDeIngreso()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Nombre")]
		public string Nombre { get; set; }

		public string Descripcion { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaInicio")]
		public DateTime FechaInicio { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaFin")]
		public DateTime FechaFin { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaAlta")]
		public DateTime FechaAlta { get; set; }

		[Required(ErrorMessage = "Debe ingresar UsuarioAlta")]
		public int UsuarioAlta { get; set; }

		[Required(ErrorMessage = "Debe ingresar Organismo")]
		public int Organismo { get; set; }

		[Required(ErrorMessage = "Debe ingresar Cargo")]
		public int Cargo { get; set; }

		[Required(ErrorMessage = "Debe ingresar Activo")]
		public bool Activo { get; set; }

        [Required(ErrorMessage = "Debe ingresar Tipo")]
        public eTiposDeConcursos Tipo { get; set; } 


        [ForeignKey("Organismo")]
		public virtual OrganismosRef Organismos { get; set; }

		[ForeignKey("Cargo")]
		public virtual CargosRef Cargos { get; set; }
		#endregion

	}
}
