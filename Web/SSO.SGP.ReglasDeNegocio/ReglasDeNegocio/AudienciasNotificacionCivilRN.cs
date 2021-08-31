
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
	public partial class AudienciasNotificacionCivilRN
	{
		AudienciasNotificacionCivilAD oAudienciasNotificacionCivilAD = new AudienciasNotificacionCivilAD();

		public AudienciasNotificacionCivil ObtenerPorId(int Id)
		{
			return this.oAudienciasNotificacionCivilAD.ObtenerPorId(Id);
		}

		public DbQuery<AudienciasNotificacionCivil> ObtenerTodo()
		{
			return this.oAudienciasNotificacionCivilAD.ObtenerTodo();
		}


		public DbQuery<AudienciasNotificacionCivilView> ObtenerParaGrilla()
		{
			return this.oAudienciasNotificacionCivilAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oAudienciasNotificacionCivilAD.ObtenerOptions(filtro);
		}

		public void Guardar(AudienciasNotificacionCivil Objeto)
		{
			try
			{
			this.oAudienciasNotificacionCivilAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(AudienciasNotificacionCivil Objeto)
		{
			try
			{
			this.oAudienciasNotificacionCivilAD.Actualizar(Objeto);
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
			this.oAudienciasNotificacionCivilAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oAudienciasNotificacionCivilAD.Dispose();
		}
		public DbQuery<AudienciasNotificacionCivilViewT> JsonT(string term)
		{
			return (DbQuery<AudienciasNotificacionCivilViewT>)this.oAudienciasNotificacionCivilAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
