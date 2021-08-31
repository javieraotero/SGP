using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class PersonasViewT
	{
			#region Propiedades

			[Display(Name = "Id", AutoGenerateField=false)]
			public int Id { get; set; }

			[Display(Name = "Apellidos")]
			public string Apellidos { get; set; }

			[Display(Name = "Nombres")]
			public string Nombres { get; set; }

			[Display(Name = "T.Doc.")]
			public string TipoDocumento { get; set; }

			[Display(Name = "Documento")]
			public long NroDocumento { get; set; }
        
			[Display(Name = "Localidad")]
			public string Localidad { get; set; }

            [Display(Name = "Nucleo")]
            public string Nucleo { get; set; }

			[Display(Name = "sexo")]
			public int? sexo{ get; set; }

		[Display(Name = "Telefono")]
		public string Telefono { get; set; }

		#endregion


	}
}
