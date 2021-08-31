
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
	public partial class TiposMateriasRefRN
	{
		TiposMateriasRefAD oTiposMateriasRefAD = new TiposMateriasRefAD();

		public TiposMateriasRef ObtenerPorId(int Id)
		{
			return this.oTiposMateriasRefAD.ObtenerPorId(Id);
		}

		public DbQuery<TiposMateriasRef> ObtenerTodo()
		{
			return this.oTiposMateriasRefAD.ObtenerTodo();
		}


		public DbQuery<TiposMateriasRefView> ObtenerParaGrilla()
		{
			return this.oTiposMateriasRefAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oTiposMateriasRefAD.ObtenerOptions(filtro);
		}

		public void Guardar(TiposMateriasRef Objeto)
		{
			try
			{
			this.oTiposMateriasRefAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(TiposMateriasRef Objeto)
		{
			try
			{
			this.oTiposMateriasRefAD.Actualizar(Objeto);
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
			this.oTiposMateriasRefAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oTiposMateriasRefAD.Dispose();
		}
		public DbQuery<TiposMateriasRefViewT> JsonT(string term)
		{
			return (DbQuery<TiposMateriasRefViewT>)this.oTiposMateriasRefAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
