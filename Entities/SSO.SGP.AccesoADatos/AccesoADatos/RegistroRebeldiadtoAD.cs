
using System;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Data.Objects.SqlClient;
using SSO.SGP.EntidadesDeNegocio;
using SSO.SGP.EntidadesDeNegocio.Vistas;
using Syncrosoft.Framework.Utils.Logs;


namespace SSO.SGP.AccesoADatos
{
	/// <summary>
	/// Acceso a Datos Generada por el Generador de codigo.
	/// </summary>
	public partial class RegistroRebeldiadtoAD
	{
		private BDEntities db = new BDEntities();

		
		public DbQuery<RegistroRebeldiaDTO> ObtenerTodo()
		{
			return (DbQuery<RegistroRebeldiaDTO>)db.RegistroRebeldiaDTO;
		}

        public RegistroRebeldiaDTO ObtenerPorDNI(string dni)
        {
            long documento;

            var rebeldia = new RegistroRebeldiaDTO();
            rebeldia.NroDocumento = 0;

            if (long.TryParse(dni, out documento)) {
                var res = from x in db.RegistroRebeldiaDTO
                          where x.NroDocumento == documento
                          && x.Estado == 2
                          select x;


                if (res.Count() > 0)
                    rebeldia = res.FirstOrDefault();
            }
          
            return rebeldia;
        }

        public void Dispose()
		{
			db.Dispose();
		}
	}
}
