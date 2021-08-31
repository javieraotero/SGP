using System;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Data.Objects.SqlClient;
using SSO.SGP.EntidadesDeNegocio;
using SSO.SGP.EntidadesDeNegocio.Vistas;
using Syncrosoft.Framework.Utils.Logs;
using Syncrosoft.Framework.Controles.Mvc.JQuery.Datatables;
using System.ComponentModel;
using System.Collections.Generic;
using System.Data.SqlClient;
using SSO.SGP.EntidadesDeNegocio.Results;
using System.Data.Objects;

namespace SSO.SGP.AccesoADatos
{
    /// <summary>
    /// Acceso a Datos Generada por el Generador de codigo.
    /// </summary>
    public partial class AgentesAD
    {
        private BDEntities db = new BDEntities();

        public Agentes ObtenerPorId(int Id)
        {
            return db.Agentes.Single(c => c.Id == Id);
        }

        public Agentes ObtenerPorLegajo(int Legajo)
        {
            return db.Agentes.Single(c => c.Legajo == Legajo);
        }

        public Agentes ObtenerPorPesona(int persona)
        {
            return db.Agentes.Where(c => c.Persona == persona).FirstOrDefault();
        }

        public Agentes ObtenerPorDni(long dni)
        {
            var res = (from x in db.Agentes
                       where x.Personas.NroDocumento == dni
                       select x).FirstOrDefault();

            return res;
        }

        public AgentesCertificadoView ObtenerCertificadoAgente(long dni)
        {
            var res = (from x in db.Agentes
                       where x.Personas.NroDocumento == dni
                             && x.CertificadoFechaDesde.HasValue
                       select new AgentesCertificadoView { 
                            Id = x.Id,
                            Nombre = x.Personas.Apellidos.Trim() + ", " + x.Personas.Nombres.Trim(),
                            Cargo = x.Nombramientos.Where(n=>!n.FechaDeBaja.HasValue && !n.FechaEliminacion.HasValue).FirstOrDefault().Cargos.Descripcion,
                            Circunscripcion = x.Nombramientos.Where(n => !n.FechaDeBaja.HasValue && !n.FechaEliminacion.HasValue).FirstOrDefault().Organismos.Circunscripcion,
                            DNI = dni,
                            Foto = x.TokenGCM
                       }).FirstOrDefault();

            return res;
        }

        public DbQuery<Agentes> ObtenerTodo()
        {
            return (DbQuery<Agentes>)db.Agentes.Where(c => c.Activo == true);
        }

        public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
        {
            var res = from x in db.Agentes
                      where (x.Personas.Nombres.Contains(filtro) || x.Personas.Apellidos.Contains(filtro))
                      && x.Activo == true
                      //where x.Personas.Apellidos.Contains(filtro)
                      select new SelectOptionsView { text = x.Personas.Apellidos.Trim() + ", " + x.Personas.Nombres.Trim(), value = x.Id };
            return (DbQuery<SelectOptionsView>)res;
        }

        public DbQuery<Agentes> GetJson(string filtro)
        {
            var res = from x in db.Agentes
                      where (x.Personas.Nombres.Contains(filtro) || x.Personas.Apellidos.Contains(filtro) || SqlFunctions.StringConvert((double)x.Legajo).Contains(filtro))
                      && x.Activo == true
                      //where x.Personas.Apellidos.Contains(filtro)
                      //select new { text = x.Personas.Apellidos.Trim() + ", " + x.Personas.Nombres.Trim(), value = x.Id, dni = x.Personas.NroDocumento, legajo = x.Legajo};
                      select x;
            return (DbQuery<Agentes>)res;
        }

        public DbQuery<Agentes> GetJsonOrganismo(string filtro, int organismo)
        {
            var res = from x in db.Agentes
                      where (x.Personas.Nombres.Contains(filtro) || x.Personas.Apellidos.Contains(filtro) || SqlFunctions.StringConvert((double)x.Legajo).Contains(filtro))
                      && x.Activo == true
                      && x.Nombramientos.Any(n=>n.Organismo == organismo && !n.FechaEliminacion.HasValue && !x.FechaBaja.HasValue)
                      //where x.Personas.Apellidos.Contains(filtro)
                      //select new { text = x.Personas.Apellidos.Trim() + ", " + x.Personas.Nombres.Trim(), value = x.Id, dni = x.Personas.NroDocumento, legajo = x.Legajo};
                      select x;
            return (DbQuery<Agentes>)res;
        }

        public DbQuery<Agentes> GetJsonFuncionarios(string filtro)
        {
            var res = from x in db.Agentes
                      where (x.Personas.Nombres.Contains(filtro) || x.Personas.Apellidos.Contains(filtro) || SqlFunctions.StringConvert((double)x.Legajo).Contains(filtro))
                      && x.Activo == true
                      && ((x.Nombramientos.Where(n=>!n.FechaDeBaja.HasValue 
                                                 && !n.FechaEliminacion.HasValue).FirstOrDefault().Cargos.Grupo == 1) || x.RequiereSubrogante)                      
                      
                            
                            //where x.Personas.Apellidos.Contains(filtro)
                      //select new { text = x.Personas.Apellidos.Trim() + ", " + x.Personas.Nombres.Trim(), value = x.Id, dni = x.Personas.NroDocumento, legajo = x.Legajo};
                      select x;
            return (DbQuery<Agentes>)res;
        }

