using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
    /// <summary>
    /// Vista generada por generador de codigo
    /// </summary>
    public class NombramientosSueldosView
    {
        #region Propiedades

        public int Id { get; set; }

        public int Agente { get; set; }

        public DateTime FechaDeAlta { get; set; }

        public DateTime? FechaDeBaja { get; set; }

        public int Organismo { get; set; }

        public int Cargo { get; set; }

        public string SituacionRevista { get; set; }

        public int? Id_Designacion { get; set; }

        public int? Nro_Rama { get; set; }

        public int? Persona_Cesida { get; set; }

        public int? Categoria_Cesida { get; set; }

        public int? Ubicacion_Cesida { get; set; }

        public string Categoria_Cesida_Descripcion { get; set; }

        public string Ubicacion_Cesida_Descripcion { get; set; }

       #endregion


    }
}
