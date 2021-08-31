
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
	public partial class CesidaValoresDeParametrosAD
	{
		private BDEntities db = new BDEntities();

		public CesidaValoresDeParametros ObtenerPorId(int Id)
		{
			return db.CesidaValoresDeParametros.Single(c => c.Id == Id);
		}

		public DbQuery<CesidaValoresDeParametros> ObtenerTodo()
		{
			return (DbQuery<CesidaValoresDeParametros>)db.CesidaValoresDeParametros;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.CesidaValoresDeParametros
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<CesidaValoresDeParametrosView> ObtenerParaGrilla()
		{
			var x = from c in db.CesidaValoresDeParametros
					select new CesidaValoresDeParametrosView
					{
						 Id = c.Id,
						 Parametro = c.Parametro,
						 Valor = c.Valor,
					};
			return (DbQuery<CesidaValoresDeParametrosView>)x;
		}

		public void Guardar(CesidaValoresDeParametros Objeto)
		{
			try
			{
				db.CesidaValoresDeParametros.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(CesidaValoresDeParametros Objeto)
		{
			try
			{
				db.CesidaValoresDeParametros.Attach(Objeto);
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
				CesidaValoresDeParametros Objeto = this.ObtenerPorId(IdObjeto);
				db.CesidaValoresDeParametros.Remove(Objeto);
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

		public DbQuery<CesidaValoresDeParametrosViewT> JsonT(string term)
		{
			var x = from c in db.CesidaValoresDeParametros
					select new CesidaValoresDeParametrosViewT
					{
						 Id = c.Id,
						 Parametro = c.Parametro,
						 Valor = c.Valor,
					};
			return (DbQuery<CesidaValoresDeParametrosViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
