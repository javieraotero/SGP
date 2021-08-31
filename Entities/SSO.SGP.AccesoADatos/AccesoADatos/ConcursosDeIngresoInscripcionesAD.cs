
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
	public partial class ConcursosDeIngresoInscripcionesAD
	{
		private BDEntities db = new BDEntities();

		public ConcursosDeIngresoInscripciones ObtenerPorId(int Id)
		{
			return db.ConcursosDeIngresoInscripciones.Single(c => c.Id == Id);
		}

        public ConcursosDeIngresoInscripciones ObtenerporDniYConcurso(long dni, int concurso)
        {
            return db.ConcursosDeIngresoInscripciones.Where(c => c.DNI == dni && c.ConcursoDeIngreso == concurso && c.FechaPreinscripcion.HasValue).FirstOrDefault();
        }

        public ConcursosDeIngresoInscripciones ObtenerPorToken(string token)
        {
            return db.ConcursosDeIngresoInscripciones.Single(c => c.Token == token);
        }

        public List<ConcursosDeIngresoInscripciones> ObtenerPorConcurso(int concurso)
        {
            return db.ConcursosDeIngresoInscripciones.Where(x => x.ConcursoDeIngreso == concurso && x.FechaPreinscripcion.HasValue).OrderBy(x => x.Id).ToList();
        }

        public List<ConcursosDeIngresoInscripciones> ObtenerPorConcursoPorLote(int concurso, int lote)
        {
            return db.ConcursosDeIngresoInscripciones.Where(x => x.ConcursoDeIngreso == concurso && x.FechaPreinscripcion.HasValue).OrderBy(x => x.Id).Skip(lote*300).Take(300).ToList();
        }

        public List<ConcursosDeIngresoInscripciones> ObtenerPorConcursoValidados(int concurso)
        {
            return db.ConcursosDeIngresoInscripciones.Where(x => x.ConcursoDeIngreso == concurso && x.FechaPreinscripcion.HasValue && x.FechaRecepcion.HasValue).ToList();
        }

        // 1 - ya está preinscripto
        // 2 - está registrado pero no realizó la preinscripción
        // 0 - no se registró 
        public int ValidarInscripcion(long dni, int concurso)
        {
            var i = from x in db.ConcursosDeIngresoInscripciones
                    where x.DNI == dni && x.ConcursoDeIngreso == concurso
                    select x;

            if (i.Count() >= 1)
            { 
                if (i.FirstOrDefault().FechaPreinscripcion.HasValue)
                    return 1;
                else
                    return 2;
            }
            else
            {
                var c = from x in db.ConcursosDeIngreso
                        where x.Id == concurso
                        select x;

                if (c.FirstOrDefault().FechaFin < DateTime.Now)
                    return 3;
                else
                    return 0;
            }

        }



        public DbQuery<ConcursosDeIngresoInscripciones> ObtenerTodo()
		{
			return (DbQuery<ConcursosDeIngresoInscripciones>)db.ConcursosDeIngresoInscripciones;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.ConcursosDeIngresoInscripciones
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<ConcursosDeIngresoInscripcionesView> ObtenerParaGrilla(int id)
		{
            var x = from c in db.ConcursosDeIngresoInscripciones
                    where c.FechaPreinscripcion.HasValue && c.ConcursoDeIngreso == id
                    select new ConcursosDeIngresoInscripcionesView
                    {
                        Id = c.Id,
                        FechaPreinscripcion = c.FechaPreinscripcion.Value,
                        Apellido = c.Apellido,
                        Nombres = c.Nombres,
                        DNI = c.DNI.Value,
                        Ciudad = c.Ciudad,
                        Provincia = c.Provincia,
                        Recibido = c.FechaRecepcion.HasValue ? "SI" : "NO"
					};
			return (DbQuery<ConcursosDeIngresoInscripcionesView>)x;
		}

		public void Guardar(ConcursosDeIngresoInscripciones Objeto)
		{
			try
			{
				db.ConcursosDeIngresoInscripciones.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ConcursosDeIngresoInscripciones Objeto)
		{
			try
			{
				db.ConcursosDeIngresoInscripciones.Attach(Objeto);
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
				ConcursosDeIngresoInscripciones Objeto = this.ObtenerPorId(IdObjeto);
				db.ConcursosDeIngresoInscripciones.Remove(Objeto);
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

		public DbQuery<ConcursosDeIngresoInscripcionesViewT> JsonT(string term)
		{
			var x = from c in db.ConcursosDeIngresoInscripciones
					select new ConcursosDeIngresoInscripcionesViewT
					{
						 Id = c.Id,
						 ConcursoDeIngreso = c.ConcursoDeIngreso,
						 FechaPreinscripcion = c.FechaPreinscripcion,
						 Apellido = c.Apellido,
						 Nombres = c.Nombres,
						 DNI = c.DNI,
						 FechaDeNacimiento = c.FechaDeNacimiento,
						 Domicilio = c.Domicilio,
						 Ciudad = c.Ciudad,
						 Provincia = c.Provincia,
						 Telefono = c.Telefono,
						 Email = c.Email,
						 TituloSecundario = c.TituloSecundario,
						 ExpedidoPor = c.ExpedidoPor,
						 FechaExpedido = c.FechaExpedido,
						 TituloUniversitario = c.TituloUniversitario,
						 TituloUniversitarioFecha = c.TituloUniversitarioFecha,
						 TituloUniversitarioExpedido = c.TituloUniversitarioExpedido,
						 AntecedentesAcademicos = c.AntecedentesAcademicos,
						 AntecedentesLaborales = c.AntecedentesLaborales,
						 FechaRecepcion = c.FechaRecepcion,
						 UsuarioRecepcion = c.UsuarioRecepcion,
						 Token = c.Token,
					};
			return (DbQuery<ConcursosDeIngresoInscripcionesViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
