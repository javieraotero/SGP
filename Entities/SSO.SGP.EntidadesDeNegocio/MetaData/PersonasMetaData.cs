using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class PersonasMetaData
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Apellidos")]
			public string Apellidos { get; set; }

			[Display(Name = "Nombres")]
			public string Nombres { get; set; }

			[Display(Name = "Tipo de Documento")]
			public int? TipoDocumento { get; set; }

			[Display(Name = "Nro de Documento")]
			public long? NroDocumento { get; set; }

			[Display(Name = "Fecha Nacimiento")]
			public DateTime? FechaNacimiento { get; set; }

			[Display(Name = "Lugar Nacimiento")]
			public string LugarNacimiento { get; set; }

			[Display(Name = "Sexo")]
			public int? Sexo { get; set; }

			[Display(Name = "Es Menor")]
			public bool EsMenor { get; set; }

			[Display(Name = "Alias")]
			public string Alias { get; set; }

			[Display(Name = "Persona Fisica")]
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

			[Display(Name = "Fecha De funcion")]
			public DateTime? FechaDefuncion { get; set; }

			[Display(Name = "Tipo Escolaridad")]
			public int? TipoEscolaridad { get; set; }

			[Display(Name = "Estado Escolaridad")]
			public int? EstadoEscolaridad { get; set; }

			[Display(Name = "Tipo Ocupacion")]
			public int? TipoOcupacion { get; set; }

			[Display(Name = "Estado Civil")]
			public int? EstadoCivil { get; set; }

			[Display(Name = "Ocupado")]
			public bool Ocupado { get; set; }

			[Display(Name = "Obra Social")]
			public bool ObraSocial { get; set; }

			[Display(Name = "Detenido")]
			public bool Detenido { get; set; }

			[Display(Name = "Incluir Identikit")]
			public bool IncluirIdentikit { get; set; }

			[Display(Name = "Foto Identikit")]
			public string FotoIdentikit { get; set; }

			[Display(Name = "Registro Voz")]
			public string RegistroVoz { get; set; }

			[Display(Name = "ColorOjos")]
			public int ColorOjos { get; set; }

			[Display(Name = "Color Pelo")]
			public int ColorPelo { get; set; }

			[Display(Name = "Longitud Pelo")]
			public int LongitudPelo { get; set; }

			[Display(Name = "Altura")]
			public int Altura { get; set; }

			[Display(Name = "Peso")]
			public int Peso { get; set; }

			[Display(Name = "Piel")]
			public int Piel { get; set; }

			[Display(Name = "Barba Bigote")]
			public int BarbaBigote { get; set; }

			[Display(Name = "Longitud Barba Bigote")]
			public int LongitudBarbaBigote { get; set; }

			[Display(Name = "Color Barba Bigote")]
			public int ColorBarbaBigote { get; set; }

			[Display(Name = "Piel Varios")]
			public int PielVarios { get; set; }

			[Display(Name = "Varios")]
			public int Varios { get; set; }

			[Display(Name = "Tonada")]
			public int Tonada { get; set; }

			[Display(Name = "Criterio Oportunidad Art15")]
			public bool CriterioOportunidadArt15 { get; set; }

			[Display(Name = "Celular")]
			public string Celular { get; set; }

			[Display(Name = "Telefono Trabajo")]
			public string TelefonoTrabajo { get; set; }

			[Display(Name = "Domicilio Trabajo")]
			public string DomicilioTrabajo { get; set; }

			[Display(Name = "FechaAlta")]
			public DateTime? FechaAlta { get; set; }

			[Display(Name = "UsuarioAlta")]
			public int? UsuarioAlta { get; set; }

			[Display(Name = "Actuacion Criterio Oportunidad")]
			public int? ActuacionCriterioOportunidad { get; set; }

			[Display(Name = "Fecha Criterio Oportunidad")]
			public DateTime? FechaCriterioOportunidad { get; set; }

			[Display(Name = "Usuario Criterio Oportunidad")]
			public int? UsuarioCriterioOportunidad { get; set; }

			[Display(Name = "Observacion Criterio Oportunidad")]
			public string ObservacionCriterioOportunidad { get; set; }

			[Display(Name = "Observaciones")]
			public string Observaciones { get; set; }

			[Display(Name = "Fecha Eliminacion")]
			public DateTime? FechaEliminacion { get; set; }

			[Display(Name = "UsuarioEliminacion")]
			public int? UsuarioEliminacion { get; set; }

			[Display(Name = "FechaModificacion")]
			public DateTime? FechaModificacion { get; set; }

			[Display(Name = "UsuarioModificacion")]
			public int? UsuarioModificacion { get; set; }

			[Display(Name = "Nombre Padre")]
			public string NombrePadre { get; set; }

			[Display(Name = "Nombre Madre")]
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

			[Display(Name = "Domicilio Procesal")]
			public string DomicilioProcesal { get; set; }

			[Display(Name = "Localidad Procesal")]
			public int? LocalidadProcesal { get; set; }
			#endregion


	}
}
