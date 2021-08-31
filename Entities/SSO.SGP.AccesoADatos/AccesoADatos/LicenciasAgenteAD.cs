
using System;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Data.Objects.SqlClient;
using SSO.SGP.EntidadesDeNegocio;
using SSO.SGP.EntidadesDeNegocio.Vistas;
using Syncrosoft.Framework.Utils.Logs;
using System.Data.Objects;
using System.Collections.Generic;
using SSO.SGP.EntidadesDeNegocio.Results;

namespace SSO.SGP.AccesoADatos
{
	/// <summary>
	/// Acceso a Datos Generada por el Generador de codigo.
	/// </summary>
	public partial class LicenciasAgenteAD
	{
		private BDEntities db = new BDEntities();

		public LicenciasAgente ObtenerPorId(int Id)
		{
			return db.LicenciasAgente.Single(c => c.Id == Id);
		}

        public LicenciasAgente ObtenerPorToken(string token)
        {
            return db.LicenciasAgente.Single(c => c.Token == token);
        }

        public DbQuery<LicenciasAgente> ObtenerTodo()
		{
			return (DbQuery<LicenciasAgente>)db.LicenciasAgente;
		}

        public DbQuery<LicenciasAgente> SinFechaDeAlta()
        {
            var res = from x in db.LicenciasAgente
                      where !x.FechaAlta.HasValue && x.AgenteRRHH.HasValue
                      select x;

            return (DbQuery<LicenciasAgente>)res;
        }

        public List<LicenciasAgente> ObtenerDenegadas(int agente)
        {
            var res = (from x in db.LicenciasAgente
                      where x.AgenteRRHH == agente
                      && x.Estado == "DE"
                      orderby x.FechaDesde descending
                      select x).Take(3).ToList();
            return (List<LicenciasAgente>)res;
        }

        public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.LicenciasAgente
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<LicenciasAgenteView> ObtenerParaGrilla()
		{
			var x = from c in db.LicenciasAgente
                    where !c.FechaEliminacion.HasValue
					select new LicenciasAgenteView
					{
						 Id = c.Id,
						 Agente = c.Agente,
						 FechaDesde = c.FechaDesde,
						 FechaHasta = c.FechaHasta,
						 Licencia = c.Licencia,
						 Subrogante = c.Subrogante,
						 Activa = c.Activa,
						 FechaAlta = c.FechaAlta,
						 UsuarioAlta = c.UsuarioAlta,
						 FechaModificacion = c.FechaModificacion,
						 UsuarioModifica = c.UsuarioModifica,
						 FechaEliminacion = c.FechaEliminacion,
						 UsuarioElimina = c.UsuarioElimina,
						 AgenteRRHH = c.AgenteRRHH,
						 Observaciones = c.Observaciones,
					};
			return (DbQuery<LicenciasAgenteView>)x;
		}

        public DbQuery<LicenciasAgenteProcesadasView> ObtenerLicenciasProcesadas(int organismo, int excluir)
        {
            var hoy = DateTime.Now.Date;

            var c = (from x in db.LicenciasAgente
                     join h in db.LicenciasAgentesAprobaciones on x.Id equals h.Licencia
                    where
                    !x.SinEfecto 
                    && (h.AgenteAprueba == excluir || x.AgenteAprobada == excluir)
                    && ((x.SubroganteRRHH.HasValue && x.SubroganteAprobadaFecha.HasValue) || (!x.SubroganteRRHH.HasValue))
                    
                    //((organismo == (int)eOrganismos.DGA && x.Nombramientos.Organismos.UnidadOrganizacionRRHH.Value != 2 && x.Nombramientos.Cargos.Grupo == 1) || (x.Nombramientos.Organismo == organismo))
                    //&& x.FechaAprobada.HasValue && x.SolicitadaPorApp && x.AgenteRRHH != excluir
                   
                    //(x.AgenteAprobada == excluir || 
                    //    (db.LicenciasAgentesAprobaciones.Any(l=>l.FechaAprobado.HasValue && l.AgenteAprueba == excluir))
                    //)
                  
                     
                     select new LicenciasAgenteProcesadasView
                    {
                       Id = x.Id,
                       Agente = x.AgenteRRHHs.Personas.Apellidos + ", " + x.AgenteRRHHs.Personas.Nombres,
                       FechaAlta = x.FechaAlta.Value,
                       FechaDesde = x.FechaDesde,
                       FechaHasta = x.FechaHasta.Value,
                       Aprobado = x.Aprobada ? "Si" : "No",
                        Dias = SqlFunctions.DateDiff("day", x.FechaDesde, x.FechaHasta.Value).Value + 1,
                        FechaAprobacion = x.FechaAprobada,
                       Licencia = x.Licencias.Descripcion,
                       Observaciones = x.Observaciones,
                       hide_Token = x.Token                       
                    }).Distinct();
            return (DbQuery<LicenciasAgenteProcesadasView>)c;
        }