        public DbQuery<Agentes> GetFuncionariosJson(string filtro)
        {
            List<int> grupos = new List<int>();
            grupos.Add(1);
            grupos.Add(5);

            var res = from x in db.Agentes
                      where (x.Personas.Nombres.Contains(filtro) || x.Personas.Apellidos.Contains(filtro) || SqlFunctions.StringConvert((double)x.Legajo).Contains(filtro))
                      && x.Nombramientos.Any(n => !n.FechaDeBaja.HasValue && !n.FechaEliminacion.HasValue)
                      && x.Activo == true && (grupos.Contains((x.Nombramientos.Where(n => !n.FechaDeBaja.HasValue
                                                 && !n.FechaEliminacion.HasValue).OrderByDescending(n=>n.FechaDeAlta).FirstOrDefault().Cargos.Grupo)) || x.RequiereSubrogante)
                      //where x.Personas.Apellidos.Contains(filtro)
                      //select new { text = x.Personas.Apellidos.Trim() + ", " + x.Personas.Nombres.Trim(), value = x.Id, dni = x.Personas.NroDocumento, legajo = x.Legajo};
                      select x;
            return (DbQuery<Agentes>)res;
        }

        public Agentes ObtenerCertificado(long dni)
        {
            var res = (from x in db.Agentes
                      where x.Personas.NroDocumento == dni
                      select x).FirstOrDefault();
            return res;
        }

        public DbQuery<AgentesView> ObtenerParaGrilla()
        {
            var x = (from c in db.Agentes
                     where c.Activo == true
                     orderby c.Id ascending
                     select new AgentesView
                     {
                         Id = c.Id,
                         Legajo = c.Legajo,
                         Telefono = c.Telefono,
                         Nombre = c.Personas.Apellidos + ", " + c.Personas.Nombres,
                         Organismo = c.Nombramientos.Where(nom => !nom.FechaDeBaja.HasValue && !nom.FechaEliminacion.HasValue).FirstOrDefault().Organismos.Descripcion,
                         Cargo = c.Nombramientos.Where(nom => !nom.FechaDeBaja.HasValue && !nom.FechaEliminacion.HasValue).FirstOrDefault().Cargos.Descripcion
                     });
            return (DbQuery<AgentesView>)x;
        }

        public DbQuery<AgentesView> ObtenerParaGrillaMM()
        {
            var x = from c in db.Agentes
                    where c.Activo == true && c.Nombramientos.Any(n => n.Organismos.UnidadOrganizacionRRHH == 2)
                    select new AgentesView
                    {
                        Id = c.Id,
                        Legajo = c.Legajo,
                        Telefono = c.Telefono,
                        Nombre = c.Personas.Apellidos + ", " + c.Personas.Nombres,
                        Organismo = c.Nombramientos.Where(nom => !nom.FechaDeBaja.HasValue && !nom.FechaEliminacion.HasValue).FirstOrDefault().Organismos.Descripcion,
                        Cargo = c.Nombramientos.Where(nom => !nom.FechaDeBaja.HasValue && !nom.FechaEliminacion.HasValue).FirstOrDefault().Cargos.Descripcion
                    };
            return (DbQuery<AgentesView>)x;
        }

        public DbQuery<AgentesView> ObtenerParaGrilla_(DataTablesParam p)
        {
            var x = from c in db.Agentes
                    where c.Activo == true
                    select new AgentesView
                    {
                        Id = c.Id,
                        Legajo = c.Legajo,
                        Telefono = c.Telefono,
                        Nombre = c.Personas.Apellidos + ", " + c.Personas.Nombres,
                        Organismo = c.Nombramientos.Where(nom => !nom.FechaDeBaja.HasValue).FirstOrDefault().Organismos.Descripcion,
                        Cargo = c.Nombramientos.Where(nom => !nom.FechaDeBaja.HasValue).FirstOrDefault().Cargos.Descripcion
                    };
            return (DbQuery<AgentesView>)x;
        }

        public void Guardar(Agentes Objeto)
        {
            try
            {
                db.Agentes.Add(Objeto);
                db.SaveChanges();
            }
            catch (Exception msg)
            {
                Logger.GrabarExcepcion(msg, false);
                throw new Exception(msg.Message);
            }
        }

