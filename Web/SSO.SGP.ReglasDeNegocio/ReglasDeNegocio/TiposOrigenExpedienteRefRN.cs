
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
	public partial class TiposOrigenExpedienteRefRN
	{
		TiposOrigenExpedienteRefAD oTiposOrigenExpedienteRefAD = new TiposOrigenExpedienteRefAD();

		public TiposOrigenExpedienteRef ObtenerPorId(int Id)
		{
			return this.oTiposOrigenExpedienteRefAD.ObtenerPorId(Id);
		}

		public DbQuery<TiposOrigenExpedienteRef> ObtenerTodo()
		{
			return this.oTiposOrigenExpedienteRefAD.ObtenerTodo();
		}


		public DbQuery<TiposOrigenExpedienteRefView> ObtenerParaGrilla()
		{
			return this.oTiposOrigenExpedienteRefAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oTiposOrigenExpedienteRefAD.ObtenerOptions(filtro);
		}

		public void Guardar(TiposOrigenExpedienteRef Objeto)
		{
			try
			{
			this.oTiposOrigenExpedienteRefAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(TiposOrigenExpedienteRef Objeto)
		{
			try
			{
			this.oTiposOrigenExpedienteRefAD.Actualizar(Objeto);
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
			this.oTiposOrigenExpedienteRefAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oTiposOrigenExpedienteRefAD.Dispose();
		}
		public DbQuery<TiposOrigenExpedienteRefViewT> JsonT(string term)
		{
			return (DbQuery<TiposOrigenExpedienteRefViewT>)this.oTiposOrigenExpedienteRefAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
