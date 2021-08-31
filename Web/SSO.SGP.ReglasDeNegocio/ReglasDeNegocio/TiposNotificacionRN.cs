
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
	public partial class TiposNotificacionRN
	{
		TiposNotificacionAD oTiposNotificacionAD = new TiposNotificacionAD();

		public TiposNotificacion ObtenerPorId(int Id)
		{
			return this.oTiposNotificacionAD.ObtenerPorId(Id);
		}

		public DbQuery<TiposNotificacion> ObtenerTodo()
		{
			return this.oTiposNotificacionAD.ObtenerTodo();
		}


		public DbQuery<TiposNotificacionView> ObtenerParaGrilla()
		{
			return this.oTiposNotificacionAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oTiposNotificacionAD.ObtenerOptions(filtro);
		}

		public void Guardar(TiposNotificacion Objeto)
		{
			try
			{
			this.oTiposNotificacionAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(TiposNotificacion Objeto)
		{
			try
			{
			this.oTiposNotificacionAD.Actualizar(Objeto);
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
			this.oTiposNotificacionAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oTiposNotificacionAD.Dispose();
		}
		public DbQuery<TiposNotificacionViewT> JsonT(string term)
		{
			return (DbQuery<TiposNotificacionViewT>)this.oTiposNotificacionAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
