
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
	public partial class PeritosContadoresAD
	{
		private BDEntities db = new BDEntities();

		public PeritosContadores ObtenerPorId(int Id)
		{
			return db.PeritosContadores.Single(c => c.Id == Id);
		}

		public DbQuery<PeritosContadores> ObtenerTodo()
		{
			return (DbQuery<PeritosContadores>)db.PeritosContadores.Where(c => c.Activo == true);
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.PeritosContadores
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<PeritosContadoresView> ObtenerParaGrilla()
		{
			var x = from c in db.PeritosContadores
					where c.Activo == true
					select new PeritosContadoresView
					{
						 Id = c.Id,
						 Inscripcion = c.Inscripcion,
						 Contador = c.Contador,
						 Organismo = c.Organismo,
						 Activo = c.Activo,
					};
			return (DbQuery<PeritosContadoresView>)x;
		}

		public void Guardar(PeritosContadores Objeto)
		{
			try
			{
				db.PeritosContadores.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(PeritosContadores Objeto)
		{
			try
			{
				db.PeritosContadores.Attach(Objeto);
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
				PeritosContadores Objeto = this.ObtenerPorId(IdObjeto);
				Objeto.Activo = false;
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

		public DbQuery<PeritosContadoresViewT> JsonT(string term)
		{
			var x = from c in db.PeritosContadores
					where c.Activo == true
					select new PeritosContadoresViewT
					{
						 Id = c.Id,
						 Inscripcion = c.Inscripcion,
						 Contador = c.Contador,
						 Organismo = c.Organismo,
						 Activo = c.Activo,
					};
			return (DbQuery<PeritosContadoresViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
