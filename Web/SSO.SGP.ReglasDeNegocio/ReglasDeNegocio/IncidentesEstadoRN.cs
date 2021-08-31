
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
	public partial class IncidentesEstadoRN
	{
		IncidentesEstadoAD oIncidentesEstadoAD = new IncidentesEstadoAD();

		public IncidentesEstado ObtenerPorId(int Id)
		{
			return this.oIncidentesEstadoAD.ObtenerPorId(Id);
		}

		public DbQuery<IncidentesEstado> ObtenerTodo()
		{
			return this.oIncidentesEstadoAD.ObtenerTodo();
		}


		public DbQuery<IncidentesEstadoView> ObtenerParaGrilla()
		{
			return this.oIncidentesEstadoAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oIncidentesEstadoAD.ObtenerOptions(filtro);
		}

		public void Guardar(IncidentesEstado Objeto)
		{
			try
			{
			this.oIncidentesEstadoAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(IncidentesEstado Objeto)
		{
			try
			{
			this.oIncidentesEstadoAD.Actualizar(Objeto);
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
			this.oIncidentesEstadoAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oIncidentesEstadoAD.Dispose();
		}
		public DbQuery<IncidentesEstadoViewT> JsonT(string term)
		{
			return (DbQuery<IncidentesEstadoViewT>)this.oIncidentesEstadoAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
