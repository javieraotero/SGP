using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSO.SGP.EntidadesDeNegocio.Custom
{
    public class CustomPartidaPresupuestaria
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Este valor es requerido")]
        [StringLength(4, ErrorMessage = "NumeroDePartida no puede superar los 4 caracteres")]
        [Display(Name="Número")]
        public string NumeroDePartida { get; set; }

        [Required(ErrorMessage = "Este valor es requerido")]
        [StringLength(50, ErrorMessage = "Descripcion no puede superar los 50 caracteres")]
        [Display(Name="Descripción")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Este valor es requerido")]
        [StringLength(50, ErrorMessage = "Mnemo no puede superar los 50 caracteres")]
        public string Mnemo { get; set; }

        [Required(ErrorMessage = "Este valor es requerido")]
        [Display(Name="Unidad de Organización")]
        public int UnidadDeOrganizacion { get; set; }

        [Required(ErrorMessage = "Debe ingresar Prioridad")]
        public bool Prioridad { get; set; }

        public DetalleDivisiones[] DetalleDivisiones { get; set; }

    }

    public class DetalleDivisiones
    {
        [Display(Name = "Id", AutoGenerateField = false)]
        public int id { get; set; }
        [Display(Name = "Nombre")]
        public string nombre { get; set; }
        [Display(Name = "Cod. CESIDA")]
        public string codigocesida { get; set; }
        [Display(Name = "Partida Pres.")]
        public string partida { get; set; }
        [Display(AutoGenerateField = false, Name = "Nuevo")]
        public bool nuevo { get; set; }
    }
}
