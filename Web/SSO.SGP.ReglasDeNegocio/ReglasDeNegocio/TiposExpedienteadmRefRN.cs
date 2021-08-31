
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
	public partial class TiposExpedienteadmRefRN
	{
		TiposExpedienteadmRefAD oTiposExpedienteadmRefAD = new TiposExpedienteadmRefAD();

		public TiposExpedienteadmRef ObtenerPorId(int Id)
		{
			return this.oTiposExpedienteadmRefAD.ObtenerPorId(Id);
		}

		public DbQuery<TiposExpedienteadmRef> ObtenerTodo()
		{
			return this.oTiposExpedienteadmRefAD.ObtenerTodo();
		}


		public DbQuery<TiposExpedienteadmRefView> ObtenerParaGrilla()
		{
			return this.oTiposExpedienteadmRefAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oTiposExpedienteadmRefAD.ObtenerOptions(filtro);
		}

		public void Guardar(TiposExpedienteadmRef Objeto)
		{
			try
			{
			this.oTiposExpedienteadmRefAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(TiposExpedienteadmRef Objeto)
		{
			try
			{
			this.oTiposExpedienteadmRefAD.Actualizar(Objeto);
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
			this.oTiposExpedienteadmRefAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oTiposExpedienteadmRefAD.Dispose();
		}
		public DbQuery<TiposExpedienteadmRefViewT> JsonT(string term)
		{
			return (DbQuery<TiposExpedienteadmRefViewT>)this.oTiposExpedienteadmRefAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
