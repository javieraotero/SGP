
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
	public partial class TiposActuacionadmRefRN
	{
		TiposActuacionadmRefAD oTiposActuacionadmRefAD = new TiposActuacionadmRefAD();

		public TiposActuacionadmRef ObtenerPorId(int Id)
		{
			return this.oTiposActuacionadmRefAD.ObtenerPorId(Id);
		}

		public DbQuery<TiposActuacionadmRef> ObtenerTodo()
		{
			return this.oTiposActuacionadmRefAD.ObtenerTodo();
		}

		public DbQuery<TiposActuacionadmRefView> ObtenerParaGrilla()
		{
			return this.oTiposActuacionadmRefAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oTiposActuacionadmRefAD.ObtenerOptions(filtro);
		}

		public void Guardar(TiposActuacionadmRef Objeto)
		{
			try
			{
			this.oTiposActuacionadmRefAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(TiposActuacionadmRef Objeto)
		{
			try
			{
			this.oTiposActuacionadmRefAD.Actualizar(Objeto);
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
			this.oTiposActuacionadmRefAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oTiposActuacionadmRefAD.Dispose();
		}
		public DbQuery<TiposActuacionadmRefViewT> JsonT(string term)
		{
			return (DbQuery<TiposActuacionadmRefViewT>)this.oTiposActuacionadmRefAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
