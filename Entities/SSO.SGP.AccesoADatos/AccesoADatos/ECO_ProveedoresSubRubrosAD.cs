
using System;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Data.Objects.SqlClient;
using SSO.SGP.EntidadesDeNegocio;
using SSO.SGP.EntidadesDeNegocio.Vistas;
using Syncrosoft.Framework.Utils.Logs;
using System.Collections.Generic;

namespace SSO.SGP.AccesoADatos
{
	/// <summary>
	/// Acceso a Datos Generada por el Generador de codigo.
	/// </summary>
	public partial class ECO_ProveedoresSubRubrosAD
	{
		private BDEntities db = new BDEntities();

		public ECO_ProveedoresSubRubros ObtenerPorId(int Id)
		{
			return db.ECO_ProveedoresSubRubros.Single(c => c.Id == Id);
		}

		public DbQuery<ECO_ProveedoresSubRubros> ObtenerTodo()
		{
			return (DbQuery<ECO_ProveedoresSubRubros>)db.ECO_ProveedoresSubRubros;
		}

        public List<ECO_ProveedoresSubRubros> ObtenerXProveedor(int id)
        {
            try
            {

                var res = (from x in db.ECO_ProveedoresSubRubros
                          where x.Proveedor == id
                          select x).ToList();

                return res;
            }
            catch (Exception msg)
            {
                Logger.GrabarExcepcion(msg, false);
                throw new Exception(msg.Message);
            }
        }

        public void Guardar(ECO_ProveedoresSubRubros Objeto)
		{
			try
			{
				db.ECO_ProveedoresSubRubros.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ECO_ProveedoresSubRubros Objeto)
		{
			try
			{
				db.ECO_ProveedoresSubRubros.Attach(Objeto);
				db.Entry(Objeto).State = EntityState.Modified;
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Eliminar(int IdObjeto)
		{
			try
			{
				ECO_ProveedoresSubRubros Objeto = this.ObtenerPorId(IdObjeto);
				db.ECO_ProveedoresSubRubros.Remove(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			db.Dispose();
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
