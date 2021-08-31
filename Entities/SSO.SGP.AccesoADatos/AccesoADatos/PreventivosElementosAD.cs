
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
	public partial class PreventivosElementosAD
	{
		private BDEntities db = new BDEntities();

		public PreventivosElementos ObtenerPorId(int Id)
		{
			return db.PreventivosElementos.Single(c => c.Id == Id);
		}

		public DbQuery<PreventivosElementos> ObtenerTodo()
		{
			return (DbQuery<PreventivosElementos>)db.PreventivosElementos;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.PreventivosElementos
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<PreventivosElementosView> ObtenerParaGrilla()
		{
			var x = from c in db.PreventivosElementos
					select new PreventivosElementosView
					{
						 Id = c.Id,
						 Preventivo = c.Preventivo,
						 Rol = c.Rol,
						 Descripcion = c.Descripcion,
						 GrupoElemento = c.GrupoElemento,
					};
			return (DbQuery<PreventivosElementosView>)x;
		}

		public void Guardar(PreventivosElementos Objeto)
		{
			try
			{
				db.PreventivosElementos.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(PreventivosElementos Objeto)
		{
			try
			{
				db.PreventivosElementos.Attach(Objeto);
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
				PreventivosElementos Objeto = this.ObtenerPorId(IdObjeto);
				db.PreventivosElementos.Remove(Objeto);
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

		public DbQuery<PreventivosElementosViewT> JsonT(string term)
		{
			var x = from c in db.PreventivosElementos
					select new PreventivosElementosViewT
					{
						 Id = c.Id,
						 Preventivo = c.Preventivo,
						 Rol = c.Rol,
						 Descripcion = c.Descripcion,
						 GrupoElemento = c.GrupoElemento,
					};
			return (DbQuery<PreventivosElementosViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
