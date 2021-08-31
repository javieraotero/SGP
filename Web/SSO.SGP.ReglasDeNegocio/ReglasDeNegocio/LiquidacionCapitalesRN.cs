
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
	public partial class LiquidacionCapitalesRN
	{
		LiquidacionCapitalesAD oLiquidacionCapitalesAD = new LiquidacionCapitalesAD();

		public LiquidacionCapitales ObtenerPorId(int Id)
		{
			return this.oLiquidacionCapitalesAD.ObtenerPorId(Id);
		}

		public DbQuery<LiquidacionCapitales> ObtenerTodo()
		{
			return this.oLiquidacionCapitalesAD.ObtenerTodo();
		}


		public DbQuery<LiquidacionCapitalesView> ObtenerParaGrilla()
		{
			return this.oLiquidacionCapitalesAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oLiquidacionCapitalesAD.ObtenerOptions(filtro);
		}

		public void Guardar(LiquidacionCapitales Objeto)
		{
			try
			{
			this.oLiquidacionCapitalesAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(LiquidacionCapitales Objeto)
		{
			try
			{
			this.oLiquidacionCapitalesAD.Actualizar(Objeto);
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
			this.oLiquidacionCapitalesAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oLiquidacionCapitalesAD.Dispose();
		}
		public DbQuery<LiquidacionCapitalesViewT> JsonT(string term)
		{
			return (DbQuery<LiquidacionCapitalesViewT>)this.oLiquidacionCapitalesAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
