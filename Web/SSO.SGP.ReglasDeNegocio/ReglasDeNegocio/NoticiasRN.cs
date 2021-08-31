
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
	public partial class NoticiasRN
	{
		NoticiasAD oNoticiasAD = new NoticiasAD();

		public Noticias ObtenerPorId(int Id)
		{
			return this.oNoticiasAD.ObtenerPorId(Id);
		}

		public DbQuery<Noticias> ObtenerTodo()
		{
			return this.oNoticiasAD.ObtenerTodo();
		}


		public DbQuery<NoticiasView> ObtenerParaGrilla()
		{
			return this.oNoticiasAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oNoticiasAD.ObtenerOptions(filtro);
		}

		public void Guardar(Noticias Objeto)
		{
			try
			{
			this.oNoticiasAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(Noticias Objeto)
		{
			try
			{
			this.oNoticiasAD.Actualizar(Objeto);
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
			this.oNoticiasAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oNoticiasAD.Dispose();
		}
		public DbQuery<NoticiasViewT> JsonT(string term)
		{
			return (DbQuery<NoticiasViewT>)this.oNoticiasAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
