
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
	public partial class ColumnasAD
	{
		private BDEntities db = new BDEntities();

		public Columnas ObtenerPorId(int Id)
		{
			return db.Columnas.Single(c => c.Id == Id);
		}

		public DbQuery<Columnas> ObtenerTodo()
		{
			return (DbQuery<Columnas>)db.Columnas;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.Columnas
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<ColumnasView> ObtenerParaGrilla()
		{
			var x = from c in db.Columnas
					select new ColumnasView
					{
						 Id = c.Id,
						 Nombre = c.Nombre,
						 Tabla = c.Tabla,
						 TipoDato = c.TipoDato,
						 Longitud = c.Longitud,
						 AdmiteNulo = c.AdmiteNulo,
						 Referencia = c.Referencia,
						 Mostrar = c.Mostrar,
					};
			return (DbQuery<ColumnasView>)x;
		}

		public void Guardar(Columnas Objeto)
		{
			try
			{
				db.Columnas.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(Columnas Objeto)
		{
			try
			{
				db.Columnas.Attach(Objeto);
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
				Columnas Objeto = this.ObtenerPorId(IdObjeto);
				db.Columnas.Remove(Objeto);
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

		public DbQuery<ColumnasViewT> JsonT(string term)
		{
			var x = from c in db.Columnas
					select new ColumnasViewT
					{
						 Id = c.Id,
						 Nombre = c.Nombre,
						 Tabla = c.Tabla,
						 TipoDato = c.TipoDato,
						 Longitud = c.Longitud,
						 AdmiteNulo = c.AdmiteNulo,
						 Referencia = c.Referencia,
						 Mostrar = c.Mostrar,
					};
			return (DbQuery<ColumnasViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