        public DbQuery<LicenciasAgenteProcesadasView> ObtenerLicenciasProcesadasAgente(int agente)
        {
            var c = from x in db.LicenciasAgente
                    where x.AgenteRRHH == agente
                    && x.FechaAprobada.HasValue && x.SolicitadaPorApp && !x.FechaEliminacion.HasValue && !x.SinEfecto
                    select new LicenciasAgenteProcesadasView
                    {
                        Id = x.Id,
                        Agente = x.AgenteRRHHs.Personas.Apellidos + ", " + x.AgenteRRHHs.Personas.Nombres,
                        FechaAlta = x.FechaAlta.Value,
                        FechaDesde = x.FechaDesde,
                        FechaHasta = x.FechaHasta.Value,
                        Aprobado = x.Aprobada ? "Si" : "No",
                        Dias = SqlFunctions.DateDiff("day", x.FechaDesde, x.FechaHasta.Value).Value + 1,
                        FechaAprobacion = x.FechaAprobada.Value,
                        Licencia = x.Licencias.Descripcion,
                        Observaciones = x.Observaciones,
                        hide_Token = x.Token
                    };
            return (DbQuery<LicenciasAgenteProcesadasView>)c;
        }

        public DbQuery<LicenciasAgentePorAprobarView> ObtenerLicenciasPendientesAprobar(int organismo)
        {
            var c = from x in db.LicenciasAgente
                    where ((organismo == (int)eOrganismos.DGA && x.Nombramientos.Organismos.UnidadOrganizacionRRHH.Value != 2 && x.Nombramientos.Cargos.Grupo == 1) || (x.Nombramientos.Organismo == organismo && x.Nombramientos.Cargos.Grupo != 1))
                    && x.FechaAprobada == null && x.SolicitadaPorApp && EntityFunctions.AddDays(x.FechaAlta.Value, 15) >= DateTime.Now
                    select new LicenciasAgentePorAprobarView
                    {
                        Id = x.Id,
                        Agente = x.AgenteRRHHs.Personas.Apellidos + ", " + x.AgenteRRHHs.Personas.Nombres,
                        FechaAlta = x.FechaAlta.Value,
                        FechaDesde = x.FechaDesde,
                        FechaHasta = x.FechaHasta,
                        Dias = SqlFunctions.DateDiff("day", x.FechaDesde, x.FechaHasta.Value).Value + 1,
                        Licencia = x.Licencias.Descripcion,
                        Observaciones = x.Observaciones,
                        hide_Token = x.Token
                    };
            return (DbQuery<LicenciasAgentePorAprobarView>)c;
        }

