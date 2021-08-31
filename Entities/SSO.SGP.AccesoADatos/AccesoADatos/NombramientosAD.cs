
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
	public partial class NombramientosAD
	{
		private BDEntities db = new BDEntities();

		public Nombramientos ObtenerPorId(int Id)
		{
			return db.Nombramientos.Single(c => c.Id == Id);
		}

		public DbQuery<Nombramientos> ObtenerTodo()
		{
			return (DbQuery<Nombramientos>)db.Nombramientos.Where(n=>!n.FechaEliminacion.HasValue);
		}

		public Agentes ObtenerAdministrador()
		{
			var n = (from x in db.Nombramientos
					 where x.Cargo == 7 && !x.FechaDeBaja.HasValue && !x.FechaEliminacion.HasValue
					 select x.Agentes
					).FirstOrDefault();

			return n;
		}

		public Agentes ObtenerProcurador()
		{
			var n = (from x in db.Nombramientos
					 where x.Cargo == 5 && !x.FechaDeBaja.HasValue && !x.FechaEliminacion.HasValue
					 select x.Agentes
					).FirstOrDefault();

			return n;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.Nombramientos
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<NombramientosView> ObtenerParaGrilla()
		{
			var x = from c in db.Nombramientos
					select new NombramientosView
					{
						 Id = c.Id,
						 Agente = c.Agente,
						 FechaDeAlta = c.FechaDeAlta,
						 FechaDeBaja = c.FechaDeBaja,
						 Motivo = c.Motivo,
						 Organismo = c.Organismo,
						 Cargo = c.Cargo,
						 SituacionRevista = c.SituacionRevista,
						 FechaFinContrato = c.FechaFinContrato,
						 FechaFinSustitucion = c.FechaFinSustitucion,
						 FechaRenuncia = c.FechaRenuncia,
						 FechaPaseAPlanta = c.FechaPaseAPlanta,
						 FechaUltimoAscenso = c.FechaUltimoAscenso,
					};
			return (DbQuery<NombramientosView>)x;
		}

		public void Guardar(Nombramientos Objeto)
		{
			try
			{
				db.Nombramientos.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(Nombramientos Objeto)
		{
			try
			{
				db.Nombramientos.Attach(Objeto);
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
				Nombramientos Objeto = this.ObtenerPorId(IdObjeto);
                Objeto.FechaEliminacion = DateTime.Now;
                db.Entry(Objeto).State = EntityState.Modified;
                db.SaveChanges();
                //db.Nombramientos.Remove(Objeto);
				//db.SaveChanges();
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

		public DbQuery<NombramientosViewT> JsonT(int agente)
		{
			var x = from c in db.Nombramientos
                    where c.Agente == agente
                    && !c.FechaEliminacion.HasValue
					select new NombramientosViewT
					{
						 Id = c.Id,
						 Agente = c.Agente,
						 FechaDeAlta = c.FechaDeAlta,
						 FechaDeBaja = c.FechaDeBaja,
                         FechaUltimoAscenso = c.FechaUltimoAscenso,
						 Organismo = c.Organismos.Descripcion,
                         SituacionRevista = c.SituacionRevista,
						 Cargo = c.Cargos.Descripcion,                         
					};
			return (DbQuery<NombramientosViewT>)x;
		}

        public NombramientosSueldosView getNombramiento(int agente)
        {
            var x = from c in db.Nombramientos
                    where c.Agente == agente
                    && !c.FechaEliminacion.HasValue
                    && c.FechaDeBaja == null
                    select new NombramientosSueldosView
                    {
                        Id = c.Id,
                        Agente = c.Agente,
                        FechaDeAlta = c.FechaDeAlta,
                        FechaDeBaja = c.FechaDeBaja,                       
                        Organismo = c.Organismo,
                        SituacionRevista = c.SituacionRevista,
                        Cargo = c.Cargo,
                        Id_Designacion = c.Designacion_Cesida,
                        Categoria_Cesida = c.Categoria_Cesida,
                        Ubicacion_Cesida = c.Ubicacion_Cesida,
                        Persona_Cesida = c.Persona_Cesida
                    };
            return (NombramientosSueldosView)x.FirstOrDefault();
        }

        /*********************************************
		* Seccion Particular
		* *******************************************/

        public int TotalPlantaPermanente() {         
            int total = (from x in db.Nombramientos
                         where x.SituacionRevista == "P"
                         && x.FechaDeBaja == null && x.FechaEliminacion == null
                         select x).Count();

            return total;
        }

        public int TotalContratado() {

            int total = (from x in db.Nombramientos
                         where x.SituacionRevista == "C"
                         && x.FechaDeBaja == null && x.FechaEliminacion == null
                         select x).Count();

            return total;        
        }

        public int TotalSustitutos()
        {

            int total = (from x in db.Nombramientos
                         where x.SituacionRevista == "S" 
                         && x.FechaDeBaja == null && x.FechaEliminacion == null
                         select x).Count();

            return total;
        }

        public int TotalEnLicencia()
        {

            int total = (from x in db.LicenciasAgente
                         where x.FechaDesde <= DateTime.Now
                         && x.FechaHasta >= DateTime.Now
                         select x.Agente).Distinct().Count();

            return total;
        }


	}
}
