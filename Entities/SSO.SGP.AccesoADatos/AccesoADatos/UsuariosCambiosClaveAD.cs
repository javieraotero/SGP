
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
	public partial class UsuariosCambiosClaveAD
	{
		private BDEntities db = new BDEntities();

		public UsuariosCambiosClave ObtenerPorId(int Id)
		{
			return db.UsuariosCambiosClave.Single(c => c.Id == Id);
		}

		public DbQuery<UsuariosCambiosClave> ObtenerTodo()
		{
			return (DbQuery<UsuariosCambiosClave>)db.UsuariosCambiosClave;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.UsuariosCambiosClave
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<UsuariosCambiosClaveView> ObtenerParaGrilla()
		{
			var x = from c in db.UsuariosCambiosClave
					select new UsuariosCambiosClaveView
					{
						 Id = c.Id,
						 Usuario = c.Usuario,
						 Fecha = c.Fecha,
						 ClaveAnterior = c.ClaveAnterior,
					};
			return (DbQuery<UsuariosCambiosClaveView>)x;
		}

		public void Guardar(UsuariosCambiosClave Objeto)
		{
			try
			{
				db.UsuariosCambiosClave.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(UsuariosCambiosClave Objeto)
		{
			try
			{
				db.UsuariosCambiosClave.Attach(Objeto);
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
				UsuariosCambiosClave Objeto = this.ObtenerPorId(IdObjeto);
				db.UsuariosCambiosClave.Remove(Objeto);
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

		public DbQuery<UsuariosCambiosClaveViewT> JsonT(string term)
		{
			var x = from c in db.UsuariosCambiosClave
					select new UsuariosCambiosClaveViewT
					{
						 Id = c.Id,
						 Usuario = c.Usuario,
						 Fecha = c.Fecha,
						 ClaveAnterior = c.ClaveAnterior,
					};
			return (DbQuery<UsuariosCambiosClaveViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
