
using System;
using System.Data.Entity.Infrastructure;
using SSO.SGP.EntidadesDeNegocio;
using SSO.SGP.AccesoADatos;
using SSO.SGP.EntidadesDeNegocio.Vistas;
using System.Collections.Generic;
using SSO.SGP.EntidadesDeNegocio.Results;

namespace SSO.SGP.ReglasDeNegocio
{
	/// <summary>
	/// Reglas De Negocio Generada por el Generador de codigo.
	/// </summary>
	public partial class LicenciasAgenteRN
	{
		LicenciasAgenteAD oLicenciasAgenteAD = new LicenciasAgenteAD();

		public LicenciasAgente ObtenerPorId(int Id)
		{
			return this.oLicenciasAgenteAD.ObtenerPorId(Id);
		}

        public LicenciasAgente ObtenerPorToken(string token)
        {
            return this.oLicenciasAgenteAD.ObtenerPorToken(token);
        }

		public List<LicenciasAgentesAprobaciones> GetAprobaciones(int licencia) {
			return this.oLicenciasAgenteAD.GetAprobaciones(licencia);
		}

		public List<LicenciasAgentesAprobacionesResult> GetAprobacionesResult(int licencia)
		{
			return this.oLicenciasAgenteAD.GetAprobacionesResult(licencia);
		}

		public DbQuery<LicenciasAgente> ObtenerTodo()
		{
			return this.oLicenciasAgenteAD.ObtenerTodo();
		}

        public List<LicenciasAgente> ObtenerDenegadas(int agente)
        {
            return this.oLicenciasAgenteAD.ObtenerDenegadas(agente);
        }


        public DbQuery<LicenciasAgenteView> ObtenerParaGrilla()
		{
			return this.oLicenciasAgenteAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oLicenciasAgenteAD.ObtenerOptions(filtro);
		}

        public DbQuery<LicenciasAgenteViewT> DiasDeLicenciaDeAgente(int agente, int licencia)
        {
            return oLicenciasAgenteAD.DiasDeLicenciaDeAgente(agente, licencia);
        }


		public void Guardar(LicenciasAgente Objeto)
		{
			try
			{
			this.oLicenciasAgenteAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(LicenciasAgente Objeto)
		{
			try
			{
			this.oLicenciasAgenteAD.Actualizar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void GuardarAprobacion(LicenciasAgentesAprobaciones Objeto)
		{
			try
			{
				this.oLicenciasAgenteAD.GuardarAprobacion(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void ActualizarAprobacion(LicenciasAgentesAprobaciones Objeto)
		{
			try
			{
				this.oLicenciasAgenteAD.ActualizarAprobacion(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Eliminar(int IdObjeto, int Usuario)
		{
			try
			{
			this.oLicenciasAgenteAD.Eliminar(IdObjeto, Usuario);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void EliminarDeBD(int IdObjeto)
		{
			try
			{
				this.oLicenciasAgenteAD.EliminarDeBasse(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oLicenciasAgenteAD.Dispose();
		}

		public DbQuery<LicenciasAgenteViewT> JsonT(int agente, int licencia, DateTime? fechadesde, DateTime? fechahasta)
		{ 
			return (DbQuery<LicenciasAgenteViewT>)this.oLicenciasAgenteAD.JsonT(agente, licencia, fechadesde, fechahasta);
		}

        public DbQuery<LicenciasAgenteViewT> JsonT(CustomConsultaLicencias consulta)
        {
            return (DbQuery<LicenciasAgenteViewT>)this.oLicenciasAgenteAD.JsonT(0,0, null, null);
        }

        public string ControlarInicioDeLicencia(int Id, int Agente, int Licencia, DateTime Desde, DateTime Hasta)
        {
            return this.oLicenciasAgenteAD.ControlarInicioDeLicencia(Id, Agente, Licencia, Desde, Hasta);
        }

        //public DbQuery<LicenciasAgenteViewT> JsonT(int agente, int licencia)
        //{
        //    return (DbQuery<LicenciasAgenteViewT>)this.oLicenciasAgenteAD.JsonT(agente, licencia);
        //}

        public void GuardarExcepcion(LicenciasAgenteExcepciones Objeto)
        {
            try
            {
                this.oLicenciasAgenteAD.GuardarExcepcion(Objeto);
            }
            catch (Exception msg)
            {
                throw new Exception(msg.Message);
            }
        }

        public DbQuery<LicenciasAgenteExcepcionesViewT> ExcepcionesDelAgente(int agente)
        {
            return (DbQuery<LicenciasAgenteExcepcionesViewT>)this.oLicenciasAgenteAD.ExcepcionesDelAgente(agente);
        }
    }
}
