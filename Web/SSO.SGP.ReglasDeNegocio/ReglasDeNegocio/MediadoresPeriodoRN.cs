
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
	public partial class MediadoresPeriodoRN
	{
		MediadoresPeriodoAD oMediadoresPeriodoAD = new MediadoresPeriodoAD();

		public MediadoresPeriodo ObtenerPorId(int Id)
		{
			return this.oMediadoresPeriodoAD.ObtenerPorId(Id);
		}

		public DbQuery<MediadoresPeriodo> ObtenerTodo()
		{
			return this.oMediadoresPeriodoAD.ObtenerTodo();
		}


		public DbQuery<MediadoresPeriodoView> ObtenerParaGrilla()
		{
			return this.oMediadoresPeriodoAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oMediadoresPeriodoAD.ObtenerOptions(filtro);
		}

		public void Guardar(MediadoresPeriodo Objeto)
		{
			try
			{
			this.oMediadoresPeriodoAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(MediadoresPeriodo Objeto)
		{
			try
			{
			this.oMediadoresPeriodoAD.Actualizar(Objeto);
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
			this.oMediadoresPeriodoAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oMediadoresPeriodoAD.Dispose();
		}
		public DbQuery<MediadoresPeriodoViewT> JsonT(string term)
		{
			return (DbQuery<MediadoresPeriodoViewT>)this.oMediadoresPeriodoAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
