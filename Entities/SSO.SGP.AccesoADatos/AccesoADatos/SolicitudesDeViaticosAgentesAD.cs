
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
	public partial class SolicitudesDeViaticosAgentesAD
	{
		private BDEntities db = new BDEntities();

		public SolicitudesDeViaticosAgentes ObtenerPorId(int Id)
		{
			return db.SolicitudesDeViaticosAgentes.Single(c => c.Id == Id);
		}

		public DbQuery<SolicitudesDeViaticosAgentes> ObtenerTodo()
		{
			return (DbQuery<SolicitudesDeViaticosAgentes>)db.SolicitudesDeViaticosAgentes;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.SolicitudesDeViaticosAgentes
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<SolicitudesDeViaticosAgentesView> ObtenerParaGrilla()
		{
			var x = from c in db.SolicitudesDeViaticosAgentes
					select new SolicitudesDeViaticosAgentesView
					{
						 Id = c.Id,
						 SolicitudDeViatico = c.SolicitudDeViatico,
						 Agente = c.Agente,
						 Dias = c.Dias,
						 ImportePorDia = c.ImportePorDia,
						 Subtotal = c.Subtotal,
						 ImporteGastos = c.ImporteGastos,
						 ImporteTotal = c.ImporteTotal,
					};
			return (DbQuery<SolicitudesDeViaticosAgentesView>)x;
		}

		public void Guardar(SolicitudesDeViaticosAgentes Objeto)
		{
			try
			{
				db.SolicitudesDeViaticosAgentes.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(SolicitudesDeViaticosAgentes Objeto)
		{
			try
			{
				db.SolicitudesDeViaticosAgentes.Attach(Objeto);
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
				SolicitudesDeViaticosAgentes Objeto = this.ObtenerPorId(IdObjeto);
				db.SolicitudesDeViaticosAgentes.Remove(Objeto);
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

		//public DbQuery<SolicitudesDeViaticosAgentesViewT> JsonT(string term)
		//{
		//	var x = from c in db.SolicitudesDeViaticosAgentes
		//			select new SolicitudesDeViaticosAgentesViewT
		//			{
		//				 Id = c.Id,
		//				 SolicitudDeViatico = c.SolicitudDeViatico,
		//				 Agente = c.Agente,
		//				 Dias = c.Dias,
		//				 ImportePorDia = c.ImportePorDia,
		//				 Subtotal = c.Subtotal,
		//				 ImporteGastos = c.ImporteGastos,
		//				 ImporteTotal = c.ImporteTotal,
		//			};
		//	return (DbQuery<SolicitudesDeViaticosAgentesViewT>)x;
		//}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
