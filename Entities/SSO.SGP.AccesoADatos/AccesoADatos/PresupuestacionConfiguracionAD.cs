
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
	public partial class PresupuestacionConfiguracionAD
	{
		private BDEntities db = new BDEntities();

		public PresupuestacionConfiguracion ObtenerPorId(int Id)
		{
			return db.PresupuestacionConfiguracion.Single(c => c.Id == Id);
		}

		public DbQuery<PresupuestacionConfiguracion> ObtenerTodo()
		{
			return (DbQuery<PresupuestacionConfiguracion>)db.PresupuestacionConfiguracion;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.PresupuestacionConfiguracion
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<PresupuestacionConfiguracionView> ObtenerParaGrilla()
		{
			var x = from c in db.PresupuestacionConfiguracion
					select new PresupuestacionConfiguracionView
					{
						 Id = c.Id,
						 Tipo = c.Tipo,
						 Valor = c.Valor,
					};
			return (DbQuery<PresupuestacionConfiguracionView>)x;
		}

		public void Guardar(PresupuestacionConfiguracion Objeto)
		{
			try
			{
				db.PresupuestacionConfiguracion.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(PresupuestacionConfiguracion Objeto)
		{
			try
			{
				db.PresupuestacionConfiguracion.Attach(Objeto);
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
				PresupuestacionConfiguracion Objeto = this.ObtenerPorId(IdObjeto);
				db.PresupuestacionConfiguracion.Remove(Objeto);
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

		public DbQuery<PresupuestacionConfiguracionViewT> JsonT(string term)
		{
			var x = from c in db.PresupuestacionConfiguracion
					select new PresupuestacionConfiguracionViewT
					{
						 Id = c.Id,
						 Tipo = c.Tipo,
						 Valor = c.Valor,
					};
			return (DbQuery<PresupuestacionConfiguracionViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
