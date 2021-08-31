
using System;
using System.Data.Entity.Infrastructure;
using SSO.SGP.EntidadesDeNegocio;
using SSO.SGP.EntidadesDeNegocio.Results;
using SSO.SGP.AccesoADatos;
using SSO.SGP.EntidadesDeNegocio.Vistas;
using System.Collections.Generic;


namespace SSO.SGP.ReglasDeNegocio
{
    /// <summary>
    /// Reglas De Negocio Generada por el Generador de codigo.
    /// </summary>
    public partial class AgentesRN
    {
        AgentesAD oAgentesAD = new AgentesAD();

        public Agentes ObtenerPorId(int Id)
        {
            return this.oAgentesAD.ObtenerPorId(Id);
        }

        public Agentes ObtenerPorLegajo(int Legajo)
        {
            return this.oAgentesAD.ObtenerPorLegajo(Legajo);
        }

        public DbQuery<Agentes> ObtenerTodo()
        {
            return this.oAgentesAD.ObtenerTodo();
        }


        public DbQuery<AgentesView> ObtenerParaGrilla(int start, int lenght)
        {
            return this.oAgentesAD.ObtenerParaGrilla();
        }

        public DbQuery<AgentesView> ObtenerParaGrillaMM()
        {
            return this.oAgentesAD.ObtenerParaGrillaMM();
        }

        public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
        {
            return this.oAgentesAD.ObtenerOptions(filtro);
        }

        public DbQuery<Agentes> GetJson(String filtro)
        {
            return this.oAgentesAD.GetJson(filtro);
        }

        public DbQuery<Agentes> GetJsonOrganismo(String filtro, int organismo)
        {
            return this.oAgentesAD.GetJsonOrganismo(filtro, organismo);
        }

        public DbQuery<Agentes> GetFuncionariosJson(String filtro)
        {
            return this.oAgentesAD.GetFuncionariosJson(filtro);
        }

        public void Guardar(Agentes Objeto)
        {
            try
            {
                this.oAgentesAD.Guardar(Objeto);
            }
            catch (Exception msg)
            {
                throw new Exception(msg.Message);
            }
        }

        public void Actualizar(Agentes Objeto)
        {
            try
            {
                this.oAgentesAD.Actualizar(Objeto);
            }
            catch (Exception msg)
            {
                throw new Exception(msg.Message);
            }
        }

        public void Eliminar(int IdObjeto)
        {
            try
            {
                this.oAgentesAD.Eliminar(IdObjeto);
            }
            catch (Exception msg)
            {
                throw new Exception(msg.Message);
            }
        }

        public void Dispose()
        {
            this.oAgentesAD.Dispose();
        }
        public DbQuery<AgentesViewT> JsonT(string term)
        {
            return (DbQuery<AgentesViewT>)this.oAgentesAD.JsonT(term);
        }
        /*********************************************
		* Seccion Particular
		* *******************************************/

        public List<DiasDeLicenciaView> DiasDeLicenciasDisponibles(int agente, int anio)
        {
            return this.oAgentesAD.DiasDeLicenciaDisponibles(agente, anio);
        }

        public List<DiasDeLicenciaView> DiasDeLicenciasDisponibles2(int agente, int anio)
        {
            return this.oAgentesAD.DiasDeLicenciaDisponibles(agente, anio);
        }

        public List<LicenciasDisponiblesResult> SaldoLicencias(string device_id, int agente) {
            return oAgentesAD.SaldoLicencias(device_id, agente);
        }

        public ResumenLicenciasPorOrganismoViewT Resumen(int legajo)
        {
            return this.oAgentesAD.ResumenLicenciasPorAgente(legajo);
        }

        public int DiasDeLicenciaDisponiblesSustitutos(int agente, DateTime fecha)
        {
            return this.oAgentesAD.DiasDeLicenciaOrdinariaSustituos(agente, fecha);
        }

        public AgentesResult validarApp(string telefono, int legajo)
        {
            return this.oAgentesAD.validarApp(telefono, legajo);
        }

        public AgentesResult validarApp2(string telefono, int legajo)
        {
            return this.oAgentesAD.login(telefono, legajo);
        }

        public bool deviceEnabled(string device_id)
        {
            return this.oAgentesAD.deviceEnabled(device_id);
        }

        public List<LicenciasResult> MisLicencias(string device_id, int agente, int licencia, int anio)
        {
            return this.oAgentesAD.MisLicencias(device_id, agente, licencia, anio);
        }

        public List<LicenciasResult> LicenciasPendientes(string device_id, int organismo) {

            return this.oAgentesAD.LicenciasPendientes(device_id, organismo);
        }

        public Result AprobarLicencia(int licencia, int agente) {
            return this.oAgentesAD.AprobarLicencia(licencia, agente);
        }

        public Result DesaprobarLicencia(string device_id, int licencia, int agente)
        {
            return this.oAgentesAD.DesaprobarLicencia(device_id, licencia, agente);
        }

        public Result UpdateToken(string device_id, string token) {
            return this.oAgentesAD.UpdateToken(device_id, token);
        }

        public List<LicenciasResult> MisLicenciasSolicitadas(string device_id, int agente, bool aprobada) {
            return this.oAgentesAD.MisLicenciasSolicitadas(device_id, agente, aprobada);
        }

        public bool updateData(int documento, string legajo_sueldo, string afiliado)
        {
            return oAgentesAD.updateData(documento, legajo_sueldo, afiliado);
        }

        public DateTime? UltimaLicencia(string device_id)
        {
            return oAgentesAD.UltimaLicencia(device_id);
        }

        }
}
