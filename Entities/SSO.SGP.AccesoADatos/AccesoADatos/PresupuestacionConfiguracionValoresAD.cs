
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
	public partial class PresupuestacionConfiguracionValoresAD
	{
		private BDEntities db = new BDEntities();

		public PresupuestacionConfiguracionValores ObtenerPorId(int Id)
		{
			return db.PresupuestacionConfiguracionValores.Single(c => c.Id == Id);
		}

		public DbQuery<PresupuestacionConfiguracionValores> ObtenerTodo()
		{
			return (DbQuery<PresupuestacionConfiguracionValores>)db.PresupuestacionConfiguracionValores;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.PresupuestacionConfiguracionValores
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<PresupuestacionConfiguracionValoresView> ObtenerParaGrilla()
		{
			var x = from c in db.PresupuestacionConfiguracionValores
					select new PresupuestacionConfiguracionValoresView
					{
						 Id = c.Id,
						 Presupuestacion = c.Presupuestacion,
						 Configuracion = c.Configuracion,
						 Valor = c.Valor,
					};
			return (DbQuery<PresupuestacionConfiguracionValoresView>)x;
		}

		public void Guardar(PresupuestacionConfiguracionValores Objeto)
		{
			try
			{
				db.PresupuestacionConfiguracionValores.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(PresupuestacionConfiguracionValores Objeto)
		{
			try
			{
				db.PresupuestacionConfiguracionValores.Attach(Objeto);
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
				PresupuestacionConfiguracionValores Objeto = this.ObtenerPorId(IdObjeto);
				db.PresupuestacionConfiguracionValores.Remove(Objeto);
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

		public DbQuery<PresupuestacionConfiguracionValoresViewT> JsonT(string term)
		{
			var x = from c in db.PresupuestacionConfiguracionValores
					select new PresupuestacionConfiguracionValoresViewT
					{
						 Id = c.Id,
						 Presupuestacion = c.Presupuestacion,
						 Configuracion = c.Configuracion,
						 Valor = c.Valor,
					};
			return (DbQuery<PresupuestacionConfiguracionValoresViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
