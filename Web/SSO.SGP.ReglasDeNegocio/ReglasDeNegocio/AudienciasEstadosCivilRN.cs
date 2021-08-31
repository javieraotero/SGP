
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
	public partial class AudienciasEstadosCivilRN
	{
		AudienciasEstadosCivilAD oAudienciasEstadosCivilAD = new AudienciasEstadosCivilAD();

		public AudienciasEstadosCivil ObtenerPorId(int Id)
		{
			return this.oAudienciasEstadosCivilAD.ObtenerPorId(Id);
		}

		public DbQuery<AudienciasEstadosCivil> ObtenerTodo()
		{
			return this.oAudienciasEstadosCivilAD.ObtenerTodo();
		}


		public DbQuery<AudienciasEstadosCivilView> ObtenerParaGrilla()
		{
			return this.oAudienciasEstadosCivilAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oAudienciasEstadosCivilAD.ObtenerOptions(filtro);
		}

		public void Guardar(AudienciasEstadosCivil Objeto)
		{
			try
			{
			this.oAudienciasEstadosCivilAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(AudienciasEstadosCivil Objeto)
		{
			try
			{
			this.oAudienciasEstadosCivilAD.Actualizar(Objeto);
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
			this.oAudienciasEstadosCivilAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oAudienciasEstadosCivilAD.Dispose();
		}
		public DbQuery<AudienciasEstadosCivilViewT> JsonT(string term)
		{
			return (DbQuery<AudienciasEstadosCivilViewT>)this.oAudienciasEstadosCivilAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
