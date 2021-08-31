
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
	public partial class EjecucionesPresupuestariasAD
	{
		private BDEntities db = new BDEntities();

		public EjecucionesPresupuestarias ObtenerPorId(int Id)
		{
			return db.EjecucionesPresupuestarias.Single(c => c.Id == Id);
		}

		public DbQuery<EjecucionesPresupuestarias> ObtenerTodo()
		{
			return (DbQuery<EjecucionesPresupuestarias>)db.EjecucionesPresupuestarias.Where(e=>!e.FechaElimina.HasValue);
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.EjecucionesPresupuestarias
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<EjecucionesPresupuestariasView> ObtenerParaGrilla()
		{
			var x = from c in db.EjecucionesPresupuestarias
                    where !c.FechaElimina.HasValue
					select new EjecucionesPresupuestariasView
					{
						 Id = c.Id,
                         Anio = c.Anio,
						 PartidaPresupuestaria = c.PartidaPresupuestarias.NumeroDePartida + " - " + c.PartidaPresupuestarias.Descripcion,
						 CreditoActual = c.Presupuestado.Value + c.ReestructuraMas.Value - c.ReestructuraMenos.Value,
						 CreditoDisponible = c.CreditoHabilitado - c.MontoPreventiva ,
						 CreditoHabilitado = c.CreditoHabilitado,
						 MontoPreventiva = c.MontoPreventiva,
						 MontoCompromiso = c.MontoCompromiso,
						 MontoOrdenadoAPagar = c.MontoOrdenadoAPagar,
					};
			return (DbQuery<EjecucionesPresupuestariasView>)x;
		}

        public DbQuery<EjecucionesPresupuestariasView> ObtenerParaGrillaPorAnio(int anio)
        {
            var x = from c in db.EjecucionesPresupuestarias
                    where c.Anio == anio && !c.FechaElimina.HasValue
                    select new EjecucionesPresupuestariasView
                    {
                        Id = c.Id,
                        Anio = c.Anio,
                        PartidaPresupuestaria = c.PartidaPresupuestarias.NumeroDePartida + " - " + c.PartidaPresupuestarias.Descripcion,
                        CreditoActual = c.CreditoActual,
                        CreditoDisponible = c.CreditoDisponible,
                        CreditoHabilitado = c.CreditoHabilitado,
                        MontoPreventiva = c.MontoPreventiva,
                        MontoCompromiso = c.MontoCompromiso,
                        MontoOrdenadoAPagar = c.MontoOrdenadoAPagar,
                    };
            return (DbQuery<EjecucionesPresupuestariasView>)x;
        }

        public DbQuery<EjecucionesPresupuestariasView> EjecucionesPorAnio(int anio)
        {
            var x = from c in db.EjecucionesPresupuestarias
                    where c.Anio == anio && !c.FechaElimina.HasValue
                    select new EjecucionesPresupuestariasView
                    {
                        Id = c.Id,
                        Anio = c.Anio,
                        PartidaPresupuestaria = c.PartidaPresupuestarias.NumeroDePartida + " - " + c.PartidaPresupuestarias.Descripcion,
                        CreditoActual = c.CreditoActual,
                        CreditoDisponible = c.CreditoDisponible,
                        CreditoHabilitado = c.CreditoHabilitado,
                        MontoPreventiva = c.MontoPreventiva,
                        MontoCompromiso = c.MontoCompromiso,
                        MontoOrdenadoAPagar = c.MontoOrdenadoAPagar,
                    };
            return (DbQuery<EjecucionesPresupuestariasView>)x;
        }

		public void Guardar(EjecucionesPresupuestarias Objeto)
		{
			try
			{
				db.EjecucionesPresupuestarias.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(EjecucionesPresupuestarias Objeto)
		{
			try
			{
				db.EjecucionesPresupuestarias.Attach(Objeto);
				db.Entry(Objeto).State = EntityState.Modified;
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Eliminar(int IdObjeto, int usuario)
		{
			try
			{
				EjecucionesPresupuestarias Objeto = this.ObtenerPorId(IdObjeto);
                Objeto.FechaElimina = DateTime.Now;
                Objeto.UsuarioElimina = usuario;
                db.EjecucionesPresupuestarias.Attach(Objeto);
                db.Entry(Objeto).State = EntityState.Modified;
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

		public DbQuery<EjecucionesPresupuestariasViewT> JsonT(string term)
		{
			var x = from c in db.EjecucionesPresupuestarias
                    where !c.FechaElimina.HasValue
					select new EjecucionesPresupuestariasViewT
					{
						 Id = c.Id,
						 Anio = c.Anio,
						 PartidaPresupuestaria = c.PartidaPresupuestaria,
						 Estado = c.Estado,
						 EstaBloqueada = c.EstaBloqueada,
						 CreditoActual = c.CreditoActual,
						 CreditoDisponible = c.CreditoDisponible,
						 CreditoHabilitado = c.CreditoHabilitado,
						 MontoPreventiva = c.MontoPreventiva,
						 MontoCompromiso = c.MontoCompromiso,
						 MontoOrdenadoAPagar = c.MontoOrdenadoAPagar,
						 PresupuestoSolicitado = c.PresupuestoSolicitado,
						 Presupuestado = c.Presupuestado,
						 ReestructuraMas = c.ReestructuraMas,
						 ReestructuraMenos = c.ReestructuraMenos,
						 Factibilidad = c.Factibilidad,
						 FactibilidadHabilitada = c.FactibilidadHabilitada,
						 ReservaMas = c.ReservaMas,
						 ReservaMenos = c.ReservaMenos,
					};
			return (DbQuery<EjecucionesPresupuestariasViewT>)x;
		}
        /*********************************************
		* Seccion Particular
		* *******************************************/

        public EjecucionesPresupuestarias ObtenerPorPartidaYAnio(int anio, int partida) {
            var e = (from x in db.EjecucionesPresupuestarias
                    where x.PartidaPresupuestaria == partida && x.Anio == anio
                    select x).FirstOrDefault();

            return e;
        }

        public List<string> CrearAnual(int anio, int unidad_de_organizacion) {

            List<string> errores = new List<string>();

            var partidas = (from x in db.PartidasPresupuestarias
                           where x.UnidadDeOrganizacion == unidad_de_organizacion && !x.FechaElimina.HasValue
                           select x).ToList();

            foreach (var p in partidas) {

                var ejecucion = (from x in db.EjecucionesPresupuestarias
                                where !x.FechaElimina.HasValue && (x.PartidaPresupuestaria == p.Id || x.PartidaPresupuestarias.NumeroDePartida.Equals(p.NumeroDePartida))
                                && x.Anio == anio
                                select x).Count();

                if (ejecucion > 0)
                {
                    errores.Add(String.Format("La partida {0} ya existe en el presupuesto {1}", p.Descripcion, anio));
                }
                else {

                    var e = new EjecucionesPresupuestarias()
                    {
                        PartidaPresupuestaria = p.Id,
                        Anio = anio,
                        CreditoActual = 0,
                        CreditoDisponible = 0,
                        CreditoHabilitado = 0,
                        MontoPreventiva = 0,
                        MontoCompromiso = 0,
                        MontoOrdenadoAPagar = 0,
                        EstaBloqueada = false,
                        Factibilidad = 0,
                        FactibilidadHabilitada = 0,
                        Presupuestado = 0,
                        ReestructuraMas = 0,
                        ReestructuraMenos = 0,
                        PresupuestoSolicitado = 0,
                        ReservaMas = 0,
                        ReservaMenos = 0,
                        Estado = 1,
                        MontoOrdenadoAPagarDF = 0,
                        ReservaNeta = 0,
                        CreditoPresupuestadoModificado = 0,
                        SaldoPreventiva = 0
                    };

                    try
                    {
                        this.Guardar(e);
                    }
                    catch (Exception ex) {
                        errores.Add(String.Format("Error al guardar la partida {0}. Mensaje del servidor. {1}", p.Descripcion, ex.Message));
                    }
                }


            }
            return errores;
        }


	}
}
