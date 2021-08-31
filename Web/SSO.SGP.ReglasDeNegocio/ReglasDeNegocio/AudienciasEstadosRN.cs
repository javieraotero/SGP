
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
	public partial class AudienciasEstadosRN
	{
		AudienciasEstadosAD oAudienciasEstadosAD = new AudienciasEstadosAD();

		public AudienciasEstados ObtenerPorId(int Id)
		{
			return this.oAudienciasEstadosAD.ObtenerPorId(Id);
		}

		public DbQuery<AudienciasEstados> ObtenerTodo()
		{
			return this.oAudienciasEstadosAD.ObtenerTodo();
		}


		public DbQuery<AudienciasEstadosView> ObtenerParaGrilla()
		{
			return this.oAudienciasEstadosAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oAudienciasEstadosAD.ObtenerOptions(filtro);
		}

		public void Guardar(AudienciasEstados Objeto)
		{
			try
			{
			this.oAudienciasEstadosAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(AudienciasEstados Objeto)
		{
			try
			{
			this.oAudienciasEstadosAD.Actualizar(Objeto);
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
			this.oAudienciasEstadosAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oAudienciasEstadosAD.Dispose();
		}
		public DbQuery<AudienciasEstadosViewT> JsonT(string term)
		{
			return (DbQuery<AudienciasEstadosViewT>)this.oAudienciasEstadosAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
