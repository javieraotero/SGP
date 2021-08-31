
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
	public partial class MovimientosDeStockRN
	{
		MovimientosDeStockAD oMovimientosDeStockAD = new MovimientosDeStockAD();

		public MovimientosDeStock ObtenerPorId(int Id)
		{
			return this.oMovimientosDeStockAD.ObtenerPorId(Id);
		}

		public DbQuery<MovimientosDeStock> ObtenerTodo()
		{
			return this.oMovimientosDeStockAD.ObtenerTodo();
		}


		public DbQuery<MovimientosDeStockView> ObtenerParaGrilla()
		{
			return this.oMovimientosDeStockAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oMovimientosDeStockAD.ObtenerOptions(filtro);
		}

		public void Guardar(MovimientosDeStock Objeto)
		{
			try
			{
			this.oMovimientosDeStockAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(MovimientosDeStock Objeto)
		{
			try
			{
			this.oMovimientosDeStockAD.Actualizar(Objeto);
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
			this.oMovimientosDeStockAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oMovimientosDeStockAD.Dispose();
		}
		public DbQuery<MovimientosDeStockViewT> JsonT(string term)
		{
			return (DbQuery<MovimientosDeStockViewT>)this.oMovimientosDeStockAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
