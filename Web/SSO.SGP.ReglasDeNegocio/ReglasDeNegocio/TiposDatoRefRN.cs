
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
	public partial class TiposDatoRefRN
	{
		TiposDatoRefAD oTiposDatoRefAD = new TiposDatoRefAD();

		public TiposDatoRef ObtenerPorId(int Id)
		{
			return this.oTiposDatoRefAD.ObtenerPorId(Id);
		}

		public DbQuery<TiposDatoRef> ObtenerTodo()
		{
			return this.oTiposDatoRefAD.ObtenerTodo();
		}


		public DbQuery<TiposDatoRefView> ObtenerParaGrilla()
		{
			return this.oTiposDatoRefAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oTiposDatoRefAD.ObtenerOptions(filtro);
		}

		public void Guardar(TiposDatoRef Objeto)
		{
			try
			{
			this.oTiposDatoRefAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(TiposDatoRef Objeto)
		{
			try
			{
			this.oTiposDatoRefAD.Actualizar(Objeto);
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
			this.oTiposDatoRefAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oTiposDatoRefAD.Dispose();
		}
		public DbQuery<TiposDatoRefViewT> JsonT(string term)
		{
			return (DbQuery<TiposDatoRefViewT>)this.oTiposDatoRefAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
