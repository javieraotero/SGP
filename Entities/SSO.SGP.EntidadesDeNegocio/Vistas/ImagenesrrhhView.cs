using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class ImagenesrrhhView
	{
			#region Propiedades

			[Display(Name = "Id", Order = 0)]
			public int Id { get; set; }

			[Display(Name = "Nombre", Order = 25)]
			public string Nombre { get; set; }

			[Display(Name = "Categoria", Order = 12)]
			public int Categoria { get; set; }

			[Display(Name = "FechaDeCarga", Order = 10)]
			public DateTime FechaDeCarga { get; set; }

			[Display(Name = "Archivo", Order = 12)]
			public string Imagen { get; set; }

            [Display(Name = "Descripción", Order = 35)]
            public string Descripcion { get; set; }

        #endregion


    }
}