        public DbQuery<LicenciasAgentePorAprobarView> ObtenerLicenciasPendientesAprobar2(int agente)
        {
            var c = from x in db.LicenciasAgente
                    where (x.AgenteAprobada == agente && !db.LicenciasAgentesAprobaciones.Any(l=>l.AgenteAprueba == agente && l.FechaAprobado.HasValue)
                     || (db.LicenciasAgentesAprobaciones.Any(l=>l.Licencia == x.Id && !l.FechaAprobado.HasValue && l.AgenteAprueba == agente)))
                    && x.FechaAprobada == null && x.SolicitadaPorApp && EntityFunctions.AddDays(x.FechaAlta.Value, 14) >= DateTime.Now && x.AgenteRRHH != agente 
                    && ((x.SubroganteRRHH.HasValue && x.SubroganteAprobadaFecha.HasValue) || (!x.SubroganteRRHH.HasValue))
                    select new LicenciasAgentePorAprobarView
                    {
                        Id = x.Id,
                        Agente = x.AgenteRRHHs.Personas.Apellidos + ", " + x.AgenteRRHHs.Personas.Nombres,
                        FechaAlta = x.FechaAlta.Value,
                        FechaDesde = x.FechaDesde,
                        FechaHasta = x.FechaHasta,
                        Dias = SqlFunctions.DateDiff("day", x.FechaDesde, x.FechaHasta.Value).Value + 1,
                        Licencia = x.Licencias.Descripcion,
                        Observaciones = x.Observaciones,
                        hide_Token = x.Token,
                        Organismo = x.AgenteRRHHs.Nombramientos.Where(z=>!z.FechaDeBaja.HasValue && !z.FechaEliminacion.HasValue).FirstOrDefault().Organismos.Descripcion,
                        Cargo = x.AgenteRRHHs.Nombramientos.Where(z => !z.FechaDeBaja.HasValue && !z.FechaEliminacion.HasValue).FirstOrDefault().Cargos.Descripcion
                    };
            return (DbQuery<LicenciasAgentePorAprobarView>)c;
        }

        public DbQuery<LicenciasAgentePorAprobarReconocimientoView> ObtenerLicenciasPendientesReconocimiento()
        {
            var c = from x in db.LicenciasAgente
                    where x.SolicitadaPorApp && x.ApruebaReconocimiento && !x.FechaEliminacion.HasValue && !x.SinEfecto
                    select new LicenciasAgentePorAprobarReconocimientoView
                    {
                        Id = x.Id,
                        Agente = x.AgenteRRHHs.Personas.Apellidos + ", " + x.AgenteRRHHs.Personas.Nombres,
                        FechaAlta = x.FechaAlta.Value,
                        FechaDesde = x.FechaDesde,
                        FechaHasta = x.FechaHasta,
                        Dias = SqlFunctions.DateDiff("day", x.FechaDesde, x.FechaHasta.Value).Value + 1,
                        Licencia = x.Licencias.Descripcion,
                        Observaciones = x.Observaciones,
                        hide_Token = x.Token,
                        Organismo = x.AgenteRRHHs.Nombramientos.Where(z => !z.FechaDeBaja.HasValue && !z.FechaEliminacion.HasValue).FirstOrDefault().Organismos.Descripcion,
                        Cargo = x.AgenteRRHHs.Nombramientos.Where(z => !z.FechaDeBaja.HasValue && !z.FechaEliminacion.HasValue).FirstOrDefault().Cargos.Descripcion
                    };
            return (DbQuery<LicenciasAgentePorAprobarReconocimientoView>)c;
        }

        public DbQuery<LicenciasAgentePorAprobarView> ObtenerLicenciasPendientesAprobarAgente(int agente)
        {
            var c = from x in db.LicenciasAgente
                    where x.AgenteRRHH == agente
                    && x.FechaAprobada == null && x.SolicitadaPorApp && EntityFunctions.AddDays(x.FechaHasta.Value, 10) >= DateTime.Now
                    select new LicenciasAgentePorAprobarView
                    {
                        Id = x.Id,
                        Agente = x.AgenteRRHHs.Personas.Apellidos + ", " + x.AgenteRRHHs.Personas.Nombres,
                        FechaAlta = x.FechaAlta.Value,
                        FechaDesde = x.FechaDesde,
                        FechaHasta = x.FechaHasta,
                        Dias = SqlFunctions.DateDiff("day", x.FechaDesde, x.FechaHasta.Value).Value + 1,
                        Licencia = x.Licencias.Descripcion,
                        Observaciones = x.Observaciones,
                        hide_Token = x.Token
                    };
            return (DbQuery<LicenciasAgentePorAprobarView>)c;
        }

