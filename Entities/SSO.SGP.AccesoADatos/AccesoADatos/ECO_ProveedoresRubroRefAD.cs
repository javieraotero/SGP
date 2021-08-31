
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
	public partial class ECO_ProveedoresRubroRefAD
	{
		private BDEntities db = new BDEntities();

		public ECO_ProveedoresRubroRef ObtenerPorId(int Id)
		{
			return db.ECO_ProveedoresRubroRef.Single(c => c.Id == Id);
		}

		public DbQuery<ECO_ProveedoresRubroRef> ObtenerProveedoresxTipo(int id)
		{
			try
			{
				var res = from x in db.ECO_ProveedoresRubroRef
						  where x.Tipo == (eTipoRubro)id
						  select x;
				return (DbQuery<ECO_ProveedoresRubroRef>)res;
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public DbQuery<ECO_ProveedoresRubroRef> ObtenerTodo()
		{
			return (DbQuery<ECO_ProveedoresRubroRef>)db.ECO_ProveedoresRubroRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.ECO_ProveedoresRubroRef
					  where x.Descripcion.Contains(filtro)
				select new SelectOptionsView {text = x.Descripcion, value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

        public DbQuery<ECO_ProveedoresRubroRef> GetAutocomplete(string filtro)
        {
            var res = from x in db.ECO_ProveedoresRubroRef
					  where x.Descripcion.Contains(filtro)
                      select x;
            return (DbQuery<ECO_ProveedoresRubroRef>)res;
        }


		public void Guardar(ECO_ProveedoresRubroRef Objeto)
		{
			try
			{
				db.ECO_ProveedoresRubroRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ECO_ProveedoresRubroRef Objeto)
		{
			try
			{
				db.ECO_ProveedoresRubroRef.Attach(Objeto);
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
				ECO_ProveedoresRubroRef Objeto = this.ObtenerPorId(IdObjeto);
				db.ECO_ProveedoresRubroRef.Remove(Objeto);
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
