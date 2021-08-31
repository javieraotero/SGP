using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class ConexionesMetaData
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Causa")]
			public int Causa { get; set; }

			[Display(Name = "Persona")]
			public int Persona { get; set; }

			[Display(Name = "DomicilioReal")]
			public string DomicilioReal { get; set; }

			[Display(Name = "Localidad")]
			public int? Localidad { get; set; }

			[Display(Name = "DomicilioConstituido")]
			public string DomicilioConstituido { get; set; }

			[Display(Name = "Apoderado")]
			public int? Apoderado { get; set; }

			[Display(Name = "Provincia")]
			public int? Provincia { get; set; }

			[Display(Name = "LocalidadResidual")]
			public string LocalidadResidual { get; set; }

			[Display(Name = "Orden")]
			public int? Orden { get; set; }

			[Display(Name = "Rol")]
			public int Rol { get; set; }

			[Display(Name = "Activo")]
			public bool Activo { get; set; }
			#endregion


	}
}
