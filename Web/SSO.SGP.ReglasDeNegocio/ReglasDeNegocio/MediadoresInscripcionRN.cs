
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
	public partial class MediadoresInscripcionRN
	{
		MediadoresInscripcionAD oMediadoresInscripcionAD = new MediadoresInscripcionAD();

		public MediadoresInscripcion ObtenerPorId(int Id)
		{
			return this.oMediadoresInscripcionAD.ObtenerPorId(Id);
		}

		public DbQuery<MediadoresInscripcion> ObtenerTodo()
		{
			return this.oMediadoresInscripcionAD.ObtenerTodo();
		}


		public DbQuery<MediadoresInscripcionView> ObtenerParaGrilla()
		{
			return this.oMediadoresInscripcionAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oMediadoresInscripcionAD.ObtenerOptions(filtro);
		}

		public void Guardar(MediadoresInscripcion Objeto)
		{
			try
			{
			this.oMediadoresInscripcionAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(MediadoresInscripcion Objeto)
		{
			try
			{
			this.oMediadoresInscripcionAD.Actualizar(Objeto);
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
			this.oMediadoresInscripcionAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oMediadoresInscripcionAD.Dispose();
		}
		public DbQuery<MediadoresInscripcionViewT> JsonT(string term)
		{
			return (DbQuery<MediadoresInscripcionViewT>)this.oMediadoresInscripcionAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
