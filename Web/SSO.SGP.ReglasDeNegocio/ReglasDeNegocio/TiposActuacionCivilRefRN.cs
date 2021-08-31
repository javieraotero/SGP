
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
	public partial class TiposActuacionCivilRefRN
	{
		TiposActuacionCivilRefAD oTiposActuacionCivilRefAD = new TiposActuacionCivilRefAD();

		public TiposActuacionCivilRef ObtenerPorId(int Id)
		{
			return this.oTiposActuacionCivilRefAD.ObtenerPorId(Id);
		}

		public DbQuery<TiposActuacionCivilRef> ObtenerTodo()
		{
			return this.oTiposActuacionCivilRefAD.ObtenerTodo();
		}


		public DbQuery<TiposActuacionCivilRefView> ObtenerParaGrilla()
		{
			return this.oTiposActuacionCivilRefAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oTiposActuacionCivilRefAD.ObtenerOptions(filtro);
		}

		public void Guardar(TiposActuacionCivilRef Objeto)
		{
			try
			{
			this.oTiposActuacionCivilRefAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(TiposActuacionCivilRef Objeto)
		{
			try
			{
			this.oTiposActuacionCivilRefAD.Actualizar(Objeto);
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
			this.oTiposActuacionCivilRefAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oTiposActuacionCivilRefAD.Dispose();
		}
		public DbQuery<TiposActuacionCivilRefViewT> JsonT(string term)
		{
			return (DbQuery<TiposActuacionCivilRefViewT>)this.oTiposActuacionCivilRefAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
