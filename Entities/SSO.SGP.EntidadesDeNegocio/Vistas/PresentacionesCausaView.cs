using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class PresentacionesCausaView
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Numero")]
			public int? Numero { get; set; }

			[Display(Name = "Fecha")]
			public DateTime Fecha { get; set; }

			[Display(Name = "Caratula")]
			public string Caratula { get; set; }

			[Display(Name = "Autos")]
			public string Autos { get; set; }

			[Display(Name = "JuzgadoSorteo")]
			public int? JuzgadoSorteo { get; set; }

			[Display(Name = "Juzgado")]
			public int? Juzgado { get; set; }

			[Display(Name = "Categoria")]
			public int? Categoria { get; set; }

			[Display(Name = "Fuero")]
			public string Fuero { get; set; }

			[Display(Name = "Materia")]
			public int Materia { get; set; }

			[Display(Name = "Reserva")]
			public bool Reserva { get; set; }

			[Display(Name = "CausaMadre")]
			public int? CausaMadre { get; set; }

			[Display(Name = "AnioCausaMadre")]
			public int? AnioCausaMadre { get; set; }

			[Display(Name = "Monto")]
			public decimal? Monto { get; set; }

			[Display(Name = "ReciboCajaForense")]
			public string ReciboCajaForense { get; set; }

			[Display(Name = "MontoCajaForense")]
			public decimal? MontoCajaForense { get; set; }

			[Display(Name = "ReciboRentas")]
			public string ReciboRentas { get; set; }

			[Display(Name = "MontoRentas")]
			public decimal? MontoRentas { get; set; }

			[Display(Name = "Origen")]
			public string Origen { get; set; }

			[Display(Name = "Ciudad")]
			public string Ciudad { get; set; }

			[Display(Name = "Provincia")]
			public int? Provincia { get; set; }

			[Display(Name = "ASolicitudDe")]
			public string ASolicitudDe { get; set; }

			[Display(Name = "Confirmada")]
			public bool Confirmada { get; set; }

			[Display(Name = "Estado")]
			public int? Estado { get; set; }

			[Display(Name = "Circunscripcion")]
			public int Circunscripcion { get; set; }

			[Display(Name = "Mediador")]
			public int? Mediador { get; set; }

			[Display(Name = "CoMediador")]
			public int? CoMediador { get; set; }

			[Display(Name = "GenCuentaBancaria")]
			public bool GenCuentaBancaria { get; set; }

			[Display(Name = "Recepcionada")]
			public bool Recepcionada { get; set; }

			[Display(Name = "Usuario")]
			public int Usuario { get; set; }

			[Display(Name = "Mediacion")]
			public bool Mediacion { get; set; }

			[Display(Name = "RequiereCoMediador")]
			public bool RequiereCoMediador { get; set; }

			[Display(Name = "EspecialidadCoMediador")]
			public int? EspecialidadCoMediador { get; set; }

			[Display(Name = "Causa")]
			public int? Causa { get; set; }

			[Display(Name = "Demanda")]
			public string Demanda { get; set; }

			[Display(Name = "ModeloAplicado")]
			public int? ModeloAplicado { get; set; }

			[Display(Name = "ReciboTRMed")]
			public string ReciboTRMed { get; set; }

			[Display(Name = "MontoTRMed")]
			public decimal? MontoTRMed { get; set; }

			[Display(Name = "Observaciones")]
			public string Observaciones { get; set; }

			[Display(Name = "OrganismoRecepciona")]
			public int? OrganismoRecepciona { get; set; }
			#endregion


	}
}
