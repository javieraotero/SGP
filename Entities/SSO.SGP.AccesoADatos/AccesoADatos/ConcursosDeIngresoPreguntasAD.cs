
using System;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Data.Objects.SqlClient;
using SSO.SGP.EntidadesDeNegocio;
using SSO.SGP.EntidadesDeNegocio.Vistas;
using Syncrosoft.Framework.Utils.Logs;
using System.Collections.Generic;

namespace SSO.SGP.AccesoADatos
{
	/// <summary>
	/// Acceso a Datos Generada por el Generador de codigo.
	/// </summary>
	public partial class ConcursosDeIngresoPreguntasAD
	{
		private BDEntities db = new BDEntities();

		public ConcursosDeIngresoPreguntas ObtenerPorId(int Id)
		{
			return db.ConcursosDeIngresoPreguntas.Single(c => c.Id == Id);
		}

		public DbQuery<ConcursosDeIngresoPreguntas> ObtenerTodo()
		{
			return (DbQuery<ConcursosDeIngresoPreguntas>)db.ConcursosDeIngresoPreguntas;
		}

        public List<ConcursosDeIngresoPreguntas> ObtenerPorExamen(int id)
        {
            var cantidad = db.ConcursosDeIngresoEvaluaciones.Where(x => x.Id == id).FirstOrDefault().Cantidad_Preguntas ?? 10;

            var preguntas = (from x in db.ConcursosDeIngresoPreguntas
                    where x.Evaluacion == id && x.Activa
                    orderby x.Orden ascending                    
                    select x                    
                   ).ToList();
            
            return preguntas.OrderBy(x => Guid.NewGuid()).Take(cantidad).ToList();
        }

        public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.ConcursosDeIngresoPreguntas
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

        public DbQuery<ConcursosDeIngresoPreguntasView> ObtenerParaGrilla()
		{
			var x = from c in db.ConcursosDeIngresoPreguntas
					select new ConcursosDeIngresoPreguntasView
					{
						 Id = c.Id,
						 Pregunta = c.Pregunta,
						 Evaluacion = c.Evaluacion,
						 Activa = c.Activa,
						 Orden = c.Orden,
					};
			return (DbQuery<ConcursosDeIngresoPreguntasView>)x;
		}

		public void Guardar(ConcursosDeIngresoPreguntas Objeto)
		{
			try
			{
				db.ConcursosDeIngresoPreguntas.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ConcursosDeIngresoPreguntas Objeto)
		{
			try
			{
				db.ConcursosDeIngresoPreguntas.Attach(Objeto);
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
				ConcursosDeIngresoPreguntas Objeto = this.ObtenerPorId(IdObjeto);
				db.ConcursosDeIngresoPreguntas.Remove(Objeto);
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

		//public DbQuery<ConcursosDeIngresoPreguntasViewT> JsonT(string term)
		//{
		//	var x = from c in db.ConcursosDeIngresoPreguntas
		//			select new ConcursosDeIngresoPreguntasViewT
		//			{
		//				 Id = c.Id,
		//				 Pregunta = c.Pregunta,
		//				 Evaluacion = c.Evaluacion,
		//				 Activa = c.Activa,
		//				 Orden = c.Orden,
		//			};
		//	return (DbQuery<ConcursosDeIngresoPreguntasViewT>)x;
		//}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
