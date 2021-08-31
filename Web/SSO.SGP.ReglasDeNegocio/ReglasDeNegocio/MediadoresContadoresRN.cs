
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
	public partial class MediadoresContadoresRN
	{
		MediadoresContadoresAD oMediadoresContadoresAD = new MediadoresContadoresAD();

		public MediadoresContadores ObtenerPorId(int Id)
		{
			return this.oMediadoresContadoresAD.ObtenerPorId(Id);
		}

		public DbQuery<MediadoresContadores> ObtenerTodo()
		{
			return this.oMediadoresContadoresAD.ObtenerTodo();
		}


		public DbQuery<MediadoresContadoresView> ObtenerParaGrilla()
		{
			return this.oMediadoresContadoresAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oMediadoresContadoresAD.ObtenerOptions(filtro);
		}

		public void Guardar(MediadoresContadores Objeto)
		{
			try
			{
			this.oMediadoresContadoresAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(MediadoresContadores Objeto)
		{
			try
			{
			this.oMediadoresContadoresAD.Actualizar(Objeto);
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
			this.oMediadoresContadoresAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oMediadoresContadoresAD.Dispose();
		}
		public DbQuery<MediadoresContadoresViewT> JsonT(string term)
		{
			return (DbQuery<MediadoresContadoresViewT>)this.oMediadoresContadoresAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
