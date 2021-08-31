
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
	public partial class SolicitudesDeViaticosRendicionesAgentesAD
	{
		private BDEntities db = new BDEntities();

		public SolicitudesDeViaticosRendicionesAgentes ObtenerPorId(int Id)
		{
			return db.SolicitudesDeViaticosRendicionesAgentes.Single(c => c.Id == Id);
		}

		public DbQuery<SolicitudesDeViaticosRendicionesAgentes> ObtenerTodo()
		{
			return (DbQuery<SolicitudesDeViaticosRendicionesAgentes>)db.SolicitudesDeViaticosRendicionesAgentes;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.SolicitudesDeViaticosRendicionesAgentes
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<SolicitudesDeViaticosRendicionesAgentesView> ObtenerParaGrilla()
		{
			var x = from c in db.SolicitudesDeViaticosRendicionesAgentes
					select new SolicitudesDeViaticosRendicionesAgentesView
					{
						 Id = c.Id,
						 Rendicion = c.Rendicion,
						 Agente = c.Agente,
						 Dias = c.Dias,
						 ImportePorDia = c.ImportePorDia,
						 Subtotal = c.Subtotal,
						 Gastos = c.Gastos,
						 Anticipo = c.Anticipo,
						 Cobrar = c.Cobrar,
						 Devolver = c.Devolver,
					};
			return (DbQuery<SolicitudesDeViaticosRendicionesAgentesView>)x;
		}

		public void Guardar(SolicitudesDeViaticosRendicionesAgentes Objeto)
		{
			try
			{
				db.SolicitudesDeViaticosRendicionesAgentes.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(SolicitudesDeViaticosRendicionesAgentes Objeto)
		{
			try
			{
				db.SolicitudesDeViaticosRendicionesAgentes.Attach(Objeto);
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
				SolicitudesDeViaticosRendicionesAgentes Objeto = this.ObtenerPorId(IdObjeto);
				db.SolicitudesDeViaticosRendicionesAgentes.Remove(Objeto);
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

		//public DbQuery<SolicitudesDeViaticosRendicionesAgentesViewT> JsonT(string term)
		//{
		//	var x = from c in db.SolicitudesDeViaticosRendicionesAgentes
		//			select new SolicitudesDeViaticosRendicionesAgentesViewT
		//			{
		//				 Id = c.Id,
		//				 Rendicion = c.Rendicion,
		//				 Agente = c.Agente,
		//				 Dias = c.Dias,
		//				 ImportePorDia = c.ImportePorDia,
		//				 Subtotal = c.Subtotal,
		//				 Gastos = c.Gastos,
		//				 Anticipo = c.Anticipo,
		//				 Cobrar = c.Cobrar,
		//				 Devolver = c.Devolver,
		//			};
		//	return (DbQuery<SolicitudesDeViaticosRendicionesAgentesViewT>)x;
		//}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
