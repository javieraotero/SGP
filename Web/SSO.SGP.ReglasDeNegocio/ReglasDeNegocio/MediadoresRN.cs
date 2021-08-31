
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
	public partial class MediadoresRN
	{
		MediadoresAD oMediadoresAD = new MediadoresAD();

		public Mediadores ObtenerPorId(int Id)
		{
			return this.oMediadoresAD.ObtenerPorId(Id);
		}

		public DbQuery<Mediadores> ObtenerTodo()
		{
			return this.oMediadoresAD.ObtenerTodo();
		}


		public DbQuery<MediadoresView> ObtenerParaGrilla()
		{
			return this.oMediadoresAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oMediadoresAD.ObtenerOptions(filtro);
		}

		public void Guardar(Mediadores Objeto)
		{
			try
			{
			this.oMediadoresAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(Mediadores Objeto)
		{
			try
			{
			this.oMediadoresAD.Actualizar(Objeto);
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
			this.oMediadoresAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oMediadoresAD.Dispose();
		}
		public DbQuery<MediadoresViewT> JsonT(string term)
		{
			return (DbQuery<MediadoresViewT>)this.oMediadoresAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
