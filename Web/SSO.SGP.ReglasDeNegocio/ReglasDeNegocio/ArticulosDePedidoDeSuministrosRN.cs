
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
	public partial class ArticulosDePedidoDeSuministrosRN
	{
		ArticulosDePedidoDeSuministrosAD oArticulosDePedidoDeSuministrosAD = new ArticulosDePedidoDeSuministrosAD();

		public ArticulosDePedidoDeSuministros ObtenerPorId(int Id)
		{
			return this.oArticulosDePedidoDeSuministrosAD.ObtenerPorId(Id);
		}

		public DbQuery<ArticulosDePedidoDeSuministros> ObtenerTodo()
		{
			return this.oArticulosDePedidoDeSuministrosAD.ObtenerTodo();
		}


		public DbQuery<ArticulosDePedidoDeSuministrosView> ObtenerParaGrilla()
		{
			return this.oArticulosDePedidoDeSuministrosAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oArticulosDePedidoDeSuministrosAD.ObtenerOptions(filtro);
		}

		public void Guardar(ArticulosDePedidoDeSuministros Objeto)
		{
			try
			{
			this.oArticulosDePedidoDeSuministrosAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ArticulosDePedidoDeSuministros Objeto)
		{
			try
			{
			this.oArticulosDePedidoDeSuministrosAD.Actualizar(Objeto);
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
			this.oArticulosDePedidoDeSuministrosAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oArticulosDePedidoDeSuministrosAD.Dispose();
		}
		public DbQuery<ArticulosDePedidoDeSuministrosViewT> JsonT(string term)
		{
			return (DbQuery<ArticulosDePedidoDeSuministrosViewT>)this.oArticulosDePedidoDeSuministrosAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
