
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
	public partial class ConcursosDeIngresoRespuestasAD
	{
		private BDEntities db = new BDEntities();

		public ConcursosDeIngresoRespuestas ObtenerPorId(int Id)
		{
			return db.ConcursosDeIngresoRespuestas.Single(c => c.Id == Id);
		}

		public DbQuery<ConcursosDeIngresoRespuestas> ObtenerTodo()
		{
			return (DbQuery<ConcursosDeIngresoRespuestas>)db.ConcursosDeIngresoRespuestas;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.ConcursosDeIngresoRespuestas
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<ConcursosDeIngresoRespuestasView> ObtenerParaGrilla()
		{
			var x = from c in db.ConcursosDeIngresoRespuestas
					select new ConcursosDeIngresoRespuestasView
					{
						 Id = c.Id,
						 Pregunta = c.Pregunta,
						 Respuesta = c.Respuesta,
						 EsCorrecta = c.EsCorrecta,
						 Activa = c.Activa,
					};
			return (DbQuery<ConcursosDeIngresoRespuestasView>)x;
		}

		public void Guardar(ConcursosDeIngresoRespuestas Objeto)
		{
			try
			{
				db.ConcursosDeIngresoRespuestas.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ConcursosDeIngresoRespuestas Objeto)
		{
			try
			{
				db.ConcursosDeIngresoRespuestas.Attach(Objeto);
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
				ConcursosDeIngresoRespuestas Objeto = this.ObtenerPorId(IdObjeto);
				db.ConcursosDeIngresoRespuestas.Remove(Objeto);
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

		//public DbQuery<ConcursosDeIngresoRespuestasViewT> JsonT(string term)
		//{
		//	var x = from c in db.ConcursosDeIngresoRespuestas
		//			select new ConcursosDeIngresoRespuestasViewT
		//			{
		//				 Id = c.Id,
		//				 Pregunta = c.Pregunta,
		//				 Respuesta = c.Respuesta,
		//				 EsCorrecta = c.EsCorrecta,
		//				 Activa = c.Activa,
		//			};
		//	return (DbQuery<ConcursosDeIngresoRespuestasViewT>)x;
		//}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
