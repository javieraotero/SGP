
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
	public partial class LiquidacionGastosRN
	{
		LiquidacionGastosAD oLiquidacionGastosAD = new LiquidacionGastosAD();

		public LiquidacionGastos ObtenerPorId(int Id)
		{
			return this.oLiquidacionGastosAD.ObtenerPorId(Id);
		}

		public DbQuery<LiquidacionGastos> ObtenerTodo()
		{
			return this.oLiquidacionGastosAD.ObtenerTodo();
		}


		public DbQuery<LiquidacionGastosView> ObtenerParaGrilla()
		{
			return this.oLiquidacionGastosAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oLiquidacionGastosAD.ObtenerOptions(filtro);
		}

		public void Guardar(LiquidacionGastos Objeto)
		{
			try
			{
			this.oLiquidacionGastosAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(LiquidacionGastos Objeto)
		{
			try
			{
			this.oLiquidacionGastosAD.Actualizar(Objeto);
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
			this.oLiquidacionGastosAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oLiquidacionGastosAD.Dispose();
		}
		public DbQuery<LiquidacionGastosViewT> JsonT(string term)
		{
			return (DbQuery<LiquidacionGastosViewT>)this.oLiquidacionGastosAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
