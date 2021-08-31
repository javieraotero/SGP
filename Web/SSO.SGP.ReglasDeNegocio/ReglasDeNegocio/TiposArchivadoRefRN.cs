
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
	public partial class TiposArchivadoRefRN
	{
		TiposArchivadoRefAD oTiposArchivadoRefAD = new TiposArchivadoRefAD();

		public TiposArchivadoRef ObtenerPorId(int Id)
		{
			return this.oTiposArchivadoRefAD.ObtenerPorId(Id);
		}

		public DbQuery<TiposArchivadoRef> ObtenerTodo()
		{
			return this.oTiposArchivadoRefAD.ObtenerTodo();
		}


		public DbQuery<TiposArchivadoRefView> ObtenerParaGrilla()
		{
			return this.oTiposArchivadoRefAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oTiposArchivadoRefAD.ObtenerOptions(filtro);
		}

		public void Guardar(TiposArchivadoRef Objeto)
		{
			try
			{
			this.oTiposArchivadoRefAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(TiposArchivadoRef Objeto)
		{
			try
			{
			this.oTiposArchivadoRefAD.Actualizar(Objeto);
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
			this.oTiposArchivadoRefAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oTiposArchivadoRefAD.Dispose();
		}
		public DbQuery<TiposArchivadoRefViewT> JsonT(string term)
		{
			return (DbQuery<TiposArchivadoRefViewT>)this.oTiposArchivadoRefAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
