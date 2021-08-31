
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
	public partial class IncidentesRN
	{
		IncidentesAD oIncidentesAD = new IncidentesAD();

		public Incidentes ObtenerPorId(int Id)
		{
			return this.oIncidentesAD.ObtenerPorId(Id);
		}

		public DbQuery<Incidentes> ObtenerTodo()
		{
			return this.oIncidentesAD.ObtenerTodo();
		}


		public DbQuery<IncidentesView> ObtenerParaGrilla()
		{
			return this.oIncidentesAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oIncidentesAD.ObtenerOptions(filtro);
		}

		public void Guardar(Incidentes Objeto)
		{
			try
			{
			this.oIncidentesAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(Incidentes Objeto)
		{
			try
			{
			this.oIncidentesAD.Actualizar(Objeto);
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
			this.oIncidentesAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oIncidentesAD.Dispose();
		}
		public DbQuery<IncidentesViewT> JsonT(string term)
		{
			return (DbQuery<IncidentesViewT>)this.oIncidentesAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
