
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
	public partial class AudienciasSolicitudPersonasRelRN
	{
		AudienciasSolicitudPersonasRelAD oAudienciasSolicitudPersonasRelAD = new AudienciasSolicitudPersonasRelAD();

		public AudienciasSolicitudPersonasRel ObtenerPorId(int Id)
		{
			return this.oAudienciasSolicitudPersonasRelAD.ObtenerPorId(Id);
		}

		public DbQuery<AudienciasSolicitudPersonasRel> ObtenerTodo()
		{
			return this.oAudienciasSolicitudPersonasRelAD.ObtenerTodo();
		}


		public DbQuery<AudienciasSolicitudPersonasRelView> ObtenerParaGrilla()
		{
			return this.oAudienciasSolicitudPersonasRelAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oAudienciasSolicitudPersonasRelAD.ObtenerOptions(filtro);
		}

		public void Guardar(AudienciasSolicitudPersonasRel Objeto)
		{
			try
			{
			this.oAudienciasSolicitudPersonasRelAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(AudienciasSolicitudPersonasRel Objeto)
		{
			try
			{
			this.oAudienciasSolicitudPersonasRelAD.Actualizar(Objeto);
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
			this.oAudienciasSolicitudPersonasRelAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oAudienciasSolicitudPersonasRelAD.Dispose();
		}
		public DbQuery<AudienciasSolicitudPersonasRelViewT> JsonT(string term)
		{
			return (DbQuery<AudienciasSolicitudPersonasRelViewT>)this.oAudienciasSolicitudPersonasRelAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
