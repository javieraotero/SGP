
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
	public partial class TiposOrigenoaVytRN
	{
		TiposOrigenoaVytAD oTiposOrigenoaVytAD = new TiposOrigenoaVytAD();

		public TiposOrigenoaVyt ObtenerPorId(int Id)
		{
			return this.oTiposOrigenoaVytAD.ObtenerPorId(Id);
		}

		public DbQuery<TiposOrigenoaVyt> ObtenerTodo()
		{
			return this.oTiposOrigenoaVytAD.ObtenerTodo();
		}


		public DbQuery<TiposOrigenoaVytView> ObtenerParaGrilla()
		{
			return this.oTiposOrigenoaVytAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oTiposOrigenoaVytAD.ObtenerOptions(filtro);
		}

		public void Guardar(TiposOrigenoaVyt Objeto)
		{
			try
			{
			this.oTiposOrigenoaVytAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(TiposOrigenoaVyt Objeto)
		{
			try
			{
			this.oTiposOrigenoaVytAD.Actualizar(Objeto);
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
			this.oTiposOrigenoaVytAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oTiposOrigenoaVytAD.Dispose();
		}
		public DbQuery<TiposOrigenoaVytViewT> JsonT(string term)
		{
			return (DbQuery<TiposOrigenoaVytViewT>)this.oTiposOrigenoaVytAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
