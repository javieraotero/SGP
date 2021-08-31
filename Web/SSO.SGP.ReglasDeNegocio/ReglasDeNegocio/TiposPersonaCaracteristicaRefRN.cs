
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
	public partial class TiposPersonaCaracteristicaRefRN
	{
		TiposPersonaCaracteristicaRefAD oTiposPersonaCaracteristicaRefAD = new TiposPersonaCaracteristicaRefAD();

		public TiposPersonaCaracteristicaRef ObtenerPorId(int Id)
		{
			return this.oTiposPersonaCaracteristicaRefAD.ObtenerPorId(Id);
		}

		public DbQuery<TiposPersonaCaracteristicaRef> ObtenerTodo()
		{
			return this.oTiposPersonaCaracteristicaRefAD.ObtenerTodo();
		}


		public DbQuery<TiposPersonaCaracteristicaRefView> ObtenerParaGrilla()
		{
			return this.oTiposPersonaCaracteristicaRefAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oTiposPersonaCaracteristicaRefAD.ObtenerOptions(filtro);
		}

		public void Guardar(TiposPersonaCaracteristicaRef Objeto)
		{
			try
			{
			this.oTiposPersonaCaracteristicaRefAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(TiposPersonaCaracteristicaRef Objeto)
		{
			try
			{
			this.oTiposPersonaCaracteristicaRefAD.Actualizar(Objeto);
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
			this.oTiposPersonaCaracteristicaRefAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oTiposPersonaCaracteristicaRefAD.Dispose();
		}
		public DbQuery<TiposPersonaCaracteristicaRefViewT> JsonT(string term)
		{
			return (DbQuery<TiposPersonaCaracteristicaRefViewT>)this.oTiposPersonaCaracteristicaRefAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
