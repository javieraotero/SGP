using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class PeritosInscripcionViewT
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Circunscripcion1")]
			public bool? Circunscripcion1 { get; set; }

			[Display(Name = "Circunscripcion2")]
			public bool? Circunscripcion2 { get; set; }

			[Display(Name = "Circunscripcion3")]
			public bool? Circunscripcion3 { get; set; }

			[Display(Name = "Circunscripcion4")]
			public bool? Circunscripcion4 { get; set; }

			[Display(Name = "FechaInscripcion")]
			public DateTime FechaInscripcion { get; set; }

			[Display(Name = "UsuarioCarga")]
			public int UsuarioCarga { get; set; }

			[Display(Name = "Especialidad")]
			public int Especialidad { get; set; }

			[Display(Name = "Periodo")]
			public int Periodo { get; set; }

			[Display(Name = "Perito")]
			public int Perito { get; set; }

			[Display(Name = "DomicilioLegal1")]
			public string DomicilioLegal1 { get; set; }

			[Display(Name = "DomicilioLegal2")]
			public string DomicilioLegal2 { get; set; }

			[Display(Name = "DomicilioLegal3")]
			public string DomicilioLegal3 { get; set; }

			[Display(Name = "DomicilioLegal4")]
			public string DomicilioLegal4 { get; set; }

			[Display(Name = "Telefono1")]
			public string Telefono1 { get; set; }

			[Display(Name = "Telefono2")]
			public string Telefono2 { get; set; }

			[Display(Name = "Telefono3")]
			public string Telefono3 { get; set; }

			[Display(Name = "Telefono4")]
			public string Telefono4 { get; set; }

			[Display(Name = "Activo")]
			public bool Activo { get; set; }
			#endregion


	}
}
