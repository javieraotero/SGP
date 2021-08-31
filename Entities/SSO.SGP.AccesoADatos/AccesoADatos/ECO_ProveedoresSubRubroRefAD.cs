
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
	public partial class ECO_ProveedoresSubRubroRefAD
	{
		private BDEntities db = new BDEntities();

		public ECO_ProveedoresSubRubroRef ObtenerPorId(int Id)
		{
			return db.ECO_ProveedoresSubRubroRef.Single(c => c.Id == Id);
		}

		public List<ECO_ProveedoresSubRubroRef> ObtenerPorIdRubro(int Id)
		{
			return db.ECO_ProveedoresSubRubroRef.Where(c => c.Rubro == Id).ToList();
		}

		public DbQuery<ECO_ProveedoresSubRubroRef> ObtenerTodo()
		{
			return (DbQuery<ECO_ProveedoresSubRubroRef>)db.ECO_ProveedoresSubRubroRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.ECO_ProveedoresSubRubroRef
					  where x.Descripcion.Contains(filtro)
				select new SelectOptionsView {text = x.Descripcion, value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

        public DbQuery<ECO_ProveedoresSubRubroRef> GetAutocomplete(string filtro)
        {
            var res = from x in db.ECO_ProveedoresSubRubroRef
					  where x.Descripcion.Contains(filtro)
                      select x;
            return (DbQuery<ECO_ProveedoresSubRubroRef>)res;
        }


		public void Guardar(ECO_ProveedoresSubRubroRef Objeto)
		{
			try
			{
				db.ECO_ProveedoresSubRubroRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ECO_ProveedoresSubRubroRef Objeto)
		{
			try
			{
				db.ECO_ProveedoresSubRubroRef.Attach(Objeto);
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
				ECO_ProveedoresSubRubroRef Objeto = this.ObtenerPorId(IdObjeto);
				db.ECO_ProveedoresSubRubroRef.Remove(Objeto);
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
