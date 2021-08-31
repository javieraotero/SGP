
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
	public partial class DenegatoriasrrhhAD
	{
		private BDEntities db = new BDEntities();

		public Denegatoriasrrhh ObtenerPorId(int Id)
		{
			return db.Denegatoriasrrhh.Single(c => c.Id == Id);
		}

		public DbQuery<Denegatoriasrrhh> ObtenerTodo()
		{
			return (DbQuery<Denegatoriasrrhh>)db.Denegatoriasrrhh;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.Denegatoriasrrhh
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<DenegatoriasrrhhView> ObtenerParaGrilla()
		{
			var x = from c in db.Denegatoriasrrhh
					select new DenegatoriasrrhhView
					{
						 Id = c.Id,
						 Agente = c.Agente,
						 Fecha = c.Fecha,
						 FechaAlta = c.FechaAlta,
						 UsuarioAlta = c.UsuarioAlta,
						 DiasDenegados = c.DiasDenegados,
					};
			return (DbQuery<DenegatoriasrrhhView>)x;
		}

		public void Guardar(Denegatoriasrrhh Objeto)
		{
			try
			{
				db.Denegatoriasrrhh.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(Denegatoriasrrhh Objeto)
		{
			try
			{
				db.Denegatoriasrrhh.Attach(Objeto);
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
				Denegatoriasrrhh Objeto = this.ObtenerPorId(IdObjeto);
				db.Denegatoriasrrhh.Remove(Objeto);
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

		public DbQuery<DenegatoriasrrhhViewT> JsonT(string term)
		{
			var x = from c in db.Denegatoriasrrhh
					select new DenegatoriasrrhhViewT
					{
						 Id = c.Id,
						 Agente = c.Agente,
						 Fecha = c.Fecha,
						 FechaAlta = c.FechaAlta,
						 UsuarioAlta = c.UsuarioAlta,
						 DiasDenegados = c.DiasDenegados,
					};
			return (DbQuery<DenegatoriasrrhhViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