        public DbQuery<LicenciasAgentePorAprobarView> ObtenerLicenciasPendientesAprobarTodos()
        {
            var c = from x in db.LicenciasAgente
                    where 
                    //x.AgenteRRHH == agente
                    x.FechaAprobada == null && x.SolicitadaPorApp && EntityFunctions.AddDays(x.FechaDesde, 14) >= DateTime.Now
                    select new LicenciasAgentePorAprobarView
                    {
                        Id = x.Id,
                        Agente = x.AgenteRRHHs.Personas.Apellidos + ", " + x.AgenteRRHHs.Personas.Nombres,
                        FechaAlta = x.FechaAlta.Value,
                        FechaDesde = x.FechaDesde,
                        FechaHasta = x.FechaHasta,
                        Dias = SqlFunctions.DateDiff("day", x.FechaDesde, x.FechaHasta.Value).Value + 1,
                        Licencia = x.Licencias.Descripcion,
                        Observaciones = x.Observaciones,
                        hide_Token = x.Token
                    };
            return (DbQuery<LicenciasAgentePorAprobarView>)c;
        }

        public DbQuery<LicenciasAgentePorAprobarView> ObtenerLicenciasPendientesSubrogar(int agente)
        {
            var c = from x in db.LicenciasAgente
                    where                     
                    (x.SubroganteRRHH == agente && !x.SubroganteAprobada && !x.SubroganteAprobadaFecha.HasValue)
                    && EntityFunctions.AddDays(x.FechaAlta.Value, 14) >= DateTime.Now
                    select new LicenciasAgentePorAprobarView
                    {
                        Id = x.Id,
                        Agente = x.AgenteRRHHs.Personas.Apellidos + ", " + x.AgenteRRHHs.Personas.Nombres,
                        FechaAlta = x.FechaAlta.Value,
                        FechaDesde = x.FechaDesde,
                        FechaHasta = x.FechaHasta,
                        Dias = SqlFunctions.DateDiff("day", x.FechaDesde, x.FechaHasta.Value).Value + 1,
                        Licencia = x.Licencias.Descripcion,
                        Observaciones = x.Observaciones,
                        hide_Token = x.Token
                    };
            return (DbQuery<LicenciasAgentePorAprobarView>)c;
        }

        public DbQuery<SubroganciasAceptadasView> ObtenerHistorialSubrogancias(int agente)
        {
            var c = from x in db.LicenciasAgente
                    where
                    (x.SubroganteRRHH == agente && x.SubroganteAprobada)
                    //&& EntityFunctions.AddDays(x.FechaAlta.Value, 5) >= DateTime.Now
                    select new SubroganciasAceptadasView
                    {
                        Id = x.Id,
                        Agente = x.AgenteRRHHs.Personas.Apellidos + ", " + x.AgenteRRHHs.Personas.Nombres,
                        Organismo = x.Nombramientos.Organismos.Descripcion,
                        FechaDesde = x.FechaDesde,
                        FechaHasta = x.FechaHasta.Value,         
                        Estado = x.FechaAprobada.HasValue && x.Aprobada ? "Aprobada" : (x.FechaAprobada.HasValue && !x.Aprobada ? "Rechazada" : "Pendiente")
                    };
            return (DbQuery<SubroganciasAceptadasView>)c;
        }

        public DbQuery<LicenciasAgenteView> ObtenerParaGrillaSinVistoRRHH()
        {
            var x = from c in db.LicenciasAgente
                    where !c.FechaEliminacion.HasValue
                    && c.Aprobada && c.SolicitadaPorApp
                    select new LicenciasAgenteView
                    {
                        Id = c.Id,
                        Agente = c.Agente,
                        FechaDesde = c.FechaDesde,
                        FechaHasta = c.FechaHasta,
                        Licencia = c.Licencia,
                        Subrogante = c.Subrogante,
                        Activa = c.Activa,
                        FechaAlta = c.FechaAlta,
                        UsuarioAlta = c.UsuarioAlta,
                        FechaModificacion = c.FechaModificacion,
                        UsuarioModifica = c.UsuarioModifica,
                        FechaEliminacion = c.FechaEliminacion,
                        UsuarioElimina = c.UsuarioElimina,
                        AgenteRRHH = c.AgenteRRHH,
                        Observaciones = c.Observaciones,
                    };
            return (DbQuery<LicenciasAgenteView>)x;
        }

