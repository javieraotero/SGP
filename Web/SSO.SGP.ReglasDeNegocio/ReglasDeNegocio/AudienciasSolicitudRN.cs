
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
	public partial class AudienciasSolicitudRN
	{
		AudienciasSolicitudAD oAudienciasSolicitudAD = new AudienciasSolicitudAD();

		public AudienciasSolicitud ObtenerPorId(int Id)
		{
			return this.oAudienciasSolicitudAD.ObtenerPorId(Id);
		}

		public DbQuery<AudienciasSolicitud> ObtenerTodo()
		{
			return this.oAudienciasSolicitudAD.ObtenerTodo();
		}


		public DbQuery<AudienciasSolicitudView> ObtenerParaGrilla()
		{
			return this.oAudienciasSolicitudAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oAudienciasSolicitudAD.ObtenerOptions(filtro);
		}

		public void Guardar(AudienciasSolicitud Objeto)
		{
			try
			{
			this.oAudienciasSolicitudAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(AudienciasSolicitud Objeto)
		{
			try
			{
			this.oAudienciasSolicitudAD.Actualizar(Objeto);
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
			this.oAudienciasSolicitudAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oAudienciasSolicitudAD.Dispose();
		}
		public DbQuery<AudienciasSolicitudViewT> JsonT(string term)
		{
			return (DbQuery<AudienciasSolicitudViewT>)this.oAudienciasSolicitudAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
