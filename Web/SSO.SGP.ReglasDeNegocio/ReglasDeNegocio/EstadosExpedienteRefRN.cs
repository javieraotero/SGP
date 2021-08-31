
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
	public partial class EstadosExpedienteRefRN
	{
		EstadosExpedienteRefAD oEstadosExpedienteRefAD = new EstadosExpedienteRefAD();

		public EstadosExpedienteRef ObtenerPorId(int Id)
		{
			return this.oEstadosExpedienteRefAD.ObtenerPorId(Id);
		}

		public DbQuery<EstadosExpedienteRef> ObtenerTodo()
		{
			return this.oEstadosExpedienteRefAD.ObtenerTodo();
		}


		public DbQuery<EstadosExpedienteRefView> ObtenerParaGrilla()
		{
			return this.oEstadosExpedienteRefAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oEstadosExpedienteRefAD.ObtenerOptions(filtro);
		}

		public void Guardar(EstadosExpedienteRef Objeto)
		{
			try
			{
			this.oEstadosExpedienteRefAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(EstadosExpedienteRef Objeto)
		{
			try
			{
			this.oEstadosExpedienteRefAD.Actualizar(Objeto);
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
			this.oEstadosExpedienteRefAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oEstadosExpedienteRefAD.Dispose();
		}
		public DbQuery<EstadosExpedienteRefViewT> JsonT(string term)
		{
			return (DbQuery<EstadosExpedienteRefViewT>)this.oEstadosExpedienteRefAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
