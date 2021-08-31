
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
	public partial class TiposCuentasBancariasRefRN
	{
		TiposCuentasBancariasRefAD oTiposCuentasBancariasRefAD = new TiposCuentasBancariasRefAD();

		public TiposCuentasBancariasRef ObtenerPorId(int Id)
		{
			return this.oTiposCuentasBancariasRefAD.ObtenerPorId(Id);
		}

		public DbQuery<TiposCuentasBancariasRef> ObtenerTodo()
		{
			return this.oTiposCuentasBancariasRefAD.ObtenerTodo();
		}


		public DbQuery<TiposCuentasBancariasRefView> ObtenerParaGrilla()
		{
			return this.oTiposCuentasBancariasRefAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oTiposCuentasBancariasRefAD.ObtenerOptions(filtro);
		}

		public void Guardar(TiposCuentasBancariasRef Objeto)
		{
			try
			{
			this.oTiposCuentasBancariasRefAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(TiposCuentasBancariasRef Objeto)
		{
			try
			{
			this.oTiposCuentasBancariasRefAD.Actualizar(Objeto);
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
			this.oTiposCuentasBancariasRefAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oTiposCuentasBancariasRefAD.Dispose();
		}
		public DbQuery<TiposCuentasBancariasRefViewT> JsonT(string term)
		{
			return (DbQuery<TiposCuentasBancariasRefViewT>)this.oTiposCuentasBancariasRefAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
