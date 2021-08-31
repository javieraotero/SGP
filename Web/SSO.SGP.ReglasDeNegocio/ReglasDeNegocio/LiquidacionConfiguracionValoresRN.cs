
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
	public partial class LiquidacionConfiguracionValoresRN
	{
		LiquidacionConfiguracionValoresAD oLiquidacionConfiguracionValoresAD = new LiquidacionConfiguracionValoresAD();

		public LiquidacionConfiguracionValores ObtenerPorId(int Id)
		{
			return this.oLiquidacionConfiguracionValoresAD.ObtenerPorId(Id);
		}

		public DbQuery<LiquidacionConfiguracionValores> ObtenerTodo()
		{
			return this.oLiquidacionConfiguracionValoresAD.ObtenerTodo();
		}


		public DbQuery<LiquidacionConfiguracionValoresView> ObtenerParaGrilla()
		{
			return this.oLiquidacionConfiguracionValoresAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oLiquidacionConfiguracionValoresAD.ObtenerOptions(filtro);
		}

		public void Guardar(LiquidacionConfiguracionValores Objeto)
		{
			try
			{
			this.oLiquidacionConfiguracionValoresAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(LiquidacionConfiguracionValores Objeto)
		{
			try
			{
			this.oLiquidacionConfiguracionValoresAD.Actualizar(Objeto);
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
			this.oLiquidacionConfiguracionValoresAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oLiquidacionConfiguracionValoresAD.Dispose();
		}
		public DbQuery<LiquidacionConfiguracionValoresViewT> JsonT(string term)
		{
			return (DbQuery<LiquidacionConfiguracionValoresViewT>)this.oLiquidacionConfiguracionValoresAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
