
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
	[MetadataTypeAttribute(typeof(PeritosInscripcionMetaData))]
	[Table("PeritosInscripcion")]
	public partial class PeritosInscripcion
	{
		#region Constructor
		public PeritosInscripcion()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		public bool? Circunscripcion1 { get; set; }

		public bool? Circunscripcion2 { get; set; }

		public bool? Circunscripcion3 { get; set; }

		public bool? Circunscripcion4 { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaInscripcion")]
		public DateTime FechaInscripcion { get; set; }

		[Required(ErrorMessage = "Debe ingresar UsuarioCarga")]
		public int UsuarioCarga { get; set; }

		[Required(ErrorMessage = "Debe ingresar Especialidad")]
		public int Especialidad { get; set; }

		[Required(ErrorMessage = "Debe ingresar Periodo")]
		public int Periodo { get; set; }

		[Required(ErrorMessage = "Debe ingresar Perito")]
		public int Perito { get; set; }

		[StringLength(150, ErrorMessage ="DomicilioLegal1 no puede superar los 150 caracteres")]
		public string DomicilioLegal1 { get; set; }

		[StringLength(150, ErrorMessage ="DomicilioLegal2 no puede superar los 150 caracteres")]
		public string DomicilioLegal2 { get; set; }

		[StringLength(150, ErrorMessage ="DomicilioLegal3 no puede superar los 150 caracteres")]
		public string DomicilioLegal3 { get; set; }

		[StringLength(150, ErrorMessage ="DomicilioLegal4 no puede superar los 150 caracteres")]
		public string DomicilioLegal4 { get; set; }

		[StringLength(100, ErrorMessage ="Telefono1 no puede superar los 100 caracteres")]
		public string Telefono1 { get; set; }

		[StringLength(100, ErrorMessage ="Telefono2 no puede superar los 100 caracteres")]
		public string Telefono2 { get; set; }

		[StringLength(100, ErrorMessage ="Telefono3 no puede superar los 100 caracteres")]
		public string Telefono3 { get; set; }

		[StringLength(100, ErrorMessage ="Telefono4 no puede superar los 100 caracteres")]
		public string Telefono4 { get; set; }

		[Required(ErrorMessage = "Debe ingresar Activo")]
		public bool Activo { get; set; }

		public virtual ICollection<PeritosContadores> PeritosContadores { get; set; }

		[ForeignKey("UsuarioCarga")]
		public virtual Usuarios UsuarioCargas { get; set; }

		[ForeignKey("Especialidad")]
		public virtual PeritosEspecialidad Especialidads { get; set; }

		[ForeignKey("Periodo")]
		public virtual PeritosPeriodo Periodos { get; set; }

		[ForeignKey("Perito")]
		public virtual Peritos Peritos { get; set; }
		#endregion

	}
}
