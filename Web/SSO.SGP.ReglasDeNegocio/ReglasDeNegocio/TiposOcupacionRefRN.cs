
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
	public partial class TiposOcupacionRefRN
	{
		TiposOcupacionRefAD oTiposOcupacionRefAD = new TiposOcupacionRefAD();

		public TiposOcupacionRef ObtenerPorId(int Id)
		{
			return this.oTiposOcupacionRefAD.ObtenerPorId(Id);
		}

		public DbQuery<TiposOcupacionRef> ObtenerTodo()
		{
			return this.oTiposOcupacionRefAD.ObtenerTodo();
		}


		public DbQuery<TiposOcupacionRefView> ObtenerParaGrilla()
		{
			return this.oTiposOcupacionRefAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oTiposOcupacionRefAD.ObtenerOptions(filtro);
		}

		public void Guardar(TiposOcupacionRef Objeto)
		{
			try
			{
			this.oTiposOcupacionRefAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(TiposOcupacionRef Objeto)
		{
			try
			{
			this.oTiposOcupacionRefAD.Actualizar(Objeto);
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
			this.oTiposOcupacionRefAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oTiposOcupacionRefAD.Dispose();
		}
		public DbQuery<TiposOcupacionRefViewT> JsonT(string term)
		{
			return (DbQuery<TiposOcupacionRefViewT>)this.oTiposOcupacionRefAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
