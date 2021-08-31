
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
	public partial class UsuariosAccesosAD
	{
		private BDEntities db = new BDEntities();

		public UsuariosAccesos ObtenerPorId(int Id)
		{
			return db.UsuariosAccesos.Single(c => c.Id == Id);
		}

		public DbQuery<UsuariosAccesos> ObtenerTodo()
		{
			return (DbQuery<UsuariosAccesos>)db.UsuariosAccesos;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.UsuariosAccesos
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<UsuariosAccesosView> ObtenerParaGrilla()
		{
			var x = from c in db.UsuariosAccesos
					select new UsuariosAccesosView
					{
						 Id = c.Id,
						 Usuario = c.Usuario,
						 Fecha = c.Fecha,
						 Ip = c.Ip,
						 Intentos = c.Intentos,
						 Navegador = c.Navegador,
						 Organismo = c.Organismo,
					};
			return (DbQuery<UsuariosAccesosView>)x;
		}

		public void Guardar(UsuariosAccesos Objeto)
		{
			try
			{
				db.UsuariosAccesos.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(UsuariosAccesos Objeto)
		{
			try
			{
				db.UsuariosAccesos.Attach(Objeto);
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
				UsuariosAccesos Objeto = this.ObtenerPorId(IdObjeto);
				db.UsuariosAccesos.Remove(Objeto);
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

		public DbQuery<UsuariosAccesosViewT> JsonT(string term)
		{
			var x = from c in db.UsuariosAccesos
					select new UsuariosAccesosViewT
					{
						 Id = c.Id,
						 Usuario = c.Usuario,
						 Fecha = c.Fecha,
						 Ip = c.Ip,
						 Intentos = c.Intentos,
						 Navegador = c.Navegador,
						 Organismo = c.Organismo,
					};
			return (DbQuery<UsuariosAccesosViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
