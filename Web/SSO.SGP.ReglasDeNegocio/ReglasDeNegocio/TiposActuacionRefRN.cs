
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
	public partial class TiposActuacionRefRN
	{
		TiposActuacionRefAD oTiposActuacionRefAD = new TiposActuacionRefAD();

		public TiposActuacionRef ObtenerPorId(int Id)
		{
			return this.oTiposActuacionRefAD.ObtenerPorId(Id);
		}

		public DbQuery<TiposActuacionRef> ObtenerTodo()
		{
			return this.oTiposActuacionRefAD.ObtenerTodo();
		}


		public DbQuery<TiposActuacionRefView> ObtenerParaGrilla()
		{
			return this.oTiposActuacionRefAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oTiposActuacionRefAD.ObtenerOptions(filtro);
		}

		public void Guardar(TiposActuacionRef Objeto)
		{
			try
			{
			this.oTiposActuacionRefAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(TiposActuacionRef Objeto)
		{
			try
			{
			this.oTiposActuacionRefAD.Actualizar(Objeto);
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
			this.oTiposActuacionRefAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oTiposActuacionRefAD.Dispose();
		}
		public DbQuery<TiposActuacionRefViewT> JsonT(string term)
		{
			return (DbQuery<TiposActuacionRefViewT>)this.oTiposActuacionRefAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
