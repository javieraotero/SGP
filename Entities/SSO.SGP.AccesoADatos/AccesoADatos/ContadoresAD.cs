
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
	public partial class ContadoresAD
	{
		private BDEntities db = new BDEntities();

		public Contadores ObtenerPorId(int Id)
		{
			return db.Contadores.Single(c => c.Id == Id);
		}

		public DbQuery<Contadores> ObtenerTodo()
		{
			return (DbQuery<Contadores>)db.Contadores;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.Contadores
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<ContadoresView> ObtenerParaGrilla()
		{
			var x = from c in db.Contadores
					select new ContadoresView
					{
						 Id = c.Id,
						 Fiscal = c.Fiscal,
						 Categoria = c.Categoria,
						 Habilitado = c.Habilitado,
						 Cantidad = c.Cantidad,
						 Circunscripcion = c.Circunscripcion,
					};
			return (DbQuery<ContadoresView>)x;
		}

		public void Guardar(Contadores Objeto)
		{
			try
			{
				db.Contadores.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(Contadores Objeto)
		{
			try
			{
				db.Contadores.Attach(Objeto);
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
				Contadores Objeto = this.ObtenerPorId(IdObjeto);
				db.Contadores.Remove(Objeto);
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

		public DbQuery<ContadoresViewT> JsonT(string term)
		{
			var x = from c in db.Contadores
					select new ContadoresViewT
					{
						 Id = c.Id,
						 Fiscal = c.Fiscal,
						 Categoria = c.Categoria,
						 Habilitado = c.Habilitado,
						 Cantidad = c.Cantidad,
						 Circunscripcion = c.Circunscripcion,
					};
			return (DbQuery<ContadoresViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
