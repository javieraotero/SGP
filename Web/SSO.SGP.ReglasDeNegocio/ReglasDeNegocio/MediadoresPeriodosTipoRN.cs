
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
	public partial class MediadoresPeriodosTipoRN
	{
		MediadoresPeriodosTipoAD oMediadoresPeriodosTipoAD = new MediadoresPeriodosTipoAD();

		public MediadoresPeriodosTipo ObtenerPorId(int Id)
		{
			return this.oMediadoresPeriodosTipoAD.ObtenerPorId(Id);
		}

		public DbQuery<MediadoresPeriodosTipo> ObtenerTodo()
		{
			return this.oMediadoresPeriodosTipoAD.ObtenerTodo();
		}


		public DbQuery<MediadoresPeriodosTipoView> ObtenerParaGrilla()
		{
			return this.oMediadoresPeriodosTipoAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oMediadoresPeriodosTipoAD.ObtenerOptions(filtro);
		}

		public void Guardar(MediadoresPeriodosTipo Objeto)
		{
			try
			{
			this.oMediadoresPeriodosTipoAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(MediadoresPeriodosTipo Objeto)
		{
			try
			{
			this.oMediadoresPeriodosTipoAD.Actualizar(Objeto);
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
			this.oMediadoresPeriodosTipoAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oMediadoresPeriodosTipoAD.Dispose();
		}
		public DbQuery<MediadoresPeriodosTipoViewT> JsonT(string term)
		{
			return (DbQuery<MediadoresPeriodosTipoViewT>)this.oMediadoresPeriodosTipoAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
