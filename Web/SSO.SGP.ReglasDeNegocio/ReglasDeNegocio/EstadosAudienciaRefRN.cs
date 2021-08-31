
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
	public partial class EstadosAudienciaRefRN
	{
		EstadosAudienciaRefAD oEstadosAudienciaRefAD = new EstadosAudienciaRefAD();

		public EstadosAudienciaRef ObtenerPorId(int Id)
		{
			return this.oEstadosAudienciaRefAD.ObtenerPorId(Id);
		}

		public DbQuery<EstadosAudienciaRef> ObtenerTodo()
		{
			return this.oEstadosAudienciaRefAD.ObtenerTodo();
		}


		public DbQuery<EstadosAudienciaRefView> ObtenerParaGrilla()
		{
			return this.oEstadosAudienciaRefAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oEstadosAudienciaRefAD.ObtenerOptions(filtro);
		}

		public void Guardar(EstadosAudienciaRef Objeto)
		{
			try
			{
			this.oEstadosAudienciaRefAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(EstadosAudienciaRef Objeto)
		{
			try
			{
			this.oEstadosAudienciaRefAD.Actualizar(Objeto);
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
			this.oEstadosAudienciaRefAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oEstadosAudienciaRefAD.Dispose();
		}
		public DbQuery<EstadosAudienciaRefViewT> JsonT(string term)
		{
			return (DbQuery<EstadosAudienciaRefViewT>)this.oEstadosAudienciaRefAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
