
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
	public partial class AcumuladosAD
	{
		private BDEntities db = new BDEntities();

		public Acumulados ObtenerPorId(int Id)
		{
			return db.Acumulados.Single(c => c.Id == Id);
		}

		public DbQuery<Acumulados> ObtenerTodo()
		{
			return (DbQuery<Acumulados>)db.Acumulados;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.Acumulados
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<AcumuladosView> ObtenerParaGrilla()
		{
			var x = from c in db.Acumulados
					select new AcumuladosView
					{
						 Id = c.Id,
						 Juzgado = c.Juzgado,
						 Categoria = c.Categoria,
						 Habilitado = c.Habilitado,
						 Cantidad = c.Cantidad,
						 Circunscripcion = c.Circunscripcion,
					};
			return (DbQuery<AcumuladosView>)x;
		}

		public void Guardar(Acumulados Objeto)
		{
			try
			{
				db.Acumulados.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(Acumulados Objeto)
		{
			try
			{
				db.Acumulados.Attach(Objeto);
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
				Acumulados Objeto = this.ObtenerPorId(IdObjeto);
				db.Acumulados.Remove(Objeto);
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

		public DbQuery<AcumuladosViewT> JsonT(string term)
		{
			var x = from c in db.Acumulados
					select new AcumuladosViewT
					{
						 Id = c.Id,
						 Juzgado = c.Juzgado,
						 Categoria = c.Categoria,
						 Habilitado = c.Habilitado,
						 Cantidad = c.Cantidad,
						 Circunscripcion = c.Circunscripcion,
					};
			return (DbQuery<AcumuladosViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
