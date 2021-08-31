using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class TiposActuacionCivilRefView
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Descripcion")]
			public string Descripcion { get; set; }

			[Display(Name = "EstadoCausa")]
			public int? EstadoCausa { get; set; }

			[Display(Name = "Activa")]
			public bool Activa { get; set; }

			[Display(Name = "Grupo")]
			public int Grupo { get; set; }

			[Display(Name = "CambiaEtapa")]
			public bool CambiaEtapa { get; set; }

			[Display(Name = "Plazo")]
			public int Plazo { get; set; }

			[Display(Name = "RequiereNotificacion")]
			public bool RequiereNotificacion { get; set; }

			[Display(Name = "RequiereCargo")]
			public bool RequiereCargo { get; set; }

			[Display(Name = "SubAmbitoCargo")]
			public int? SubAmbitoCargo { get; set; }

			[Display(Name = "CantidadFirmantes")]
			public int CantidadFirmantes { get; set; }

			[Display(Name = "ModalidadDiasFechaPlazo")]
			public int ModalidadDiasFechaPlazo { get; set; }

			[Display(Name = "UsuarioAlta")]
			public int? UsuarioAlta { get; set; }

			[Display(Name = "FechaAlta")]
			public DateTime? FechaAlta { get; set; }

			[Display(Name = "UsuarioModifica")]
			public int? UsuarioModifica { get; set; }

			[Display(Name = "FechaModifica")]
			public DateTime? FechaModifica { get; set; }

			[Display(Name = "UsuarioElimina")]
			public int? UsuarioElimina { get; set; }

			[Display(Name = "FechaElimina")]
			public DateTime? FechaElimina { get; set; }
			#endregion


	}
}
