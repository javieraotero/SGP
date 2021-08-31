
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
	public partial class MediadoresInscripcionEstadoRN
	{
		MediadoresInscripcionEstadoAD oMediadoresInscripcionEstadoAD = new MediadoresInscripcionEstadoAD();

		public MediadoresInscripcionEstado ObtenerPorId(int Id)
		{
			return this.oMediadoresInscripcionEstadoAD.ObtenerPorId(Id);
		}

		public DbQuery<MediadoresInscripcionEstado> ObtenerTodo()
		{
			return this.oMediadoresInscripcionEstadoAD.ObtenerTodo();
		}


		public DbQuery<MediadoresInscripcionEstadoView> ObtenerParaGrilla()
		{
			return this.oMediadoresInscripcionEstadoAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oMediadoresInscripcionEstadoAD.ObtenerOptions(filtro);
		}

		public void Guardar(MediadoresInscripcionEstado Objeto)
		{
			try
			{
			this.oMediadoresInscripcionEstadoAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(MediadoresInscripcionEstado Objeto)
		{
			try
			{
			this.oMediadoresInscripcionEstadoAD.Actualizar(Objeto);
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
			this.oMediadoresInscripcionEstadoAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oMediadoresInscripcionEstadoAD.Dispose();
		}
		public DbQuery<MediadoresInscripcionEstadoViewT> JsonT(string term)
		{
			return (DbQuery<MediadoresInscripcionEstadoViewT>)this.oMediadoresInscripcionEstadoAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
