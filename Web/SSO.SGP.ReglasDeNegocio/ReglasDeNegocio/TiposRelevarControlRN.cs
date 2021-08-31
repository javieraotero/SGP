
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
	public partial class TiposRelevarControlRN
	{
		TiposRelevarControlAD oTiposRelevarControlAD = new TiposRelevarControlAD();

		public TiposRelevarControl ObtenerPorId(int Id)
		{
			return this.oTiposRelevarControlAD.ObtenerPorId(Id);
		}

		public DbQuery<TiposRelevarControl> ObtenerTodo()
		{
			return this.oTiposRelevarControlAD.ObtenerTodo();
		}


		public DbQuery<TiposRelevarControlView> ObtenerParaGrilla()
		{
			return this.oTiposRelevarControlAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oTiposRelevarControlAD.ObtenerOptions(filtro);
		}

		public void Guardar(TiposRelevarControl Objeto)
		{
			try
			{
			this.oTiposRelevarControlAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(TiposRelevarControl Objeto)
		{
			try
			{
			this.oTiposRelevarControlAD.Actualizar(Objeto);
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
			this.oTiposRelevarControlAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oTiposRelevarControlAD.Dispose();
		}
		public DbQuery<TiposRelevarControlViewT> JsonT(string term)
		{
			return (DbQuery<TiposRelevarControlViewT>)this.oTiposRelevarControlAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
