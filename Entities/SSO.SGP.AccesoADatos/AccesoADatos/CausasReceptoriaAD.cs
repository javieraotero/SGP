
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
	public partial class CausasReceptoriaAD
	{
		private BDEntities db = new BDEntities();

		public CausasReceptoria ObtenerPorId(int Id)
		{
			return db.CausasReceptoria.Single(c => c.Id == Id);
		}

		public DbQuery<CausasReceptoria> ObtenerTodo()
		{
			return (DbQuery<CausasReceptoria>)db.CausasReceptoria;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.CausasReceptoria
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<CausasReceptoriaView> ObtenerParaGrilla()
		{
			var x = from c in db.CausasReceptoria
					select new CausasReceptoriaView
					{
						 Id = c.Id,
						 Numero = c.Numero,
						 Caratula = c.Caratula,
						 Circunscripcion = c.Circunscripcion,
					};
			return (DbQuery<CausasReceptoriaView>)x;
		}

		public void Guardar(CausasReceptoria Objeto)
		{
			try
			{
				db.CausasReceptoria.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(CausasReceptoria Objeto)
		{
			try
			{
				db.CausasReceptoria.Attach(Objeto);
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
				CausasReceptoria Objeto = this.ObtenerPorId(IdObjeto);
				db.CausasReceptoria.Remove(Objeto);
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

		public DbQuery<CausasReceptoriaViewT> JsonT(string term)
		{
			var x = from c in db.CausasReceptoria
					select new CausasReceptoriaViewT
					{
						 Id = c.Id,
						 Numero = c.Numero,
						 Caratula = c.Caratula,
						 Circunscripcion = c.Circunscripcion,
					};
			return (DbQuery<CausasReceptoriaViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
