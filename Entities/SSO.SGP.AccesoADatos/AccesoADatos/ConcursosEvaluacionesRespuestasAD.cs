
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
	public partial class ConcursosEvaluacionesRespuestasAD
	{
		private BDEntities db = new BDEntities();

		public ConcursosEvaluacionesRespuestas ObtenerPorId(int Id)
		{
			return db.ConcursosEvaluacionesRespuestas.Single(c => c.Id == Id);
		}

		public DbQuery<ConcursosEvaluacionesRespuestas> ObtenerTodo()
		{
			return (DbQuery<ConcursosEvaluacionesRespuestas>)db.ConcursosEvaluacionesRespuestas;
		}

        //public ConcursosEvaluacionesRespuestas ObtenerRespuesta(int Id)
        //{
        //    return db.ConcursosEvaluacionesRespuestas.Single(c => c.Id == Id);
        //}

        public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.ConcursosEvaluacionesRespuestas
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

        public ConcursosEvaluacionesRespuestas ObtenerPorRespuesta(int inscription, int pregunta)
        {
            var res = (from x in db.ConcursosEvaluacionesRespuestas
                      where x.Pregunta == pregunta && x.InscripcionEvalacion == inscription
                      select x).FirstOrDefault();

            return res;
        }

        public DbQuery<ConcursosEvaluacionesRespuestasView> ObtenerParaGrilla()
		{
			var x = from c in db.ConcursosEvaluacionesRespuestas
					select new ConcursosEvaluacionesRespuestasView
					{
						 Id = c.Id,
						 //Inscripcion = c.Inscripcion,
						 Pregunta = c.Pregunta,
						 Respuesta = c.Respuesta,
						 FechaInicio = c.FechaInicio,
						 FechaFin = c.FechaFin,
						 RespuestaCorrecta = c.RespuestaCorrecta,
						 InscripcionEvalacion = c.InscripcionEvalacion,
					};
			return (DbQuery<ConcursosEvaluacionesRespuestasView>)x;
		}

		public void Guardar(ConcursosEvaluacionesRespuestas Objeto)
		{
			try
			{
				db.ConcursosEvaluacionesRespuestas.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ConcursosEvaluacionesRespuestas Objeto)
		{
			try
			{
				db.ConcursosEvaluacionesRespuestas.Attach(Objeto);
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
				ConcursosEvaluacionesRespuestas Objeto = this.ObtenerPorId(IdObjeto);
				db.ConcursosEvaluacionesRespuestas.Remove(Objeto);
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

        //public DbQuery<ConcursosEvaluacionesRespuestasViewT> JsonT(string term)
        //{
        //	var x = from c in db.ConcursosEvaluacionesRespuestas
        //			select new ConcursosEvaluacionesRespuestasViewT
        //			{
        //				 Id = c.Id,
        //				 Inscripcion = c.Inscripcion,
        //				 Pregunta = c.Pregunta,
        //				 Respuesta = c.Respuesta,
        //				 FechaInicio = c.FechaInicio,
        //				 FechaFin = c.FechaFin,
        //				 RespuestaCorrecta = c.RespuestaCorrecta,
        //				 InscripcionEvalacion = c.InscripcionEvalacion,
        //			};
        //	return (DbQuery<ConcursosEvaluacionesRespuestasViewT>)x;
        //}
        /*********************************************
		* Seccion Particular
		* *******************************************/

        public List<ConcursosEvaluacionesRespuestas> getRespuestasInscripto(int evaluacion, int inscripcion) {

            var res = (from r in db.ConcursosEvaluacionesRespuestas
                       join e in db.ConcursosInscripcionesEvaluaciones on r.InscripcionEvalacion equals e.Id
                       where e.Evaluacion == evaluacion && e.Inscripcion == inscripcion
                       select r).ToList();

            return res;
        }

	}
}
