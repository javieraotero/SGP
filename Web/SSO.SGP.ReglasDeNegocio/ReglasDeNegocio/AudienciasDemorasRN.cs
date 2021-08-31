
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
	public partial class AudienciasDemorasRN
	{
		AudienciasDemorasAD oAudienciasDemorasAD = new AudienciasDemorasAD();

		public AudienciasDemoras ObtenerPorId(int Id)
		{
			return this.oAudienciasDemorasAD.ObtenerPorId(Id);
		}

		public DbQuery<AudienciasDemoras> ObtenerTodo()
		{
			return this.oAudienciasDemorasAD.ObtenerTodo();
		}


		public DbQuery<AudienciasDemorasView> ObtenerParaGrilla()
		{
			return this.oAudienciasDemorasAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oAudienciasDemorasAD.ObtenerOptions(filtro);
		}

		public void Guardar(AudienciasDemoras Objeto)
		{
			try
			{
			this.oAudienciasDemorasAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(AudienciasDemoras Objeto)
		{
			try
			{
			this.oAudienciasDemorasAD.Actualizar(Objeto);
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
			this.oAudienciasDemorasAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oAudienciasDemorasAD.Dispose();
		}
		public DbQuery<AudienciasDemorasViewT> JsonT(string term)
		{
			return (DbQuery<AudienciasDemorasViewT>)this.oAudienciasDemorasAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
