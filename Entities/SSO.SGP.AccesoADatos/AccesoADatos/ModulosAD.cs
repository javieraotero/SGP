
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
	public partial class ModulosAD
	{
		private BDEntities db = new BDEntities();

		public Modulos ObtenerPorId(int Id)
		{
			return db.Modulos.Single(c => c.Id == Id);
		}

		public DbQuery<Modulos> ObtenerTodo()
		{
			return (DbQuery<Modulos>)db.Modulos;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.Modulos
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<ModulosView> ObtenerParaGrilla()
		{
			var x = from c in db.Modulos
					select new ModulosView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 Abreviatura = c.Abreviatura,
						 ModuloPadre = c.ModuloPadre,
					};
			return (DbQuery<ModulosView>)x;
		}

		public void Guardar(Modulos Objeto)
		{
			try
			{
				db.Modulos.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(Modulos Objeto)
		{
			try
			{
				db.Modulos.Attach(Objeto);
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
				Modulos Objeto = this.ObtenerPorId(IdObjeto);
				db.Modulos.Remove(Objeto);
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

		public DbQuery<ModulosViewT> JsonT(string term)
		{
			var x = from c in db.Modulos
					select new ModulosViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 Abreviatura = c.Abreviatura,
						 ModuloPadre = c.ModuloPadre,
					};
			return (DbQuery<ModulosViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
