using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class LicenciasAgentePorAprobarView
    {
			#region Propiedades

			[Display(Name = "Id", AutoGenerateField=false, Order = 0)]
			public int Id { get; set; }

            [Display(Name = "Agente", Order = 15)]
            public string Agente { get; set; }

            [Display(Name = "Organismo", Order = 13)]
            public string Organismo { get; set; }

            [Display(Name = "Cargo", Order = 13)]
            public string Cargo { get; set; }

            [Display(Name = "F.Reg.", Order =7)]
            public DateTime FechaAlta { get; set; }

			[Display(Name = "Desde", Order = 7)]
			public DateTime FechaDesde { get; set; }

            [Display(Name = "Días", Order =5)]
            public int Dias { get; set; }

			[Display(Name = "Hasta", Order = 7)]
			public DateTime? FechaHasta { get; set; }

			[Display(Name = "Licencia", Order = 15)]
			public string Licencia { get; set; }

			[Display(Name = "Observaciones", Order = 10)]
			public string Observaciones { get; set; }

            [Display(Name = "hide_Token", Order = 0)]
            public string hide_Token { get; set; }

        #endregion
    }

    public class LicenciasAgentePorAprobarReconocimientoView
    {
        #region Propiedades

        [Display(Name = "Id", AutoGenerateField = false, Order = 0)]
        public int Id { get; set; }

        [Display(Name = "Agente", Order = 15)]
        public string Agente { get; set; }

        [Display(Name = "Teléfono", Order = 5)]
        public string Telefono { get; set; }

        [Display(Name = "Organismo", Order = 12)]
        public string Organismo { get; set; }

        [Display(Name = "Cargo", Order = 12)]
        public string Cargo { get; set; }

        [Display(Name = "F.Reg.", Order = 6)]
        public DateTime FechaAlta { get; set; }

        [Display(Name = "Desde", Order = 6)]
        public DateTime FechaDesde { get; set; }

        [Display(Name = "Días", Order = 4)]
        public int Dias { get; set; }

        [Display(Name = "Hasta", Order = 7)]
        public DateTime? FechaHasta { get; set; }

        [Display(Name = "Licencia", Order = 15)]
        public string Licencia { get; set; }

        [Display(Name = "Observaciones", Order = 10)]
        public string Observaciones { get; set; }

        [Display(Name = "hide_Token", Order = 0)]
        public string hide_Token { get; set; }

        #endregion
    }

    public class LicenciasAgenteProcesadasView
    {
        #region Propiedades

        [Display(Name = "Id", AutoGenerateField = false, Order = 0)]
        public int Id { get; set; }

        [Display(Name = "Agente", Order = 15)]
        public string Agente { get; set; }

        [Display(Name = "F.Reg.", Order = 10)]
        public DateTime FechaAlta { get; set; }

        [Display(Name = "Desde", Order = 10)]
        public DateTime FechaDesde { get; set; }

        [Display(Name = "Días", Order = 5)]
        public int Dias { get; set; }

        [Display(Name = "Hasta", Order = 10)]
        public DateTime FechaHasta { get; set; }

        [Display(Name = "Licencia", Order = 30)]
        public string Licencia { get; set; }

        [Display(Name = "Observaciones", Order = 15)]
        public string Observaciones { get; set; }

        [Display(Name = "Aprob?", Order = 15)]
        public string Aprobado { get; set; }

        [Display(Name = "F.Aprob", Order = 15)]
        public DateTime? FechaAprobacion { get; set; }

        [Display(Name = "hide_Token", Order = 0)]
        public string hide_Token { get; set; }

        #endregion


    }

    public class SubroganciasAceptadasView
    {
        #region Propiedades

        [Display(Name = "Id", AutoGenerateField = false, Order = 0)]
        public int Id { get; set; }

        [Display(Name = "Funcionario", Order = 20)]
        public string Agente { get; set; }

        [Display(Name = "Organismo", Order = 10)]
        public string Organismo{ get; set; }

        [Display(Name = "Desde", Order = 10)]
        public DateTime FechaDesde { get; set; }

        [Display(Name = "Hasta", Order = 10)]
        public DateTime FechaHasta { get; set; }

        [Display(Name = "Estado", Order = 10)]
        public string Estado { get; set; }

        #endregion


    }

}
