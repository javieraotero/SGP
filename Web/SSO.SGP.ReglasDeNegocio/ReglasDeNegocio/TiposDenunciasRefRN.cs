
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
	public partial class TiposDenunciasRefRN
	{
		TiposDenunciasRefAD oTiposDenunciasRefAD = new TiposDenunciasRefAD();

		public TiposDenunciasRef ObtenerPorId(int Id)
		{
			return this.oTiposDenunciasRefAD.ObtenerPorId(Id);
		}

		public DbQuery<TiposDenunciasRef> ObtenerTodo()
		{
			return this.oTiposDenunciasRefAD.ObtenerTodo();
		}


		public DbQuery<TiposDenunciasRefView> ObtenerParaGrilla()
		{
			return this.oTiposDenunciasRefAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oTiposDenunciasRefAD.ObtenerOptions(filtro);
		}

		public void Guardar(TiposDenunciasRef Objeto)
		{
			try
			{
			this.oTiposDenunciasRefAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(TiposDenunciasRef Objeto)
		{
			try
			{
			this.oTiposDenunciasRefAD.Actualizar(Objeto);
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
			this.oTiposDenunciasRefAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oTiposDenunciasRefAD.Dispose();
		}
		public DbQuery<TiposDenunciasRefViewT> JsonT(string term)
		{
			return (DbQuery<TiposDenunciasRefViewT>)this.oTiposDenunciasRefAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
