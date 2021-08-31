
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
	public partial class CoMediadoresContadoresAD
	{
		private BDEntities db = new BDEntities();

		public CoMediadoresContadores ObtenerPorId(int Id)
		{
			return db.CoMediadoresContadores.Single(c => c.Id == Id);
		}

		public DbQuery<CoMediadoresContadores> ObtenerTodo()
		{
			return (DbQuery<CoMediadoresContadores>)db.CoMediadoresContadores.Where(c => c.Activo == true);
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.CoMediadoresContadores
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<CoMediadoresContadoresView> ObtenerParaGrilla()
		{
			var x = from c in db.CoMediadoresContadores
					where c.Activo == true
					select new CoMediadoresContadoresView
					{
						 Id = c.Id,
						 Inscripcion = c.Inscripcion,
						 Contador = c.Contador,
						 Circunscripcion = c.Circunscripcion,
						 Activo = c.Activo,
					};
			return (DbQuery<CoMediadoresContadoresView>)x;
		}

		public void Guardar(CoMediadoresContadores Objeto)
		{
			try
			{
				db.CoMediadoresContadores.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(CoMediadoresContadores Objeto)
		{
			try
			{
				db.CoMediadoresContadores.Attach(Objeto);
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
				CoMediadoresContadores Objeto = this.ObtenerPorId(IdObjeto);
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

		public DbQuery<CoMediadoresContadoresViewT> JsonT(string term)
		{
			var x = from c in db.CoMediadoresContadores
					where c.Activo == true
					select new CoMediadoresContadoresViewT
					{
						 Id = c.Id,
						 Inscripcion = c.Inscripcion,
						 Contador = c.Contador,
						 Circunscripcion = c.Circunscripcion,
						 Activo = c.Activo,
					};
			return (DbQuery<CoMediadoresContadoresViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
