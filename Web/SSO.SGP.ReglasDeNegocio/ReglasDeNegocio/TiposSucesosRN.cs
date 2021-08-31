
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
	public partial class TiposSucesosRN
	{
		TiposSucesosAD oTiposSucesosAD = new TiposSucesosAD();

		public TiposSucesos ObtenerPorId(int Id)
		{
			return this.oTiposSucesosAD.ObtenerPorId(Id);
		}

		public DbQuery<TiposSucesos> ObtenerTodo()
		{
			return this.oTiposSucesosAD.ObtenerTodo();
		}


		public DbQuery<TiposSucesosView> ObtenerParaGrilla()
		{
			return this.oTiposSucesosAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oTiposSucesosAD.ObtenerOptions(filtro);
		}

		public void Guardar(TiposSucesos Objeto)
		{
			try
			{
			this.oTiposSucesosAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(TiposSucesos Objeto)
		{
			try
			{
			this.oTiposSucesosAD.Actualizar(Objeto);
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
			this.oTiposSucesosAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oTiposSucesosAD.Dispose();
		}
		public DbQuery<TiposSucesosViewT> JsonT(string term)
		{
			return (DbQuery<TiposSucesosViewT>)this.oTiposSucesosAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
