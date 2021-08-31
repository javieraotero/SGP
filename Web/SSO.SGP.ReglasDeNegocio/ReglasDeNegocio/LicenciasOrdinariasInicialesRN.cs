
using System;
using System.Data.Entity.Infrastructure;
using SSO.SGP.EntidadesDeNegocio;
using SSO.SGP.AccesoADatos;
using SSO.SGP.EntidadesDeNegocio.Vistas;


namespace SSO.SGP.ReglasDeNegocio
{
	/// <summary>
	/// Reglas De Negocio Generada por el Generador de codigo.
	/// </summary>
	public partial class LicenciasOrdinariasInicialesRN
	{
		LicenciasOrdinariasInicialesAD oLicenciasOrdinariasInicialesAD = new LicenciasOrdinariasInicialesAD();

		public LicenciasOrdinariasIniciales ObtenerPorId(int Id)
		{
			return this.oLicenciasOrdinariasInicialesAD.ObtenerPorId(Id);
		}

		public DbQuery<LicenciasOrdinariasIniciales> ObtenerTodo()
		{
			return this.oLicenciasOrdinariasInicialesAD.ObtenerTodo();
		}


		public DbQuery<LicenciasOrdinariasInicialesView> ObtenerParaGrilla()
		{
			return this.oLicenciasOrdinariasInicialesAD.ObtenerParaGrilla();
		}

        public DbQuery<LicenciasOrdinariasIniciales> ObtenerPorAgente(int agente)
        {
            return this.oLicenciasOrdinariasInicialesAD.ObtenerPorAgente(agente);
        }

        public DbQuery<LicenciasOrdinariasIniciales> ObtenerTodoPorAgente(int agente)
        {
            return this.oLicenciasOrdinariasInicialesAD.ObtenerTodoPorAgente(agente);
        }

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oLicenciasOrdinariasInicialesAD.ObtenerOptions(filtro);
		}

		public void Guardar(LicenciasOrdinariasIniciales Objeto)
		{
			try
			{
			this.oLicenciasOrdinariasInicialesAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(LicenciasOrdinariasIniciales Objeto)
		{
			try
			{
			this.oLicenciasOrdinariasInicialesAD.Actualizar(Objeto);
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
			this.oLicenciasOrdinariasInicialesAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oLicenciasOrdinariasInicialesAD.Dispose();
		}
		public DbQuery<LicenciasOrdinariasInicialesViewT> JsonT(string term)
		{
			return (DbQuery<LicenciasOrdinariasInicialesViewT>)this.oLicenciasOrdinariasInicialesAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
