
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
	public partial class AudienciasNotificacionRN
	{
		AudienciasNotificacionAD oAudienciasNotificacionAD = new AudienciasNotificacionAD();

		public AudienciasNotificacion ObtenerPorId(int Id)
		{
			return this.oAudienciasNotificacionAD.ObtenerPorId(Id);
		}

		public DbQuery<AudienciasNotificacion> ObtenerTodo()
		{
			return this.oAudienciasNotificacionAD.ObtenerTodo();
		}


		public DbQuery<AudienciasNotificacionView> ObtenerParaGrilla()
		{
			return this.oAudienciasNotificacionAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oAudienciasNotificacionAD.ObtenerOptions(filtro);
		}

		public void Guardar(AudienciasNotificacion Objeto)
		{
			try
			{
			this.oAudienciasNotificacionAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(AudienciasNotificacion Objeto)
		{
			try
			{
			this.oAudienciasNotificacionAD.Actualizar(Objeto);
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
			this.oAudienciasNotificacionAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oAudienciasNotificacionAD.Dispose();
		}
		public DbQuery<AudienciasNotificacionViewT> JsonT(string term)
		{
			return (DbQuery<AudienciasNotificacionViewT>)this.oAudienciasNotificacionAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
