
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
	public partial class MediadoresTipoRN
	{
		MediadoresTipoAD oMediadoresTipoAD = new MediadoresTipoAD();

		public MediadoresTipo ObtenerPorId(int Id)
		{
			return this.oMediadoresTipoAD.ObtenerPorId(Id);
		}

		public DbQuery<MediadoresTipo> ObtenerTodo()
		{
			return this.oMediadoresTipoAD.ObtenerTodo();
		}


		public DbQuery<MediadoresTipoView> ObtenerParaGrilla()
		{
			return this.oMediadoresTipoAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oMediadoresTipoAD.ObtenerOptions(filtro);
		}

		public void Guardar(MediadoresTipo Objeto)
		{
			try
			{
			this.oMediadoresTipoAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(MediadoresTipo Objeto)
		{
			try
			{
			this.oMediadoresTipoAD.Actualizar(Objeto);
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
			this.oMediadoresTipoAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oMediadoresTipoAD.Dispose();
		}
		public DbQuery<MediadoresTipoViewT> JsonT(string term)
		{
			return (DbQuery<MediadoresTipoViewT>)this.oMediadoresTipoAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
