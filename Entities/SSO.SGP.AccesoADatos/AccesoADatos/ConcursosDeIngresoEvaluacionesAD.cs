
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
	public partial class ConcursosDeIngresoEvaluacionesAD
	{
		private BDEntities db = new BDEntities();

		public ConcursosDeIngresoEvaluaciones ObtenerPorId(int Id)
		{
			return db.ConcursosDeIngresoEvaluaciones.Single(c => c.Id == Id);
		}

        public List<ConcursosDeIngresoEvaluaciones> ObtenerPorEvaluacion(int id)
        {
            return db.ConcursosDeIngresoEvaluaciones.Where(x => x.Concurso == id && x.Activa).OrderByDescending(x => x.FechaInicio).ToList();
        }

        public List<PreguntasCustom> ObtenerPreguntas(int evaluacion)
        {
            var res = (from x in db.ConcursosDeIngresoPreguntas
                      where x.Evaluacion == evaluacion 
                      && x.Activa
                      orderby x.Orden ascending
                      select new PreguntasCustom
                      {
                          id = x.Id,
                          pregunta = x.Pregunta,
                          activa = x.Activa,
                          orden = x.Orden,
                          respuestas = (from p in db.ConcursosDeIngresoRespuestas
                                        where p.Pregunta == x.Id
                                        && p.Activa
                                        select new RespuestasCustom {
                                            id = p.Id,
                                            respuesta = p.Respuesta,
                                            activa = p.Activa,
                                            es_correcta = p.EsCorrecta
                                        })
                      }).ToList();

            return res;
        }

		public List<PreguntasCustom> ObtenerPreguntas2(int evaluacion, int inscription)
		{
			var res = (from x in db.ConcursosDeIngresoPreguntas
					   join y in db.ConcursosDeIngresoPreguntasInscripto on x.Id equals y.Pregunta
					   where x.Evaluacion == evaluacion && y.InscripcionEvaluacion == inscription
					   && x.Activa
					   orderby x.Id ascending
					   select new PreguntasCustom
					   {
						   id = x.Id,
						   pregunta = x.Pregunta,
						   activa = x.Activa,
						   orden = x.Id,
						   respuestas = (from p in db.ConcursosDeIngresoRespuestas
										 where p.Pregunta == x.Id
										 && p.Activa
										 select new RespuestasCustom
										 {
											 id = p.Id,
											 respuesta = p.Respuesta,
											 activa = p.Activa,
											 es_correcta = p.EsCorrecta
										 })
					   }).ToList();

			return res;
		}

		public List<CustomResultadoEvaluacion> ObtenerResultados(int evaluacion)
        {
            var res = (from x in db.ConcursosInscripcionesEvaluaciones
                       join i in db.ConcursosDeIngresoInscripciones on x.Inscripcion equals i.Id
                       where x.Evaluacion == evaluacion
                       select new CustomResultadoEvaluacion
                       {
                           id = x.Id,
                           nombre = i.Apellido + ", " + i.Nombres,
                           dni = i.DNI,
                           resultado = x.Porcentaje
                       }).OrderBy(x => x.nombre).ToList();

            return res;
        }

        public List<RespuestasInscripto> ObtenerRespuestasInscripto(int inscripcion)
        {
            var res = (from x in db.ConcursosEvaluacionesRespuestas
                       where x.InscripcionEvalacion == inscripcion                       
                       select new RespuestasInscripto
                       {
                           id = x.Id,
                           pregunta = x.Pregunta,
                           respuesta = x.Respuesta
                       }).ToList();

            return res;
        }



        public DbQuery<ConcursosDeIngresoEvaluaciones> ObtenerTodo()
		{
			return (DbQuery<ConcursosDeIngresoEvaluaciones>)db.ConcursosDeIngresoEvaluaciones;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.ConcursosDeIngresoEvaluaciones
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<ConcursosDeIngresoEvaluacionesView> ObtenerParaGrilla()
		{
			var x = from c in db.ConcursosDeIngresoEvaluaciones
					select new ConcursosDeIngresoEvaluacionesView
					{
						 Id = c.Id,
						 Concurso = c.Concurso,
						 Descripcion = c.Descripcion,
						 FechaInicio = c.FechaInicio,
						 FechaFin = c.FechaFin,
					};
			return (DbQuery<ConcursosDeIngresoEvaluacionesView>)x;
		}

		public void Guardar(ConcursosDeIngresoEvaluaciones Objeto)
		{
			try
			{
				db.ConcursosDeIngresoEvaluaciones.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ConcursosDeIngresoEvaluaciones Objeto)
		{
			try
			{
				db.ConcursosDeIngresoEvaluaciones.Attach(Objeto);
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
				ConcursosDeIngresoEvaluaciones Objeto = this.ObtenerPorId(IdObjeto);
				db.ConcursosDeIngresoEvaluaciones.Remove(Objeto);
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

		//public DbQuery<ConcursosDeIngresoEvaluacionesViewT> JsonT(string term)
		//{
		//	var x = from c in db.ConcursosDeIngresoEvaluaciones
		//			select new ConcursosDeIngresoEvaluacionesViewT
		//			{
		//				 Id = c.Id,
		//				 Concurso = c.Concurso,
		//				 Descripcion = c.Descripcion,
		//				 FechaInicio = c.FechaInicio,
		//				 FechaFin = c.FechaFin,
		//			};
		//	return (DbQuery<ConcursosDeIngresoEvaluacionesViewT>)x;
		//}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
