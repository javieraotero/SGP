
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
	public partial class ConcursosInscripcionesEvaluacionesAD
	{
		private BDEntities db = new BDEntities();

		public ConcursosInscripcionesEvaluaciones ObtenerPorId(int Id)
		{
			return db.ConcursosInscripcionesEvaluaciones.Single(c => c.Id == Id);
		}

        public ConcursosInscripcionesEvaluaciones ObtenerPorDni(long dni, int evaluacion)
        {
            var res = (from x in db.ConcursosInscripcionesEvaluaciones
                       where x.DNI == dni && x.Evaluacion == evaluacion
                       select x).FirstOrDefault();

            return res;
        }

        public ConcursosInscripcionesEvaluaciones ObtenerPorEvaluacionYDni(int evaluacion, long dni)
        {
            var res = (from x in db.ConcursosInscripcionesEvaluaciones
                       where x.DNI == dni && x.Evaluacion == evaluacion
                       select x).FirstOrDefault();

            return res;
        }

        public ConcursosInscripcionesEvaluaciones ObtenerPorMail(string mail)
        {
            var res = (from x in db.ConcursosInscripcionesEvaluaciones
                       where x.Email.ToLower() == mail.ToLower()
                       select x).FirstOrDefault();

            return res;
        }

        public ConcursosInscripcionesEvaluaciones ObtenerPorMailYEvaluacion(string mail, int evaluacion)
        {
            var res = (from x in db.ConcursosInscripcionesEvaluaciones
                       where x.Email.ToLower() == mail.ToLower() && x.Evaluacion == evaluacion
                       select x).FirstOrDefault();

            return res;
        }

        public List<ConcursosInscripcionesEvaluaciones> ObtenerPendientes(int evaluacion)
        {
            var res = (from x in db.ConcursosInscripcionesEvaluaciones
                       where x.Evaluacion == evaluacion && !x.FechaConfirmacion.HasValue
                       select x).ToList();

            return res;
        }

        public DbQuery<ConcursosInscripcionesEvaluaciones> ObtenerTodo()
		{
			return (DbQuery<ConcursosInscripcionesEvaluaciones>)db.ConcursosInscripcionesEvaluaciones;
		}


		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.ConcursosInscripcionesEvaluaciones
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<ConcursosInscripcionesEvaluacionesView> ObtenerParaGrilla()
		{
			var x = from c in db.ConcursosInscripcionesEvaluaciones
					select new ConcursosInscripcionesEvaluacionesView
					{
						 Id = c.Id,
						 Evaluacion = c.Evaluacion,
						 DNI = c.DNI,
						 Email = c.Email,
						 CodigoDNI = c.CodigoDNI,
						 FechaInicio = c.FechaInicio,
						 FechaEnvio = c.FechaEnvio,
						 ConfirmacionEmail = c.ConfirmacionEmail,
						 FechaConfirmacion = c.FechaConfirmacion,
						 Token = c.Token,
					};
			return (DbQuery<ConcursosInscripcionesEvaluacionesView>)x;
		}

		public void Guardar(ConcursosInscripcionesEvaluaciones Objeto)
		{
			try
			{
				db.ConcursosInscripcionesEvaluaciones.Add(Objeto);
				db.SaveChanges();

                var cantidad = db.ConcursosDeIngresoEvaluaciones.Where(x => x.Id == Objeto.Evaluacion).FirstOrDefault().Cantidad_Preguntas ?? 10;

                var preguntas = (from x in db.ConcursosDeIngresoPreguntas
                                 where x.Evaluacion == Objeto.Evaluacion && x.Activa                                 
                                 // orderby x.Orden ascending
                                 select x
                       ).ToList();

                var selecccion_preguntas = preguntas.OrderBy(x => Guid.NewGuid()).Take(cantidad).ToList();

                foreach (var s in selecccion_preguntas)
                {

                    var sp = new ConcursosDeIngresoPreguntasInscripto
                    {
                        Pregunta = s.Id,
                        InscripcionEvaluacion = Objeto.Id
					};

                    db.ConcursosDeIngresoPreguntasInscripto.Add(sp);

                }
				db.SaveChanges();

			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ConcursosInscripcionesEvaluaciones Objeto)
		{
			try
			{
				db.ConcursosInscripcionesEvaluaciones.Attach(Objeto);
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
				ConcursosInscripcionesEvaluaciones Objeto = this.ObtenerPorId(IdObjeto);
				db.ConcursosInscripcionesEvaluaciones.Remove(Objeto);
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

		//public DbQuery<ConcursosInscripcionesEvaluacionesViewT> JsonT(string term)
		//{
		//	var x = from c in db.ConcursosInscripcionesEvaluaciones
		//			select new ConcursosInscripcionesEvaluacionesViewT
		//			{
		//				 Id = c.Id,
		//				 Evaluacion = c.Evaluacion,
		//				 DNI = c.DNI,
		//				 Email = c.Email,
		//				 CodigoDNI = c.CodigoDNI,
		//				 FechaInicio = c.FechaInicio,
		//				 FechaEnvio = c.FechaEnvio,
		//				 ConfirmacionEmail = c.ConfirmacionEmail,
		//				 FechaConfirmacion = c.FechaConfirmacion,
		//				 Token = c.Token,
		//			};
		//	return (DbQuery<ConcursosInscripcionesEvaluacionesViewT>)x;
		//}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
