using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class PersonasView
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Apellidos")]
			public string Apellidos { get; set; }

			[Display(Name = "Nombres")]
			public string Nombres { get; set; }

			[Display(Name = "TipoDocumento")]
			public int? TipoDocumento { get; set; }

			[Display(Name = "NroDocumento")]
			public long? NroDocumento { get; set; }

			[Display(Name = "FechaNacimiento")]
			public DateTime? FechaNacimiento { get; set; }

			[Display(Name = "LugarNacimiento")]
			public string LugarNacimiento { get; set; }

			[Display(Name = "Sexo")]
			public int? Sexo { get; set; }

			[Display(Name = "EsMenor")]
			public bool EsMenor { get; set; }

			[Display(Name = "Alias")]
			public string Alias { get; set; }

			[Display(Name = "PersonaFisica")]
			public bool PersonaFisica { get; set; }

			[Display(Name = "Barrio")]
			public int? Barrio { get; set; }

			[Display(Name = "Calle")]
			public int? Calle { get; set; }

			[Display(Name = "Domicilio")]
			public string Domicilio { get; set; }

			[Display(Name = "Localidad")]
			public int? Localidad { get; set; }

			[Display(Name = "Ocupacion")]
			public string Ocupacion { get; set; }

			[Display(Name = "Nacionalidad")]
			public string Nacionalidad { get; set; }

			[Display(Name = "Activa")]
			public bool Activa { get; set; }

			[Display(Name = "Telefono")]
			public string Telefono { get; set; }

			[Display(Name = "Fallecido")]
			public bool Fallecido { get; set; }

			[Display(Name = "FechaDefuncion")]
			public DateTime? FechaDefuncion { get; set; }

			[Display(Name = "TipoEscolaridad")]
			public int? TipoEscolaridad { get; set; }

			[Display(Name = "EstadoEscolaridad")]
			public int? EstadoEscolaridad { get; set; }

			[Display(Name = "TipoOcupacion")]
			public int? TipoOcupacion { get; set; }

			[Display(Name = "EstadoCivil")]
			public int? EstadoCivil { get; set; }

			[Display(Name = "Ocupado")]
			public bool Ocupado { get; set; }

			[Display(Name = "ObraSocial")]
			public bool ObraSocial { get; set; }

			[Display(Name = "Detenido")]
			public bool Detenido { get; set; }

			[Display(Name = "IncluirIdentikit")]
			public bool IncluirIdentikit { get; set; }

			[Display(Name = "FotoIdentikit")]
			public string FotoIdentikit { get; set; }

			[Display(Name = "RegistroVoz")]
			public string RegistroVoz { get; set; }

			[Display(Name = "ColorOjos")]
			public int ColorOjos { get; set; }

			[Display(Name = "ColorPelo")]
			public int ColorPelo { get; set; }

			[Display(Name = "LongitudPelo")]
			public int LongitudPelo { get; set; }

			[Display(Name = "Altura")]
			public int Altura { get; set; }

			[Display(Name = "Peso")]
			public int Peso { get; set; }

			[Display(Name = "Piel")]
			public int Piel { get; set; }

			[Display(Name = "BarbaBigote")]
			public int BarbaBigote { get; set; }

			[Display(Name = "LongitudBarbaBigote")]
			public int LongitudBarbaBigote { get; set; }

			[Display(Name = "ColorBarbaBigote")]
			public int ColorBarbaBigote { get; set; }

			[Display(Name = "PielVarios")]
			public int PielVarios { get; set; }

			[Display(Name = "Varios")]
			public int Varios { get; set; }

			[Display(Name = "Tonada")]
			public int Tonada { get; set; }

			[Display(Name = "CriterioOportunidadArt15")]
			public bool CriterioOportunidadArt15 { get; set; }

			[Display(Name = "Celular")]
			public string Celular { get; set; }

			[Display(Name = "TelefonoTrabajo")]
			public string TelefonoTrabajo { get; set; }

			[Display(Name = "DomicilioTrabajo")]
			public string DomicilioTrabajo { get; set; }

			[Display(Name = "FechaAlta")]
			public DateTime? FechaAlta { get; set; }

			[Display(Name = "UsuarioAlta")]
			public int? UsuarioAlta { get; set; }

			[Display(Name = "ActuacionCriterioOportunidad")]
			public int? ActuacionCriterioOportunidad { get; set; }

			[Display(Name = "FechaCriterioOportunidad")]
			public DateTime? FechaCriterioOportunidad { get; set; }

			[Display(Name = "UsuarioCriterioOportunidad")]
			public int? UsuarioCriterioOportunidad { get; set; }

			[Display(Name = "ObservacionCriterioOportunidad")]
			public string ObservacionCriterioOportunidad { get; set; }

			[Display(Name = "Observaciones")]
			public string Observaciones { get; set; }

			[Display(Name = "FechaEliminacion")]
			public DateTime? FechaEliminacion { get; set; }

			[Display(Name = "UsuarioEliminacion")]
			public int? UsuarioEliminacion { get; set; }

			[Display(Name = "FechaModificacion")]
			public DateTime? FechaModificacion { get; set; }

			[Display(Name = "UsuarioModificacion")]
			public int? UsuarioModificacion { get; set; }

			[Display(Name = "NombrePadre")]
			public string NombrePadre { get; set; }

			[Display(Name = "NombreMadre")]
			public string NombreMadre { get; set; }

			[Display(Name = "ActuacionSuspencionProcesoAPrueba")]
			public int? ActuacionSuspencionProcesoAPrueba { get; set; }

			[Display(Name = "FechaSuspencionProcesoAPrueba")]
			public DateTime? FechaSuspencionProcesoAPrueba { get; set; }

			[Display(Name = "UsuarioSuspencionProcesoAPrueba")]
			public int? UsuarioSuspencionProcesoAPrueba { get; set; }

			[Display(Name = "ObservacionSuspencionProcesoAPrueba")]
			public string ObservacionSuspencionProcesoAPrueba { get; set; }

			[Display(Name = "SuspencionProcesoAPrueba")]
			public bool SuspencionProcesoAPrueba { get; set; }

			[Display(Name = "Concurso")]
			public int? Concurso { get; set; }

			[Display(Name = "DomicilioProcesal")]
			public string DomicilioProcesal { get; set; }

			[Display(Name = "LocalidadProcesal")]
			public int? LocalidadProcesal { get; set; }
			#endregion


	}
}
