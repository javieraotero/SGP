using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
    /// <summary>
    /// Vista generada por generador de codigo
    /// </summary>
    public class AgentesView
    {
        #region Propiedades

        [Display(Name = "Id", AutoGenerateField = false, Order = 0)]
        public int Id { get; set; }

        [Display(Name = "Legajo", Order = 5)]
        public int Legajo { get; set; }

        [Display(Name = "Nombre", Order = 35)]
        public string Nombre { get; set; }

        [Display(Name = "Teléfono", Order = 5)]
        public string Telefono { get; set; }

        [Display(Name = "Email", Order = 10)]
        public string Email { get; set; }

        [Display(Name = "Organismo", Order = 25)]
        public string Organismo { get; set; }

        [Display(Name = "Cargo", Order = 15)]
        public string Cargo { get; set; }




        #endregion
    }

    public class AgentesTrazabilidadView
    {
        #region Propiedades

        [Display(Name = "Id", AutoGenerateField = false, Order = 0)]
        public int Id { get; set; }

        [Display(Name = "Legajo", Order = 5)]
        public int Legajo { get; set; }

        [Display(Name = "Nombre", Order = 35)]
        public string Nombre { get; set; }

        [Display(Name = "Teléfono", Order = 15)]
        public string Telefono { get; set; }

        [Display(Name = "Organismo", Order = 25)]
        public string Organismo { get; set; }

        [Display(Name = "Cargo", Order = 15)]
        public string Cargo { get; set; }

        public long? Documento { get; set; }

        public int? Persona { get; set; }


        #endregion
    }

    public class AgentesCertificadoView
    {
        #region Propiedades

        [Display(Name = "Id", AutoGenerateField = false, Order = 0)]
        public int Id { get; set; }

        [Display(Name = "Legajo", Order = 5)]
        public int Legajo { get; set; }

        [Display(Name = "Nombre", Order = 35)]
        public string Nombre { get; set; }

        [Display(Name = "Teléfono", Order = 15)]
        public string Telefono { get; set; }

        [Display(Name = "Organismo", Order = 25)]
        public string Organismo { get; set; }

        [Display(Name = "Cargo", Order = 15)]
        public string Cargo { get; set; }

        [Display(Name = "Foto", Order = 15)]
        public string Foto { get; set; }

        [Display(Name = "Foto", Order = 15)]
        public int? Circunscripcion { get; set; }

        [Display(Name = "DNI", Order = 15)]
        public long DNI { get; set; }

        #endregion
    }

    public class AgentesViewMM
    {
        #region Propiedades

        [Display(Name = "Id", AutoGenerateField = false, Order = 0)]
        public int Id { get; set; }

        [Display(Name = "Legajo", Order = 5)]
        public int Legajo { get; set; }

        [Display(Name = "Nombre", Order = 35)]
        public string Nombre { get; set; }

        [Display(Name = "Organismo", Order = 25)]
        public string Organismo { get; set; }

        [Display(Name = "Ordinarias", Order = 15)]
        public int Cargo { get; set; }


        #endregion
    }
}
