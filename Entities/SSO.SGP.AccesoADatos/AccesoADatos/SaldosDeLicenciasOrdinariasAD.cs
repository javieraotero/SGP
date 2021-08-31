
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
	public partial class SaldosDeLicenciasOrdinariasAD
	{
		private BDEntities db = new BDEntities();

		public SaldosDeLicenciasOrdinarias ObtenerPorId(int Id)
		{
			return db.SaldosDeLicenciasOrdinarias.Single(c => c.Id == Id);
		}

		public DbQuery<SaldosDeLicenciasOrdinarias> ObtenerTodo()
		{
			return (DbQuery<SaldosDeLicenciasOrdinarias>)db.SaldosDeLicenciasOrdinarias;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.SaldosDeLicenciasOrdinarias
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<SaldosDeLicenciasOrdinariasView> ObtenerParaGrilla()
		{
			var x = from c in db.SaldosDeLicenciasOrdinarias
					select new SaldosDeLicenciasOrdinariasView
					{
						 Id = c.Id,
						 Agente = c.Agente,
						 Anio = c.Anio,
						 DiasTrabajados = c.DiasTrabajados,
						 DiasUtilizados = c.DiasUtilizados,
						 Enero = c.Enero,
						 Julio = c.Julio,
					};
			return (DbQuery<SaldosDeLicenciasOrdinariasView>)x;
		}

		public void Guardar(SaldosDeLicenciasOrdinarias Objeto)
		{
			try
			{
				db.SaldosDeLicenciasOrdinarias.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(SaldosDeLicenciasOrdinarias Objeto)
		{
			try
			{
				db.SaldosDeLicenciasOrdinarias.Attach(Objeto);
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
				SaldosDeLicenciasOrdinarias Objeto = this.ObtenerPorId(IdObjeto);
				db.SaldosDeLicenciasOrdinarias.Remove(Objeto);
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

		public DbQuery<SaldosDeLicenciasOrdinariasViewT> JsonT(string term)
		{
			var x = from c in db.SaldosDeLicenciasOrdinarias
					select new SaldosDeLicenciasOrdinariasViewT
					{
						 Id = c.Id,
						 Agente = c.Agente,
						 Anio = c.Anio,
						 DiasTrabajados = c.DiasTrabajados,
						 DiasUtilizados = c.DiasUtilizados,
						 Enero = c.Enero,
						 Julio = c.Julio,
					};
			return (DbQuery<SaldosDeLicenciasOrdinariasViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
