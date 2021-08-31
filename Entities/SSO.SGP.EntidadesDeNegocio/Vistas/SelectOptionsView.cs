using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class SelectOptionsView
	{
			#region Propiedades

			public int value { get; set; }

			public string text { get; set; }

			#endregion


	}

    public class AutocompleteView
    {
        #region Propiedades

        public int id { get; set; }

        public string label { get; set; }

        #endregion


    }

	public class SelectOptionsTurnosView
	{
		#region Propiedades

		public int value { get; set; }

		public string text { get; set; }

		public string descripcion { get; set; }

		public bool solo_abogado { get; set; }

		public string descripcion_corta { get; set; }

		#endregion


	}
}
