
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
	public partial class ArticulosDeSuministrosRN
	{
		ArticulosDeSuministrosAD oArticulosDeSuministrosAD = new ArticulosDeSuministrosAD();

		public ArticulosDeSuministros ObtenerPorId(int Id)
		{
			return this.oArticulosDeSuministrosAD.ObtenerPorId(Id);
		}

		public DbQuery<ArticulosDeSuministros> ObtenerTodo()
		{
			return this.oArticulosDeSuministrosAD.ObtenerTodo();
		}


		public DbQuery<ArticulosDeSuministrosView> ObtenerParaGrilla()
		{
			return this.oArticulosDeSuministrosAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oArticulosDeSuministrosAD.ObtenerOptions(filtro);
		}

		public void Guardar(ArticulosDeSuministros Objeto)
		{
			try
			{
			this.oArticulosDeSuministrosAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ArticulosDeSuministros Objeto)
		{
			try
			{
			this.oArticulosDeSuministrosAD.Actualizar(Objeto);
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
			this.oArticulosDeSuministrosAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oArticulosDeSuministrosAD.Dispose();
		}

		public DbQuery<ArticulosDeSuministrosViewT> JsonT(string term)
		{
			return (DbQuery<ArticulosDeSuministrosViewT>)this.oArticulosDeSuministrosAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