        public void Actualizar(Agentes Objeto)
        {
            try
            {
                db.Agentes.Attach(Objeto);
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
                Agentes Objeto = this.ObtenerPorId(IdObjeto);
                Objeto.Activo = false;
                Objeto.FechaBaja = DateTime.Now;
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

        public DbQuery<AgentesViewT> JsonT(string term)
        {
            var x = from c in db.Agentes
                    where c.Activo == true
                    select new AgentesViewT
                    {
                        Id = c.Id,
                        Legajo = c.Legajo,
                        Telefono = c.Telefono,
                        Profesion = c.Profesion,
                        EstudiosCursados = c.EstudiosCursados,
                        AfiliadoISS = c.AfiliadoISS,
                        FechaDeCasamiento = c.FechaDeCasamiento,
                        Persona = c.Persona,
                        Activo = c.Activo,
                        FechaBaja = c.FechaBaja,
                        FechaAlta = c.FechaAlta,
                        NumeroPS = c.NumeroPS,
                        Domicilio = c.Domicilio,
                        FechaUltimoAscenso = c.FechaUltimoAscenso,
                        UltimoCargo = c.UltimoCargo,
                    };
            return (DbQuery<AgentesViewT>)x;
        }
        /*********************************************
		* Seccion Particular
		* *******************************************/
        //Stored Procedures
        public List<DiasDeLicenciaView> DiasDeLicenciaDisponibles(int agente, int anio)
        {
            var par1 = new SqlParameter();
            par1.ParameterName = "@agente";
            par1.Direction = System.Data.ParameterDirection.Input;
            par1.Value = agente;
            par1.SqlDbType = System.Data.SqlDbType.Int;

            var par2 = new SqlParameter();
            par2.ParameterName = "@anio";
            par2.Direction = System.Data.ParameterDirection.Input;
            par2.Value = anio;
            par2.SqlDbType = System.Data.SqlDbType.Int;
            //par2.TypeName = "INT";

            var x = ((IObjectContextAdapter)this.db).ObjectContext.ExecuteStoreQuery<DiasDeLicenciaView>("EXEC DiasDeLicenciasDisponibles @agente, @anio", par1, par2);

            return x.ToList<DiasDeLicenciaView>();
        }

        public virtual int DiasDeLicenciaOrdinariaSustituos(int Agente, DateTime Fecha)
        {

            var par1 = new SqlParameter();
            par1.ParameterName = "@Agente";
            par1.Direction = System.Data.ParameterDirection.Input;
            par1.Value = Agente;
            par1.SqlDbType = System.Data.SqlDbType.Int;

            var par2 = new SqlParameter();
            par2.ParameterName = "@Fecha";
            par2.Direction = System.Data.ParameterDirection.Input;
            par2.Value = Fecha;
            par2.SqlDbType = System.Data.SqlDbType.DateTime;
            //par2.TypeName = "INT";

            return ((IObjectContextAdapter)this.db).ObjectContext.ExecuteStoreQuery<int>("EXEC DiasDeLicenciaOrdinariaSustitutos @Agente, @Fecha", par1, par2).FirstOrDefault();

        }

        public List<AgentesConBonificacionView> AgentesConBonificacion(DateTime Desde, DateTime Hasta, int Mes, int Anio)
        {

            var par2 = new SqlParameter();
            par2.ParameterName = "@Desde";
            par2.Direction = System.Data.ParameterDirection.Input;
            par2.Value = Desde;
            par2.SqlDbType = System.Data.SqlDbType.DateTime;

            var par3 = new SqlParameter();
            par3.ParameterName = "@Hasta";
            par3.Direction = System.Data.ParameterDirection.Input;
            par3.Value = Hasta;
            par3.SqlDbType = System.Data.SqlDbType.DateTime;

            var par4 = new SqlParameter();
            par4.ParameterName = "@Mes";
            par4.Direction = System.Data.ParameterDirection.Input;
            par4.Value = Mes;
            par4.SqlDbType = System.Data.SqlDbType.Int;

            var par5 = new SqlParameter();
            par5.ParameterName = "@Anio";
            par5.Direction = System.Data.ParameterDirection.Input;
            par5.Value = Anio;
            par5.SqlDbType = System.Data.SqlDbType.Int;

            var x = ((IObjectContextAdapter)this.db).ObjectContext.ExecuteStoreQuery<AgentesConBonificacionView>("EXEC AgentesConBonificaciones @Desde, @Hasta, @Mes, @Anio", par2, par3, par4, par5);

            return x.ToList<AgentesConBonificacionView>();            

        }

        public List<AgentesConBonificacionView> AgentesConBonificacionExcel(DateTime Desde, DateTime Hasta, int Mes, int Anio, bool mp)
        {

            var par2 = new SqlParameter();
            par2.ParameterName = "@Desde";
            par2.Direction = System.Data.ParameterDirection.Input;
            par2.Value = Desde;
            par2.SqlDbType = System.Data.SqlDbType.DateTime;

            var par3 = new SqlParameter();
            par3.ParameterName = "@Hasta";
            par3.Direction = System.Data.ParameterDirection.Input;
            par3.Value = Hasta;
            par3.SqlDbType = System.Data.SqlDbType.DateTime;

            var par4 = new SqlParameter();
            par4.ParameterName = "@Mes";
            par4.Direction = System.Data.ParameterDirection.Input;
            par4.Value = Mes;
            par4.SqlDbType = System.Data.SqlDbType.Int;

            var par5 = new SqlParameter();
            par5.ParameterName = "@Anio";
            par5.Direction = System.Data.ParameterDirection.Input;
            par5.Value = Anio;
            par5.SqlDbType = System.Data.SqlDbType.Int;

            var x = ((IObjectContextAdapter)this.db).ObjectContext.ExecuteStoreQuery<AgentesConBonificacionView>("EXEC AgentesConBonificaciones @Desde, @Hasta, @Mes, @Anio", par2, par3, par4, par5);

            var res = x.ToList<AgentesConBonificacionView>();

            var res2 = from a in res
                       join o in db.OrganismosRef on a.IdOrganismo equals o.Id
                       where (!mp && o.UnidadOrganizacionRRHH != 2) || (mp && o.UnidadOrganizacionRRHH == 2)
                       select a;

            return res2.ToList<AgentesConBonificacionView>();

        }

        public ResumenLicenciasPorOrganismoViewT ResumenLicenciasPorAgente(int Legajo)
        {

            var par1 = new SqlParameter();
            par1.ParameterName = "@Legajo";
            par1.Direction = System.Data.ParameterDirection.Input;
            par1.Value = Legajo;
            par1.SqlDbType = System.Data.SqlDbType.Int;

            //par2.TypeName = "INT";

            var x = ((IObjectContextAdapter)this.db).ObjectContext.ExecuteStoreQuery<ResumenLicenciasPorOrganismoViewT>("EXEC ResumenDeLicenciaPorAgente @Legajo", par1);

            return x.FirstOrDefault();
        }

        public AgentesResult validarApp(string device_id, int legajo)
        {

            var res = db.Agentes.Where(a => a.Device_Id == device_id && a.Legajo == legajo).ToList();

            if (res.Count() > 0)
            {
                return (from x in res
                        select new AgentesResult
                        {
                            Id = x.Id,
                            Nombre = x.Personas.Nombres,
                            Apellido = x.Personas.Apellidos,
                            Documento = x.Personas.NroDocumento.Value,
                            FechaNacimiento = x.Personas.FechaNacimiento,
                            Domicilio = x.Domicilio,
                            Legajo = x.Legajo,
                            Id_Organismo = x.Nombramientos.FirstOrDefault().Organismo,
                            Organismo = x.Nombramientos.FirstOrDefault().Organismos.Descripcion,
                            Cargo = x.Nombramientos.FirstOrDefault().Cargos.Descripcion,
                            FechaUltimoAscenso = x.Nombramientos.FirstOrDefault().FechaUltimoAscenso,
                            Id_Nombramiento = x.Nombramientos.FirstOrDefault().Id,
                            //Otorga = 
                        }).FirstOrDefault();
            }
            else
                return null;

        }

        public AgentesResult GetAgentesApp(int persona)
        {

            var res = db.Agentes.Where(a => a.Persona == persona).ToList();

            if (res.Count() > 0)
            {
                var agente = (from x in res
                              select new AgentesResult
                              {
                                  Id = x.Id,
                                  Nombre = x.Personas.Nombres,
                                  Apellido = x.Personas.Apellidos,
                                  Documento = x.Personas.NroDocumento.Value,
                                  FechaNacimiento = x.Personas.FechaNacimiento,
                                  Domicilio = x.Domicilio,
                                  Legajo = x.Legajo,
                                  Id_Organismo = x.Nombramientos.FirstOrDefault().Organismo,
                                  Organismo = x.Nombramientos.FirstOrDefault().Organismos.Descripcion,
                                  Cargo = x.Nombramientos.Where(n=>n.FechaDeBaja == null).FirstOrDefault().Cargos.Descripcion,
                                  FechaUltimoAscenso = x.Nombramientos.Where(n => n.FechaDeBaja == null).FirstOrDefault().FechaUltimoAscenso,
                                  Id_Nombramiento = x.Nombramientos.Where(n => n.FechaDeBaja == null).FirstOrDefault().Id,
                                  Url_Profile = (x.Imagenesrrhh.Where(m => m.Categoria == 5).Count() > 0) ? x.Imagenesrrhh.Where(m => m.Categoria == 5).Last().Imagen : "",
                                  Email = x.Email,
                                  Telefono = x.Telefono
                                  //Otorga = (x.Nombramientos.FirstOrDefault().Cargos.Grupo == 1) ? true : false
                              }).FirstOrDefault();

                var organismo = (from x in db.OrganismosRef
                                 where x.Id == agente.Id_Organismo
                                 select x).FirstOrDefault();


                var cargos = (from x in db.Nombramientos
                              where ((organismo.DependeDe.HasValue && x.Organismo == organismo.DependeDe.Value) || (!organismo.DependeDe.HasValue && x.Organismo == agente.Id_Organismo))
                              && x.FechaDeBaja == null && x.Cargos.Grupo == 1
                              select x.Cargos).Distinct().ToList();

                int cargo = (from x in cargos
                             where x.Grupo == 1
                             select x).Min(c => c.Orden);


                var superior = (from x in db.Nombramientos
                                where ((organismo.DependeDe.HasValue && x.Organismo == organismo.DependeDe.Value) || (!organismo.DependeDe.HasValue && x.Organismo == agente.Id_Organismo))
                                && x.FechaDeBaja == null
                                && x.Cargos.Grupo == 1 && x.Cargos.Orden == cargo
                                select x.Agentes).FirstOrDefault();

                var licencia = from x in db.LicenciasAgente
                               where x.AgenteRRHH == superior.Id && !x.FechaEliminacion.HasValue && !x.SinEfecto && x.FechaHasta.Value >= DateTime.Now
                               select x;

                if (licencia.Count() > 0)
                {
                    if (licencia.FirstOrDefault().SubroganteRRHH.HasValue)
                    {
                        superior = this.ObtenerPorId(licencia.FirstOrDefault().SubroganteRRHH.Value);
                    }
                }

                agente.IdSuperior = superior.Id;
                agente.Superior = superior.Personas.Apellidos.TrimEnd() + ", " + superior.Personas.Nombres.TrimEnd();

                if (agente.Id == superior.Id)
                    agente.Otorga = true;
                else
                    agente.Otorga = false;

                return agente;

            }
            else
                return null;

        }

        public List<LicenciasResult> MisLicencias(string device_id, int agente, int licencia, int anio)
        {
            var res = (from x in db.LicenciasAgente
                       where x.AgenteRRHH == agente
                       && x.Licencia == licencia
                       && x.Aprobada
                       && x.FechaDesde.Year == anio
                       && !x.SinEfecto
                       && x.FechaEliminacion == null
                       select new LicenciasResult
                       {
                           Aprobada = true,
                           Desde = x.FechaDesde,
                           Hasta = x.FechaHasta.Value,
                           Licencia = x.Licencias.Descripcion,
                           Id = x.Id
                       }
                      ).ToList();

            return res;
        }



        public List<LicenciasResult> LicenciasPendientes(string device_id, int organismo)
        {
            var agente = (from x in db.Agentes
                          where x.Device_Id == device_id
                          select x).FirstOrDefault();

            var res = (from x in db.LicenciasAgente
                       where x.Nombramientos.Organismo == organismo
                       && x.FechaAprobada == null && x.SolicitadaPorApp && EntityFunctions.AddDays(x.FechaAlta.Value,5) >= DateTime.Now
                       select new LicenciasResult
                       {
                           Aprobada = false,
                           Id_Agente = x.AgenteRRHH.Value,
                           Agente = x.AgenteRRHHs.Personas.Apellidos.TrimEnd() + ", " + x.AgenteRRHHs.Personas.Nombres.TrimEnd(),
                           Desde = x.FechaDesde,
                           Hasta = x.FechaHasta.Value,
                           Id = x.Id,
                           Licencia = x.Licencias.Descripcion
                       }
                       ).ToList();

            return res;
        }

        public List<LicenciasDisponiblesResult> SaldoLicencias(string device_id, int agente)
        {
            List<LicenciasDisponiblesResult> lista = new List<LicenciasDisponiblesResult>();
            var a = (from x in db.Agentes
                     where x.Device_Id == device_id
                     select x).FirstOrDefault();

            var saldos = this.DiasDeLicenciaDisponibles(agente, DateTime.Now.Year);

            var ordinarias = (from x in db.LicenciasOrdinariasIniciales
                              where x.Agente == agente
                              select x
                 ).Sum(s => s.Saldo);

            lista.Add(new LicenciasDisponiblesResult() { Licencia = "ORDINARIA", Dias = ordinarias });

            foreach (var i in saldos)
            {
                var d = new LicenciasDisponiblesResult()
                {
                    Dias = i.Dias,
                    Licencia = i.Licencia.Replace("<STRONG>", "").Replace("</strong>", "")
                };
                lista.Add(d);
            }

            // Retornar saldo de licencias de ordinarias o particulares
            return lista.Where(l => l.Licencia.Contains("ORDINARIA") || l.Licencia.Contains("PARTICULARES")).ToList();
        }


        public List<LicenciasResult> MisLicenciasSolicitadas(string device_id, int agente, bool aprobada)
        {
            var a = (from x in db.Agentes
                     where x.Device_Id == device_id
                     select x).FirstOrDefault();

            var res = (from x in db.LicenciasAgente
                       where x.AgenteRRHH == agente
                       && x.Aprobada == aprobada
                       && x.SolicitadaPorApp == true
                       select new LicenciasResult
                       {
                           Aprobada = aprobada,
                           Id_Agente = x.AgenteRRHH.Value,
                           Agente = x.AgenteRRHHs.Personas.Apellidos.TrimEnd() + ", " + x.AgenteRRHHs.Personas.Nombres.TrimEnd(),
                           Desde = x.FechaDesde,
                           Hasta = x.FechaHasta.Value,
                           Id = x.Id,
                           Licencia = x.Licencias.Descripcion,
                           FechaAprobada = x.FechaAprobada,
                           Desaprobada = (x.FechaAprobada.HasValue && !x.Aprobada),
                           Pendiente = (!x.FechaAprobada.HasValue)
                       }
                       ).ToList();

            return res;
        }

        public Result AprobarLicencia(int licencia, int agente)
        {
            string error = "";
            Result res = new Result();

            try
            {
                var a = db.Agentes.Where(x => x.Id == agente).FirstOrDefault();
                var lic = (from x in db.LicenciasAgente where x.Id == licencia select x).FirstOrDefault();

                if (!lic.Aprobada)
                {

                    error = db.ControlarLicencia(0, lic.AgenteRRHH.Value, lic.Licencia, lic.FechaDesde, lic.FechaHasta.Value);

                    if (error.Length == 0)
                    {

                        lic.Aprobada = true;
                        lic.AgenteAprobada = agente;
                        lic.FechaAprobada = DateTime.Now;
                        lic.Observaciones = "Aprobada desde APP";
                        lic.Activa = true;
                        lic.FechaEliminacion = null;
                        lic.SinEfecto = false;

                        db.LicenciasAgente.Attach(lic);
                        db.Entry(lic).State = EntityState.Modified;
                        db.SaveChanges();

                        res.state = true;
                        res.message = "La licencia ha sido aprobada";
                        res.exception = "-";
                        res.id = lic.AgenteRRHH.Value;

                    }
                    else
                    {

                        res.state = false;
                        res.message = error;
                        res.exception = "";
                        res.id = 0;

                    }
                }
            }
            catch (Exception e)
            {
                res.state = false;
                res.exception = e.Message;
                res.message = "Error al procesar llamada remota al sistema";
                res.id = 0;
            }

            return res;

        }

        public Result DesaprobarLicencia(string device_id, int licencia, int agente)
        {
            string error = "";
            Result res = new Result();

            try
            {
                var a = db.Agentes.Where(x => x.Id == agente).FirstOrDefault();
                var lic = (from x in db.LicenciasAgente where x.Id == licencia select x).FirstOrDefault();

                if (!lic.Aprobada)
                {

                    //error = db.ControlarLicencia(0, lic.AgenteRRHH.Value, lic.Licencia, lic.FechaDesde, lic.FechaHasta.Value);

                    if (error.Length == 0)
                    {

                        lic.Aprobada = false;
                        lic.AgenteAprobada = agente;
                        lic.FechaAprobada = DateTime.Now;
                        lic.Observaciones = "Desaprobada desde APP";

                        db.LicenciasAgente.Attach(lic);
                        db.Entry(lic).State = EntityState.Modified;
                        db.SaveChanges();

                        res.state = true;
                        res.message = "La licencia ha sido desaprobada";
                        res.exception = "-";
                        res.id = lic.AgenteRRHH.Value;

                    }
                    else
                    {

                        res.state = false;
                        res.message = error;
                        res.exception = "";
                        res.id = 0;

                    }
                }
            }
            catch (Exception e)
            {
                res.state = false;
                res.exception = e.Message;
                res.message = "Error al procesar llamada remota al sistema";
                res.id = 0;
            }

            return res;

        }

        public AgentesResult login(string device_id, int legajo)
        {

            var res = db.Agentes.Where(a => a.Device_Id == device_id && a.Legajo == legajo).ToList();

            if (res.Count() > 0)
            {
                var agente = (from x in res
                              select new AgentesResult
                              {
                                  Id = x.Id,
                                  Nombre = x.Personas.Nombres,
                                  Apellido = x.Personas.Apellidos,
                                  Documento = x.Personas.NroDocumento.Value,
                                  FechaNacimiento = x.Personas.FechaNacimiento,
                                  Domicilio = x.Domicilio,
                                  Legajo = x.Legajo,
                                  Id_Organismo = x.Nombramientos.FirstOrDefault().Organismo,
                                  Organismo = x.Nombramientos.FirstOrDefault().Organismos.Descripcion,
                                  Cargo = x.Nombramientos.FirstOrDefault().Cargos.Descripcion,
                                  FechaUltimoAscenso = x.Nombramientos.FirstOrDefault().FechaUltimoAscenso,
                                  Id_Nombramiento = x.Nombramientos.FirstOrDefault().Id,
                                  Otorga = false,
                                  Url_Profile = (x.Imagenesrrhh.Where(m => m.Categoria == 7).Count() > 0) ? x.Imagenesrrhh.Where(m => m.Categoria == 7).Last().Imagen : ""
                              }).FirstOrDefault();

                var cargos = (from x in db.Nombramientos
                              where x.Organismo == agente.Id_Organismo
                              && x.FechaDeBaja == null
                              select x.Cargos).Distinct().ToList();

                int cargo = (from x in cargos
                             where x.Grupo == 1
                             select x).Min(c => c.Orden);


                var superior = (from x in db.Nombramientos
                                where x.Organismo == agente.Id_Organismo
                                && x.FechaDeBaja == null
                                && x.Cargos.Grupo == 1 && x.Cargos.Orden == cargo
                                select x.Agentes).FirstOrDefault();

                agente.IdSuperior = superior.Id;
                agente.Superior = superior.Personas.Apellidos.TrimEnd() + ", " + superior.Personas.Nombres.TrimEnd();

                if (agente.Id == superior.Id)
                    agente.Otorga = true;

                return agente;


            }
            else
                return null;

        }

        public Result UpdateToken(string device_id, string token)
        {
            var res = new Result();

            try
            {
                var a = db.Agentes.Where(d => d.Device_Id == device_id).SingleOrDefault();
                a.TokenGCM = token;

                db.Agentes.Attach(a);
                db.Entry(a).State = EntityState.Modified;
                db.SaveChanges();

                res.state = true;
                res.message = "Token actualizado";

            }
            catch (Exception e)
            {

                res.exception = e.Message;
                res.state = false;

            }

            return res;

        }

        public bool updateData(int documento, string legajo_sueldo, string afiliado)
        {

            try
            {
                var a = (from x in db.Agentes
                         where x.Personas.NroDocumento == documento
                         select x).FirstOrDefault();

                a.LegajoSueldo = legajo_sueldo;
                a.AfiliadoISS = afiliado;

                this.Actualizar(a);

                return true;
            }
            catch (Exception e)
            {

                return false;

            }
        }

        public DateTime? UltimaLicencia(string device_id)
        {

            var l = (from x in db.LicenciasAgente
                     where x.AgenteRRHHs.Device_Id == device_id
                     && x.FechaEliminacion == null
                     && x.Activa
                     select x
                     ).Max(t => t.FechaDesde);

            return (l);
        }


        public bool deviceEnabled(string device_id)
        {

            var res = (from x in db.Agentes where x.Device_Id == device_id && x.AppActivo select x).ToList();

            if (res.Count > 0)
                return true;
            else
                return false;

        }

        public AgentesResult deviceEnabled2(string device_id)
        {

            var res = (from x in db.Agentes where x.Device_Id == device_id && x.AppActivo select x).ToList();

            if (res.Count > 0)
            {

                var agente = (from x in res
                              select new AgentesResult
                              {
                                  Id = x.Id,
                                  Nombre = x.Personas.Nombres,
                                  Apellido = x.Personas.Apellidos,
                                  Documento = x.Personas.NroDocumento.Value,
                                  FechaNacimiento = x.Personas.FechaNacimiento,
                                  Domicilio = x.Domicilio,
                                  Legajo = x.Legajo,
                                  Id_Organismo = x.Nombramientos.FirstOrDefault().Organismo,
                                  Organismo = x.Nombramientos.FirstOrDefault().Organismos.Descripcion,
                                  Cargo = x.Nombramientos.FirstOrDefault().Cargos.Descripcion,
                                  FechaUltimoAscenso = x.Nombramientos.FirstOrDefault().FechaUltimoAscenso,
                                  Id_Nombramiento = x.Nombramientos.FirstOrDefault().Id,
                                  //Otorga = 
                              }).FirstOrDefault();

                var cargos = (from x in db.Nombramientos
                              where x.Organismo == agente.Id_Organismo
                              && x.FechaDeBaja == null
                              select x.Cargos).Distinct().ToList();

                int cargo = (from x in cargos
                             where x.Grupo == 1
                             select x).Min(c => c.Orden);


                var superior = (from x in db.Nombramientos
                                where x.Organismo == agente.Id_Organismo
                                && x.FechaDeBaja == null
                                && x.Cargos.Grupo == 1 && x.Cargos.Orden == cargo
                                select x.Agentes).FirstOrDefault();

                agente.IdSuperior = superior.Id;
                agente.Superior = superior.Personas.Apellidos.TrimEnd() + ", " + superior.Personas.Nombres.TrimEnd();

                if (agente.Id == superior.Id)
                    agente.Otorga = true;

                return agente;



            }
            else
                return null;

        }

        public List<AgentesView> GetFuncionarios()
        {
            var res = from x in db.Nombramientos
                      where x.Cargos.Grupo == 1 && x.FechaEliminacion == null && x.FechaDeBaja == null
                      select new AgentesView
                      {
                          Id = x.Agentes.Id,
                          Cargo = x.Cargos.Descripcion,
                          Legajo = x.Agentes.Legajo,
                          Nombre = x.Agentes.Personas.Apellidos.Trim() + ", " + x.Agentes.Personas.Nombres.Trim(),
                          Organismo = x.Organismos.Descripcion,
                          Telefono = x.Agentes.Telefono
                      };
            return res.ToList();
        }


        public AgenteConLicenciaResult agenteConLicencia(int agente) {

            var hoy = DateTime.Now.Date;
            var result = new AgenteConLicenciaResult()
            {
                con_licencia = false
            };

            var licencias = (from x in db.LicenciasAgente
                             where x.AgenteRRHH == agente && x.FechaDesde <= hoy && x.FechaHasta >= hoy && !x.FechaEliminacion.HasValue && !x.SinEfecto
                             select x).ToList();

            if (licencias.Count > 0) {
                result.con_licencia = true;
                result.subrogante = licencias.FirstOrDefault().Subrogante ?? null;
            }

            return result;

        }

        public AgenteConLicenciaResult agenteConLicenciaEnFechas(int agente, DateTime desde, DateTime hasta)
        {
            var result = new AgenteConLicenciaResult()
            {
                con_licencia = false
            };

            var licencias = (from x in db.LicenciasAgente
                             where x.AgenteRRHH == agente && desde <= x.FechaHasta && hasta >= x.FechaDesde && !x.FechaEliminacion.HasValue && !x.SinEfecto
                             select x).ToList();

            if (licencias.Count > 0)
            {
                result.con_licencia = true;
                result.subrogante = licencias.FirstOrDefault().Subrogante ?? null;
            }

            return result;

        }


        public AgentesResult GetByUser(string user) {

            int? subrogante = null;

            var res = new AgentesResult();
            res.habilita_licencia = true;

            var excepciones = db.OrganismosExtensionesRRHH.ToList();

            var u = from x in db.Usuarios
                    join p in db.Personas on x.Persona equals p.Id
                    join a in db.Agentes on p.Id equals a.Persona
                    where x.Usuario == user
                    select a;

            if (u.Count() > 0)
            {
                var a = u.FirstOrDefault();

                res = new AgentesResult()
                {
                    Id = a.Id,
                    Nombre = a.Personas.Apellidos.Trim() + ", " + a.Personas.Nombres.Trim(),
                    Legajo = a.Legajo,
                    Id_Organismo = a.Nombramientos.Where(f => !f.FechaDeBaja.HasValue).FirstOrDefault().Organismo,
                    Id_Nombramiento = a.Nombramientos.Where(f => !f.FechaDeBaja.HasValue).FirstOrDefault().Id,
                    Grupo = a.Nombramientos.Where(f => !f.FechaDeBaja.HasValue).FirstOrDefault().Cargos.Grupo,
                    Cargo = a.Nombramientos.Where(f => !f.FechaDeBaja.HasValue).FirstOrDefault().Cargos.Descripcion,
                    Id_Cargo = a.Nombramientos.Where(f => !f.FechaDeBaja.HasValue).FirstOrDefault().Cargo,
                    RequiereSubrogante = a.RequiereSubrogante,
                    AgenteSolicitudLicenciaDefault = a.AgenteSolicitudLicenciaDefault,
                    Profesion = a.Profesion
                }; //u.FirstOrDefault();

                var organismo = (from x in db.OrganismosRef
                                 where x.Id == res.Id_Organismo
                                 select x).FirstOrDefault();

                //var mi_cargo = a.Nombramientos.Where(x => !x.FechaDeBaja.HasValue && !x.FechaEliminacion.HasValue).FirstOrDefault().Cargos;


                int? agente;
                Agentes agente_excepcion;
                int? depende_de = null;

                /*
                 Si hay excepciones para el organismo: 
                 1. Si tiene Agente enviar la solicitud a ese agente. 
                 2. No tiene agente, pero tiene DependeDe -> enviar la solicitud a la máxima autoridad de ese organismo "DependeDe" 
                 3. Tiene Cargo entonces enviar a ese cargo
                */

                if (excepciones.Where(x => x.CargoOrigen == res.Id_Cargo && x.CargoDestino.HasValue).Count() > 0)
                {
                    var cargo_destino = excepciones.Where(x => x.CargoOrigen == res.Id_Cargo && x.CargoDestino.HasValue).FirstOrDefault().CargoDestino.Value;

                    agente = (from z in db.Nombramientos
                              where !z.FechaDeBaja.HasValue && z.Cargo == cargo_destino
                              select z).FirstOrDefault().Agente;

                    agente_excepcion = db.Agentes.Where(x => x.Id == agente).FirstOrDefault();

                    res.Superior = agente_excepcion.Personas.Apellidos.Trim() + ", " + agente_excepcion.Personas.Nombres.Trim();
                    res.EmailSuperior = agente_excepcion.Email;
                    res.IdSuperior = agente_excepcion.Id;
                }

                if (excepciones.Where(x => x.Organismo == res.Id_Organismo && x.DependeDe.HasValue).Count() > 0)
                {
                    depende_de = excepciones.Where(x => x.Organismo == res.Id_Organismo && x.DependeDe.HasValue).FirstOrDefault().DependeDe;
                }

                if (a.AgenteSolicitudLicenciaDefault.HasValue && a.AgenteSolicitudLicenciaDefault.Value > 0)
                {

                    var agente_default = (from x in db.Agentes where x.Id == a.AgenteSolicitudLicenciaDefault.Value select x).FirstOrDefault();

                    res.IdSuperior = a.AgenteSolicitudLicenciaDefault.Value;
                    res.EmailSuperior = agente_default.Email;
                    res.Superior = agente_default.Personas.Apellidos.Trim() + ", " + agente_default.Personas.Nombres.Trim();


                }
                else
                {

                    if (excepciones.Where(x => x.Organismo == res.Id_Organismo && (x.Agente.HasValue || x.DependeDe.HasValue)).Count() > 0)
                    {
                        if (excepciones.Where(x => x.Organismo == res.Id_Organismo && x.Agente.HasValue).Count() > 0)
                        {
                            agente = excepciones.Where(y => y.Organismo == res.Id_Organismo && y.Agente.HasValue).FirstOrDefault().Agente;

                            var agente_con_licencia = agenteConLicencia(agente.Value);

                            if (!agente_con_licencia.con_licencia)
                            {
                                agente_excepcion = db.Agentes.Where(x => x.Id == agente).FirstOrDefault();

                                res.Superior = agente_excepcion.Personas.Apellidos.Trim() + ", " + agente_excepcion.Personas.Nombres.Trim();
                                res.EmailSuperior = agente_excepcion.Email;
                                res.IdSuperior = agente_excepcion.Id;
                            }
                            else
                            {

                                if (agente_con_licencia.subrogante.HasValue)
                                {
                                    agente_excepcion = db.Agentes.Where(x => x.Id == agente_con_licencia.subrogante.Value).FirstOrDefault();

                                    res.Superior = agente_excepcion.Personas.Apellidos.Trim() + ", " + agente_excepcion.Personas.Nombres.Trim();
                                    res.EmailSuperior = agente_excepcion.Email;
                                    res.IdSuperior = agente_excepcion.Id;
                                }
                                else
                                {
                                    agente_excepcion = db.Agentes.Where(x => x.Id == agente).FirstOrDefault();

                                    res.habilita_licencia = false;
                                    res.mensaje = agente_excepcion.Personas.Apellidos.Trim() + ", " + agente_excepcion.Personas.Nombres.Trim() + " está con Licencia el día de hoy y no se ha encontrado su subrogante";

                                }
                            }
                        }
                    }
                    else
                    {

                        var cargos = (from x in db.Nombramientos
                                      where ((depende_de.HasValue && x.Organismo == depende_de.Value) || (!depende_de.HasValue && x.Organismo == res.Id_Organismo))
                                      && x.FechaDeBaja == null && x.Cargos.Grupo == 1
                                      select x.Cargos).Distinct().ToList();

                        int cargo = (from x in cargos
                                     where x.Grupo == 1
                                     select x).Min(c => c.Orden);

                        var superiores = (from x in db.Nombramientos
                                          where ((depende_de.HasValue && x.Organismo == depende_de.Value) || (!depende_de.HasValue && x.Organismo == res.Id_Organismo))
                                          && x.FechaDeBaja == null
                                          && x.Cargos.Grupo == 1 && x.Cargos.Orden == cargo
                                          select x.Agentes).ToList();

                        var funcionarios = (from f in superiores
                                            select new FuncionariosResult
                                            {
                                                Id = f.Id,
                                                Nombre = f.Personas.Apellidos + ", " + f.Personas.Nombres,
                                                Cargo = f.Nombramientos.Where(n => !n.FechaDeBaja.HasValue && !n.FechaEliminacion.HasValue).FirstOrDefault().Cargos.Descripcion,
                                                Email = f.Email
                                            }).ToList();


                        var superior = superiores.FirstOrDefault();


                        res.Funcionarios = funcionarios;
                        res.IdSuperior = superior.Id;
                        res.Superior = superior.Personas.Apellidos.Trim() + ", " + superior.Personas.Nombres.Trim();
                        res.EmailSuperior = superior.Email;

                    }

                    var ahora = DateTime.Now.Date;

                    var licencia_actual = (from x in db.LicenciasAgente
                                           where x.AgenteRRHH == res.IdSuperior
                                           && x.FechaDesde <= ahora && x.FechaHasta >= ahora
                                           && !x.FechaEliminacion.HasValue && !x.SinEfecto
                                           select x).ToList();

                    if (licencia_actual.Count > 0)
                    {
                        subrogante = licencia_actual.FirstOrDefault().Subrogante;

                        if (subrogante.HasValue)
                        {
                            res.IdSuperior = subrogante.Value;
                            var agente_subrogane = db.Agentes.Where(x => x.Id == subrogante.Value).FirstOrDefault();

                            res.Superior = agente_subrogane.Personas.Apellidos.Trim() + ", " + agente_subrogane.Personas.Nombres.Trim();
                            res.EmailSuperior = agente_subrogane.Email;
                        }
                    }
                }

            }

            return res;

        } 


    }

    public class AgenteConLicenciaResult { 
        public bool con_licencia { get; set; }
        public int? subrogante { get; set; }
    }

}
