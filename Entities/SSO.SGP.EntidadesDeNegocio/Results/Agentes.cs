using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSO.SGP.EntidadesDeNegocio.Results
{
    public class AgentesResult
    {

        public int Id { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public int Legajo { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public long Documento { get; set; }
        public string Domicilio { get; set; }
        public int Id_Organismo { get; set; }
        public int Id_Nombramiento { get; set; }
        public string Organismo { get; set; }
        public bool Otorga { get; set; }
        public string Cargo { get; set; }
        public DateTime? FechaUltimoAscenso { get; set; }
        public int IdSuperior { get; set; }
        public string Superior { get; set; }
        public string Url_Profile { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public int Grupo { get; set; }
        public List<FuncionariosResult> Funcionarios { get; set; }
        public string EmailSuperior { get; set; }
        public int Id_Cargo { get; set; }
        public bool RequiereSubrogante { get; set; }

        public string mensaje { get; set; }

        public bool habilita_licencia { get; set; }

        public int? AgenteSolicitudLicenciaDefault { get; set; }
        public string Profesion { get; set; }


    }

    public class FuncionariosResult
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Cargo { get; set; }
        public string Email { get; set; }
    }

}
