
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
	public partial class TiposParentescosRefRN
	{
		TiposParentescosRefAD oTiposParentescosRefAD = new TiposParentescosRefAD();

		public TiposParentescosRef ObtenerPorId(int Id)
		{
			return this.oTiposParentescosRefAD.ObtenerPorId(Id);
		}

		public DbQuery<TiposParentescosRef> ObtenerTodo()
		{
			return this.oTiposParentescosRefAD.ObtenerTodo();
		}


		public DbQuery<TiposParentescosRefView> ObtenerParaGrilla()
		{
			return this.oTiposParentescosRefAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oTiposParentescosRefAD.ObtenerOptions(filtro);
		}

		public void Guardar(TiposParentescosRef Objeto)
		{
			try
			{
			this.oTiposParentescosRefAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(TiposParentescosRef Objeto)
		{
			try
			{
			this.oTiposParentescosRefAD.Actualizar(Objeto);
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
			this.oTiposParentescosRefAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oTiposParentescosRefAD.Dispose();
		}
		public DbQuery<TiposParentescosRefViewT> JsonT(string term)
		{
			return (DbQuery<TiposParentescosRefViewT>)this.oTiposParentescosRefAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