        public void Guardar(LicenciasAgente Objeto)
		{
			try
			{
				db.LicenciasAgente.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

        public void GuardarAprobacion(LicenciasAgentesAprobaciones Objeto)
        {
            try
            {
                db.LicenciasAgentesAprobaciones.Add(Objeto);
                db.SaveChanges();
            }
            catch (Exception msg)
            {
                Logger.GrabarExcepcion(msg, false);
                throw new Exception(msg.Message);
            }
        }


        public void ActualizarAprobacion(LicenciasAgentesAprobaciones Objeto)
        {
            try
            {
                db.LicenciasAgentesAprobaciones.Attach(Objeto);
                db.Entry(Objeto).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception msg)
            {
                Logger.GrabarExcepcion(msg, false);
                throw new Exception(msg.Message);
            }
        }

        public void Actualizar(LicenciasAgente Objeto)
		{
			try
			{
				db.LicenciasAgente.Attach(Objeto);
				db.Entry(Objeto).State = EntityState.Modified;
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Eliminar(int IdObjeto, int Usuario)
		{
			try
			{
				LicenciasAgente Objeto = this.ObtenerPorId(IdObjeto);

                if (!Objeto.Nombramientos.SituacionRevista.ToUpper().Equals("S"))
                {
                    if (Objeto.Licencias.CodigoRRHH == 1)
                    {
                        int dias = (int)((Objeto.FechaHasta.Value - Objeto.FechaDesde).TotalDays) + 1;

                        var saldos = db.LicenciasOrdinariasIniciales.Where(s => s.Agente == Objeto.AgenteRRHH && s.Saldo > 0).First();

                        if (saldos != null)
                        {
                            saldos.Saldo = saldos.Saldo + dias;

                            if (!Objeto.FechaEliminacion.HasValue)
                            {
                                db.Entry(saldos).State = EntityState.Modified;
                                db.SaveChanges();
                            }
                        }
                    }
                }
                
                Objeto.FechaEliminacion = DateTime.Now;
                Objeto.UsuarioElimina = Usuario;
                db.Entry(Objeto).State = EntityState.Modified;
                //db.LicenciasAgente.Remove(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

        public void EliminarDeBasse(int IdObjeto)
        {
            try
            {
                LicenciasAgente Objeto = this.ObtenerPorId(IdObjeto);
                db.LicenciasAgente.Remove(Objeto);
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

        public bool AgenteConLicencia(int agente, DateTime desde, DateTime hasta) {

            var res = (from x in db.LicenciasAgente
                       where x.AgenteRRHH == agente && (desde < x.FechaHasta && hasta > x.FechaDesde)
                       && !x.FechaEliminacion.HasValue && !x.SinEfecto
                       select x).Count();


            return res > 0;

        }

		public DbQuery<LicenciasAgenteViewT> JsonT(int agente, int licencia, DateTime? fechadesde, DateTime? fechahasta)
		{
			var x = from c in db.LicenciasAgente
                    where c.AgenteRRHH != null && c.AgenteRRHH == agente
                    && !c.FechaEliminacion.HasValue && c.Aprobada
                    && ((licencia > 0 && licencia == c.Licencia) || (licencia == 0))
                    && ((fechadesde.HasValue && c.FechaHasta >= fechadesde.Value) || (!fechadesde.HasValue))
                    && ((fechahasta.HasValue && c.FechaDesde <= fechahasta.Value) || (!fechahasta.HasValue))
                    orderby c.FechaDesde ascending
					select new LicenciasAgenteViewT
					{
						 Id = c.Id,
						 FechaDesde = c.FechaDesde,
						 FechaHasta = c.FechaHasta,
                         FechaAlta = c.FechaAlta.Value,
                         Dias = SqlFunctions.DateDiff("day", c.FechaDesde, c.FechaHasta.Value).Value + 1,
						 Licencia = c.Licencias.Descripcion,
 						 Observaciones = c.Observaciones
					};
			return (DbQuery<LicenciasAgenteViewT>)x;
		}

        public DbQuery<LicenciasAgenteViewT> JsonTPendiente(int agente, DateTime? fechadesde, DateTime? fechahasta)
        {
            var x = from c in db.LicenciasAgente
                    where c.AgenteRRHH != null && c.AgenteRRHH == agente
                    && !c.FechaEliminacion.HasValue
                    //&& ((licencia > 0 && licencia == c.Licencia) || (licencia == 0))
                    && ((fechadesde.HasValue && c.FechaHasta >= fechadesde.Value) || (!fechadesde.HasValue))
                    && ((fechahasta.HasValue && c.FechaDesde <= fechahasta.Value) || (!fechahasta.HasValue))
                    && c.SolicitadaPorApp && !c.Aprobada
                    orderby c.FechaDesde ascending
                    select new LicenciasAgenteViewT
                    {
                        Id = c.Id,
                        FechaDesde = c.FechaDesde,
                        FechaHasta = c.FechaHasta,
                        FechaAlta = c.FechaAlta.Value,
                        Dias = SqlFunctions.DateDiff("day", c.FechaDesde, c.FechaHasta.Value).Value + 1,
                        Licencia = c.Licencias.Descripcion,
                        Observaciones = c.Observaciones
                    };
            return (DbQuery<LicenciasAgenteViewT>)x;
        }

        public DbQuery<LicenciasAgenteViewT> JsonT(CustomConsultaLicencias consulta)
        {
            var x = from c in db.LicenciasAgente
                    where c.AgenteRRHH == consulta.Agente && !c.FechaEliminacion.HasValue &&
                    ((consulta.FechaDesde.HasValue && c.FechaDesde >= consulta.FechaDesde.Value) || (!consulta.FechaDesde.HasValue)) &&
                    ((consulta.FechaHasta.HasValue && c.FechaHasta >= consulta.FechaHasta.Value) || (!consulta.FechaHasta.HasValue)) &&
                    ((consulta.Licencia > 0 && c.Licencia == consulta.Licencia) || (consulta.Licencia == 0))
                    orderby c.FechaDesde descending
                    select new LicenciasAgenteViewT
                    {
                        Id = c.Id,
                        FechaDesde = c.FechaDesde,
                        FechaAlta = c.FechaAlta.Value,
                        Dias = SqlFunctions.DateDiff( "day", c.FechaDesde, c.FechaHasta.Value).Value + 1,
                        FechaHasta = c.FechaHasta,
                        Licencia = c.Licencias.Descripcion,
                        Observaciones = c.Observaciones
                    };
            return (DbQuery<LicenciasAgenteViewT>)x;
        }

        public DbQuery<LicenciasAgenteViewT> DiasDeLicenciaDeAgente(int agente, int licencia)
        {
            var x = (from c in db.LicenciasAgente
                     where c.AgenteRRHH == agente && !c.FechaEliminacion.HasValue &&
                     //((anio > 0 && c.FechaDesde.Year == anio) || (anio == 0))
                     c.Licencia == licencia
                     select new LicenciasAgenteViewT
                     {
                         Id = 0,
                         Licencia = "",
                         FechaDesde = c.FechaDesde,
                         FechaHasta = c.FechaHasta
                     });

            return (DbQuery<LicenciasAgenteViewT>) x;
        }


        public string ControlarInicioDeLicencia(int Id, int Agente, int Licencia, DateTime Desde, DateTime Hasta)
        {

            string resultado = db.ControlarLicencia(Id, Agente, Licencia, Desde, Hasta);
            return resultado;

        }

        public string ExisteSolicitud(int Id, int Agente, int Licencia, DateTime Desde, DateTime Hasta)
        {

            var res = from x in db.LicenciasAgente
                      where x.FechaDesde == Desde
                        && x.FechaHasta == Hasta
                        && x.AgenteRRHH == Agente
                        && x.Licencia == Licencia
                        && !x.Aprobada
                      select x;

           string resultado = db.ControlarLicencia(Id, Agente, Licencia, Desde, Hasta);
            return resultado;

        }

        public List<LicenciasAgentesAprobaciones> GetAprobaciones(int licencia)
        {

            var res = from x in db.LicenciasAgentesAprobaciones
                      where x.Licencia == licencia                      
                      select x;

            return res.ToList();
            

        }

        public List<LicenciasAgentesAprobacionesResult> GetAprobacionesResult(int licencia)
        {

            var res = from x in db.LicenciasAgentesAprobaciones
                      join a in db.Agentes on x.AgenteAprueba equals a.Id
                      where x.Licencia == licencia && x.FechaAprobado.HasValue
                      select new LicenciasAgentesAprobacionesResult {
                          Fecha = x.FechaAprobado.Value,
                          Agente = a.Personas.Apellidos.Trim() + ", " + a.Personas.Nombres.Trim()
                      };

            return res.ToList();


        }

        public List<LicenciasAgentesAprobacionesDetalleResult> GetAprobacionesDetalleResult(int licencia)
        {

            var res = from x in db.LicenciasAgentesAprobaciones
                      join a in db.Agentes on x.AgenteAprueba equals a.Id
                      where x.Licencia == licencia
                      select new LicenciasAgentesAprobacionesDetalleResult
                      {
                          Fecha = x.FechaAprobado,
                          Agente = a.Personas.Apellidos.Trim() + ", " + a.Personas.Nombres.Trim()
                      };

            return res.ToList();


        }

        public void GuardarExcepcion(LicenciasAgenteExcepciones Objeto)
        {
            try
            {
                db.LicenciasAgenteExcepciones.Add(Objeto);
                db.SaveChanges();
            }
            catch (Exception msg)
            {
                Logger.GrabarExcepcion(msg, false);
                throw new Exception(msg.Message);
            }
        }

        public DbQuery<LicenciasAgenteExcepcionesViewT> ExcepcionesDelAgente(int agente)
        {
            var x = (from c in db.LicenciasAgenteExcepciones
                     join l in db.LicenciasRef on c.Licencia equals l.Id
                     where c.Agente == agente
                     select new LicenciasAgenteExcepcionesViewT
                     {
                         Id = 0,
                         Licencia = l.Descripcion,
                         Dias = c.DiasQueHabilita,
                         FechaFin = c.FechaFin,
                         Resolucion = c.Resolucion
                     });

            return (DbQuery<LicenciasAgenteExcepcionesViewT>)x;
        }

        public DbQuery<LicenciasAgentePorOrganismoView> LicenciasPorOrganismo(int organismo)
        {
            var desde = DateTime.Now.AddDays(-10);

            var x = (from c in db.LicenciasAgente
                     where !c.SinEfecto && ((c.SolicitadaPorApp && c.FechaAprobada.HasValue) || (!c.SolicitadaPorApp))
                     && c.FechaDesde >= desde 
                     && c.AgenteRRHHs.Nombramientos.Any(n=>!n.FechaEliminacion.HasValue && !n.FechaDeBaja.HasValue && n.Organismo == organismo)
                     select new LicenciasAgentePorOrganismoView {
                         Nombre = c.AgenteRRHHs.Personas.Apellidos.Trim() + " " + c.AgenteRRHHs.Personas.Nombres.Trim(),
                         Id = c.Id,
                         Agente = c.AgenteRRHH,
                         DescripcionLicencia = c.Licencias.Descripcion,
                         Licencia = c.Licencia,
                         FechaDesde = c.FechaDesde,
                         FechaHasta = c.FechaHasta,
                         Estado = c.Aprobada ? "APROBADA" : (!c.Aprobada && !c.FechaAprobada.HasValue) ? "PENDIENTE" : "DESAPROBADA"
                     });

            return (DbQuery<LicenciasAgentePorOrganismoView>)x;
        }


    }
}
