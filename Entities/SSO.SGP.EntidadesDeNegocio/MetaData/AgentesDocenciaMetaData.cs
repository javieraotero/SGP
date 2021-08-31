using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class AgentesDocenciaMetaData
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Agente")]
			public int Agente { get; set; }

			[Display(Name = "Fecha")]
			public DateTime Fecha { get; set; }

			[Display(Name = "Institución")]
			public string Institucion { get; set; }
         
			[Display(Name = "Carga Horaria")]
			public int CargaHoraria { get; set; }

			[Display(Name = "Horas Catedra?")]
			public bool HorasCatedra { get; set; }

			[Display(Name = "Horas Semanales?")]
			public bool HorasSemanales { get; set; }

			[Display(Name = "Observaciones")]
			public string Observaciones { get; set; }

            [Display(Name = "Detalle")]
            public string Detalle { get; set; }

            [Display(Name = "Período")]
            public string Periodo { get; set; }
        #endregion


    }
}
