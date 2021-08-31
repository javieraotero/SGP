
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
	public partial class AudienciasCivilRN
	{
		AudienciasCivilAD oAudienciasCivilAD = new AudienciasCivilAD();

		public AudienciasCivil ObtenerPorId(int Id)
		{
			return this.oAudienciasCivilAD.ObtenerPorId(Id);
		}

		public DbQuery<AudienciasCivil> ObtenerTodo()
		{
			return this.oAudienciasCivilAD.ObtenerTodo();
		}


		public DbQuery<AudienciasCivilView> ObtenerParaGrilla()
		{
			return this.oAudienciasCivilAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oAudienciasCivilAD.ObtenerOptions(filtro);
		}

		public void Guardar(AudienciasCivil Objeto)
		{
			try
			{
			this.oAudienciasCivilAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(AudienciasCivil Objeto)
		{
			try
			{
			this.oAudienciasCivilAD.Actualizar(Objeto);
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
			this.oAudienciasCivilAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oAudienciasCivilAD.Dispose();
		}
		public DbQuery<AudienciasCivilViewT> JsonT(string term)
		{
			return (DbQuery<AudienciasCivilViewT>)this.oAudienciasCivilAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
